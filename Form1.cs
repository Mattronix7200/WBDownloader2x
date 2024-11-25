using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json.Linq;
using Timer = System.Threading.Timer;
using System.Reflection;
using System.Windows.Forms;
using System.Text;
using System.Numerics;
using System.Text.Json;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Web.WebView2.WinForms;
using System.Security.Cryptography;
using Microsoft.Web.WebView2.Wpf;
using System.Threading.Channels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WBDownloader2
{
    public partial class Form1 : Form
    {
        private Process appProcess;
        private System.Windows.Forms.Timer timer;
        private int stoppedDownloads = 0;
        private List<string> pausedDownloads;
        private Form4 form4 = null;
        private bool isApplicationClosing = false;

        private Dictionary<string, string> themes = new Dictionary<string, string>();

        // init directories:

        public static readonly string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
        public string themesPath = Path.Combine(rootPath, "data", "settings", "themes");
        public string configPath = Path.Combine(rootPath, "data", "settings", "config.ini");
        public string appPath = Path.Combine(rootPath, "data", "bin", "ClipWatcher.exe");
        public string localVersionFilePath = Path.Combine(rootPath, "data", "settings", "ver.ini");
        public string exePath = Path.Combine(rootPath, "data", "bin", "BootstrapperWB.exe");
        public string fallbackDirectory = Path.Combine(rootPath, "data", "settings", "themes", "unpacked");
        public string logsDirectory = Path.Combine(rootPath, "data", "userdata", "logs");
        public string configFilePath = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");
        public string directoryPath = Path.Combine(rootPath, "data", "apps", "external");
        public string relativePath = Path.Combine(rootPath, "data", "apps", "main", "main.html");
        public string relativePath2 = Path.Combine(rootPath, "data", "apps", "main", "empty02.html");
        public string relativePath3 = Path.Combine(rootPath, "data", "apps", "main", "empty01.html");

        private void CheckRequiredFile(string filePath, string description)
        {
            if (isApplicationClosing)
                return;

            if (!File.Exists(filePath))
            {
                isApplicationClosing = true;
                Program.LogEvent($"ERR [X]: B³¹d systemu: Nie znaleziono wymaganego pliku wymaganego do uruchomienia programu. Brakuj¹cy plik: {description}. Program nie bêdzie kontynuowany. Proszê ponownie zainstalowaæ ten program w celu rozwi¹zania tego problemu.");
                MessageBox.Show($"Nie znaleziono wymaganego pliku wymaganego do uruchomienia programu. Proszê ponownie zainstalowaæ ten program w celu rozwi¹zania tego problemu",
                                "B³¹d systemu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Environment.Exit(1); // Zakoñcz program
            }
        }



        private void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }


        // needed categories to init:
        private void InitializeDirectoriesAndFiles()
        {
            string[] requiredFiles = {
                Path.Combine(rootPath, "data", "apps", "main", "assets", "favicon.ico"),
                Path.Combine(rootPath, "data", "apps", "main", "main.html"),
                Path.Combine(rootPath, "data", "apps", "main", "empty01.html"),
                Path.Combine(rootPath, "data", "apps", "main", "empty02.html"),
                Path.Combine(rootPath, "data", "settings", "themes", "unpacked", "blank.html"),
                Path.Combine(rootPath, "data", "bin", "download_aria.bat"),
                Path.Combine(rootPath, "data", "bin", "settings_aria.bat"),
                Path.Combine(rootPath, "data", "bin", "wget.exe"),
                Path.Combine(rootPath, "data", "bin", "winclip.exe"),
                Path.Combine(rootPath, "data", "bin", "winreg.exe"),
                Path.Combine(rootPath, "data", "bin", "a2reporter.exe"),
                Path.Combine(rootPath, "data", "bin", "aria2c.exe"),
                Path.Combine(rootPath, "data", "bin", "BootstrapperWB.exe"),
                Path.Combine(rootPath, "data", "bin", "ClipWatcher.exe"),
                Path.Combine(rootPath, "data", "bin", "createdump.exe"),
                Path.Combine(rootPath, "data", "bin", "docprop.exe"),
                Path.Combine(rootPath, "data", "bin", "GUICompl.exe"),
                Path.Combine(rootPath, "data", "bin", "installer.exe"),
                Path.Combine(rootPath, "data", "bin", "readlink.exe"),
                Path.Combine(rootPath, "data", "bin", "readlog.exe"),
                Path.Combine(rootPath, "data", "bin", "WBD-assembly.exe"),
                Path.Combine(rootPath, "data", "bin", "WBDownloader2.exe"),
                Path.Combine(rootPath, "data", "settings", "config.ini"),
                Path.Combine(rootPath, "data", "settings", "ver.ini")
            };

            foreach (string filePath in requiredFiles)
            {
                CheckRequiredFile(filePath, filePath);
            }

            string[] optionalDirectories = {
                Path.Combine(rootPath, "data", "apps", "external"),
                Path.Combine(rootPath, "data", "userdata", "logs"),
                Path.Combine(rootPath, "data", "userdata")
            };

            foreach (string directoryPath in optionalDirectories)
            {
                EnsureDirectoryExists(directoryPath);
            }

            string[] optionalFiles = {
                Path.Combine(rootPath, "data", "userdata", "logs", "appevents_log.txt"),
                Path.Combine(rootPath, "data", "userdata", "logs", "download_log.txt"),
                Path.Combine(rootPath, "data", "userdata", "savedLinks.txt")
            };

            foreach (string filePath in optionalFiles)
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
            }
        }


        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string aria2cRpcUrl = "http://localhost:6800/jsonrpc";
        private static HashSet<string> displayedFiles = new HashSet<string>();
        private static List<(string FileName, DateTime DownloadTime)> downloadList = new List<(string, DateTime)>();

        private System.Windows.Forms.Timer loadTimer;

        private void OnLoadTimerTick(object sender, EventArgs e)
        {
            this.Opacity = 1;
            loadTimer.Stop();
            loadTimer.Dispose();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Opacity = 0;
            base.OnShown(e);
        }

        public Form1()
        {
            Program.LogEvent("Uruchamianie aplikacji...");

            InitializeComponent();

            Program.LogEvent("Inicjowanie danych i plików aplikacji...");

            InitializeDirectoriesAndFiles();

            Program.LogEvent("Wczytywanie plików ustawieñ...");

            LoadConfig();


            this.Opacity = 0;

            loadTimer = new System.Windows.Forms.Timer();
            loadTimer.Interval = 3000;
            loadTimer.Tick += new EventHandler(OnLoadTimerTick);
            loadTimer.Start();

            set1.CheckedChanged += ToggleButton_CheckedChanged;
            set2.CheckedChanged += ToggleButton_CheckedChanged;
            set3.CheckedChanged += ToggleButton_CheckedChanged;
            set4.CheckedChanged += ToggleButton_CheckedChanged;
            set5.CheckedChanged += ToggleButton_CheckedChanged;
            set6.CheckedChanged += ToggleButton_CheckedChanged;
            set7.CheckedChanged += ToggleButton_CheckedChanged;
            set8.CheckedChanged += ToggleButton_CheckedChanged2;
            set12.CheckedChanged += ToggleButton_CheckedChanged;
            set13.CheckedChanged += ToggleButton_CheckedChanged;
            set14.CheckedChanged += ToggleButton_CheckedChanged;
            set15.CheckedChanged += ToggleButton_CheckedChanged2;
            set16.CheckedChanged += ToggleButton_CheckedChanged2;


            downloadSpeedControl.Scroll += DownloadSpeedControl_Scroll;

            locationTextBox.TextChanged += LocationTextBox_TextChanged;

            setUITheme.OnSelectedIndexChanged += setUITheme_SelectedIndexChanged;

            LoadThemes();
            LoadSelectedTheme();

            this.panel_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Header_MouseDown);
            this.panel_Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Header_MouseMove);
            this.panel_Header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Header__MouseUp);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);

            this.minimalizeApp.MouseEnter += new EventHandler(this.minimalizeApp_MouseEnter);
            this.closeApp.MouseEnter += new EventHandler(this.closeApp_MouseEnter);
            this.minimalizeApp.MouseLeave += new EventHandler(this.minimalizeApp_MouseLeave);
            this.closeApp.MouseLeave += new EventHandler(this.closeApp_MouseLeave);

            action1.Click += new EventHandler(action1_Click);
            action2.Click += new EventHandler(action2_Click);
            action3.Click += new EventHandler(action3_Click);
            action4.Click += new EventHandler(action4_Click);
            action5.Click += new EventHandler(action5_Click);
            action6.Click += new EventHandler(action6_Click);
            action7.Click += new EventHandler(action7_Click);


            FormClosing += Form1_FormClosing;

            if (dbSiteFlowPage.Enabled == false || dbSiteFlowPage.Visible == false)
            {
                goBack.Enabled = false;
                goBack.Visible = false;
            }

            InitializeWebViewIconApp();
            InitializeWebViewBrowserWindow();

            infoHTML1.Visible = true;
            infoHTML2.Visible = true;

            InitializeAria2cMonitor();
            InitializeButtonHandlers();

            pausedDownloads = new List<string>();
            linkComboBox.KeyDown += linkComboBox_KeyDown;
            linkComboBox.Click += linkComboBox_Click;

            mainPanel.Enabled = true;
            mainPanel.Visible = true;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            mainPanel.Size = new Size(894, 630);
            mainPanel.Location = new Point(106, 40);

            //string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "bin", "ClipWatcher.exe");

            EnsureClipWatcherIsRunning(appPath);
            Task.Run(() => MonitorClipWatcher(appPath));

            Thread thread = new Thread(new ThreadStart(BackgroundWorker));
            thread.IsBackground = true;
            thread.Start();

            ReloadInfoWindow1();
            ReloadInfoWindow2();
            ReloadInfoWindow3();
            ReloadInfoWindow4();
            ReloadInfoWindow5();
            ReloadInfoWindow6();
            InitializeWebViewDownloadCenter1();
            InitializeWebViewDownloadCenter2();

            loadExtensions();
            //UpdateInfoVisibility();

            closewebViewMar.Enabled = false;
            closewebViewMar.Visible = false;

            DisplayDownloads();
            LoadVersionInfo();
            CheckVersion();

            setServer.OnSelectedIndexChanged += setServer_SelectedIndexChanged;

            _isInitializing = false;

            Program.LogEvent("Zakoñczono ³adowanie aplikacji.\n======================================\n WindowsBASE.pl - Mened¿er pobierania\n======================================\n");
            Program.LogEvent("Rozpoczêto logowanie statusu aplikacji");
        }

        int betaSel;
        private bool _canLoadTheme = true;

        private async Task CheckVersion()
        {
            if (betaSel == 1 || betaSel == 0)
            {
                //string localVersionFilePath = Path.Combine(Application.StartupPath, "./data/settings/ver.ini");

                string remoteVersionFileUrl = betaSel == 1 ?
                    "https://windowsbase.pl/uploads/apps/wbdownloader/versionb.txt" :
                    "https://windowsbase.pl/uploads/apps/wbdownloader/version.txt";

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string remoteVersionFileContent = await client.GetStringAsync(remoteVersionFileUrl);
                        string[] remoteVersionLines = remoteVersionFileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        string remoteVersion = "";
                        string updateUrl = "";

                        foreach (string line in remoteVersionLines)
                        {
                            string[] parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length == 2)
                            {
                                remoteVersion = parts[0].Trim('"');
                                updateUrl = parts[1].Trim('"');
                            }
                        }
                        string localVersion = GetVersionFromIniFile(localVersionFilePath);
                        if (string.Compare(remoteVersion, localVersion) > 0)
                        {
                            newUpdateNotifier.Visible = true;
                            newUpdateNotifier.Enabled = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (HttpRequestException)
                {
                    return;
                }
            }
        }
        private string GetVersionFromIniFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("version"))
                {
                    string[] parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim('"', ';');
                    }
                }
            }
            return "2.1.0";
        }

        private bool _isRestarting = false;
        private bool _isInitializing = true;


        public void RestartApplication()
        {
            Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath));
            if (runningProcesses.Length > 0)
            {
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = "\"/startmode 4\""
            };
            Process.Start(startInfo);
        }

        private void LoadThemes()
        {
            if (!Directory.Exists(themesPath))
            {
                Directory.CreateDirectory(themesPath);
            }

            var files = Directory.GetFiles(themesPath, "theme*.ini");

            foreach (var file in files)
            {
                var themeName = GetThemeNameFromFile(file);
                if (themeName != null)
                {
                    themes[themeName] = file;
                    setUITheme.Items.Add(themeName);
                    //LoadThemeActions(file);
                }
            }

            setUITheme.Items.Add("Domyœlny");
        }

        private void LoadThemeActions(string themeFilePath)
        {
            var lines = File.ReadAllLines(themeFilePath);
            foreach (var line in lines)
            {
                if (line.Contains("="))
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    var controlProperty = parts[0].Trim();
                    var propertyValue = parts[1].Trim();

                    if (controlProperty.StartsWith("action"))
                    {
                        ApplyActionProperty(controlProperty, propertyValue);
                    }
                }
            }
        }


        private Image[] cachedImagesEnter = new Image[7];
        private Image[] cachedImagesLeave = new Image[7];
        //private string fallbackDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "settings", "themes", "unpacked");


        private void ApplyActionProperty(string controlProperty, string propertyValue)
        {
            var parts = controlProperty.Split('.');
            if (parts.Length == 3)
            {
                var controlName = parts[0].Trim();
                var eventName = parts[1].Trim();
                var propertyName = parts[2].Trim();

                var control = this.Controls.Find(controlName, true).FirstOrDefault();
                if (control != null && control is Panel panel)
                {
                    int index = int.Parse(controlName.Replace("action", "")) - 1;

                    if (eventName == "OnMouseEnter" && propertyName == "BackgroundImage")
                    {
                        if (cachedImagesEnter[index] == null)
                        {
                            cachedImagesEnter[index] = (Image)Properties.Resources.ResourceManager.GetObject(propertyValue);
                            if (cachedImagesEnter[index] == null)
                            {
                                string filePath = Path.Combine(fallbackDirectory, propertyValue + ".png");
                                if (File.Exists(filePath))
                                {
                                    cachedImagesEnter[index] = Image.FromFile(filePath);
                                }
                            }
                        }
                        panel.MouseEnter += (sender, e) => panel.BackgroundImage = cachedImagesEnter[index];
                    }
                    else if (eventName == "OnMouseLeave" && propertyName == "BackgroundImage")
                    {
                        if (cachedImagesLeave[index] == null)
                        {
                            cachedImagesLeave[index] = (Image)Properties.Resources.ResourceManager.GetObject(propertyValue);
                            if (cachedImagesLeave[index] == null)
                            {
                                string filePath = Path.Combine(fallbackDirectory, propertyValue + ".png");
                                if (File.Exists(filePath))
                                {
                                    cachedImagesLeave[index] = Image.FromFile(filePath);
                                }
                            }
                        }
                        panel.MouseLeave += (sender, e) => panel.BackgroundImage = cachedImagesLeave[index];

                        panel.BackgroundImage = cachedImagesLeave[index];
                    }
                }
                else
                {
                    Program.LogEvent($"[!] WRN: Nie znaleziono elementu interfejsu graficznego aplikacji: {controlName} - {controlProperty}. Ignorujê ...");
                }
            }
            else
            {
                Program.LogEvent($"[!] WRN: Nieprawid³owe zdefiniowane ustawienie formatu: {controlProperty}. Ignorujê ...");
            }
        }





        private string GetThemeNameFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.StartsWith("// Name:"))
                {
                    var name = line.Substring("// Name:".Length).Trim();
                    return name;
                }
            }
            return null;
        }

        Color defaultBackgroundColor;
        Color textColor;

        private void LoadSelectedTheme()
        {
            if (!_canLoadTheme)
            {
                return;
            }
            else
            {
                if (File.Exists(configPath))
                {
                    var lines = File.ReadAllLines(configPath);
                    var selectedThemeLine = lines.FirstOrDefault(line => line.StartsWith("selectedTheme="));
                    if (selectedThemeLine != null)
                    {
                        int selectedThemeIndex = int.Parse(selectedThemeLine.Split('=')[1]);
                        if (selectedThemeIndex == 99)
                        {
                            setUITheme.SelectedItem = null;
                            defaultBackgroundColor = ColorTranslator.FromHtml("#1f262d");
                            textColor = Color.White;
                            LoadDefaultThemeActions();
                        }
                        else if (selectedThemeIndex >= 0 && selectedThemeIndex < setUITheme.Items.Count)
                        {
                            var selectedThemeKey = setUITheme.Items[selectedThemeIndex].ToString();
                            if (themes.ContainsKey(selectedThemeKey))
                            {
                                DefaultThemePlaceHolder.Enabled = false;
                                DefaultThemePlaceHolder.Visible = false;

                                setUITheme.SelectedItem = selectedThemeKey;
                                ApplyTheme(themes[selectedThemeKey]);
                                LoadThemeActions(themes[selectedThemeKey]); // Load actions for the selected theme

                                string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
                                string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";
                            }
                        }
                    }
                }
            }

        }


        private void ApplyTheme(string themeFilePath)
        {
            var lines = File.ReadAllLines(themeFilePath);
            foreach (var line in lines)
            {
                if (line.Contains("="))
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    var controlProperty = parts[0].Trim();
                    var propertyValue = parts[1].Trim();

                    if (controlProperty == "infoHTML1.DefaultBackgroundColor")
                    {
                        defaultBackgroundColor = ParseColor(propertyValue);
                    }
                    else if (controlProperty == "infoHTML1.TextColor")
                    {
                        textColor = ParseColor(propertyValue);
                    }
                    else if (controlProperty == "HTML.DefaultFile")
                    {
                        htmlFileName = (propertyValue);
                    }
                    else if (controlProperty == "Form1.BackgroundImage")
                    {
                        if (File.Exists(propertyValue))
                        {
                            this.BackgroundImage = Image.FromFile(Path.Combine(themeFilePath, propertyValue));
                        }
                        else
                        {
                            Program.LogEvent($"[X] ERR: Nie znaleziono pliku graficznego: {BackgroundImage}. Wybrana skrórka graficzna, mo¿e byæ nieprawid³owo wyœwietlana. Proszê sprawdziæ spójnoœæ plików ...  ");
                        }
                    }
                    else if (controlProperty.StartsWith("action"))
                    {
                        ApplyActionProperty(controlProperty, propertyValue);
                    }
                    else if (controlProperty == "Form1.BackgroundImageLayout")
                    {
                        if (Enum.TryParse(propertyValue, out ImageLayout layout))
                        {
                            this.BackgroundImageLayout = layout;
                        }
                        else
                        {
                            Program.LogEvent($"[!] WRN: Zastosowano niepoprawny layout stylu graficznego: {propertyValue}. Ignorujê ...");
                        }
                    }


                    var controlPropertyParts = controlProperty.Split('.');
                    if (controlPropertyParts.Length == 2)
                    {
                        var controlName = controlPropertyParts[0].Trim();
                        var propertyName = controlPropertyParts[1].Trim();

                        var control = this.Controls.Find(controlName, true).FirstOrDefault();
                        if (control != null)
                        {
                            ApplyProperty(control, propertyName, propertyValue);
                        }
                        else
                        {
                            Program.LogEvent($"[!] WRN: Nie znaleziono elementu kontrolki interfejsu: {propertyName}. Ignorujê ...");
                        }
                    }
                    else
                    {
                        Program.LogEvent($"[!] WRN: Nieprawid³owe ustawienie formatu kontrolki interfejsu: {controlProperty}. Ignorujê ...");

                    }
                }
            }
        }



        private void ApplyProperty(Control control, string propertyName, string propertyValue)
        {
            if (propertyName == "BackColor")
            {
                control.BackColor = ParseColor(propertyValue);
            }
            else if (propertyName == "DefaultFile")
            {
                htmlFileName = (propertyValue);
            }
            else if (propertyName == "ForeColor")
            {
                control.ForeColor = ParseColor(propertyValue);
            }
            else if (propertyName == "Background")
            {
                control.BackColor = ParseColor(propertyValue);
            }
            else if (propertyName == "BackgroundImageLayout")
            {
                if (Enum.TryParse(propertyValue, out ImageLayout layout))
                {
                    control.BackgroundImageLayout = layout;
                }
            }
            else if (propertyName == "BackgroundImage")
            {
                var imagePath = Path.Combine(themesPath, propertyValue);
                if (File.Exists(imagePath))
                {
                    control.BackgroundImage = Image.FromFile(imagePath);
                }
            }
            else if (propertyName == "OnBackColor")
            {
                var onBackColorProperty = control.GetType().GetProperty("OnBackColor");
                if (onBackColorProperty != null)
                {
                    onBackColorProperty.SetValue(control, ParseColor(propertyValue));
                }
            }
            else if (propertyName == "OffBackColor")
            {
                var offBackColorProperty = control.GetType().GetProperty("OffBackColor");
                if (offBackColorProperty != null)
                {
                    offBackColorProperty.SetValue(control, ParseColor(propertyValue));
                }
            }
            else if (control is Microsoft.Web.WebView2.WinForms.WebView2 webView)
            {
                if (propertyName == "DefaultBackgroundColor" || propertyName == "TextColor")
                {
                    var backgroundColor = propertyName == "DefaultBackgroundColor" ? ParseColor(propertyValue) : Color.Empty;
                    var textColor = propertyName == "TextColor" ? ParseColor(propertyValue) : Color.Empty;

                    SetWebViewBackgroundColor(webView, backgroundColor, textColor);
                }
            }

        }

        private void SetWebViewBackgroundColor(Microsoft.Web.WebView2.WinForms.WebView2 webView, Color backgroundColor, Color textColor)
        {
            string backgroundColorString = backgroundColor != Color.Empty ? $"rgb({backgroundColor.R}, {backgroundColor.G}, {backgroundColor.B})" : "";
            string textColorString = textColor != Color.Empty ? $"rgb({textColor.R}, {textColor.G}, {textColor.B})" : "";

            string script = "";

            if (!string.IsNullOrEmpty(backgroundColorString))
            {
                script += $"document.body.style.backgroundColor = '{backgroundColorString}'; ";
            }

            if (!string.IsNullOrEmpty(textColorString))
            {
                script += $"document.body.style.color = '{textColorString}'; ";
            }

            webView.ExecuteScriptAsync(script);
        }



        private Color ParseColor(string colorString)
        {
            if (colorString.StartsWith("Color.FromArgb"))
            {
                var argbValues = colorString
                    .Replace("Color.FromArgb(", "")
                    .Replace(")", "")
                    .Split(',')
                    .Select(s => s.Trim())
                    .Select(int.Parse)
                    .ToArray();

                if (argbValues.Length == 4)
                {
                    return Color.FromArgb(argbValues[0], argbValues[1], argbValues[2], argbValues[3]);
                }
                else if (argbValues.Length == 3)
                {
                    return Color.FromArgb(argbValues[0], argbValues[1], argbValues[2]);
                }
            }
            else if (colorString.StartsWith("Color"))
            {
                var colorName = colorString.Replace("Color.", "").Trim();
                return Color.FromName(colorName);
            }
            else
            {
                var rgbValues = colorString
                    .Split(',')
                    .Select(s => s.Trim())
                    .Select(int.Parse)
                    .ToArray();

                if (rgbValues.Length == 3)
                {
                    return Color.FromArgb(rgbValues[0], rgbValues[1], rgbValues[2]);
                }
            }

            throw new FormatException($"[!] WRN: Nieprawid³owo u¿yty kolor stylów GUI: {colorString}. Ignorujê...");
        }



        private void SaveSelectedTheme(int selectedIndex)
        {
            var lines = File.Exists(configPath) ? File.ReadAllLines(configPath).ToList() : new List<string>();
            var selectedThemeLine = lines.FirstOrDefault(line => line.StartsWith("selectedTheme="));
            if (selectedThemeLine != null)
            {
                lines.Remove(selectedThemeLine);
            }
            lines.Add($"selectedTheme={selectedIndex}");
            File.WriteAllLines(configPath, lines);
            Program.LogEvent($"[-] OK: Zapisano zmiany w ustawieniach programu.");

        }


        private void setUITheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isRestarting || _isInitializing)
                return;

            var selectedTheme = setUITheme.SelectedItem.ToString();

            if (selectedTheme == "Domyœlny")
            {
                SaveSelectedTheme(99);

                DialogResult result = MessageBox.Show(
                    "W celu zastosowania zmian w wygl¹dzie aplikacji, konieczne bêdzie ponowne uruchomienie aplikacji.\nKliknij przycisk OK, aby zrestartowaæ aplikacjê teraz",
                    "Czy chcesz zrestartowaæ aplikacjê?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.OK)
                {
                    _isRestarting = true;
                    Program.LogEvent("[-] OK: U¿ytkownik wybra³ skórkê graficzn¹ programu- Domyœlny. W celu zastosowania zmian, program uruchomi siê ponownie\n Ponownie uruchamianie...\n");
                    RestartApplication();
                }
                else
                {
                    changedInfo.Enabled = true;
                    changedInfo.Visible = true;
                    _canLoadTheme = false;
                }
            }
            else if (themes.ContainsKey(selectedTheme))
            {
                DefaultThemePlaceHolder.Enabled = false;
                DefaultThemePlaceHolder.Visible = false;

                var themeFilePath = themes[selectedTheme];
                SaveSelectedTheme(setUITheme.SelectedIndex);

                DialogResult result = MessageBox.Show(
                    "W celu zastosowania zmian w wygl¹dzie aplikacji, konieczne bêdzie ponowne uruchomienie aplikacji.\nKliknij przycisk OK, aby zrestartowaæ aplikacjê teraz",
                    "Czy chcesz zrestartowaæ aplikacjê?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.OK)
                {
                    _isRestarting = true;
                    Program.LogEvent($"[-] OK: U¿ytkownik wybra³ skórkê graficzn¹ programu- {selectedTheme}. W celu zastosowania zmian, program uruchomi siê ponownie\n Ponownie uruchamianie...\n");
                    RestartApplication();
                }
                else
                {
                    changedInfo.Enabled = true;
                    changedInfo.Visible = true;
                    _canLoadTheme = false;
                }
            }
        }


        private void LoadDefaultThemeActions()
        {
            ApplyActionProperty("action1.OnMouseEnter.BackgroundImage", "img62");
            ApplyActionProperty("action1.OnMouseLeave.BackgroundImage", "img61");
            ApplyActionProperty("action2.OnMouseEnter.BackgroundImage", "img82");
            ApplyActionProperty("action2.OnMouseLeave.BackgroundImage", "img81");
            ApplyActionProperty("action3.OnMouseEnter.BackgroundImage", "img12");
            ApplyActionProperty("action3.OnMouseLeave.BackgroundImage", "img11");
            ApplyActionProperty("action4.OnMouseEnter.BackgroundImage", "img01");
            ApplyActionProperty("action4.OnMouseLeave.BackgroundImage", "img02");
            ApplyActionProperty("action5.OnMouseEnter.BackgroundImage", "img22");
            ApplyActionProperty("action5.OnMouseLeave.BackgroundImage", "img21");
            ApplyActionProperty("action6.OnMouseEnter.BackgroundImage", "img52");
            ApplyActionProperty("action6.OnMouseLeave.BackgroundImage", "img51");
            ApplyActionProperty("action7.OnMouseEnter.BackgroundImage", "img72");
            ApplyActionProperty("action7.OnMouseLeave.BackgroundImage", "img71");
        }


        private void LoadVersionInfo()
        {
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string verIniPath = Path.Combine(rootPath, "data", "settings", "ver.ini");
            string verIniPath = localVersionFilePath;

            if (File.Exists(verIniPath))
            {
                var lines = File.ReadAllLines(verIniPath);

                string version = string.Empty;
                string build = string.Empty;
                string channel = string.Empty;

                foreach (var line in lines)
                {
                    if (line.Trim().StartsWith("version:"))
                    {
                        version = ExtractValue(line);
                    }
                    else if (line.Trim().StartsWith("build:"))
                    {
                        build = ExtractValue(line);
                    }
                    else if (line.Trim().StartsWith("channel:"))
                    {
                        channel = ExtractValue(line);
                    }
                }

                verLabel.Text = $"Wersja programu: {version} (Kompilacja: {build} , CU: {channel})";
                Program.LogEvent($"[-] OK: Wersja programu: {version} (Kompilacja: {build} , CU: {channel})");

            }
            else
            {
                verLabel.Text = "N/A";
                Program.LogEvent($"[!] WRN: Brak informacji o aktalnej wersji programu.");

            }
        }

        private string ExtractValue(string line)
        {
            var parts = line.Split(':');
            if (parts.Length > 1)
            {
                string value = parts[1].Trim().Trim('"', ';').Trim();
                return value;
            }
            return string.Empty;
        }


        private async void BackgroundWorker()
        {
            while (true)
            {
                try
                {
                    await FetchAndPrintCompletedDownloads();
                    this.BeginInvoke((Action)(() =>
                    {
                        DisplayDownloads();
                    }));
                }
                catch (HttpRequestException)
                {
                    await Task.Delay(1000);
                }
                catch (Exception)
                {
                    // return
                }

                await Task.Delay(1000);
            }
        }

        private static async Task FetchAndPrintCompletedDownloads()
        {
            var requestBody = new
            {
                jsonrpc = "2.0",
                method = "aria2.tellStopped",
                id = "qwer",
                @params = new object[] { 0, 1000 }
            };

            var response = await SendRequest(requestBody);
            PrintCompletedDownloads(response);
        }

        private static async Task<JsonDocument> SendRequest(object requestBody)
        {
            var jsonRequestBody = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequestBody, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(aria2cRpcUrl, content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(responseString);
        }

        private static void PrintCompletedDownloads(JsonDocument jsonResponse)
        {
            var result = jsonResponse.RootElement.GetProperty("result");

            foreach (var download in result.EnumerateArray())
            {
                string status = download.GetProperty("status").GetString();

                if (status == "complete" || status == "error")
                {
                    var files = download.GetProperty("files");
                    foreach (var file in files.EnumerateArray())
                    {
                        string filePath = file.GetProperty("path").GetString();
                        string fileName = Path.GetFileName(filePath);

                        if (!displayedFiles.Contains(fileName))
                        {
                            displayedFiles.Add(fileName);
                            downloadList.Add((fileName, DateTime.Now));
                        }
                    }
                }
            }
        }

        private void DisplayDownloads()
        {
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string configFilePath2 = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");

            string downloadFolderPath = string.Empty;

            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    if (line.StartsWith("set download="))
                    {
                        downloadFolderPath = line.Substring(19).Trim();
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(downloadFolderPath) || !Directory.Exists(downloadFolderPath))
            {
                infoHTML2.Visible = true;
                return;
            }

            var recentFiles = new DirectoryInfo(downloadFolderPath).GetFiles()
                        .Where(f => !IsFileHiddenOrInvalid(f))
                        .OrderByDescending(f => f.LastWriteTime)
                        .Take(10)
                        .ToList();

            int totalDownloads = recentFiles.Count;
            if (recentFiles.Count == 0)
            {
                infoHTML2.Visible = true;
            }
            else
            {
                infoHTML2.Visible = false;

                for (int i = 0; i < 10; i++)
                {
                    Panel fileD = this.Controls.Find($"fileD{i + 1}", true).FirstOrDefault() as Panel;
                    Label fileTag = this.Controls.Find($"FileTag{i + 1}", true).FirstOrDefault() as Label;
                    Label fileTime = this.Controls.Find($"FileTime{i + 1}", true).FirstOrDefault() as Label;

                    if (i < recentFiles.Count)
                    {
                        var file = recentFiles[i];
                        string fileName = file.Name;
                        DateTime downloadTime = file.LastWriteTime;
                        string formattedTime = FormatTimeAgo(downloadTime);

                        if (fileD != null && fileTag != null && fileTime != null)
                        {
                            fileD.Visible = true;
                            fileTag.Text = fileName;
                            fileTime.Text = formattedTime;
                        }
                    }
                    else
                    {
                        if (fileD != null)
                        {
                            fileD.Visible = false;
                        }
                    }
                }

                downloadCompleteLabel.Text = (totalDownloads > 99) ? "99+ pobranych elementów" : $"{totalDownloads} pobranych elementów";
            }
        }

        private bool IsFileHiddenOrInvalid(FileInfo file)
        {
            string[] invalidExtensions = { ".aria", ".aria2", ".aria2c", ".dat", ".inf", ".txt", ".url", ".html", ".ink", ".lnk", ".pdf", ".doc", ".docx", ".xls",
        ".xlsx", ".csv", ".json", ".db", ".xml", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tif", ".tiff", ".svg",
        ".mp3", ".wav", ".flac", ".aac", ".ogg", ".wma", ".mp4", ".avi", ".mkv", ".flv", ".mov", ".wmv", ".m4v", ".ts",
        ".html", ".htm", ".css", ".js", ".php", ".asp", ".aspx", ".jsp", ".py", ".rb", ".java", ".c", ".cpp", ".cs",
        ".h", ".hpp", ".pl", ".vb", ".sh", ".bat", ".cmd", ".ps1", ".json", ".yaml", ".yml", ".ini", ".log", ".md",
        ".sh", ".cmd", ".bat", ".iss", ".ico", ".part", ".crdownload", ".fdmdownload", ".xcf"};
            return (file.Attributes & FileAttributes.Hidden) != 0 || invalidExtensions.Contains(file.Extension.ToLower());
        }

        private string FormatTimeAgo(DateTime dateTime)
        {
            TimeSpan timeAgo = DateTime.Now - dateTime;

            if (timeAgo.TotalSeconds < 60)
            {
                return "chwilê temu";
            }
            else if (timeAgo.TotalMinutes < 60)
            {
                return $"{timeAgo.Minutes} minut temu";
            }
            else if (timeAgo.TotalHours < 24)
            {
                return $"{timeAgo.Hours} godzin temu";
            }
            else
            {
                return $"{timeAgo.Days} dni temu";
            }
        }

        private void InitializeAria2cMonitor()
        {
            client = new HttpClient();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeButtonHandlers()
        {
            stopDownloadItem1.Click += async (sender, e) => await StopDownload(0);
            stopDownloadItem2.Click += async (sender, e) => await StopDownload(1);
            stopDownloadItem3.Click += async (sender, e) => await StopDownload(2);
            stopDownloadItem4.Click += async (sender, e) => await StopDownload(3);
            removeDownloadItem1.Click += async (sender, e) => await RemoveDownload(0);
            removeDownloadItem2.Click += async (sender, e) => await RemoveDownload(1);
            removeDownloadItem3.Click += async (sender, e) => await RemoveDownload(2);
            removeDownloadItem4.Click += async (sender, e) => await RemoveDownload(3);
            stopDownload.Click += async (sender, e) => await StopAllDownloads();
            resumeDownload.Click += async (sender, e) => await ResumeAllDownloads();
        }


        private async void Timer_Tick(object sender, EventArgs e)
        {
            var downloads = await GetActiveDownloads();
            double totalCompletePercentage = 0;


            for (int i = 0; i < 4; i++)
            {
                var downloadItem = Controls.Find($"downloadedItem{i + 1}", true).FirstOrDefault();
                var downloadFilename = Controls.Find($"downloadFilename{i + 1}", true).FirstOrDefault();
                var downloadSize = Controls.Find($"downloadSize{i + 1}", true).FirstOrDefault();
                var downloadSpeed = Controls.Find($"downloadSpeed{i + 1}", true).FirstOrDefault();
                var downloadComplete = Controls.Find($"downloadComplete{i + 1}", true).FirstOrDefault();
                var downloadBar = Controls.Find($"downloadBar{i + 1}", true).FirstOrDefault() as System.Windows.Forms.ProgressBar;

                if (downloads.Count == 0)
                {
                    infoHTML1.Visible = true;
                }
                else if (i < downloads.Count)
                {
                    infoHTML1.Visible = false;
                    var download = downloads[i];
                    downloadItem.Visible = true;
                    downloadFilename.Text = download.FileName;
                    downloadSize.Text = FormatSize(download.Size);
                    downloadSpeed.Text = FormatSpeed(download.Speed);
                    downloadComplete.Text = $"{download.CompletePercentage:F2}%";
                    downloadBar.Value = (int)(download.CompletePercentage);

                    totalCompletePercentage += download.CompletePercentage;
                    if (set12.Checked == true)
                    {
                        Program.LogEvent($"[-] OK: Status pobierania: {totalCompletePercentage} ukoñczono ogó³em.");
                    }
                }
                else
                {
                    infoHTML1.Visible = false;

                    if (downloadItem != null)
                    {
                        downloadItem.Visible = false;
                    }
                    DisplayDownloads();
                }
            }

            var downloadMoreLabel = Controls.Find("downloadMoreLabel", true).FirstOrDefault();
            int extraDownloads = downloads.Count - 4;
            if (extraDownloads > 0)
            {
                downloadMoreLabel.Text = $"{extraDownloads} aktywnych pobrañ w tle";
                if (set12.Checked == true)
                {
                    Program.LogEvent($"[-] OK: Status pobierania: {extraDownloads} aktywnych pobrañ w tle");
                }
            }
            else
            {
                // return
            }

            var overallProgressBar = Controls.Find("overallProgressBar", true).FirstOrDefault() as System.Windows.Forms.ProgressBar;
            if (downloads.Count > 0)
            {
                double averageCompletion = totalCompletePercentage / downloads.Count;
                overallProgressBar.Value = (int)averageCompletion;
                if (set12.Checked == true)
                {
                    Program.LogEvent($"[-] OK: Status pobierania: {averageCompletion}");
                }

            }
            else
            {
                overallProgressBar.Value = 0;
                if (set12.Checked == true)
                {
                    Program.LogEvent($"[-] OK: Brak aktywnych zadañ pobierania w kolejce, lub pobieranie zosta³o ukoñczone.");
                }
                // return
            }
        }



        private async Task<List<DownloadInfo>> GetActiveDownloads()
        {
            var downloads = new List<DownloadInfo>();

            try
            {
                var response = await client.PostAsync("http://localhost:6800/jsonrpc",
                new StringContent("{\"jsonrpc\":\"2.0\",\"method\":\"aria2.tellActive\",\"id\":\"qwer\"}"));
                var json = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(json)["result"];

                foreach (var item in result)
                {
                    var totalLength = long.Parse(item["totalLength"].ToString());
                    var completedLength = long.Parse(item["completedLength"].ToString());
                    var downloadInfo = new DownloadInfo
                    {
                        Gid = item["gid"].ToString(),
                        FileName = item["files"].First()["path"].ToString(),
                        Size = totalLength,
                        Speed = long.Parse(item["downloadSpeed"].ToString()),
                        Complete = completedLength,
                        CompletePercentage = totalLength == 0 ? 0 : (double)completedLength / totalLength * 100
                    };
                    downloads.Add(downloadInfo);
                    if (set12.Checked == true)
                    {
                        Program.LogEvent($"[-] OK: Dodano plik {item} do kolejki pobierania.");
                    }
                }
            }
            catch (Exception ex)
            {
                //RETURN
            }

            return downloads;
        }

        private string FormatSize(long size)
        {
            if (size >= 1024 * 1024 * 1024)
                return $"{size / (1024 * 1024 * 1024.0):F2} GiB";
            if (size >= 1024 * 1024)
                return $"{size / (1024 * 1024.0):F2} MiB";
            if (size >= 1024)
                return $"{size / 1024.0:F2} KiB";
            return $"{size} B";
        }

        private string FormatSpeed(long speed)
        {
            if (speed >= 1024 * 1024)
                return $"{speed / (1024 * 1024.0):F2} MiB/s";
            if (speed >= 1024)
                return $"{speed / 1024.0:F2} KiB/s";
            return $"{speed} B/s";
        }

        private async Task StopDownload(int index)
        {
            var downloads = await GetActiveDownloads();
            if (index < downloads.Count)
            {
                var gid = downloads[index].Gid;
                await SendAria2cCommand("aria2.pause", gid);
                stoppedDownloads++;
                Controls.Find("downloadStopLabel", true).FirstOrDefault().Text = $"{stoppedDownloads} zatrzymanych pobrañ";
                pausedDownloads.Add(gid);
                Program.LogEvent($"[-] OK: Pobieranie zakolejkowanego pliku: {gid} zosta³o zatrzymane przez u¿ytkownika.");
            }
        }

        private async Task RemoveDownload(int index)
        {
            var downloads = await GetActiveDownloads();
            if (index < downloads.Count)
            {
                var gid = downloads[index].Gid;
                await SendAria2cCommand("aria2.remove", gid);
                await SendAria2cCommand("aria2.removeDownloadResult", gid);
                RefreshUI();
                Program.LogEvent($"[-] OK: Pobieranie zakolejkowanego pliku: {gid} zosta³o usuniête przez u¿ytkownika.");
            }
        }

        private async Task StopAllDownloads()
        {
            await SendAria2cCommand("aria2.pauseAll");
            var downloads = await GetActiveDownloads();
            pausedDownloads.Clear();
            foreach (var download in downloads)
            {
                pausedDownloads.Add(download.Gid);
            }
            stoppedDownloads = pausedDownloads.Count;
            Controls.Find("downloadStopLabel", true).FirstOrDefault().Text = $"{stoppedDownloads} zatrzymanych pobrañ";
            Program.LogEvent($"[-] OK: Aktualny stan pobierania: {stoppedDownloads} zatrzymanych zadañ.");
        }

        private async Task ResumeAllDownloads()
        {
            await SendAria2cCommand("aria2.unpauseAll");
            pausedDownloads.Clear();
            stoppedDownloads = 0;
        }


        private async Task SendAria2cCommand(string method, string gid = null)
        {
            try
            {
                var request = new
                {
                    jsonrpc = "2.0",
                    method = method,
                    id = "qwer",
                    @params = gid == null ? new string[0] : new[] { gid }
                };

                var response = await client.PostAsync("http://localhost:6800/jsonrpc",
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request)));
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                // return
                Program.LogEvent($"[X] ERR: Wykryto b³¹d podczas wys³ania sygna³u do modu³u pobieraj¹cego - aria2c: {ex}");
            }
        }

        private void RefreshUI()
        {
            for (int i = 0; i < 4; i++)
            {
                var downloadItem = Controls.Find($"downloadedItem{i + 1}", true).FirstOrDefault();
                downloadItem.Visible = false;
            }
            Timer_Tick(null, null);
        }

        public class DownloadInfo
        {
            public string Gid { get; set; }
            public string FileName { get; set; }
            public long Size { get; set; }
            public long Speed { get; set; }
            public long Complete { get; set; }
            public double CompletePercentage { get; set; }
        }

        static void EnsureClipWatcherIsRunning(string appPath)
        {
            if (!IsClipWatcherRunning())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(appPath)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    Arguments = "/startmode 1"
                };

                Process.Start(startInfo);
                Program.LogEvent($"[-] OK: Pomyœlnie uruchomiono podproces programu: {startInfo}");
            }
        }

        static bool IsClipWatcherRunning()
        {
            return Process.GetProcessesByName("ClipWatcher").Any();
        }

        static void MonitorClipWatcher(string appPath)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (!IsClipWatcherRunning())
                {
                    EnsureClipWatcherIsRunning(appPath);
                }
            }

        }

        private bool isUninstallMode = false;
        private Dictionary<string, string> appDetails;

        private async void loadExtensions()
        {
            //string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "apps", "external");

            if (!Directory.Exists(directoryPath))
            {
                return;
            }
            var directories = Directory.GetDirectories(directoryPath);
            if (directories.Length == 0)
            {
                return;
            }
            List<string> exeFiles = new List<string>();
            foreach (var dir in directories)
            {
                var files = Directory.GetFiles(dir, "*.exe");
                exeFiles.AddRange(files);
            }
            string jsonUrl = "https://windowsbase.pl/uploads/apps/wbdownloader/extData.json";
            HttpClient client = new HttpClient();
            string jsonResponse = await client.GetStringAsync(jsonUrl);

            var jsonData = JsonDocument.Parse(jsonResponse).RootElement;
            var extensions = jsonData.EnumerateArray();

            appDetails = new Dictionary<string, string>();
            foreach (var extension in extensions)
            {
                if (extension.TryGetProperty("location", out JsonElement locationElement) &&
                    extension.TryGetProperty("name", out JsonElement nameElement))
                {
                    string location = locationElement.GetString();
                    string name = nameElement.GetString();
                    appDetails[location] = name;
                }
            }

            extensionsInstalled.Controls.Clear();

            HashSet<string> addedExeFiles = new HashSet<string>();

            foreach (var exeFile in exeFiles)
            {
                string relativePath = "." + exeFile.Substring(directoryPath.Length).Replace("\\", "/");

                if (appDetails.TryGetValue(relativePath, out string appName) && !addedExeFiles.Contains(relativePath))
                {
                    Icon appIcon = Icon.ExtractAssociatedIcon(exeFile);

                    Panel appPanel = new Panel();
                    appPanel.Padding = new Padding(10);
                    appPanel.Margin = new Padding(10);
                    appPanel.BorderStyle = BorderStyle.FixedSingle;
                    appPanel.Width = 150;
                    appPanel.Height = 150;

                    PictureBox iconBox = new PictureBox();
                    iconBox.Image = appIcon.ToBitmap();
                    iconBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    iconBox.Dock = DockStyle.Top;
                    iconBox.Height = 48;

                    Label appLabel = new Label();
                    appLabel.Text = appName;

                    //relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "apps", "external", relativePath);
                    relativePath = Path.Combine(directoryPath, relativePath);

                    appLabel.Tag = relativePath;

                    appLabel.TextAlign = ContentAlignment.MiddleCenter;
                    appLabel.Dock = DockStyle.Fill;
                    appLabel.Padding = new Padding(15);
                    appLabel.Margin = new Padding(0, 15, 0, 0);

                    appLabel.Click += (sender, e) =>
                    {
                        if (isUninstallMode)
                        {
                            UninstallExtension((Label)sender);
                        }
                        else
                        {
                            try
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo(exeFile)
                                {
                                    UseShellExecute = true,
                                    Verb = "runas"
                                };
                                Process.Start(startInfo);
                                Program.LogEvent($"[-] OK: Uruchomiono dodatek: {startInfo}");

                            }
                            catch (Exception ex)
                            {
                                if (form4 == null || form4.IsDisposed)
                                {
                                    form4 = new Form4();
                                    form4.Show();
                                }
                                else
                                {
                                    form4.BringToFront();
                                }
                            }
                        }
                    };

                    appPanel.Controls.Add(iconBox);
                    appPanel.Controls.Add(appLabel);

                    extensionsInstalled.Controls.Add(appPanel);

                    addedExeFiles.Add(relativePath);
                }
            }

            UpdateInfoVisibility();
            Program.LogEvent($"[-] OK: Stan aktualnie zainstalowanych dodatków zosta³ odœwie¿ony.");

        }

        private void UpdateInfoVisibility()
        {
            string relativePath = directoryPath;
            if (Directory.Exists(relativePath))
            {
                bool isContainerEmpty = !Directory.EnumerateFileSystemEntries(relativePath).Any();

                if (isContainerEmpty)
                {
                    ShowEmptyState();
                }
                else
                {
                    ShowContentState();
                }
            }
            else
            {
                ShowEmptyState();
                Program.LogEvent($"WRN [-]: Katalog '{relativePath}' nie istnieje. Prze³¹czono na stan pusty.");
            }
        }


        private void ShowEmptyState()
        {
            extNoInfo1.Visible = true;
            extNoInfo1.Enabled = true;
            extNoInfo2.Visible = true;
            extNoInfo2.Enabled = true;
            extNoInfo3.Visible = true;
            extNoInfo3.Enabled = true;
            extInfoNone.Visible = true;
            extInfoNone.Enabled = true;

            refreshExt.Visible = false;
            manageExt.Visible = false;
            refreshExt.Enabled = false;
            manageExt.Enabled = false;

            extInfoNone.Size = new Size(845, 536);
            extInfoNone.Location = new Point(3, 3);
            if (!extensionsInstalled.Controls.Contains(extInfoNone))
            {
                extensionsInstalled.Controls.Add(extInfoNone);
            }
            extNoInfo1.Size = new Size(200, 200);
            extNoInfo1.Location = new Point(315, 53);
            extNoInfo2.Size = new Size(366, 25);
            extNoInfo2.Location = new Point(237, 270);
            extNoInfo3.Size = new Size(545, 112);
            extNoInfo3.Location = new Point(145, 310);
            if (!extInfoNone.Controls.Contains(extNoInfo1))
            {
                extInfoNone.Controls.Add(extNoInfo1);
            }
            if (!extInfoNone.Controls.Contains(extNoInfo2))
            {
                extInfoNone.Controls.Add(extNoInfo2);
            }
            if (!extInfoNone.Controls.Contains(extNoInfo3))
            {
                extInfoNone.Controls.Add(extNoInfo3);
            }
        }

        private void ShowContentState()
        {
            extNoInfo1.Visible = false;
            extNoInfo1.Enabled = false;
            extNoInfo2.Visible = false;
            extNoInfo2.Enabled = false;
            extNoInfo3.Visible = false;
            extNoInfo3.Enabled = false;
            extInfoNone.Visible = false;
            extInfoNone.Enabled = false;

            refreshExt.Visible = true;
            manageExt.Visible = true;
            refreshExt.Enabled = true;
            manageExt.Enabled = true;

            if (extensionsInstalled.Controls.Contains(extInfoNone))
            {
                extensionsInstalled.Controls.Remove(extInfoNone);
            }
            extInfoNone.Controls.Remove(extNoInfo1);
            extInfoNone.Controls.Remove(extNoInfo2);
            extInfoNone.Controls.Remove(extNoInfo3);
        }



        private void manageExt_Click(object sender, EventArgs e)
        {
            isUninstallMode = !isUninstallMode;

            uninstallLabel.Visible = true;


            if (isUninstallMode)
            {
                extensionsInstalled.Controls.Add(uninstallLabel);
                manageExt.Text = "Wy³¹cz usuwanie";
            }
            else
            {
                extensionsInstalled.Controls.Remove(uninstallLabel);
                manageExt.Text = "Usuñ dodatki";
            }

            UpdateInfoVisibility();
            Program.LogEvent($"[-] OK: Stan aktualnie zainstalowanych dodatków zosta³ odœwie¿ony.");

        }

        //private void UninstallExtension(Label appLabel)
        //{
        //    string relativePath = (string)appLabel.Tag;

        //    if (relativePath.StartsWith("./"))
        //    {
        //        relativePath = relativePath.Substring(2);
        //    }
        //    else if (relativePath.StartsWith(".\\"))
        //    {
        //        relativePath = relativePath.Substring(2);
        //    }

        //    relativePath = relativePath.Replace(@".\", @"\");
        //    relativePath = relativePath.Replace(@"./", @"\");

        //    while (relativePath.Contains(@"\.\"))
        //    {
        //        relativePath = relativePath.Replace(@"\.\", @"\");
        //    }

        //    if (relativePath.EndsWith(".exe"))
        //    {
        //        relativePath = Path.GetDirectoryName(relativePath);
        //    }

        //    //string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        //    //string directoryPath = Path.Combine(basePath, relativePath);

        //    try
        //    {
        //        if (Directory.Exists(directoryPath))
        //        {
        //            Directory.Delete(directoryPath, true);
        //            extensionsInstalled.Controls.Remove(appLabel.Parent);
        //            appDetails.Remove((string)appLabel.Tag);
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Nie uda³o siê odinstalowaæ dodatku.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            Program.LogEvent($"[X] ERR: Nie uda³o siê odinstalowaæ dodatku.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Nie uda³o siê odinstalowaæ dodatku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Program.LogEvent($"[X] ERR: Nie uda³o siê odinstalowaæ dodatku. B³¹d: {ex.Message}");
        //    }

        //}

        private void UninstallExtension(Label appLabel)
        {
            string relativePath = (string)appLabel.Tag;
            relativePath = relativePath.Replace("./", "").Replace(".\\", "").Replace("/", "\\");
            while (relativePath.Contains("\\.\\"))
            {
                relativePath = relativePath.Replace("\\.\\", "\\");
            }
            if (relativePath.EndsWith(".exe"))
            {
                relativePath = Path.GetDirectoryName(relativePath);
            }
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            try
            {
                if (!string.IsNullOrEmpty(directoryPath) && Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                    extensionsInstalled.Controls.Remove(appLabel.Parent);
                    if (appDetails.ContainsKey((string)appLabel.Tag))
                    {
                        appDetails.Remove((string)appLabel.Tag);
                    }

                    Program.LogEvent($"[OK] Dodatek usuniêty: {directoryPath}");
                }
                else
                {
                    MessageBox.Show($"Nie uda³o siê znaleŸæ katalogu dodatku:\n{directoryPath}",
                                    "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Program.LogEvent($"[WARN] Katalog dodatku nie istnieje: {directoryPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie uda³o siê usun¹æ dodatku:\n{ex.Message}",
                                "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.LogEvent($"[X] ERR: Nie uda³o siê usun¹æ dodatku. B³¹d: {ex.Message}");
            }
        }


        private async void InitializeWebViewIconApp()
        {
            await logoIcon.EnsureCoreWebView2Async();

            logoIcon.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            logoIcon.CoreWebView2.Settings.IsStatusBarEnabled = false;
            logoIcon.NavigationCompleted += async (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    string css = @"
                body { background-color: transparent !important; margin: 0; }
                img { background-color: transparent !important; pointer-events: none; }";
                    await logoIcon.ExecuteScriptAsync($"const style = document.createElement('style'); style.innerHTML = `{css}`; document.head.appendChild(style);");
                }
            };

            logoIcon.DefaultBackgroundColor = System.Drawing.Color.Transparent;
        }

        private async void InitializeWebViewBrowserWindow()
        {
            LoadSelectedTheme();
            await browserWindowWebView.EnsureCoreWebView2Async();
            //string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string relativePath = Path.Combine("data", "apps", "main", "main.html");
            string appDirectory = rootPath;
            string fullPath = Path.Combine(appDirectory, relativePath);
            string fileUrl = new Uri(fullPath).AbsoluteUri;
            browserWindowWebView.CoreWebView2.Navigate(fileUrl);
            browserWindowWebView.NavigationCompleted += BrowserWindowWebView_NavigationCompleted;
            browserWindowWebView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            browserWindowWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            browserWindowWebView.CoreWebView2.Settings.IsStatusBarEnabled = false;


            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            browserWindowWebView.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    browserWindowWebView.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }

            };

            LoadSelectedTheme();

        }

        private async void InitializeWebViewDownloadCenter1()
        {
            LoadSelectedTheme();
            await userDbViewer.EnsureCoreWebView2Async();
            userDbViewer.NavigationCompleted += BrowserWindowWebView_NavigationCompleted;
            userDbViewer.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            userDbViewer.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            userDbViewer.CoreWebView2.Settings.IsStatusBarEnabled = false;

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            userDbViewer.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          body {{
                              background-color: {backgroundColorCss};
                              color: {textColorCss};
                          }}
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    userDbViewer.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }

            };

            LoadSelectedTheme();
        }



        private async void InitializeWebViewDownloadCenter2()
        {
            LoadSelectedTheme();
            await ftpViewer.EnsureCoreWebView2Async();
            ftpViewer.NavigationCompleted += BrowserWindowWebView_NavigationCompleted;
            ftpViewer.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            ftpViewer.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            ftpViewer.CoreWebView2.Settings.IsStatusBarEnabled = false;

            string htmlText = $@"
            <style>
                        body {{
                            font-family: Segoe UI,Frutiger,Frutiger Linotype,Dejavu Sans,Helvetica Neue,Arial,sans-serif; 
                            background-color: {defaultBackgroundColor};
                            color: {textColor};
                        }}
                        ::-webkit-scrollbar {{
                            width: 12px; 
                            height: 12px;
                        }}
                        ::-webkit-scrollbar-thumb {{
                            background-color: steelblue; 
                            border-radius: 10px;
                        }}
                        ::-webkit-scrollbar-thumb:hover {{
                            background-color: royalblue;
                        }}
                        ::-webkit-scrollbar-track {{
                            background-color: #1f262d;
                            border-radius: 10px;
                        }}
                        ::-webkit-scrollbar-track:hover {{
                            background-color: #1f262d;
                        }}
            </style>";

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            ftpViewer.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                    var style = document.createElement('style');
                    style.innerHTML = `
                        body {{
                            background-color: {backgroundColorCss};
                            color: {textColorCss};
                        }}
                        ::-webkit-scrollbar {{
                            width: 12px; 
                            height: 12px;
                        }}
                        ::-webkit-scrollbar-thumb {{
                            background-color: steelblue; 
                            border-radius: 10px;
                        }}
                        ::-webkit-scrollbar-thumb:hover {{
                            background-color: royalblue;
                        }}
                        ::-webkit-scrollbar-track {{
                            background-color: #1f262d;
                            border-radius: 10px;
                        }}
                        ::-webkit-scrollbar-track:hover {{
                            background-color: #1f262d;
                        }}
                    `;
                    document.head.appendChild(style);
                ";
                    ftpViewer.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }
            };

            databaseViewer.NavigateToString(htmlText);

            // LoadSelectedTheme();

        }

        private void BrowserWindowWebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            string searchString = Path.Combine(rootPath, "data", "apps", "main", "main.html");
            if (linkComboBox.Text.Contains(searchString))
            {
                linkComboBox.Text = "about://home";
            }
            else
            {
                linkComboBox.Text = browserWindowWebView.Source.AbsoluteUri;
            }
        }

        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
        }

        private Form2 form2 = null;


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var aria2Process = Process.GetProcessesByName("aria2c").FirstOrDefault();
            var clipProcess = Process.GetProcessesByName("ClipWatcher").FirstOrDefault();

            if (aria2Process != null)
            {
                if (form2 == null || form2.IsDisposed)
                {
                    Form2 form2 = new Form2(this);
                    form2.Show();
                }
                else
                {
                    form2.BringToFront();
                }
                e.Cancel = true;

            }
            else
            {
                // return
                clipProcess?.Kill();
            }
        }

        private void minimalizeApp_MouseEnter(object sender, EventArgs e)
        {
            minimalizeApp.Image = Properties.Resources.minus;
            minimalizeApp.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void minimalizeApp_MouseLeave(object sender, EventArgs e)
        {
            minimalizeApp.Image = Properties.Resources.minusHover;
            minimalizeApp.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void closeApp_MouseEnter(object sender, EventArgs e)
        {
            closeApp.Image = Properties.Resources.close;
            closeApp.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void closeApp_MouseLeave(object sender, EventArgs e)
        {
            closeApp.Image = Properties.Resources.closeHover;
            closeApp.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public class Item
        {
            public string Id { get; set; }
            public string Nazwa_obrazu { get; set; }
            public string Tag { get; set; }
            public string Kategoria { get; set; }
            public string Info { get; set; }
            public string Images { get; set; }
            public string Filename { get; set; }
            public string Size { get; set; }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void panel_Header_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel_Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel_Header__MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dbsiteButton_Click(object sender, EventArgs e)
        {
            dbSiteFlowPage.Enabled = true;
            dbSiteFlowPage.Visible = true;
            dbSiteFlowPage.Size = new Size(863, 605);
            dbSiteFlowPage.Location = new Point(17, 13);
            welcomeHeader.Visible = false;
            welcomeHeader.Enabled = false;
            userDbFlowPage.Visible = false;
            userDbFlowPage.Enabled = false;
            mainPanelRedirectPanel.Enabled = true;
            mainPanelRedirectPanel.Visible = true;
            mainPanelRedirectPanel.Location = new Point(106, 40);
            mainPanelRedirectPanel.Size = new Size(894, 630);
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void dbuserButton_Click(object sender, EventArgs e)
        {
            dbSiteFlowPage.Enabled = false;
            dbSiteFlowPage.Visible = false;
            welcomeHeader.Visible = false;
            welcomeHeader.Enabled = false;
            userDbViewer.Size = new Size(842, 520);
            userDbViewer.Location = new Point(12, 70);
            userDbFlowPage.Size = new Size(863, 605);
            userDbFlowPage.Location = new Point(17, 13);
            userDbFlowPage.Visible = true;
            userDbFlowPage.Enabled = true;
            mainPanelRedirectPanel.Enabled = true;
            mainPanelRedirectPanel.Visible = true;
            mainPanelRedirectPanel.Location = new Point(106, 40);
            mainPanelRedirectPanel.Size = new Size(894, 630);
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void dbftpButton_Click(object sender, EventArgs e)
        {
            dbSiteFlowPage.Enabled = false;
            dbSiteFlowPage.Visible = false;
            welcomeHeader.Visible = false;
            welcomeHeader.Enabled = false;
            ftpViewer.Size = new Size(842, 520);
            ftpViewer.Location = new Point(12, 70);
            ftpFlowPage.Size = new Size(863, 605);
            ftpFlowPage.Location = new Point(17, 13);
            ftpFlowPage.Visible = true;
            ftpFlowPage.Enabled = true;
            mainPanelRedirectPanel.Enabled = true;
            mainPanelRedirectPanel.Visible = true;
            mainPanelRedirectPanel.Location = new Point(106, 40);
            mainPanelRedirectPanel.Size = new Size(894, 630);
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            mainPanel.Enabled = true;
            mainPanel.Visible = true;
            mainPanel.Size = new Size(894, 630);
            mainPanel.Location = new Point(106, 40);
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            welcomeHeader.Enabled = true;
            welcomeHeader.Visible = true;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = false;
            searchfilesPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void browserIcon_Click(object sender, EventArgs e)
        {
            InitializeWebViewBrowserWindow();
            LoadSelectedTheme();
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = true;
            browserPanel.Visible = true;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = false;
            searchfilesPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            browserPanel.Size = new Size(894, 630);
            browserPanel.Location = new Point(106, 40);
        }

        private void newsIcon_Click(object sender, EventArgs e)
        {
            connectivityPanel.Enabled = true;
            connectivityPanel.Visible = true;
            connectivityPanel.Size = new Size(894, 630);
            connectivityPanel.Location = new Point(106, 40);
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = false;
            searchfilesPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            settingsPanel.Visible = true;
            settingsPanel.Enabled = true;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = false;
            searchfilesPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            settingsPanel.Size = new Size(894, 630);
            settingsPanel.Location = new Point(106, 40);
            LoadSelectedTheme();
        }

        private void toolsIcon_Click(object sender, EventArgs e)
        {
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            extensionsMarketplace.Visible = true;
            extensionsMarketplace.Enabled = true;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = false;
            searchfilesPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            extensionsMarketplace.Size = new Size(894, 630);
            extensionsMarketplace.Location = new Point(106, 40);
            loadExtensions();
            LoadSelectedTheme();
        }

        private void searchIcon_Click(object sender, EventArgs e)
        {
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            searchfilesPanel.Visible = true;
            searchfilesPanel.Enabled = true;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            faqAppPanel.Enabled = false;
            faqAppPanel.Visible = false;
            searchfilesPanel.Size = new Size(894, 630);
            searchfilesPanel.Location = new Point(106, 40);
            LoadSelectedTheme();
        }


        Dictionary<string, string> comboBoxDictionary = new Dictionary<string, string>
            {
                {"Microsoft DOS", "msdos"},
                {"Microsoft Windows 1.x", "w1x"},
                {"Microsoft Windows 2.x", "w2x"},
                {"Microsoft Windows 3.x", "w3x"},
                {"Microsoft Windows NT 3.x", "wnt3x"},
                {"Microsoft Windows 95", "w95"},
                {"Microsoft Windows NT 4.0", "wnt4x"},
                {"Microsoft Windows 98", "w98"},
                {"Microsoft Windows ME", "wme"},
                {"Microsoft Windows 2000", "w2000"},
                {"Microsoft Windows XP", "wxp"},
                {"Microsoft Windows Embedded", "embedded"},
                {"Microsoft Windows Vista", "wvista"},
                {"Microsoft Windows 7", "w7"},
                {"Microsoft Windows 8", "w8"},
                {"Microsoft Windows 8.1", "w81"},
                {"Microsoft Windows 10", "w10"},
                {"Microsoft Windows 11", "w11"},
                {"Microsoft Windows 2000 Server", "2k"},
                {"Microsoft Windows 2003/2003 R2", "2k3"},
                {"Microsoft Windows Home Server 2007", "2k7"},
                {"Microsoft Windows 2008/2008 R2", "2k8"},
                {"Microsoft Windows Home Server 2011", "2k11"},
                {"Microsoft Windows 2012/2012 R2", "2k12"},
                {"Microsoft Windows 2016", "2k16"},
                {"Microsoft Windows 2019", "2k19"},
                {"Microsoft Windows 2022", "2k22"},
                {"Microsoft DOS (Beta)", "msdosbeta"},
                {"Microsoft Windows 1.x (Beta)", "w1xbeta"},
                {"Microsoft Windows 3.x (Beta)", "w3xbeta"},
                {"Microsoft Windows NT 3.x (Beta)", "wnt3xbeta"},
                {"Microsoft Windows 'Chicago' (95) (Beta)", "w95beta"},
                {"Microsoft Windows NT 4.0 (Beta)", "wnt4xbeta"},
                {"Microsoft Windows Embedded (Beta)", "embeddedbeta"},
                {"Microsoft Windows 'Memphis' (98) (Beta)", "w98beta"},
                {"Microsoft Windows 'Millenium' (ME) (Beta)", "wmebeta"},
                {"Microsoft Windows 'NT 5.0' (2000) (Beta)", "w2000beta"},
                {"Microsoft Windows 'Whistler' (XP) (Beta)", "wxpbeta"},
                {"Microsoft Windows 'Longhorn' (Vista) (Beta)", "vistabeta"},
                {"Microsoft Windows 7 (Beta)", "w7beta"},
                {"Microsoft Windows 8 (Beta)", "w8beta"},
                {"Microsoft Windows 8.1 (Beta)", "w81beta"},
                {"Microsoft Windows 10 (Beta)", "w10beta"},
                {"Microsoft Windows 10 '19H1'/1903'", "w10beta_19h1"},
                {"Microsoft Windows 10 'Manganese'", "w10beta_m"},
                {"Microsoft Windows 10 'Iron'", "w10beta_i"},
                {"Microsoft Windows 10 'Threshold'", "w10beta_t1"},
                {"Microsoft Windows 11 (Beta)", "w11beta"},
                {"Microsoft Windows Server 2000 (Beta)", "2kbeta"},
                {"Microsoft Windows 2003/2003 R2 (Beta)", "2k3beta"},
                {"Microsoft Windows Home Server 2007 (Beta)", "2k7beta"},
                {"Microsoft Windows 2008/2008 R2 (Beta)", "2k8beta"},
                {"Microsoft Windows 2012/2012 R2 (Beta)", "2k12beta"},
                {"Microsoft Windows 2016 (Beta)", "2k16beta"},
                {"Microsoft Windows 2019 (Beta)", "2k19beta"},
                {"Microsoft Windows 2022 (Beta)", "2k22beta"},
                {"Microsoft Office 3.x", "msoffice3x"},
                {"Microsoft Office 4.x", "msoffice4x"},
                {"Microsoft Office 95", "msoffice95"},
                {"Microsoft Office 97", "msoffice97"},
                {"Microsoft Office 2000", "msoffice2000"},
                {"Microsoft Office XP", "msofficexp"},
                {"Microsoft Office 2003", "msoffice2003"},
                {"Microsoft Office 2007", "msoffice2007"},
                {"Microsoft Office 2010", "msoffice2010"},
                {"Microsoft Office 2013", "msoffice2013"},
                {"Microsoft Office 2016", "msoffice2016"},
                {"Microsoft Office 2019/365", "msoffice2019"},
                {"Microsoft Office 2021", "msoffice2021"},
                {"IBM PC-DOS", "ibmdos"},
                {"IBM PC-DOS (Beta)", "ibmdosbeta"},
                {"IBM OS/2", "ibmos2"},
                {"IBM OS/2 (Beta)", "ibmos2beta"},
                {"Linux Debian", "debian"},
                {"Linux Fedora", "fedora"},
                {"Linux Mint", "mint"},
                {"Linux Ubuntu", "ubuntu"},
                {"Apple Macintosh OS", "macos"},
                {"Inne wersje rozwojowe systemów operacyjnych", "otherbeta"},
                {"Maszyny wirtualne (VMware)", "vmware"},
                {"Maszyny wirtualne (VirtualBox)", "vmbox"},
                {"Aktualizacje Microsoft Update", "wupdates"},
                {"Pakiety Service Pack", "wupdatespacks"},
                {"Aktualizacje Microsoft Update (Beta)", "wupdatesbeta"},
                {"Pakiety redystrybucyjne (DirectX)", "directx"},
                {"Pakiety redystrybucyjne (Visual C++)", "redists"},
                {"Microsoft Office for Mac (2008/2011)", "msofficemac"},
                {"Porzucone programy 3rd-party", "oldsoftware3rd"},
                {"Porzucone programy Microsoft", "oldsoftwarems"},
                {"Porzucone programy DOS", "oldsoftwaredos"},
                {"P³yty Recovery 'OEM'", "oemrd"},
                {"Ró¿ne kompilacje Microsoft Windows/Office", "misc"},
                {"Spo³ecznoœciowe poprawki ISO- Windows Vista (Beta)", "vistabetaadd"}
            };

        public static class ConfigReader
        {
            public static Dictionary<string, string> ReadConfig(string configFilePath)
            {
                var config = new Dictionary<string, string>();
                foreach (var line in File.ReadAllLines(configFilePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
                return config;
            }
        }

        private HttpClient client = new HttpClient();
        private string downloadServer;
        //private string languageSelected;
        private string showDDialogsEnabled;
        private string isBCUpdtChannel;


        public static class ConfigReaderSettingUI
        {
            public static Dictionary<string, string> ReadConfig(string filePath)
            {
                var config = new Dictionary<string, string>();

                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        if (line.Contains("="))
                        {
                            var parts = line.Split(new[] { '=' }, 2);
                            if (parts.Length == 2)
                            {
                                config[parts[0].Trim()] = parts[1].Trim();
                            }
                        }
                    }
                }

                return config;
            }

            public static void WriteConfig(string filePath, Dictionary<string, string> config)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var entry in config)
                    {
                        writer.WriteLine($"{entry.Key}={entry.Value}");
                    }
                }
            }
        }
        private void DownloadSpeedControl_Scroll(object sender, EventArgs e)
        {
            var speedMap = new Dictionary<int, string>
            {
                { 1, "16K" },
                { 2, "64K" },
                { 3, "128K" },
                { 4, "256K" },
                { 5, "512K" },
                { 6, "1M" },
                { 7, "2M" },
                { 8, "3M" },
                { 9, "5M" },
                { 10, "10M" }
            };

            if (speedMap.TryGetValue(downloadSpeedControl.Value, out string speedValue))
            {
                //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                //string configFilePath = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");


                var lines = File.ReadAllLines(configFilePath).ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith("set max=--max-overall-download-limit="))
                    {
                        lines[i] = $"set max=--max-overall-download-limit={speedValue}";
                        break;
                    }
                }

                File.WriteAllLines(configFilePath, lines);
            }
        }

        private string downloadValue;
        private string isAutoStartLauncher;

        private void LoadConfig()
        {
            try
            {
                //string rootPath = Application.StartupPath;
                //string configFilePath = Path.Combine(rootPath, "data", "settings", "config.ini");
                //string configFilePath2 = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");
                Program.LogEvent("[-] OK: Wczytano prawdi³owo folder docelowy zawieraj¹cy pliki z ustawieniami: " + rootPath);
                Program.LogEvent("[-] OK: Wczytano plik ustawieñ aplikacji");
                Program.LogEvent("[-] OK: Wczytano plik ustawieñ modu³u pobieraj¹cego.");

                if (File.Exists(configPath))
                {
                    var config = ConfigReader.ReadConfig(configPath);
                    LoadSettingsFromConfig(config);
                    CheckAndStartBootstrapper();
                }
                else
                {
                    HandleConfigFileMissing();
                    return;
                }
                if (File.Exists(configFilePath))
                {
                    LoadSettingsFromBatchFile(configFilePath);
                }
                else
                {
                    Program.LogEvent($"[X] ERR: Wykryto nieprawid³owe ustawienie. Proszê ponownie zainstalowaæ program w celu usuniêcia tego b³êdu.");
                    MessageBox.Show("Proszê ponownie zainstalowaæ program w celu usuniêcia tego b³êdu.");
                }
            }
            catch (Exception ex)
            {
                HandleLoadException(ex);
            }
        }

        private void LoadSettingsFromConfig(Dictionary<string, string> config)
        {
            downloadServer = config.ContainsKey("downloadServer") ? config["downloadServer"] : "1";
            downloadValue = config.ContainsKey("downloadServer") ? config["downloadServer"] : "default_value";
            showDDialogsEnabled = config.ContainsKey("showDDialogsEnabled") ? config["showDDialogsEnabled"] : "1";
            isBCUpdtChannel = config.ContainsKey("isBCUpdtChannel") ? config["isBCUpdtChannel"] : "1";
            isAutoStartLauncher = config.ContainsKey("isAutoStartLauncher") ? config["isAutoStartLauncher"] : "1";

            setServer.SelectedIndex = downloadServer == "0" ? 0 : 1;
            set8.Checked = showDDialogsEnabled == "1";
            set15.Checked = isBCUpdtChannel == "1";
            set16.Checked = isAutoStartLauncher == "1";

            LoadChannelSettings();
        }

        private void LoadSettingsFromBatchFile(string configFilePath2)
        {
            var lines = File.ReadAllLines(configFilePath2);
            foreach (var line in lines)
            {
                ParseBatchSettingLine(line);
            }
        }
        private void ParseBatchSettingLine(string line)
        {
            if (line.StartsWith("set download="))
            {
                locationTextBox.Text = line.Substring(19);
            }
            else if (line.StartsWith("set inetset=") || line.StartsWith("@REM set inetset="))
            {
                SetCheckBoxState(set1, line.StartsWith("set inetset="));
            }
            else if (line.StartsWith("set purges=") || line.StartsWith("@REM set purges="))
            {
                SetCheckBoxState(set2, line.StartsWith("set purges="));
            }
            else if (line.StartsWith("set inetset2=") || line.StartsWith("@REM set inetset2="))
            {
                SetCheckBoxState(set3, line.StartsWith("set inetset2="));
            }
            else if (line.StartsWith("set contd=") || line.StartsWith("@REM set contd="))
            {
                SetCheckBoxState(set6, line.StartsWith("set contd="));
            }
            else if (line.StartsWith("set verify=") || line.StartsWith("@REM set verify="))
            {
                SetCheckBoxState(set7, line.StartsWith("set verify="));
            }
            else if (line.StartsWith("set connect=") || line.StartsWith("@REM set connect="))
            {
                SetCheckBoxState(set4, line.StartsWith("set connect="));
            }
            else if (line.StartsWith("set logme=") || line.StartsWith("@REM set logme="))
            {
                SetCheckBoxState(set12, line.StartsWith("set logme="));
            }
            else if (line.StartsWith("set max=--max-overall-download-limit="))
            {
                SetDownloadSpeed(line.Substring("set max=--max-overall-download-limit=".Length).Trim());
                SetCheckBoxState(set13, line.StartsWith("set max="));
            }
        }
        private void SetCheckBoxState(CheckBox checkBox, bool isChecked)
        {
            checkBox.CheckState = isChecked ? CheckState.Checked : CheckState.Unchecked;
            checkBox.Checked = isChecked;
        }
        private void LoadChannelSettings()
        {
            string verIniPath = Path.Combine(rootPath, "data", "settings", "ver.ini");
            //string verIniPath = localVersionFilePath;

            if (File.Exists(verIniPath))
            {
                var lines = File.ReadAllLines(verIniPath);
                string channel = lines.FirstOrDefault(line => line.Trim().StartsWith("channel:"))?
                                    .Split(':').LastOrDefault()?
                                    .Replace(";", string.Empty)
                                    .Trim()
                                    .ToLower() ?? "Stable";

                if (isBCUpdtChannel == "1" || channel == "Beta")
                {
                    betaStatus.Visible = true;
                    betaStatus.Enabled = true;
                    set15.Enabled = false;
                    set15.OnBackColor = Color.Black;
                }

            }
        }


        private void CheckAndStartBootstrapper()
        {
            if (isAutoStartLauncher != "1") return;

            try
            {
                //string exePath = Path.Combine(Application.StartupPath, "BootstrapperWB.exe");

                if (File.Exists(exePath) && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath)).Length == 0)
                {
                    var startInfo = new ProcessStartInfo(exePath)
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        CreateNoWindow = false,
                        UseShellExecute = true,
                        Arguments = "\"/startmode 3\""
                    };
                    Process.Start(startInfo);
                }
                else
                {
                    Program.LogEvent("[-] OK: Aktywne uruchomienie instacji. Zamykam modu³.");
                }
            }
            catch (Exception ex)
            {
                Program.LogEvent($"[X] ERR: Wyst¹pi³ wyj¹tek aplikacji: {ex}");
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas uruchamiania pliku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleConfigFileMissing()
        {
            MessageBox.Show($"Wyst¹pi³ b³¹d podczas zapisu ustawieñ, proszê ponownie zainstalowaæ program, aby naprawiæ problem.");
            Program.LogEvent($"[X] ERR: Wyst¹pi³ b³¹d podczas zapisu ustawieñ, proszê ponownie zainstalowaæ program, aby naprawiæ problem.");

            downloadServer = "1";
            showDDialogsEnabled = "1";
            isBCUpdtChannel = "0";
            downloadValue = "1";
            setServer.SelectedIndex = 1;
            isAutoStartLauncher = "1";
        }

        private void HandleLoadException(Exception ex)
        {
            MessageBox.Show("Sprawdz uprawnienia dostêpu dla tej aplikacji. Byæ mo¿e program antywirusowy blokuje dostêp do niektórych wa¿nych plików tego programu.");
            Program.LogEvent($"[X] ERR: Wykryto wyj¹tek aplikacji: {ex}.");
            Program.LogEvent($"[X] ERR: Sprawdz uprawnienia dostêpu dla tej aplikacji. Byæ mo¿e program antywirusowy blokuje dostêp do niektórych wa¿nych plików tego programu.");

            downloadServer = "1";
            showDDialogsEnabled = "1";
            isBCUpdtChannel = "0";
            setServer.SelectedIndex = 1;
            isAutoStartLauncher = "1";
        }

        private void SetDownloadSpeed(string speedValue)
        {
            int speedIndex;

            switch (speedValue)
            {
                case "16K": speedIndex = 1; break;
                case "64K": speedIndex = 2; break;
                case "128K": speedIndex = 3; break;
                case "256K": speedIndex = 4; break;
                case "512K": speedIndex = 5; break;
                case "1M": speedIndex = 6; break;
                case "2M": speedIndex = 7; break;
                case "3M": speedIndex = 8; break;
                case "5M": speedIndex = 9; break;
                case "10M": speedIndex = 10; break;
                default:
                    Program.LogEvent($"[!] WRN: Wykryto nieprawid³owe ustawienie prêdkoœci. Zresetowano do domyœlnej wartoœci.");
                    speedIndex = 1;
                    break;
            }
            if (speedIndex >= downloadSpeedControl.Minimum && speedIndex <= downloadSpeedControl.Maximum)
            {
                downloadSpeedControl.Value = speedIndex;
            }
            else
            {
                Program.LogEvent("[!] WRN: Prêdkoœæ pobierania poza zakresem kontrolki.");
            }
        }



        private void SaveConfig()
        {
            try
            {
                //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                //string configFilePath = Path.Combine(rootPath, "data", "settings", "config.ini");

                var config = new Dictionary<string, string>
                {
                    { "downloadServer", setServer.SelectedIndex == 0 ? "0" : "1" },
                    { "showDDialogsEnabled", set8.Checked ? "1" : "0" },
                    { "isBCUpdtChannel", set15.Checked ? "1" : "0" },
                    { "isAutoStartLauncher", set16.Checked ? "1" : "0" }
                };

                ConfigReaderSettingUI.WriteConfig(configPath, config);
                Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");

            }
            catch (Exception ex)
            {
                Program.LogEvent($"[X] ERR: Wyst¹pi³ b³¹d podczas zapisu ustawieñ: {ex.Message}");
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas zapisu ustawieñ: {ex.Message}");
            }
        }


        private void setServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveConfig();
            SaveSelectedTheme(setUITheme.SelectedIndex);
            Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");
        }


        private void ToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            CustomControls.RJControls.RJToggleButton button = sender as CustomControls.RJControls.RJToggleButton;
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string configFilePath2 = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");


            var lines = File.ReadAllLines(configFilePath).ToList();
            string settingName = string.Empty;

            if (button == set1) settingName = "set inetset=";
            else if (button == set2) settingName = "set purges=";
            else if (button == set3) settingName = "set inetset2=";
            else if (button == set4) settingName = "set connect=";
            else if (button == set5) settingName = "set certbp=";
            else if (button == set6) settingName = "set contd=";
            else if (button == set7) settingName = "set verify=";
            else if (button == set12) settingName = "set logme=";
            else if (button == set13) settingName = "set max=";
            else if (button == set14) settingName = "set olddn=";

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(settingName))
                {
                    if (button.Checked)
                    {
                        lines[i] = lines[i].Replace("@REM ", "");
                    }
                    else
                    {
                        if (!lines[i].StartsWith("@REM "))
                        {
                            lines[i] = "@REM " + lines[i];
                        }
                    }
                    break;
                }
            }

            File.WriteAllLines(configFilePath, lines);
            Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");

        }

        private void ToggleButton_CheckedChanged2(object sender, EventArgs e)
        {
            CustomControls.RJControls.RJToggleButton button2 = sender as CustomControls.RJControls.RJToggleButton;
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string configFilePath3 = Path.Combine(rootPath, "data", "settings", "config.ini");


            if (button2 == set8)
            {
                var lines2 = File.ReadAllLines(configPath).ToList();
                for (int i = 0; i < lines2.Count; i++)
                {
                    if (lines2[i].StartsWith("showDDialogsEnabled="))
                    {
                        lines2[i] = button2.Checked ? "showDDialogsEnabled=1" : "showDDialogsEnabled=0";
                        break;
                    }
                }
                File.WriteAllLines(configPath, lines2);
                Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");
            }
            else if (button2 == set15)
            {
                var lines2 = File.ReadAllLines(configPath).ToList();
                for (int i = 0; i < lines2.Count; i++)
                {
                    if (lines2[i].StartsWith("isBCUpdtChannel="))
                    {
                        lines2[i] = button2.Checked ? "isBCUpdtChannel=1" : "isBCUpdtChannel=0";
                        break;
                    }
                }
                File.WriteAllLines(configPath, lines2);
                Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");
            }
            else if (button2 == set16)
            {
                var lines2 = File.ReadAllLines(configPath).ToList();
                for (int i = 0; i < lines2.Count; i++)
                {
                    if (lines2[i].StartsWith("isAutoStartLauncher="))
                    {
                        lines2[i] = button2.Checked ? "isAutoStartLauncher=1" : "isAutoStartLauncher=0";
                        break;
                    }
                }
                File.WriteAllLines(configPath, lines2);
                Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");
            }
        }


        private void LocationTextBox_TextChanged(object sender, EventArgs e)
        {
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string configFilePath2 = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");


            var lines = File.ReadAllLines(configFilePath).ToList();
            string newValue = locationTextBox.Text;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("set download="))
                {
                    lines[i] = "set download=--dir=" + newValue;
                    break;
                }
            }

            File.WriteAllLines(configFilePath, lines);
            Program.LogEvent($"[-] OK: Pomyœlnie zapisano ustawienia aplikacji.");
        }

        private string htmlFileName = "blank.html";

        private async void ReloadBrowserDBWindow()
        {
            LoadSelectedTheme();
            await databaseViewer.EnsureCoreWebView2Async();
            //string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string appDirectory = rootPath;
            string relativePath = Path.Combine(fallbackDirectory, htmlFileName);
            string fullPath = Path.Combine(appDirectory, relativePath);
            string fileUrl = new Uri(fullPath).AbsoluteUri;
            databaseViewer.CoreWebView2.Navigate(fileUrl);
            databaseViewer.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            databaseViewer.CoreWebView2.Settings.IsStatusBarEnabled = false;

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            databaseViewer.CoreWebView2.NavigationCompleted += async (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
              var style = document.createElement('style');
              style.innerHTML = `
                  body {{
                      background-color: {backgroundColorCss};
                      color: {textColorCss};
                  }}
                  ::-webkit-scrollbar {{
                      width: 12px; 
                      height: 12px;
                  }}
                  ::-webkit-scrollbar-thumb {{
                      background-color: steelblue; 
                      border-radius: 10px;
                  }}
                  ::-webkit-scrollbar-thumb:hover {{
                      background-color: royalblue;
                  }}
                  ::-webkit-scrollbar-track {{
                      background-color: #1f262d;
                      border-radius: 10px;
                  }}
                  ::-webkit-scrollbar-track:hover {{
                      background-color: #1f262d;
                  }}
              `;
              document.head.appendChild(style);
          ";
                    await databaseViewer.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }
            };

            LoadSelectedTheme();
        }


        private async void ReloadInfoWindow1()
        {
            LoadSelectedTheme();

            await infoHTML1.EnsureCoreWebView2Async();
            //string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string relativePath = Path.Combine("data", "apps", "main", "empty02.html");
            string appDirectory = rootPath;
            string fullPath = Path.Combine(appDirectory, relativePath2);
            string fileUrl = new Uri(fullPath).AbsoluteUri;
            infoHTML1.CoreWebView2.Navigate(fileUrl);
            infoHTML1.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            infoHTML1.CoreWebView2.Settings.IsStatusBarEnabled = false;

            infoHTML1.CoreWebView2.NavigationCompleted += async (sender, args) =>
            {
                string customScrollBarCss = @"
                
                ::-webkit-scrollbar {
                    width: 12px; 
                    height: 12px;
                }
                ::-webkit-scrollbar-thumb {
                    background-color: steelblue; 
                    border-radius: 10px;
                }
                ::-webkit-scrollbar-thumb:hover {
                    background-color: royalblue;
                }
                ::-webkit-scrollbar-track {
                    background-color: rgb(33, 42, 50); 
                    border-radius: 10px;
                }
                ::-webkit-scrollbar-track:hover {
                    background-color: rgb(33, 42, 50); 
                }
                ";
                string injectCssScript = $@"
                var style = document.createElement('style');
                style.innerHTML = `{customScrollBarCss}`;
                document.head.appendChild(style);
                ";
                await infoHTML1.CoreWebView2.ExecuteScriptAsync(injectCssScript);
            };

            LoadSelectedTheme();
        }

        private async void ReloadInfoWindow2()
        {
            LoadSelectedTheme();
            await infoHTML2.EnsureCoreWebView2Async();
            //string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string relativePath = Path.Combine("data", "apps", "main", "empty01.html");
            string appDirectory = rootPath;
            string fullPath = Path.Combine(appDirectory, relativePath3);
            string fileUrl = new Uri(fullPath).AbsoluteUri;
            infoHTML2.CoreWebView2.Navigate(fileUrl);
            infoHTML2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            infoHTML2.CoreWebView2.Settings.IsStatusBarEnabled = false;

            infoHTML2.CoreWebView2.NavigationCompleted += async (sender, args) =>
            {
                string customScrollBarCss = @"
                
                ::-webkit-scrollbar {
                    width: 12px; 
                    height: 12px;
                }
                ::-webkit-scrollbar-thumb {
                    background-color: steelblue; 
                    border-radius: 10px;
                }
                ::-webkit-scrollbar-thumb:hover {
                    background-color: royalblue;
                }
                ::-webkit-scrollbar-track {
                    background-color: rgb(33, 42, 50); 
                    border-radius: 10px;
                }
                ::-webkit-scrollbar-track:hover {
                    background-color: rgb(33, 42, 50); 
                }
                ";
                string injectCssScript = $@"
                var style = document.createElement('style');
                style.innerHTML = `{customScrollBarCss}`;
                document.head.appendChild(style);
                ";
                await infoHTML2.CoreWebView2.ExecuteScriptAsync(injectCssScript);
            };

            LoadSelectedTheme();
        }

        private async void ReloadInfoWindow3()
        {
            LoadSelectedTheme();

            await extensionsMarketplaceWebView.EnsureCoreWebView2Async();
            string fileUrl = "https://windowsbase.pl/uploads/apps/wbdownloader/extensions.html";
            extensionsMarketplaceWebView.CoreWebView2.Navigate(fileUrl);
            extensionsMarketplaceWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            extensionsMarketplaceWebView.CoreWebView2.Settings.IsStatusBarEnabled = false;

            extensionsMarketplaceWebView.CoreWebView2.NavigationCompleted += async (sender, args) =>
            {
                string scaleScript = "document.body.style.zoom = '90%';";
                await extensionsMarketplaceWebView.CoreWebView2.ExecuteScriptAsync(scaleScript);
            };

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            extensionsMarketplaceWebView.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          .main {{
                              background-color: {backgroundColorCss};
                              color: {textColorCss};
                          }}
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    extensionsMarketplaceWebView.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }

            };

            //  LoadSelectedTheme();
        }

        private async void ReloadInfoWindow4()
        {
            LoadConfig();
            LoadSelectedTheme();

            await search_WebView.EnsureCoreWebView2Async();

            string fileUrl = "https://windowsbase.pl/search_app.php";

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";


            search_WebView.CoreWebView2.Navigate(fileUrl);
            search_WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            search_WebView.CoreWebView2.Settings.IsStatusBarEnabled = false;


            search_WebView.CoreWebView2.NavigationCompleted += async (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string jsInjection = $"var downloadValue = '{downloadValue}';";
                    await search_WebView.CoreWebView2.ExecuteScriptAsync(jsInjection);

                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          .main {{
                              background-color: {backgroundColorCss};
                              color: {textColorCss};
                          }}
                          .searchSet b, .search-col3 li a, a, span, .searchSet div, .footer, .searchSet label  {{
                              color: {textColorCss} !important;
                          }}
                          .searchfield {{
                              background-color: {backgroundColorCss} !important;
                          }}
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    await search_WebView.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }
            };
        }


        private async void ReloadInfoWindow5()
        {
            LoadSelectedTheme();

            await contactFormWebView.EnsureCoreWebView2Async();
            contactFormWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            contactFormWebView.CoreWebView2.Settings.IsStatusBarEnabled = false;


            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            contactFormWebView.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          .main {{
                              background-color: {backgroundColorCss};
                              color: {textColorCss};
                          }}
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    contactFormWebView.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }

            };

            LoadSelectedTheme();
        }


        private async void ReloadInfoWindow6()
        {
            LoadSelectedTheme();

            await faqAppWebView.EnsureCoreWebView2Async();
            faqAppWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            faqAppWebView.CoreWebView2.Settings.IsStatusBarEnabled = false;


            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            faqAppWebView.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                      var style = document.createElement('style');
                      style.innerHTML = `
                          body, html, body::before {{
                              background-color: {backgroundColorCss};
                              color: {textColorCss};
                          }}
                          ::-webkit-scrollbar {{
                              width: 12px; 
                              height: 12px;
                          }}
                          ::-webkit-scrollbar-thumb {{
                              background-color: steelblue; 
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-thumb:hover {{
                              background-color: royalblue;
                          }}
                          ::-webkit-scrollbar-track {{
                              background-color: #1f262d;
                              border-radius: 10px;
                          }}
                          ::-webkit-scrollbar-track:hover {{
                              background-color: #1f262d;
                          }}
                      `;
                      document.head.appendChild(style);
                  ";
                    faqAppWebView.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }

            };

            LoadSelectedTheme();
        }

        private async void selectCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (databaseViewer.Enabled == false || databaseViewer.Visible == false)
            {
                databaseViewer.Enabled = true;
                databaseViewer.Visible = true;
                infoSelect.Visible = false;
                infoSelect.Enabled = false;
                goBack.Enabled = true;
                goBack.Visible = true;
            }

            ReloadBrowserDBWindow();
            LoadSelectedTheme();

            var responseString = await client.GetStringAsync("https://windowsbase.pl/admin_database/database.json");
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(responseString);

            string comboBoxValue = selectCategory.SelectedItem.ToString();
            string category = comboBoxDictionary[comboBoxValue];
            var filteredItems = items.Where(item => item.Tag == category).ToList();
            string htmlText = $@"
            <style>
                body {{
                    font-family: Segoe UI,Frutiger,Frutiger Linotype,Dejavu Sans,Helvetica Neue,Arial,sans-serif; 
                    background-color: {defaultBackgroundColor};
                    color: {textColor};
                }}
                table {{
                    width: 100%;
                    border-collapse: collapse;
                    border-radius: 3px;
                }}
                th, td {{
                    border: 1px solid black;
                    padding: 15px;
                    text-align: left;
                    border-color: SteelBlue;
                }}
                img {{
                    max-width: 64px;
                    height: auto;
                    margin: 0 5px 0 0;
                    background: rgba(255,255,255,0.7);
                }}
                .bit {{
                   max-width: 56px;
                }}
                td {{
                    max-width: 33vw;
                    text-wrap: balance;
                    word-wrap: break-word;
                    overflow-wrap: break-word;
                }}
                th {{
                    background-color: #516171;
                    text-align: center;
                }}
                li {{
                    list-style-type:none;
                }}
                a {{
                    color: steelblue;
                }}
                .zip_imglabel {{
                   max-width: 32px;
                   background: transparent;
                }}
                img.\37z_imglabel {{
                   max-width: 32px;
                   background: transparent;
                }}
                img.bit.a3264_imglabel, img.bit.ia64_imglabel {{
                    max-width: 86px;
                }}

            </style>
        <table>
            <tr>
                <th>Nazwa obrazu</th>
                <th>Nazwa pliku</th>
                <th>Rozmiar</th>
            </tr>";

            string[] formats = new string[] { ".iso", ".zip", ".rar", ".mdf", ".img", ".exe", ".7z", ".bin", ".cue" };

            foreach (var item in filteredItems)
            {
                string modified = item.Nazwa_obrazu.Replace("download.php", "download_app.php").Replace("target=\"_blank\"", "");

                foreach (var format in formats)
                {
                    modified = modified.Replace(format, $"{format}&downloadServer={downloadServer}");
                }

                htmlText += $"<tr><td>{modified}</td><td>{item.Filename}</td><td>{item.Size}</td></tr>";
            }
            htmlText += "</table>";

            string backgroundColorCss = $"rgb({defaultBackgroundColor.R}, {defaultBackgroundColor.G}, {defaultBackgroundColor.B})";
            string textColorCss = $"rgb({textColor.R}, {textColor.G}, {textColor.B})";

            databaseViewer.CoreWebView2.NavigationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    string cssInjection = $@"
                    var style = document.createElement('style');
                    style.innerHTML = `
                        body {{
                            background-color: {backgroundColorCss};
                            color: {textColorCss};
                        }}
                    `;
                    document.head.appendChild(style);
                ";

                    databaseViewer.CoreWebView2.ExecuteScriptAsync(cssInjection);
                }
            };

            databaseViewer.NavigateToString(htmlText);

            // LoadSelectedTheme();

        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.LogEvent($"[-] OK: Zamykam aplikacjê ...");

        }

        private void minimalizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeDBViewer_Click(object sender, EventArgs e)
        {
            dbSiteFlowPage.Enabled = false;
            dbSiteFlowPage.Visible = false;
            welcomeHeader.Visible = true;
            welcomeHeader.Enabled = true;
            databaseViewer.Enabled = false;
            databaseViewer.Visible = false;
            infoSelect.Visible = true;
            infoSelect.Enabled = true;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            mainPanel.Enabled = true;
            mainPanel.Visible = true;
            LoadSelectedTheme();
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            databaseViewer.GoBack();
            databaseViewer.Enabled = false;
            databaseViewer.Visible = false;
            infoSelect.Enabled = true;
            infoSelect.Visible = true;
            LoadSelectedTheme();
        }

        private void userDbgoBack_Click(object sender, EventArgs e)
        {
            userDbViewer.GoBack();
            LoadSelectedTheme();
        }

        private void userDbClose_Click(object sender, EventArgs e)
        {
            userDbFlowPage.Enabled = false;
            userDbFlowPage.Visible = false;
            welcomeHeader.Enabled = true;
            welcomeHeader.Visible = true;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            mainPanel.Enabled = true;
            mainPanel.Visible = true;
            LoadSelectedTheme();
        }

        private void ftpClose_Click(object sender, EventArgs e)
        {
            ftpFlowPage.Enabled = false;
            ftpFlowPage.Visible = false;
            welcomeHeader.Enabled = true;
            welcomeHeader.Visible = true;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            mainPanel.Enabled = true;
            mainPanel.Visible = true;
            LoadSelectedTheme();
        }

        private void ftpgoBack_Click(object sender, EventArgs e)
        {
            ftpViewer.GoBack();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private Form3 form3 = null;

        private void favouritesIcon_Click(object sender, EventArgs e)
        {
            browserWindowWebView.Visible = false;
            this.Enabled = false;

            if (form3 == null || form3.IsDisposed)
            {
                form3 = new Form3(this);

                int offsetX = 130;
                int offsetY = 100;

                form3.StartPosition = FormStartPosition.Manual;
                form3.Location = new Point(this.Location.X + offsetX, this.Location.Y + offsetY);
                form3.Show();
            }
            else
            {
                form3.BringToFront();
            }
        }


        private void browserGoBack_Click(object sender, EventArgs e)
        {
            if (browserWindowWebView.CoreWebView2.CanGoBack)
            {
                browserWindowWebView.CoreWebView2.GoBack();
            }
        }

        private void browserGoNext_Click(object sender, EventArgs e)
        {
            if (browserWindowWebView.CoreWebView2.CanGoForward)
            {
                browserWindowWebView.CoreWebView2.GoForward();
            }
        }

        private void homePageRedirect_Click(object sender, EventArgs e)
        {
            InitializeWebViewBrowserWindow();
        }

        private void browserRefresh_Click(object sender, EventArgs e)
        {
            browserWindowWebView.CoreWebView2.Reload();
            LoadSelectedTheme();
        }

        private void linkComboBox_TextChanged(object sender, EventArgs e)
        {
            string searchString = "data/apps/main/main.html";
            if (linkComboBox.Text.Contains(searchString))
            {
                linkComboBox.Text = "about://home";
            }
        }

        private void linkComboBox_Click(object sender, EventArgs e)
        {
            linkComboBox.Text = "";
        }


        private void linkComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string url = linkComboBox.Text;
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    browserWindowWebView.CoreWebView2.Navigate(url);
                }
                else
                {
                    MessageBox.Show("Podano nieprawid³owy adres URL.");
                    Program.LogEvent($"[!] WRN: Modu³ przegl¹darki: Podano nieprawid³owy adres URL.");

                }
            }
        }

        private void stopDownload_Click(object sender, EventArgs e)
        {

        }

        private void resumeDownload_Click(object sender, EventArgs e)
        {
            stoppedDownloads = 0;
            Controls.Find("downloadStopLabel", true).FirstOrDefault().Text = $"{stoppedDownloads} zatrzymanych pobrañ";
        }

        private Form5 form5 = null;
        private void openFolder_Click(object sender, EventArgs e)
        {
            //string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //string configFilePath2 = Path.Combine(rootPath, "data", "bin", "settings_aria.bat");

            string downloadFolderPath = string.Empty;
            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    if (line.StartsWith("set download="))
                    {
                        downloadFolderPath = line.Substring(19);
                        Program.LogEvent($"[-] OK: Ustawiono na katalog docelowy: {downloadFolderPath}.");
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(downloadFolderPath) && Directory.Exists(downloadFolderPath))
            {
                Process.Start("explorer.exe", downloadFolderPath);
                Program.LogEvent($"[-] OK: Otworzono katalog docelowy: {downloadFolderPath}.");
            }
            else
            {
                if (form5 == null || form5.IsDisposed)
                {
                    form5 = new Form5();
                    form5.Show();
                }
                else
                {
                    form5.BringToFront();
                }
            }
        }

        private void showDownloadedItems_Click(object sender, EventArgs e)
        {
            FilesDownloaded.Visible = true;
            FilesDownloaded.Enabled = true;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            FilesDownloaded.Size = new Size(894, 630);
            FilesDownloaded.Location = new Point(106, 40);
            LoadSelectedTheme();
        }


        private void btngoBackDownload_Click(object sender, EventArgs e)
        {
            FilesDownloaded.Visible = false;
            FilesDownloaded.Enabled = false;
            downloadPanel.Visible = true;
            downloadPanel.Enabled = true;
            downloadPanel.Size = new Size(894, 630);
            downloadPanel.Location = new Point(106, 40);
            LoadSelectedTheme();
        }

        private void selectLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    locationTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void locationTextBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void closewebViewMar_Click(object sender, EventArgs e)
        {
            extensionsMarketplaceWebView.Enabled = false;
            extensionsMarketplaceWebView.Visible = false;
            gotoMarketplace.Visible = true;
            gotoMarketplace.Enabled = true;
            closewebViewMar.Enabled = false;
            closewebViewMar.Visible = false;
            loadExtensions();
            LoadSelectedTheme();
        }

        private void gotoMarketplace_Click(object sender, EventArgs e)
        {
            extensionsMarketplaceWebView.Enabled = true;
            extensionsMarketplaceWebView.Visible = true;
            gotoMarketplace.Visible = false;
            gotoMarketplace.Enabled = false;
            closewebViewMar.Enabled = true;
            closewebViewMar.Visible = true;
            LoadSelectedTheme();
        }


        private void refreshExt_Click(object sender, EventArgs e)
        {
            loadExtensions();
            LoadSelectedTheme();
        }


        private void action1_Click(object sender, EventArgs e)
        {
            faqAppPanel.Visible = false;
            faqAppPanel.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            downloadPanel.Visible = true;
            downloadPanel.Enabled = true;
            downloadPanel.Size = new Size(894, 630);
            downloadPanel.Location = new Point(106, 40);
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            LoadSelectedTheme();
        }


        private void action2_Click(object sender, EventArgs e)
        {
            //string logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "userdata", "logs");
            string downloadLogPath = Path.Combine(logsDirectory, "download_log.txt");
            string appLoggedEventsPath = Path.Combine(logsDirectory, "appevents_log.txt");

            if (File.Exists(downloadLogPath))
            {
                Process.Start("notepad.exe", downloadLogPath);
            }
            else
            {
                MessageBox.Show($"Plik logów nie zosta³ znaleziony: {downloadLogPath}");
                Program.LogEvent($"[X] ERR: Plik logów nie zosta³ znaleziony: {downloadLogPath}.");
            }

            if (File.Exists(appLoggedEventsPath))
            {
                Process.Start("notepad.exe", appLoggedEventsPath);
            }
            else
            {
                MessageBox.Show($"Plik logów nie zosta³ znaleziony: {appLoggedEventsPath}");
                Program.LogEvent($"[X] ERR: Plik logów nie zosta³ znaleziony: {appLoggedEventsPath}.");
            }
        }

        private void action3_Click(object sender, EventArgs e)
        {
            faqAppPanel.Visible = true;
            faqAppPanel.Enabled = true;
            faqAppPanel.Size = new Size(894, 630);
            faqAppPanel.Location = new Point(106, 40);
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            LoadSelectedTheme();
        }

        private void action4_Click(object sender, EventArgs e)
        {
            faqAppPanel.Visible = false;
            faqAppPanel.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            contactPanel.Enabled = false;
            contactPanel.Visible = false;
            newsPanel.Visible = true;
            newsPanel.Enabled = true;
            newsPanel.Size = new Size(894, 630);
            newsPanel.Location = new Point(106, 40);
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            LoadSelectedTheme();
        }

        private void action5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Dostêpne wkrótce!");
        }

        private void action6_Click(object sender, EventArgs e)
        {
            faqAppPanel.Visible = false;
            faqAppPanel.Enabled = false;
            connectivityPanel.Enabled = false;
            connectivityPanel.Visible = false;
            mainPanel.Enabled = false;
            mainPanel.Visible = false;
            mainPanelRedirectPanel.Enabled = false;
            mainPanelRedirectPanel.Visible = false;
            browserPanel.Enabled = false;
            browserPanel.Visible = false;
            settingsPanel.Visible = false;
            settingsPanel.Enabled = false;
            FilesDownloaded.Enabled = false;
            FilesDownloaded.Visible = false;
            extensionsMarketplace.Visible = false;
            extensionsMarketplace.Enabled = false;
            newsPanel.Visible = false;
            newsPanel.Enabled = false;
            contactPanel.Enabled = true;
            contactPanel.Visible = true;
            downloadPanel.Visible = false;
            downloadPanel.Enabled = false;
            contactPanel.Size = new Size(894, 630);
            contactPanel.Location = new Point(106, 40);
            LoadSelectedTheme();
        }

        private void action7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Dostêpne wkrótce!");
        }

        private Form6 form6 = null;

        private void aboutAppRedirect_Click(object sender, EventArgs e)
        {
            if (form6 == null || form6.IsDisposed)
            {
                form6 = new Form6();
                form6.FormClosed += (s, args) => form6 = null;
                form6.Show();
            }
            else
            {
                form6.BringToFront();
                form6.Activate();
            }
        }

        private void fixApp_Click(object sender, EventArgs e)
        {
            try
            {
                //string exePath = Path.Combine(Application.StartupPath, "BootstrapperWB.exe");

                if (File.Exists(exePath))
                {
                    Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath));
                    if (runningProcesses.Length > 0)
                    {
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        "W celu zastosowania zmian i próby wykonania naprawy danych aplikacji w pliku pamiêci podrêcznej, zostanie przeprowadzone ponowne uruchomienie programu.",
                        "Program zostanie uruchomiony ponownie",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        //ProcessStartInfo startInfo = new ProcessStartInfo(exePath);
                        //Process.Start(startInfo);

                        ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
                        {
                            WindowStyle = ProcessWindowStyle.Normal,
                            CreateNoWindow = false,
                            UseShellExecute = false,
                            Arguments = "\"/startmode 1\""
                        };
                        Process.Start(startInfo);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nie mo¿na uruchomiæ narzêdzia naprawczego. Nie znaleziono pliku rozruchowego.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Program.LogEvent($"[X] ERR: Wyst¹pi³ wyj¹tek aplikacji: {ex}");
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas uruchamiania pliku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void checkForUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                //string exePath = Path.Combine(Application.StartupPath, "BootstrapperWB.exe");

                if (File.Exists(exePath))
                {
                    Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath));
                    if (runningProcesses.Length > 0)
                    {
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        "Aby manualnie sprawdziæ dostêpnoœæ aktualizacji, nale¿y ponownie uruchomiæ program. Czy chcesz to zrobiæ teraz?",
                        "Program zostanie uruchomiony ponownie",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
                        {
                            WindowStyle = ProcessWindowStyle.Normal,
                            CreateNoWindow = false,
                            UseShellExecute = false,
                            Arguments = "\"/startmode 3\""
                        };
                        Process.Start(startInfo);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nie mo¿na uruchomiæ aktualizatora programu.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Program.LogEvent($"[X] ERR: Wyst¹pi³ wyj¹tek aplikacji: {ex}");
                MessageBox.Show($"Wyst¹pi³ b³¹d podczas uruchamiania pliku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void appUpdateNews_Click(object sender, EventArgs e)
        {
            newsHTML.Visible = false;
            newsHTML.Enabled = false;
            appchangesPanel.Enabled = true;
            appchangesPanel.Visible = true;
            LoadSelectedTheme();
        }

        private void dbUpdateNews_Click(object sender, EventArgs e)
        {
            newsHTML.Visible = true;
            newsHTML.Enabled = true;
            appchangesPanel.Enabled = false;
            appchangesPanel.Visible = false;
            LoadSelectedTheme();
        }

        private void newUpdateNotifier_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Dostêpna jest nowa wersja programu, czy chcesz przeprowadziæ aktualizacjê teraz?",
                "Dostêpna nowa wersja programu",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                _isRestarting = true;
                Program.LogEvent("[-] OK: Rozpoczêto rêczn¹ aktualizacje programu. Wymagane ponowne uruchomienie programu. \n Wymuszam ponowny restart aplikacji...\n");
                //RestartApplication();

                Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath));
                if (runningProcesses.Length > 0)
                {
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    Arguments = "\"/startmode 3\""
                };
                Process.Start(startInfo);
            }



        }

        private void betaStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Korzystasz z rozwojowej wersji naszego oprogramowania, przez co mo¿esz doœwiadczyæ " +
                "niespodziewanych b³êdów dzia³ania tej aplikacji, niedopracowanych funkcji oraz zapoznaæ siê z " +
                "nowoœciami nadchodz¹cymi do stabilnej wersji programu. \n\nAby powróciæ do stabilnej wersji kana³u " +
                "aktualizacji, musisz ponownie zainstalowaæ ten program.", "Informacja o statusie oprogramowania", MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }

        private void portableMake_Click(object sender, EventArgs e)
        {
            //string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BootstrapperWB.exe");

            Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(exePath));
            if (runningProcesses.Length > 0)
            {
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = "\"/startmode 2\""
            };
            Process.Start(startInfo);

        }
    }
}
