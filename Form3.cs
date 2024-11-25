using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using WBDownloader2.Properties;

namespace WBDownloader2
{
    public partial class Form3 : Form
    {
        public static readonly string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

        public Form1 _form1;

        public Form3(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            LoadFavorites();
            InitializePictureBoxEvents();

            for (int i = 1; i <= 20; i++)
            {
                Button delFavButton = Controls.Find($"delFav{i}", true).FirstOrDefault() as Button;
                if (delFavButton != null)
                {
                    delFavButton.Click += delFav_Click;
                }
            }
        }

        private void InitializePictureBoxEvents()
        {
            for (int i = 1; i <= 21; i++)
            {
                PictureBox pictureBox = Controls.Find($"link{i}Picture", true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.MouseEnter += PictureBox_MouseEnter;
                    pictureBox.MouseLeave += PictureBox_MouseLeave;
                    pictureBox.Click += PictureBox_Click;
                }
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.BackColor = Color.SlateGray;
            pictureBox.Size = new Size(pictureBox.Width + 20, pictureBox.Height + 20);
            pictureBox.Location = new Point(pictureBox.Location.X - 10, pictureBox.Location.Y - 10);
            pictureBox.Cursor = Cursors.Hand;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Size = new Size(pictureBox.Width - 20, pictureBox.Height - 20);
            pictureBox.Location = new Point(pictureBox.Location.X + 10, pictureBox.Location.Y + 10);
            pictureBox.Cursor = Cursors.Default;
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = int.Parse(pictureBox.Name.Replace("link", "").Replace("Picture", ""));

            string baseDir = Path.Combine(rootPath, "data", "userdata");
            string linksFilePath = Path.Combine(baseDir, "savedLinks.txt");

            if (File.Exists(linksFilePath))
            {
                var lines = File.ReadAllLines(linksFilePath);
                if (index <= lines.Length)
                {
                    string line = lines[index - 1];
                    int firstDashIndex = line.IndexOf('-');
                    if (firstDashIndex > -1)
                    {
                        string link = line.Substring(firstDashIndex + 1);
                        _form1.browserWindowWebView.CoreWebView2.Navigate(link);
                        this.Close();
                        _form1.Enabled = true;
                        _form1.browserWindowWebView.Visible = true;
                    }
                }
            }
        }

        private void closeForm3_Click(object sender, EventArgs e)
        {
            this.Close();
            _form1.Enabled = true;
            _form1.browserWindowWebView.Visible = true;
        }


        private async void addFav_Click(object sender, EventArgs e)
        {
            string baseDir = Path.Combine(rootPath, "data", "userdata");
            Directory.CreateDirectory(baseDir);

            string link = _form1.browserWindowWebView.Source.ToString();

            if (string.IsNullOrEmpty(link))
            {
                MessageBox.Show("Nie można dodać zakładki z pustym linkiem.");
                return;
            }

            string faviconUrl = await GetFaviconUrl(_form1.browserWindowWebView);
            if (!string.IsNullOrEmpty(faviconUrl))
            {
                byte[] faviconData = await DownloadFavicon(faviconUrl);
                if (faviconData != null)
                {
                    string faviconPath = Path.Combine(baseDir, $"favicon{GetNextFaviconIndex(baseDir)}.ico");
                    File.WriteAllBytes(faviconPath, faviconData);
                }
            }
            else
            {
                string fallbackFaviconPath = "https://windowsbase.pl/images/brokenLink.ico";
                byte[] faviconDefault = await DownloadFavicon(fallbackFaviconPath);
                string faviconPath = Path.Combine(baseDir, $"favicon{GetNextFaviconIndex(baseDir)}.ico");
                File.WriteAllBytes(faviconPath, faviconDefault);
            }

            string linksFilePath = Path.Combine(baseDir, "savedLinks.txt");
            int linkIndex = GetNextLinkIndex(linksFilePath);
            using (StreamWriter writer = new StreamWriter(linksFilePath, true))
            {
                writer.WriteLine($"{linkIndex}-{link}");
            }

            UpdateUI(linkIndex, link, faviconUrl);
            LoadFavorites();
        }

        private async Task<string> GetFaviconUrl(WebView2 webView)
        {
            string faviconUrl = await webView.CoreWebView2.ExecuteScriptAsync(@"
                (function() {
                    var links = document.getElementsByTagName('link');
                    for (var i = 0; i < links.length; i++) {
                        if ((links[i].rel === 'icon') || (links[i].rel === 'shortcut icon')) {
                            return links[i].href;
                        }
                    }
                    return '';
                })();");
            return faviconUrl.Trim('"');
        }

        private async Task<byte[]> DownloadFavicon(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetByteArrayAsync(url);
                }
            }
            catch
            {
                return null;
            }
        }

        private int GetNextFaviconIndex(string baseDir)
        {
            return Directory.GetFiles(baseDir, "favicon*.ico").Length + 1;
        }

        private int GetNextLinkIndex(string linksFilePath)
        {
            if (!File.Exists(linksFilePath)) return 1;

            string lastLine = File.ReadLines(linksFilePath).LastOrDefault();
            if (string.IsNullOrEmpty(lastLine)) return 1;

            string[] parts = lastLine.Split('-');
            return int.TryParse(parts[0], out int lastIndex) ? lastIndex + 1 : 1;
        }

        private void UpdateUI(int index, string link, string faviconUrl)
        {
            if (index > 21) return;

            PictureBox pictureBox = Controls.Find($"link{index}Picture", true).FirstOrDefault() as PictureBox;
            Label label = Controls.Find($"linkLabel{index}", true).FirstOrDefault() as Label;

            if (pictureBox != null && label != null)
            {
                string truncatedLink = link.Length > 20 ? link.Substring(0, 20) + "..." : link;
                label.Text = truncatedLink;
                label.Visible = true;

                if (!string.IsNullOrEmpty(faviconUrl))
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.ImageLocation = faviconUrl;
                }
            }

            if (index == 21)
            {
                addFav.Enabled = false;
            }
        }

        private void LoadFavorites()
        {
            string baseDir = Path.Combine(rootPath, "data", "userdata");
            string linksFilePath = Path.Combine(baseDir, "savedLinks.txt");

            if (File.Exists(linksFilePath))
            {
                var lines = File.ReadAllLines(linksFilePath);
                foreach (var line in lines)
                {
                    int firstDashIndex = line.IndexOf('-');
                    if (firstDashIndex > -1 && int.TryParse(line.Substring(0, firstDashIndex), out int index))
                    {
                        string link = line.Substring(firstDashIndex + 1);
                        string faviconPath = Path.Combine(baseDir, $"favicon{index}.ico");
                        UpdateUI(index, link, File.Exists(faviconPath) ? faviconPath : null);
                    }
                }
            }
        }


        private void remFav_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Text == "Wyłącz edycję zakładek")
            {
                clickedButton.Text = "Edytuj zakładki";
                for (int i = 1; i <= 20; i++)
                {
                    Button delFavButton = Controls.Find($"delFav{i}", true).FirstOrDefault() as Button;
                    if (delFavButton != null)
                    {
                        delFavButton.Visible = false;
                    }
                }
                addFav.Enabled = true;
            }
            else
            {
                clickedButton.Text = "Wyłącz edycję zakładek";
                string baseDir = Path.Combine(rootPath, "data", "userdata");
                string linksFilePath = Path.Combine(baseDir, "savedLinks.txt");

                if (File.Exists(linksFilePath))
                {
                    var lines = File.ReadAllLines(linksFilePath);
                    for (int i = 1; i <= lines.Length; i++)
                    {
                        Button delFavButton = Controls.Find($"delFav{i}", true).FirstOrDefault() as Button;
                        if (delFavButton != null)
                        {
                            delFavButton.Visible = true;
                        }
                    }
                }
                addFav.Enabled = false;
            }
        }

        private void delFav_Click(object sender, EventArgs e)
        {
            Button delFavButton = sender as Button;
            int index = int.Parse(delFavButton.Name.Replace("delFav", ""));

            string baseDir = Path.Combine(rootPath, "data", "userdata");
            string linksFilePath = Path.Combine(baseDir, "savedLinks.txt");

            if (File.Exists(linksFilePath))
            {
                var lines = File.ReadAllLines(linksFilePath).ToList();

                if (index <= lines.Count)
                {
                    string removedLine = lines[index - 1];
                    lines.RemoveAt(index - 1);
                    string faviconPath = Path.Combine(baseDir, $"favicon{index}.ico");
                    if (File.Exists(faviconPath))
                    {
                        File.Delete(faviconPath);
                    }
                    for (int i = index; i <= lines.Count; i++)
                    {
                        string[] parts = lines[i - 1].Split(new[] { '-' }, 2);
                        int oldIndex = int.Parse(parts[0]);
                        string link = parts[1].Trim();
                        lines[i - 1] = $"{oldIndex - 1}-{link}";
                        string currentFaviconPath = Path.Combine(baseDir, $"favicon{i + 1}.ico");
                        string newFaviconPath = Path.Combine(baseDir, $"favicon{i}.ico");
                        if (File.Exists(currentFaviconPath))
                        {
                            File.Move(currentFaviconPath, newFaviconPath);
                        }
                    }
                    File.WriteAllLines(linksFilePath, lines);
                    LoadFavorites();
                }
            }
            delFavButton.Visible = false;
        }
    }
}
