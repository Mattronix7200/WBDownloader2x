using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Resources;
using System.Windows.Forms;
using System;
using System.Reflection.Emit;

namespace WBDownloader2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel_Header = new Panel();
            logoIcon = new Microsoft.Web.WebView2.WinForms.WebView2();
            betaStatus = new CustomControls.RJControls.RJButton();
            newUpdateNotifier = new CustomControls.RJControls.RJButton();
            closeApp = new PictureBox();
            minimalizeApp = new PictureBox();
            label1 = new System.Windows.Forms.Label();
            changedInfo = new System.Windows.Forms.Label();
            browserPanel = new Panel();
            browserPanelNavigation = new Panel();
            linkComboBox = new TextBox();
            browserRefresh = new PictureBox();
            favouritesIcon = new PictureBox();
            homePageRedirect = new PictureBox();
            browserGoNext = new PictureBox();
            browserGoBack = new PictureBox();
            browserWindowWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel_leftMenu = new Panel();
            searchIcon = new PictureBox();
            toolsIcon = new PictureBox();
            homeIcon = new PictureBox();
            settingsIcon = new PictureBox();
            browserIcon = new PictureBox();
            newsIcon = new PictureBox();
            panel_ContentBox = new Panel();
            welcomeHeader = new Panel();
            label2 = new System.Windows.Forms.Label();
            dbuserButton = new Button();
            dbsiteButton = new Button();
            dbftpButton = new Button();
            label56 = new System.Windows.Forms.Label();
            label55 = new System.Windows.Forms.Label();
            dbSiteFlowPage = new Panel();
            goBack = new PictureBox();
            closeDBViewer = new PictureBox();
            selectCategory = new CustomControls.RJControls.RJComboBox();
            databaseViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            infoSelect = new System.Windows.Forms.Label();
            mainPanel = new Panel();
            ftpFlowPage = new Panel();
            ftpgoBack = new PictureBox();
            ftpClose = new PictureBox();
            ftpViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            label3 = new System.Windows.Forms.Label();
            userDbFlowPage = new Panel();
            userDbgoBack = new PictureBox();
            userDbClose = new PictureBox();
            userDbViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            userDbHeader = new System.Windows.Forms.Label();
            downloadPanel = new Panel();
            infoHTML1 = new Microsoft.Web.WebView2.WinForms.WebView2();
            downloadControlPanel = new Panel();
            pictureBox9 = new PictureBox();
            downloadCompleteLabel = new System.Windows.Forms.Label();
            showDownloadedItems = new Button();
            overallLabelStatus = new System.Windows.Forms.Label();
            overallProgressBar = new CustomControls.RJControls.RJProgressBar();
            pictureBox3 = new PictureBox();
            downloadStopLabel = new System.Windows.Forms.Label();
            pictureBox1 = new PictureBox();
            resumeDownload = new Button();
            downloadMoreLabel = new System.Windows.Forms.Label();
            stopDownload = new Button();
            downloadedItem4 = new Panel();
            downloadBar4 = new ProgressBar();
            removeDownloadItem4 = new PictureBox();
            downloadComplete4 = new System.Windows.Forms.Label();
            stopDownloadItem4 = new PictureBox();
            downloadSpeed4 = new System.Windows.Forms.Label();
            downloadSize4 = new System.Windows.Forms.Label();
            downloadFilename4 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            downloadedItem3 = new Panel();
            downloadBar3 = new ProgressBar();
            removeDownloadItem3 = new PictureBox();
            downloadComplete3 = new System.Windows.Forms.Label();
            stopDownloadItem3 = new PictureBox();
            downloadSpeed3 = new System.Windows.Forms.Label();
            downloadSize3 = new System.Windows.Forms.Label();
            downloadFilename3 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            downloadedItem2 = new Panel();
            downloadBar2 = new ProgressBar();
            removeDownloadItem2 = new PictureBox();
            downloadComplete2 = new System.Windows.Forms.Label();
            stopDownloadItem2 = new PictureBox();
            downloadSpeed2 = new System.Windows.Forms.Label();
            downloadSize2 = new System.Windows.Forms.Label();
            downloadFilename2 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            downloadedItem1 = new Panel();
            downloadBar1 = new ProgressBar();
            downloadComplete1 = new System.Windows.Forms.Label();
            downloadSpeed1 = new System.Windows.Forms.Label();
            downloadSize1 = new System.Windows.Forms.Label();
            removeDownloadItem1 = new PictureBox();
            downloadFilename1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            stopDownloadItem1 = new PictureBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            FilesDownloaded = new Panel();
            infoHTML2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btngoBackDownload = new Button();
            fileD10 = new Panel();
            FileTime10 = new System.Windows.Forms.Label();
            FileTag10 = new System.Windows.Forms.Label();
            openFolder = new Button();
            fileD9 = new Panel();
            FileTime9 = new System.Windows.Forms.Label();
            FileTag9 = new System.Windows.Forms.Label();
            fileD8 = new Panel();
            FileTime8 = new System.Windows.Forms.Label();
            FileTag8 = new System.Windows.Forms.Label();
            fileD7 = new Panel();
            FileTime7 = new System.Windows.Forms.Label();
            FileTag7 = new System.Windows.Forms.Label();
            fileD6 = new Panel();
            FileTime6 = new System.Windows.Forms.Label();
            FileTag6 = new System.Windows.Forms.Label();
            fileD5 = new Panel();
            FileTime5 = new System.Windows.Forms.Label();
            FileTag5 = new System.Windows.Forms.Label();
            fileD4 = new Panel();
            FileTime4 = new System.Windows.Forms.Label();
            FileTag4 = new System.Windows.Forms.Label();
            fileD3 = new Panel();
            FileTime3 = new System.Windows.Forms.Label();
            FileTag3 = new System.Windows.Forms.Label();
            fileD2 = new Panel();
            FileTime2 = new System.Windows.Forms.Label();
            FileTag2 = new System.Windows.Forms.Label();
            fileD1 = new Panel();
            FileTime1 = new System.Windows.Forms.Label();
            FileTag1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            settingsPanel = new Panel();
            setHolderWindow = new Panel();
            portableMake = new CustomControls.RJControls.RJButton();
            DefaultThemePlaceHolder = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            set16 = new CustomControls.RJControls.RJToggleButton();
            label40 = new System.Windows.Forms.Label();
            set15 = new CustomControls.RJControls.RJToggleButton();
            fixApp = new CustomControls.RJControls.RJButton();
            label39 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            set14label = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            set8 = new CustomControls.RJControls.RJToggleButton();
            label35 = new System.Windows.Forms.Label();
            checkForUpdates = new CustomControls.RJControls.RJButton();
            verLabel = new System.Windows.Forms.Label();
            setUITheme = new CustomControls.RJControls.RJComboBox();
            label34 = new System.Windows.Forms.Label();
            locationTextBox = new TextBox();
            selectLocation = new CustomControls.RJControls.RJButton();
            label28 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            setServerlabel = new System.Windows.Forms.Label();
            setServer = new CustomControls.RJControls.RJComboBox();
            set14 = new CustomControls.RJControls.RJToggleButton();
            set13label = new System.Windows.Forms.Label();
            set13 = new CustomControls.RJControls.RJToggleButton();
            set12label = new System.Windows.Forms.Label();
            set12 = new CustomControls.RJControls.RJToggleButton();
            set7label = new System.Windows.Forms.Label();
            set7 = new CustomControls.RJControls.RJToggleButton();
            set6label = new System.Windows.Forms.Label();
            set6 = new CustomControls.RJControls.RJToggleButton();
            set5label = new System.Windows.Forms.Label();
            set5 = new CustomControls.RJControls.RJToggleButton();
            set4label = new System.Windows.Forms.Label();
            set4 = new CustomControls.RJControls.RJToggleButton();
            set3label = new System.Windows.Forms.Label();
            set3 = new CustomControls.RJControls.RJToggleButton();
            set2label = new System.Windows.Forms.Label();
            set2 = new CustomControls.RJControls.RJToggleButton();
            set1label = new System.Windows.Forms.Label();
            set1 = new CustomControls.RJControls.RJToggleButton();
            label19 = new System.Windows.Forms.Label();
            setBarH1 = new Panel();
            pictureBox7 = new PictureBox();
            label11 = new System.Windows.Forms.Label();
            setBarH4 = new Panel();
            label20 = new System.Windows.Forms.Label();
            pictureBox6 = new PictureBox();
            setBarH2 = new Panel();
            pictureBox2 = new PictureBox();
            label12 = new System.Windows.Forms.Label();
            setBarH5 = new Panel();
            pictureBox5 = new PictureBox();
            label18 = new System.Windows.Forms.Label();
            setBarH3 = new Panel();
            pictureBox4 = new PictureBox();
            label17 = new System.Windows.Forms.Label();
            downloadSpeedControl = new TrackBar();
            barMainSet = new Panel();
            pictureBox8 = new PictureBox();
            label10 = new System.Windows.Forms.Label();
            extensionsMarketplace = new Panel();
            extensionsMarketplaceWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            extensionsInstalled = new FlowLayoutPanel();
            extInfoNone = new Panel();
            extNoInfo3 = new System.Windows.Forms.Label();
            extNoInfo1 = new PictureBox();
            extNoInfo2 = new System.Windows.Forms.Label();
            uninstallLabel = new System.Windows.Forms.Label();
            refreshExt = new Button();
            manageExt = new Button();
            closewebViewMar = new PictureBox();
            label33 = new System.Windows.Forms.Label();
            gotoMarketplace = new Button();
            connectivityPanel = new Panel();
            aboutAppRedirect = new Button();
            action6 = new Panel();
            action7 = new Panel();
            action5 = new Panel();
            action4 = new Panel();
            action3 = new Panel();
            action2 = new Panel();
            action1 = new Panel();
            label41 = new System.Windows.Forms.Label();
            label47 = new System.Windows.Forms.Label();
            newsHTML = new Microsoft.Web.WebView2.WinForms.WebView2();
            appchangesPanel = new Panel();
            label42 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            dbUpdateNews = new CustomControls.RJControls.RJButton();
            appUpdateNews = new CustomControls.RJControls.RJButton();
            newsPanel = new Panel();
            label46 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            searchfilesPanel = new Panel();
            search_WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            contactPanel = new Panel();
            contactFormWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            faqAppPanel = new Panel();
            faqAppWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            mainPanelRedirectPanel = new Panel();
            panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimalizeApp).BeginInit();
            browserPanel.SuspendLayout();
            browserPanelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)browserRefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)favouritesIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)homePageRedirect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)browserGoNext).BeginInit();
            ((System.ComponentModel.ISupportInitialize)browserGoBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)browserWindowWebView).BeginInit();
            panel_leftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)searchIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolsIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)homeIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingsIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)browserIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newsIcon).BeginInit();
            welcomeHeader.SuspendLayout();
            dbSiteFlowPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)goBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeDBViewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseViewer).BeginInit();
            mainPanel.SuspendLayout();
            ftpFlowPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ftpgoBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ftpClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ftpViewer).BeginInit();
            userDbFlowPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userDbgoBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userDbClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userDbViewer).BeginInit();
            downloadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)infoHTML1).BeginInit();
            downloadControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            downloadedItem4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem4).BeginInit();
            downloadedItem3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem3).BeginInit();
            downloadedItem2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem2).BeginInit();
            downloadedItem1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem1).BeginInit();
            FilesDownloaded.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)infoHTML2).BeginInit();
            fileD10.SuspendLayout();
            fileD9.SuspendLayout();
            fileD8.SuspendLayout();
            fileD7.SuspendLayout();
            fileD6.SuspendLayout();
            fileD5.SuspendLayout();
            fileD4.SuspendLayout();
            fileD3.SuspendLayout();
            fileD2.SuspendLayout();
            fileD1.SuspendLayout();
            settingsPanel.SuspendLayout();
            setHolderWindow.SuspendLayout();
            setBarH1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            setBarH4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            setBarH2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            setBarH5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            setBarH3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)downloadSpeedControl).BeginInit();
            barMainSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            extensionsMarketplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)extensionsMarketplaceWebView).BeginInit();
            extensionsInstalled.SuspendLayout();
            extInfoNone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)extNoInfo1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closewebViewMar).BeginInit();
            connectivityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)newsHTML).BeginInit();
            appchangesPanel.SuspendLayout();
            newsPanel.SuspendLayout();
            searchfilesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)search_WebView).BeginInit();
            contactPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contactFormWebView).BeginInit();
            faqAppPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)faqAppWebView).BeginInit();
            mainPanelRedirectPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Header
            // 
            panel_Header.BackColor = Color.FromArgb(52, 64, 76);
            panel_Header.Controls.Add(logoIcon);
            panel_Header.Controls.Add(betaStatus);
            panel_Header.Controls.Add(newUpdateNotifier);
            panel_Header.Controls.Add(closeApp);
            panel_Header.Controls.Add(minimalizeApp);
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(changedInfo);
            panel_Header.Location = new Point(0, 0);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(1000, 40);
            panel_Header.TabIndex = 0;
            // 
            // logoIcon
            // 
            logoIcon.AllowExternalDrop = false;
            logoIcon.CreationProperties = null;
            logoIcon.DefaultBackgroundColor = Color.Transparent;
            logoIcon.ForeColor = Color.Gray;
            logoIcon.Location = new Point(12, 6);
            logoIcon.Name = "logoIcon";
            logoIcon.Size = new Size(28, 28);
            logoIcon.Source = new Uri("https://windowsbase.pl/images/logo/applogo.png", UriKind.Absolute);
            logoIcon.TabIndex = 17;
            logoIcon.ZoomFactor = 1D;
            // 
            // betaStatus
            // 
            betaStatus.BackColor = Color.Orange;
            betaStatus.BackgroundColor = Color.Orange;
            betaStatus.BorderColor = Color.Gold;
            betaStatus.BorderRadius = 3;
            betaStatus.BorderSize = 0;
            betaStatus.FlatAppearance.BorderSize = 0;
            betaStatus.FlatStyle = FlatStyle.Flat;
            betaStatus.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            betaStatus.ForeColor = Color.White;
            betaStatus.Location = new Point(336, 7);
            betaStatus.Name = "betaStatus";
            betaStatus.Size = new Size(61, 26);
            betaStatus.TabIndex = 21;
            betaStatus.Text = "BETA";
            betaStatus.TextColor = Color.White;
            betaStatus.UseVisualStyleBackColor = false;
            betaStatus.Visible = false;
            betaStatus.Click += betaStatus_Click;
            // 
            // newUpdateNotifier
            // 
            newUpdateNotifier.BackColor = Color.MediumSeaGreen;
            newUpdateNotifier.BackgroundColor = Color.MediumSeaGreen;
            newUpdateNotifier.BorderColor = Color.SpringGreen;
            newUpdateNotifier.BorderRadius = 3;
            newUpdateNotifier.BorderSize = 0;
            newUpdateNotifier.Cursor = Cursors.Hand;
            newUpdateNotifier.Enabled = false;
            newUpdateNotifier.FlatAppearance.BorderSize = 0;
            newUpdateNotifier.FlatStyle = FlatStyle.Flat;
            newUpdateNotifier.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            newUpdateNotifier.ForeColor = Color.White;
            newUpdateNotifier.Location = new Point(403, 7);
            newUpdateNotifier.Name = "newUpdateNotifier";
            newUpdateNotifier.Size = new Size(265, 26);
            newUpdateNotifier.TabIndex = 20;
            newUpdateNotifier.Text = "DOSTĘPNA AKTUALIZACJA PROGRAMU";
            newUpdateNotifier.TextColor = Color.White;
            newUpdateNotifier.UseVisualStyleBackColor = false;
            newUpdateNotifier.Visible = false;
            newUpdateNotifier.Click += newUpdateNotifier_Click;
            // 
            // closeApp
            // 
            closeApp.BackColor = Color.FromArgb(52, 64, 76);
            closeApp.BackgroundImage = Properties.Resources.closeHover;
            closeApp.BackgroundImageLayout = ImageLayout.Zoom;
            closeApp.Cursor = Cursors.Hand;
            closeApp.Location = new Point(964, 9);
            closeApp.Name = "closeApp";
            closeApp.Size = new Size(25, 25);
            closeApp.SizeMode = PictureBoxSizeMode.StretchImage;
            closeApp.TabIndex = 19;
            closeApp.TabStop = false;
            closeApp.Click += closeApp_Click;
            // 
            // minimalizeApp
            // 
            minimalizeApp.BackColor = Color.FromArgb(52, 64, 76);
            minimalizeApp.BackgroundImage = Properties.Resources.minusHover;
            minimalizeApp.BackgroundImageLayout = ImageLayout.Zoom;
            minimalizeApp.Cursor = Cursors.Hand;
            minimalizeApp.Location = new Point(933, 9);
            minimalizeApp.Name = "minimalizeApp";
            minimalizeApp.Size = new Size(25, 25);
            minimalizeApp.SizeMode = PictureBoxSizeMode.StretchImage;
            minimalizeApp.TabIndex = 18;
            minimalizeApp.TabStop = false;
            minimalizeApp.Click += minimalizeApp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 11);
            label1.Name = "label1";
            label1.Size = new Size(284, 20);
            label1.TabIndex = 7;
            label1.Text = "Menedżer pobierania - WindowsBASE.pl";
            // 
            // changedInfo
            // 
            changedInfo.AutoSize = true;
            changedInfo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            changedInfo.ForeColor = Color.SpringGreen;
            changedInfo.Location = new Point(689, 13);
            changedInfo.Name = "changedInfo";
            changedInfo.Size = new Size(234, 13);
            changedInfo.TabIndex = 63;
            changedInfo.Text = "Uruchom ponownie aby zastosować zmiany.";
            changedInfo.Visible = false;
            // 
            // browserPanel
            // 
            browserPanel.Controls.Add(browserPanelNavigation);
            browserPanel.Controls.Add(browserWindowWebView);
            browserPanel.Location = new Point(122, 43);
            browserPanel.Name = "browserPanel";
            browserPanel.Size = new Size(10, 10);
            browserPanel.TabIndex = 24;
            browserPanel.Visible = false;
            // 
            // browserPanelNavigation
            // 
            browserPanelNavigation.BackColor = Color.Black;
            browserPanelNavigation.Controls.Add(linkComboBox);
            browserPanelNavigation.Controls.Add(browserRefresh);
            browserPanelNavigation.Controls.Add(favouritesIcon);
            browserPanelNavigation.Controls.Add(homePageRedirect);
            browserPanelNavigation.Controls.Add(browserGoNext);
            browserPanelNavigation.Controls.Add(browserGoBack);
            browserPanelNavigation.Location = new Point(0, 0);
            browserPanelNavigation.Name = "browserPanelNavigation";
            browserPanelNavigation.Size = new Size(894, 45);
            browserPanelNavigation.TabIndex = 1;
            // 
            // linkComboBox
            // 
            linkComboBox.BackColor = Color.Black;
            linkComboBox.BorderStyle = BorderStyle.FixedSingle;
            linkComboBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            linkComboBox.ForeColor = Color.White;
            linkComboBox.Location = new Point(209, 10);
            linkComboBox.Name = "linkComboBox";
            linkComboBox.PlaceholderText = " https://windowsbase.pl";
            linkComboBox.Size = new Size(598, 29);
            linkComboBox.TabIndex = 6;
            linkComboBox.TextChanged += linkComboBox_TextChanged;
            // 
            // browserRefresh
            // 
            browserRefresh.Cursor = Cursors.Hand;
            browserRefresh.Image = Properties.Resources.refresh;
            browserRefresh.Location = new Point(132, 8);
            browserRefresh.Name = "browserRefresh";
            browserRefresh.Size = new Size(32, 32);
            browserRefresh.SizeMode = PictureBoxSizeMode.Zoom;
            browserRefresh.TabIndex = 5;
            browserRefresh.TabStop = false;
            browserRefresh.Click += browserRefresh_Click;
            // 
            // favouritesIcon
            // 
            favouritesIcon.Cursor = Cursors.Hand;
            favouritesIcon.Image = Properties.Resources.star;
            favouritesIcon.Location = new Point(850, 8);
            favouritesIcon.Name = "favouritesIcon";
            favouritesIcon.Size = new Size(32, 32);
            favouritesIcon.SizeMode = PictureBoxSizeMode.Zoom;
            favouritesIcon.TabIndex = 4;
            favouritesIcon.TabStop = false;
            favouritesIcon.Click += favouritesIcon_Click;
            // 
            // homePageRedirect
            // 
            homePageRedirect.Cursor = Cursors.Hand;
            homePageRedirect.Image = Properties.Resources.homeb;
            homePageRedirect.Location = new Point(94, 8);
            homePageRedirect.Name = "homePageRedirect";
            homePageRedirect.Size = new Size(32, 32);
            homePageRedirect.SizeMode = PictureBoxSizeMode.Zoom;
            homePageRedirect.TabIndex = 2;
            homePageRedirect.TabStop = false;
            homePageRedirect.Click += homePageRedirect_Click;
            // 
            // browserGoNext
            // 
            browserGoNext.Cursor = Cursors.Hand;
            browserGoNext.Image = Properties.Resources.aforw;
            browserGoNext.Location = new Point(53, 8);
            browserGoNext.Name = "browserGoNext";
            browserGoNext.Size = new Size(32, 32);
            browserGoNext.SizeMode = PictureBoxSizeMode.Zoom;
            browserGoNext.TabIndex = 1;
            browserGoNext.TabStop = false;
            browserGoNext.Click += browserGoNext_Click;
            // 
            // browserGoBack
            // 
            browserGoBack.Cursor = Cursors.Hand;
            browserGoBack.Image = Properties.Resources.aback;
            browserGoBack.Location = new Point(13, 8);
            browserGoBack.Name = "browserGoBack";
            browserGoBack.Size = new Size(32, 32);
            browserGoBack.SizeMode = PictureBoxSizeMode.Zoom;
            browserGoBack.TabIndex = 0;
            browserGoBack.TabStop = false;
            browserGoBack.Click += browserGoBack_Click;
            // 
            // browserWindowWebView
            // 
            browserWindowWebView.AllowExternalDrop = true;
            browserWindowWebView.CreationProperties = null;
            browserWindowWebView.DefaultBackgroundColor = Color.White;
            browserWindowWebView.Location = new Point(0, 46);
            browserWindowWebView.Name = "browserWindowWebView";
            browserWindowWebView.Size = new Size(894, 584);
            browserWindowWebView.Source = new Uri("https://windowsbase.pl", UriKind.Absolute);
            browserWindowWebView.TabIndex = 0;
            browserWindowWebView.ZoomFactor = 1D;
            // 
            // panel_leftMenu
            // 
            panel_leftMenu.BackColor = Color.FromArgb(52, 64, 76);
            panel_leftMenu.Controls.Add(searchIcon);
            panel_leftMenu.Controls.Add(toolsIcon);
            panel_leftMenu.Controls.Add(homeIcon);
            panel_leftMenu.Controls.Add(settingsIcon);
            panel_leftMenu.Controls.Add(browserIcon);
            panel_leftMenu.Controls.Add(newsIcon);
            panel_leftMenu.Controls.Add(panel_ContentBox);
            panel_leftMenu.Location = new Point(0, 40);
            panel_leftMenu.Name = "panel_leftMenu";
            panel_leftMenu.Size = new Size(105, 630);
            panel_leftMenu.TabIndex = 1;
            // 
            // searchIcon
            // 
            searchIcon.Cursor = Cursors.Hand;
            searchIcon.Image = Properties.Resources.search;
            searchIcon.Location = new Point(30, 521);
            searchIcon.Name = "searchIcon";
            searchIcon.Size = new Size(40, 40);
            searchIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            searchIcon.TabIndex = 16;
            searchIcon.TabStop = false;
            searchIcon.Click += searchIcon_Click;
            // 
            // toolsIcon
            // 
            toolsIcon.Cursor = Cursors.Hand;
            toolsIcon.Image = Properties.Resources.repair_tools;
            toolsIcon.Location = new Point(30, 426);
            toolsIcon.Name = "toolsIcon";
            toolsIcon.Size = new Size(40, 40);
            toolsIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            toolsIcon.TabIndex = 15;
            toolsIcon.TabStop = false;
            toolsIcon.Click += toolsIcon_Click;
            // 
            // homeIcon
            // 
            homeIcon.Cursor = Cursors.Hand;
            homeIcon.Image = Properties.Resources.home;
            homeIcon.Location = new Point(30, 46);
            homeIcon.Name = "homeIcon";
            homeIcon.Size = new Size(40, 40);
            homeIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            homeIcon.TabIndex = 9;
            homeIcon.TabStop = false;
            homeIcon.Click += homeIcon_Click;
            // 
            // settingsIcon
            // 
            settingsIcon.Cursor = Cursors.Hand;
            settingsIcon.Image = Properties.Resources.settings;
            settingsIcon.Location = new Point(30, 331);
            settingsIcon.Name = "settingsIcon";
            settingsIcon.Size = new Size(40, 40);
            settingsIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            settingsIcon.TabIndex = 14;
            settingsIcon.TabStop = false;
            settingsIcon.Click += settingsIcon_Click;
            // 
            // browserIcon
            // 
            browserIcon.Cursor = Cursors.Hand;
            browserIcon.Image = Properties.Resources.browser;
            browserIcon.Location = new Point(30, 141);
            browserIcon.Name = "browserIcon";
            browserIcon.Size = new Size(40, 40);
            browserIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            browserIcon.TabIndex = 12;
            browserIcon.TabStop = false;
            browserIcon.Click += browserIcon_Click;
            // 
            // newsIcon
            // 
            newsIcon.Cursor = Cursors.Hand;
            newsIcon.Image = Properties.Resources.newspaper;
            newsIcon.Location = new Point(30, 236);
            newsIcon.Name = "newsIcon";
            newsIcon.Size = new Size(40, 40);
            newsIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            newsIcon.TabIndex = 11;
            newsIcon.TabStop = false;
            newsIcon.Click += newsIcon_Click;
            // 
            // panel_ContentBox
            // 
            panel_ContentBox.Location = new Point(106, 0);
            panel_ContentBox.Name = "panel_ContentBox";
            panel_ContentBox.Size = new Size(894, 630);
            panel_ContentBox.TabIndex = 2;
            // 
            // welcomeHeader
            // 
            welcomeHeader.Controls.Add(label2);
            welcomeHeader.Controls.Add(dbuserButton);
            welcomeHeader.Controls.Add(dbsiteButton);
            welcomeHeader.Controls.Add(dbftpButton);
            welcomeHeader.Location = new Point(19, 17);
            welcomeHeader.Name = "welcomeHeader";
            welcomeHeader.Size = new Size(863, 180);
            welcomeHeader.TabIndex = 5;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 13);
            label2.Name = "label2";
            label2.Size = new Size(838, 87);
            label2.TabIndex = 0;
            label2.Text = resources.GetString("label2.Text");
            // 
            // dbuserButton
            // 
            dbuserButton.BackColor = Color.SteelBlue;
            dbuserButton.Cursor = Cursors.Hand;
            dbuserButton.FlatStyle = FlatStyle.Flat;
            dbuserButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dbuserButton.ForeColor = Color.LightSkyBlue;
            dbuserButton.Location = new Point(228, 117);
            dbuserButton.Name = "dbuserButton";
            dbuserButton.Size = new Size(212, 55);
            dbuserButton.TabIndex = 3;
            dbuserButton.Text = "Baza użytkowników";
            dbuserButton.UseVisualStyleBackColor = false;
            dbuserButton.Click += dbuserButton_Click;
            // 
            // dbsiteButton
            // 
            dbsiteButton.BackColor = Color.SteelBlue;
            dbsiteButton.Cursor = Cursors.Hand;
            dbsiteButton.FlatStyle = FlatStyle.Flat;
            dbsiteButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dbsiteButton.ForeColor = Color.LightSkyBlue;
            dbsiteButton.Location = new Point(10, 117);
            dbsiteButton.Name = "dbsiteButton";
            dbsiteButton.Size = new Size(212, 55);
            dbsiteButton.TabIndex = 2;
            dbsiteButton.Text = "Oficjalna baza strony";
            dbsiteButton.UseVisualStyleBackColor = false;
            dbsiteButton.Click += dbsiteButton_Click;
            // 
            // dbftpButton
            // 
            dbftpButton.BackColor = Color.SteelBlue;
            dbftpButton.Cursor = Cursors.Hand;
            dbftpButton.FlatStyle = FlatStyle.Flat;
            dbftpButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dbftpButton.ForeColor = Color.LightSkyBlue;
            dbftpButton.Location = new Point(446, 117);
            dbftpButton.Name = "dbftpButton";
            dbftpButton.Size = new Size(156, 55);
            dbftpButton.TabIndex = 1;
            dbftpButton.Text = "Serwer FTP";
            dbftpButton.UseVisualStyleBackColor = false;
            dbftpButton.Click += dbftpButton_Click;
            // 
            // label56
            // 
            label56.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label56.ForeColor = Color.White;
            label56.Location = new Point(12, 57);
            label56.Name = "label56";
            label56.Size = new Size(202, 26);
            label56.TabIndex = 12;
            label56.Text = "Wybrana podkategoria:";
            // 
            // label55
            // 
            label55.BackColor = Color.FromArgb(30, 41, 61);
            label55.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label55.ForeColor = Color.White;
            label55.Location = new Point(0, 1);
            label55.Name = "label55";
            label55.Size = new Size(845, 44);
            label55.TabIndex = 11;
            label55.Text = "   Oficjalna baza strony";
            label55.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dbSiteFlowPage
            // 
            dbSiteFlowPage.AutoScroll = true;
            dbSiteFlowPage.Controls.Add(goBack);
            dbSiteFlowPage.Controls.Add(closeDBViewer);
            dbSiteFlowPage.Controls.Add(selectCategory);
            dbSiteFlowPage.Controls.Add(databaseViewer);
            dbSiteFlowPage.Controls.Add(infoSelect);
            dbSiteFlowPage.Controls.Add(label56);
            dbSiteFlowPage.Controls.Add(label55);
            dbSiteFlowPage.Enabled = false;
            dbSiteFlowPage.Location = new Point(14, 10);
            dbSiteFlowPage.Name = "dbSiteFlowPage";
            dbSiteFlowPage.Size = new Size(10, 10);
            dbSiteFlowPage.TabIndex = 7;
            dbSiteFlowPage.Visible = false;
            // 
            // goBack
            // 
            goBack.BackColor = Color.FromArgb(30, 41, 61);
            goBack.BackgroundImage = Properties.Resources.back_arrow;
            goBack.BackgroundImageLayout = ImageLayout.Zoom;
            goBack.Cursor = Cursors.Hand;
            goBack.Location = new Point(777, 11);
            goBack.Name = "goBack";
            goBack.Size = new Size(25, 25);
            goBack.TabIndex = 17;
            goBack.TabStop = false;
            goBack.Click += goBack_Click;
            // 
            // closeDBViewer
            // 
            closeDBViewer.BackColor = Color.FromArgb(30, 41, 61);
            closeDBViewer.BackgroundImage = Properties.Resources.x_icon;
            closeDBViewer.BackgroundImageLayout = ImageLayout.Zoom;
            closeDBViewer.Cursor = Cursors.Hand;
            closeDBViewer.Location = new Point(808, 11);
            closeDBViewer.Name = "closeDBViewer";
            closeDBViewer.Size = new Size(25, 25);
            closeDBViewer.TabIndex = 14;
            closeDBViewer.TabStop = false;
            closeDBViewer.Click += closeDBViewer_Click;
            // 
            // selectCategory
            // 
            selectCategory.BackColor = Color.FromArgb(31, 38, 45);
            selectCategory.BorderColor = Color.SteelBlue;
            selectCategory.BorderSize = 1;
            selectCategory.DropDownStyle = ComboBoxStyle.DropDown;
            selectCategory.Font = new Font("Segoe UI", 10F);
            selectCategory.ForeColor = Color.White;
            selectCategory.IconColor = Color.SteelBlue;
            selectCategory.Items.AddRange(new object[] { "Microsoft DOS", "Microsoft Windows 1.x", "Microsoft Windows 2.x", "Microsoft Windows 3.x", "Microsoft Windows NT 3.x", "Microsoft Windows 95", "Microsoft Windows NT 4.0", "Microsoft Windows 98", "Microsoft Windows ME", "Microsoft Windows 2000", "Microsoft Windows XP", "Microsoft Windows Embedded", "Microsoft Windows Vista", "Microsoft Windows 7", "Microsoft Windows 8", "Microsoft Windows 8.1", "Microsoft Windows 10", "Microsoft Windows 11", "Microsoft Windows 2000 Server", "Microsoft Windows 2003/2003 R2", "Microsoft Windows Home Server 2007", "Microsoft Windows 2008/2008 R2", "Microsoft Windows Home Server 2011", "Microsoft Windows 2012/2012 R2", "Microsoft Windows 2016", "Microsoft Windows 2019", "Microsoft Windows 2022", "Microsoft DOS (Beta)", "Microsoft Windows 1.x (Beta)", "Microsoft Windows 3.x (Beta)", "Microsoft Windows NT 3.x (Beta)", "Microsoft Windows 'Chicago' (95) (Beta)", "Microsoft Windows NT 4.0 (Beta)", "Microsoft Windows Embedded (Beta)", "Microsoft Windows 'Memphis' (98) (Beta)", "Microsoft Windows 'Millenium' (ME) (Beta)", "Microsoft Windows 'NT 5.0' (2000) (Beta)", "Microsoft Windows 'Whistler' (XP) (Beta)", "Microsoft Windows 'Longhorn' (Vista) (Beta)", "Microsoft Windows 7 (Beta)", "Microsoft Windows 8 (Beta)", "Microsoft Windows 8.1 (Beta)", "Microsoft Windows 10 (Beta)", "Microsoft Windows 10 '19H1'/1903'", "Microsoft Windows 10 'Manganese'", "Microsoft Windows 10 'Iron'", "Microsoft Windows 10 'Threshold'", "Microsoft Windows 11 (Beta)", "Microsoft Windows Server 2000 (Beta)", "Microsoft Windows 2003/2003 R2 (Beta)", "Microsoft Windows Home Server 2007 (Beta)", "Microsoft Windows 2008/2008 R2 (Beta)", "Microsoft Windows 2012/2012 R2 (Beta)", "Microsoft Windows 2016 (Beta)", "Microsoft Windows 2019 (Beta)", "Microsoft Windows 2022 (Beta)", "Microsoft Office 3.x", "Microsoft Office 4.x", "Microsoft Office 95", "Microsoft Office 97", "Microsoft Office 2000", "Microsoft Office XP", "Microsoft Office 2003", "Microsoft Office 2007", "Microsoft Office 2010", "Microsoft Office 2013", "Microsoft Office 2016", "Microsoft Office 2019/365", "Microsoft Office 2021", "IBM PC-DOS", "IBM PC-DOS (Beta)", "IBM OS/2", "IBM OS/2 (Beta)", "Linux Debian", "Linux Fedora", "Linux Mint", "Linux Ubuntu", "Apple Macintosh OS", "Inne wersje rozwojowe systemów operacyjnych", "Maszyny wirtualne (VMware)", "Maszyny wirtualne (VirtualBox)", "Aktualizacje Microsoft Update", "Pakiety Service Pack", "Aktualizacje Microsoft Update (Beta)", "Pakiety redystrybucyjne (DirectX)", "Pakiety redystrybucyjne (Visual C++)", "Microsoft Office for Mac (2008/2011)", "Porzucone programy 3rd-party", "Porzucone programy Microsoft", "Porzucone programy DOS", "Płyty Recovery 'OEM'", "Różne kompilacje Microsoft Windows/Office", "Społecznościowe poprawki ISO- Windows Vista (Beta)" });
            selectCategory.ListBackColor = Color.SteelBlue;
            selectCategory.ListTextColor = Color.White;
            selectCategory.Location = new Point(206, 53);
            selectCategory.MinimumSize = new Size(200, 30);
            selectCategory.Name = "selectCategory";
            selectCategory.Padding = new Padding(1);
            selectCategory.Size = new Size(627, 30);
            selectCategory.TabIndex = 15;
            selectCategory.Texts = "";
            selectCategory.OnSelectedIndexChanged += selectCategory_OnSelectedIndexChanged;
            // 
            // databaseViewer
            // 
            databaseViewer.AllowExternalDrop = true;
            databaseViewer.CreationProperties = null;
            databaseViewer.DefaultBackgroundColor = Color.Transparent;
            databaseViewer.Enabled = false;
            databaseViewer.Location = new Point(13, 89);
            databaseViewer.Name = "databaseViewer";
            databaseViewer.Size = new Size(829, 515);
            databaseViewer.Source = new Uri("https://windowsbase.pl/uploads/apps/wbdownloader/blank.html", UriKind.Absolute);
            databaseViewer.TabIndex = 14;
            databaseViewer.Visible = false;
            databaseViewer.ZoomFactor = 1D;
            // 
            // infoSelect
            // 
            infoSelect.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            infoSelect.ForeColor = Color.White;
            infoSelect.Location = new Point(220, 98);
            infoSelect.Name = "infoSelect";
            infoSelect.Size = new Size(357, 26);
            infoSelect.TabIndex = 13;
            infoSelect.Text = "Aby rozpocząć, wybierz interesującą ciebie kategorię...";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(31, 38, 45);
            mainPanel.Controls.Add(welcomeHeader);
            mainPanel.Location = new Point(109, 43);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(10, 10);
            mainPanel.TabIndex = 8;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // ftpFlowPage
            // 
            ftpFlowPage.AutoScroll = true;
            ftpFlowPage.BackColor = Color.Transparent;
            ftpFlowPage.Controls.Add(ftpgoBack);
            ftpFlowPage.Controls.Add(ftpClose);
            ftpFlowPage.Controls.Add(ftpViewer);
            ftpFlowPage.Controls.Add(label3);
            ftpFlowPage.Enabled = false;
            ftpFlowPage.Location = new Point(46, 10);
            ftpFlowPage.Name = "ftpFlowPage";
            ftpFlowPage.Size = new Size(10, 10);
            ftpFlowPage.TabIndex = 23;
            ftpFlowPage.Visible = false;
            // 
            // ftpgoBack
            // 
            ftpgoBack.BackColor = Color.FromArgb(30, 41, 61);
            ftpgoBack.BackgroundImage = Properties.Resources.back_arrow;
            ftpgoBack.BackgroundImageLayout = ImageLayout.Zoom;
            ftpgoBack.Cursor = Cursors.Hand;
            ftpgoBack.Location = new Point(787, 21);
            ftpgoBack.Name = "ftpgoBack";
            ftpgoBack.Size = new Size(25, 25);
            ftpgoBack.TabIndex = 22;
            ftpgoBack.TabStop = false;
            ftpgoBack.Click += ftpgoBack_Click;
            // 
            // ftpClose
            // 
            ftpClose.BackColor = Color.FromArgb(30, 41, 61);
            ftpClose.BackgroundImage = Properties.Resources.x_icon;
            ftpClose.BackgroundImageLayout = ImageLayout.Zoom;
            ftpClose.Cursor = Cursors.Hand;
            ftpClose.Location = new Point(818, 21);
            ftpClose.Name = "ftpClose";
            ftpClose.Size = new Size(25, 25);
            ftpClose.TabIndex = 21;
            ftpClose.TabStop = false;
            ftpClose.Click += ftpClose_Click;
            // 
            // ftpViewer
            // 
            ftpViewer.AllowExternalDrop = true;
            ftpViewer.CreationProperties = null;
            ftpViewer.DefaultBackgroundColor = Color.Transparent;
            ftpViewer.Location = new Point(9, 57);
            ftpViewer.Name = "ftpViewer";
            ftpViewer.Size = new Size(842, 120);
            ftpViewer.Source = new Uri("https://db.windowsbase.pl/database/index_app.php", UriKind.Absolute);
            ftpViewer.TabIndex = 18;
            ftpViewer.ZoomFactor = 1D;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(30, 41, 61);
            label3.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.White;
            label3.Location = new Point(9, 10);
            label3.Name = "label3";
            label3.Size = new Size(845, 44);
            label3.TabIndex = 20;
            label3.Text = "   Oficjalny dostęp do serwera głównego";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userDbFlowPage
            // 
            userDbFlowPage.AutoScroll = true;
            userDbFlowPage.BackColor = Color.Transparent;
            userDbFlowPage.Controls.Add(userDbgoBack);
            userDbFlowPage.Controls.Add(userDbClose);
            userDbFlowPage.Controls.Add(userDbViewer);
            userDbFlowPage.Controls.Add(userDbHeader);
            userDbFlowPage.Enabled = false;
            userDbFlowPage.Location = new Point(30, 10);
            userDbFlowPage.Name = "userDbFlowPage";
            userDbFlowPage.Size = new Size(10, 10);
            userDbFlowPage.TabIndex = 19;
            userDbFlowPage.Visible = false;
            // 
            // userDbgoBack
            // 
            userDbgoBack.BackColor = Color.FromArgb(30, 41, 61);
            userDbgoBack.BackgroundImage = Properties.Resources.back_arrow;
            userDbgoBack.BackgroundImageLayout = ImageLayout.Zoom;
            userDbgoBack.Cursor = Cursors.Hand;
            userDbgoBack.Location = new Point(787, 21);
            userDbgoBack.Name = "userDbgoBack";
            userDbgoBack.Size = new Size(25, 25);
            userDbgoBack.TabIndex = 22;
            userDbgoBack.TabStop = false;
            userDbgoBack.Click += userDbgoBack_Click;
            // 
            // userDbClose
            // 
            userDbClose.BackColor = Color.FromArgb(30, 41, 61);
            userDbClose.BackgroundImage = Properties.Resources.x_icon;
            userDbClose.BackgroundImageLayout = ImageLayout.Zoom;
            userDbClose.Cursor = Cursors.Hand;
            userDbClose.Location = new Point(818, 21);
            userDbClose.Name = "userDbClose";
            userDbClose.Size = new Size(25, 25);
            userDbClose.TabIndex = 21;
            userDbClose.TabStop = false;
            userDbClose.Click += userDbClose_Click;
            // 
            // userDbViewer
            // 
            userDbViewer.AllowExternalDrop = true;
            userDbViewer.CreationProperties = null;
            userDbViewer.DefaultBackgroundColor = Color.White;
            userDbViewer.Location = new Point(12, 70);
            userDbViewer.Name = "userDbViewer";
            userDbViewer.Size = new Size(842, 120);
            userDbViewer.Source = new Uri("https://windowsbase.pl/panel/user_db/index_app.php", UriKind.Absolute);
            userDbViewer.TabIndex = 18;
            userDbViewer.ZoomFactor = 1D;
            // 
            // userDbHeader
            // 
            userDbHeader.BackColor = Color.FromArgb(30, 41, 61);
            userDbHeader.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            userDbHeader.ForeColor = Color.White;
            userDbHeader.Location = new Point(9, 10);
            userDbHeader.Name = "userDbHeader";
            userDbHeader.Size = new Size(845, 44);
            userDbHeader.TabIndex = 20;
            userDbHeader.Text = "   Baza użytkowników strony";
            userDbHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // downloadPanel
            // 
            downloadPanel.Controls.Add(infoHTML1);
            downloadPanel.Controls.Add(downloadControlPanel);
            downloadPanel.Controls.Add(downloadedItem4);
            downloadPanel.Controls.Add(downloadedItem3);
            downloadPanel.Controls.Add(downloadedItem2);
            downloadPanel.Controls.Add(downloadedItem1);
            downloadPanel.Controls.Add(label4);
            downloadPanel.Location = new Point(156, 43);
            downloadPanel.Name = "downloadPanel";
            downloadPanel.Size = new Size(10, 10);
            downloadPanel.TabIndex = 25;
            downloadPanel.Visible = false;
            // 
            // infoHTML1
            // 
            infoHTML1.AllowExternalDrop = true;
            infoHTML1.CreationProperties = null;
            infoHTML1.DefaultBackgroundColor = Color.Transparent;
            infoHTML1.Enabled = false;
            infoHTML1.Location = new Point(6, 7);
            infoHTML1.Name = "infoHTML1";
            infoHTML1.Size = new Size(884, 518);
            infoHTML1.TabIndex = 21;
            infoHTML1.Visible = false;
            infoHTML1.ZoomFactor = 1D;
            // 
            // downloadControlPanel
            // 
            downloadControlPanel.BackColor = Color.FromArgb(23, 22, 20);
            downloadControlPanel.Controls.Add(pictureBox9);
            downloadControlPanel.Controls.Add(downloadCompleteLabel);
            downloadControlPanel.Controls.Add(showDownloadedItems);
            downloadControlPanel.Controls.Add(overallLabelStatus);
            downloadControlPanel.Controls.Add(overallProgressBar);
            downloadControlPanel.Controls.Add(pictureBox3);
            downloadControlPanel.Controls.Add(downloadStopLabel);
            downloadControlPanel.Controls.Add(pictureBox1);
            downloadControlPanel.Controls.Add(resumeDownload);
            downloadControlPanel.Controls.Add(downloadMoreLabel);
            downloadControlPanel.Controls.Add(stopDownload);
            downloadControlPanel.Location = new Point(0, 531);
            downloadControlPanel.Name = "downloadControlPanel";
            downloadControlPanel.Size = new Size(894, 100);
            downloadControlPanel.TabIndex = 12;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = Properties.Resources.refresh;
            pictureBox9.Location = new Point(608, 61);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(25, 25);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 20;
            pictureBox9.TabStop = false;
            // 
            // downloadCompleteLabel
            // 
            downloadCompleteLabel.AutoSize = true;
            downloadCompleteLabel.BackColor = Color.Transparent;
            downloadCompleteLabel.Font = new Font("Segoe UI", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            downloadCompleteLabel.ForeColor = Color.MediumAquamarine;
            downloadCompleteLabel.Location = new Point(526, 11);
            downloadCompleteLabel.Name = "downloadCompleteLabel";
            downloadCompleteLabel.Size = new Size(147, 17);
            downloadCompleteLabel.TabIndex = 34;
            downloadCompleteLabel.Text = "0 ukończonych pobrań";
            // 
            // showDownloadedItems
            // 
            showDownloadedItems.Cursor = Cursors.Hand;
            showDownloadedItems.FlatStyle = FlatStyle.Flat;
            showDownloadedItems.Location = new Point(644, 60);
            showDownloadedItems.Name = "showDownloadedItems";
            showDownloadedItems.Size = new Size(210, 28);
            showDownloadedItems.TabIndex = 33;
            showDownloadedItems.Text = "Pokaż pobrane elementy";
            showDownloadedItems.UseVisualStyleBackColor = true;
            showDownloadedItems.Click += showDownloadedItems_Click;
            // 
            // overallLabelStatus
            // 
            overallLabelStatus.AutoSize = true;
            overallLabelStatus.BackColor = Color.Transparent;
            overallLabelStatus.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            overallLabelStatus.Location = new Point(20, 14);
            overallLabelStatus.Name = "overallLabelStatus";
            overallLabelStatus.Size = new Size(168, 17);
            overallLabelStatus.TabIndex = 32;
            overallLabelStatus.Text = "Status pobierania ogółem:";
            // 
            // overallProgressBar
            // 
            overallProgressBar.ChannelColor = Color.LightSteelBlue;
            overallProgressBar.ChannelHeight = 10;
            overallProgressBar.ForeBackColor = Color.RoyalBlue;
            overallProgressBar.ForeColor = Color.White;
            overallProgressBar.Location = new Point(20, 38);
            overallProgressBar.Name = "overallProgressBar";
            overallProgressBar.ShowMaximun = false;
            overallProgressBar.ShowValue = CustomControls.RJControls.TextPosition.None;
            overallProgressBar.Size = new Size(856, 10);
            overallProgressBar.SliderColor = Color.RoyalBlue;
            overallProgressBar.SliderHeight = 8;
            overallProgressBar.SymbolAfter = "";
            overallProgressBar.SymbolBefore = "";
            overallProgressBar.TabIndex = 32;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.resume;
            pictureBox3.Location = new Point(319, 61);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 25);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // downloadStopLabel
            // 
            downloadStopLabel.AutoSize = true;
            downloadStopLabel.BackColor = Color.Transparent;
            downloadStopLabel.Font = new Font("Segoe UI", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            downloadStopLabel.ForeColor = Color.LightSlateGray;
            downloadStopLabel.Location = new Point(707, 11);
            downloadStopLabel.Name = "downloadStopLabel";
            downloadStopLabel.Size = new Size(151, 17);
            downloadStopLabel.TabIndex = 13;
            downloadStopLabel.Text = "0 zatrzymanych pobrań";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // resumeDownload
            // 
            resumeDownload.Cursor = Cursors.Hand;
            resumeDownload.FlatStyle = FlatStyle.Flat;
            resumeDownload.Location = new Point(355, 60);
            resumeDownload.Name = "resumeDownload";
            resumeDownload.Size = new Size(210, 28);
            resumeDownload.TabIndex = 6;
            resumeDownload.Text = "Wznów pobieranie ";
            resumeDownload.UseVisualStyleBackColor = true;
            resumeDownload.Click += resumeDownload_Click;
            // 
            // downloadMoreLabel
            // 
            downloadMoreLabel.AutoSize = true;
            downloadMoreLabel.BackColor = Color.Transparent;
            downloadMoreLabel.Font = new Font("Segoe UI", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            downloadMoreLabel.ForeColor = Color.LightSkyBlue;
            downloadMoreLabel.Location = new Point(327, 11);
            downloadMoreLabel.Name = "downloadMoreLabel";
            downloadMoreLabel.Size = new Size(166, 17);
            downloadMoreLabel.TabIndex = 11;
            downloadMoreLabel.Text = "0 aktywnych pobrań w tle";
            // 
            // stopDownload
            // 
            stopDownload.Cursor = Cursors.Hand;
            stopDownload.FlatStyle = FlatStyle.Flat;
            stopDownload.Location = new Point(74, 60);
            stopDownload.Name = "stopDownload";
            stopDownload.Size = new Size(210, 28);
            stopDownload.TabIndex = 4;
            stopDownload.Text = "Zatrzymaj pobieranie";
            stopDownload.UseVisualStyleBackColor = true;
            stopDownload.Click += stopDownload_Click;
            // 
            // downloadedItem4
            // 
            downloadedItem4.BackgroundImage = Properties.Resources.hover;
            downloadedItem4.BackgroundImageLayout = ImageLayout.Stretch;
            downloadedItem4.Controls.Add(downloadBar4);
            downloadedItem4.Controls.Add(removeDownloadItem4);
            downloadedItem4.Controls.Add(downloadComplete4);
            downloadedItem4.Controls.Add(stopDownloadItem4);
            downloadedItem4.Controls.Add(downloadSpeed4);
            downloadedItem4.Controls.Add(downloadSize4);
            downloadedItem4.Controls.Add(downloadFilename4);
            downloadedItem4.Controls.Add(label29);
            downloadedItem4.Controls.Add(label30);
            downloadedItem4.Controls.Add(label31);
            downloadedItem4.Controls.Add(label32);
            downloadedItem4.Location = new Point(19, 403);
            downloadedItem4.Name = "downloadedItem4";
            downloadedItem4.Size = new Size(859, 103);
            downloadedItem4.TabIndex = 9;
            downloadedItem4.Visible = false;
            // 
            // downloadBar4
            // 
            downloadBar4.Location = new Point(155, 82);
            downloadBar4.Name = "downloadBar4";
            downloadBar4.Size = new Size(635, 10);
            downloadBar4.TabIndex = 30;
            // 
            // removeDownloadItem4
            // 
            removeDownloadItem4.BackColor = Color.Transparent;
            removeDownloadItem4.Cursor = Cursors.Hand;
            removeDownloadItem4.Image = Properties.Resources.del;
            removeDownloadItem4.Location = new Point(803, 18);
            removeDownloadItem4.Name = "removeDownloadItem4";
            removeDownloadItem4.Size = new Size(32, 32);
            removeDownloadItem4.SizeMode = PictureBoxSizeMode.StretchImage;
            removeDownloadItem4.TabIndex = 31;
            removeDownloadItem4.TabStop = false;
            // 
            // downloadComplete4
            // 
            downloadComplete4.AutoSize = true;
            downloadComplete4.BackColor = Color.Transparent;
            downloadComplete4.Location = new Point(795, 77);
            downloadComplete4.Name = "downloadComplete4";
            downloadComplete4.Size = new Size(36, 15);
            downloadComplete4.TabIndex = 8;
            downloadComplete4.Text = "data4";
            // 
            // stopDownloadItem4
            // 
            stopDownloadItem4.BackColor = Color.Transparent;
            stopDownloadItem4.Cursor = Cursors.Hand;
            stopDownloadItem4.Image = (Image)resources.GetObject("stopDownloadItem4.Image");
            stopDownloadItem4.Location = new Point(765, 18);
            stopDownloadItem4.Name = "stopDownloadItem4";
            stopDownloadItem4.Size = new Size(32, 32);
            stopDownloadItem4.SizeMode = PictureBoxSizeMode.StretchImage;
            stopDownloadItem4.TabIndex = 30;
            stopDownloadItem4.TabStop = false;
            // 
            // downloadSpeed4
            // 
            downloadSpeed4.AutoSize = true;
            downloadSpeed4.BackColor = Color.Transparent;
            downloadSpeed4.Location = new Point(155, 54);
            downloadSpeed4.Name = "downloadSpeed4";
            downloadSpeed4.Size = new Size(36, 15);
            downloadSpeed4.TabIndex = 7;
            downloadSpeed4.Text = "data3";
            // 
            // downloadSize4
            // 
            downloadSize4.AutoSize = true;
            downloadSize4.BackColor = Color.Transparent;
            downloadSize4.Location = new Point(155, 31);
            downloadSize4.Name = "downloadSize4";
            downloadSize4.Size = new Size(36, 15);
            downloadSize4.TabIndex = 6;
            downloadSize4.Text = "data2";
            // 
            // downloadFilename4
            // 
            downloadFilename4.BackColor = Color.Transparent;
            downloadFilename4.Location = new Point(155, 9);
            downloadFilename4.Name = "downloadFilename4";
            downloadFilename4.Size = new Size(560, 15);
            downloadFilename4.TabIndex = 5;
            downloadFilename4.Text = "data1";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.Transparent;
            label29.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label29.Location = new Point(16, 53);
            label29.Name = "label29";
            label29.Size = new Size(134, 17);
            label29.TabIndex = 4;
            label29.Text = "Prędkość pobierania:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = Color.Transparent;
            label30.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label30.Location = new Point(16, 76);
            label30.Name = "label30";
            label30.Size = new Size(79, 17);
            label30.TabIndex = 3;
            label30.Text = "Ukończono:";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.BackColor = Color.Transparent;
            label31.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label31.Location = new Point(16, 30);
            label31.Name = "label31";
            label31.Size = new Size(61, 17);
            label31.TabIndex = 3;
            label31.Text = "Rozmiar:";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.BackColor = Color.Transparent;
            label32.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label32.Location = new Point(16, 9);
            label32.Name = "label32";
            label32.Size = new Size(98, 17);
            label32.TabIndex = 2;
            label32.Text = "Pobierany plik:";
            // 
            // downloadedItem3
            // 
            downloadedItem3.BackgroundImage = Properties.Resources.hover;
            downloadedItem3.BackgroundImageLayout = ImageLayout.Stretch;
            downloadedItem3.Controls.Add(downloadBar3);
            downloadedItem3.Controls.Add(removeDownloadItem3);
            downloadedItem3.Controls.Add(downloadComplete3);
            downloadedItem3.Controls.Add(stopDownloadItem3);
            downloadedItem3.Controls.Add(downloadSpeed3);
            downloadedItem3.Controls.Add(downloadSize3);
            downloadedItem3.Controls.Add(downloadFilename3);
            downloadedItem3.Controls.Add(label21);
            downloadedItem3.Controls.Add(label22);
            downloadedItem3.Controls.Add(label23);
            downloadedItem3.Controls.Add(label24);
            downloadedItem3.Location = new Point(19, 294);
            downloadedItem3.Name = "downloadedItem3";
            downloadedItem3.Size = new Size(859, 103);
            downloadedItem3.TabIndex = 10;
            downloadedItem3.Visible = false;
            // 
            // downloadBar3
            // 
            downloadBar3.Location = new Point(155, 82);
            downloadBar3.Name = "downloadBar3";
            downloadBar3.Size = new Size(635, 10);
            downloadBar3.TabIndex = 28;
            // 
            // removeDownloadItem3
            // 
            removeDownloadItem3.BackColor = Color.Transparent;
            removeDownloadItem3.Cursor = Cursors.Hand;
            removeDownloadItem3.Image = Properties.Resources.del;
            removeDownloadItem3.Location = new Point(803, 18);
            removeDownloadItem3.Name = "removeDownloadItem3";
            removeDownloadItem3.Size = new Size(32, 32);
            removeDownloadItem3.SizeMode = PictureBoxSizeMode.StretchImage;
            removeDownloadItem3.TabIndex = 29;
            removeDownloadItem3.TabStop = false;
            // 
            // downloadComplete3
            // 
            downloadComplete3.AutoSize = true;
            downloadComplete3.BackColor = Color.Transparent;
            downloadComplete3.Location = new Point(795, 77);
            downloadComplete3.Name = "downloadComplete3";
            downloadComplete3.Size = new Size(36, 15);
            downloadComplete3.TabIndex = 8;
            downloadComplete3.Text = "data4";
            // 
            // stopDownloadItem3
            // 
            stopDownloadItem3.BackColor = Color.Transparent;
            stopDownloadItem3.Cursor = Cursors.Hand;
            stopDownloadItem3.Image = (Image)resources.GetObject("stopDownloadItem3.Image");
            stopDownloadItem3.Location = new Point(765, 18);
            stopDownloadItem3.Name = "stopDownloadItem3";
            stopDownloadItem3.Size = new Size(32, 32);
            stopDownloadItem3.SizeMode = PictureBoxSizeMode.StretchImage;
            stopDownloadItem3.TabIndex = 28;
            stopDownloadItem3.TabStop = false;
            // 
            // downloadSpeed3
            // 
            downloadSpeed3.AutoSize = true;
            downloadSpeed3.BackColor = Color.Transparent;
            downloadSpeed3.Location = new Point(155, 54);
            downloadSpeed3.Name = "downloadSpeed3";
            downloadSpeed3.Size = new Size(36, 15);
            downloadSpeed3.TabIndex = 7;
            downloadSpeed3.Text = "data3";
            // 
            // downloadSize3
            // 
            downloadSize3.AutoSize = true;
            downloadSize3.BackColor = Color.Transparent;
            downloadSize3.Location = new Point(155, 31);
            downloadSize3.Name = "downloadSize3";
            downloadSize3.Size = new Size(36, 15);
            downloadSize3.TabIndex = 6;
            downloadSize3.Text = "data2";
            // 
            // downloadFilename3
            // 
            downloadFilename3.BackColor = Color.Transparent;
            downloadFilename3.Location = new Point(155, 9);
            downloadFilename3.Name = "downloadFilename3";
            downloadFilename3.Size = new Size(560, 15);
            downloadFilename3.TabIndex = 5;
            downloadFilename3.Text = "data1";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label21.Location = new Point(16, 53);
            label21.Name = "label21";
            label21.Size = new Size(134, 17);
            label21.TabIndex = 4;
            label21.Text = "Prędkość pobierania:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label22.Location = new Point(16, 76);
            label22.Name = "label22";
            label22.Size = new Size(79, 17);
            label22.TabIndex = 3;
            label22.Text = "Ukończono:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Transparent;
            label23.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label23.Location = new Point(16, 30);
            label23.Name = "label23";
            label23.Size = new Size(61, 17);
            label23.TabIndex = 3;
            label23.Text = "Rozmiar:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label24.Location = new Point(16, 9);
            label24.Name = "label24";
            label24.Size = new Size(98, 17);
            label24.TabIndex = 2;
            label24.Text = "Pobierany plik:";
            // 
            // downloadedItem2
            // 
            downloadedItem2.BackgroundImage = Properties.Resources.hover;
            downloadedItem2.BackgroundImageLayout = ImageLayout.Stretch;
            downloadedItem2.Controls.Add(downloadBar2);
            downloadedItem2.Controls.Add(removeDownloadItem2);
            downloadedItem2.Controls.Add(downloadComplete2);
            downloadedItem2.Controls.Add(stopDownloadItem2);
            downloadedItem2.Controls.Add(downloadSpeed2);
            downloadedItem2.Controls.Add(downloadSize2);
            downloadedItem2.Controls.Add(downloadFilename2);
            downloadedItem2.Controls.Add(label13);
            downloadedItem2.Controls.Add(label14);
            downloadedItem2.Controls.Add(label15);
            downloadedItem2.Controls.Add(label16);
            downloadedItem2.Location = new Point(19, 185);
            downloadedItem2.Name = "downloadedItem2";
            downloadedItem2.Size = new Size(859, 103);
            downloadedItem2.TabIndex = 9;
            downloadedItem2.Visible = false;
            // 
            // downloadBar2
            // 
            downloadBar2.Location = new Point(155, 82);
            downloadBar2.Name = "downloadBar2";
            downloadBar2.Size = new Size(635, 10);
            downloadBar2.TabIndex = 10;
            // 
            // removeDownloadItem2
            // 
            removeDownloadItem2.BackColor = Color.Transparent;
            removeDownloadItem2.Cursor = Cursors.Hand;
            removeDownloadItem2.Image = Properties.Resources.del;
            removeDownloadItem2.Location = new Point(803, 18);
            removeDownloadItem2.Name = "removeDownloadItem2";
            removeDownloadItem2.Size = new Size(32, 32);
            removeDownloadItem2.SizeMode = PictureBoxSizeMode.StretchImage;
            removeDownloadItem2.TabIndex = 27;
            removeDownloadItem2.TabStop = false;
            // 
            // downloadComplete2
            // 
            downloadComplete2.AutoSize = true;
            downloadComplete2.BackColor = Color.Transparent;
            downloadComplete2.Location = new Point(795, 77);
            downloadComplete2.Name = "downloadComplete2";
            downloadComplete2.Size = new Size(36, 15);
            downloadComplete2.TabIndex = 8;
            downloadComplete2.Text = "data4";
            // 
            // stopDownloadItem2
            // 
            stopDownloadItem2.BackColor = Color.Transparent;
            stopDownloadItem2.Cursor = Cursors.Hand;
            stopDownloadItem2.Image = (Image)resources.GetObject("stopDownloadItem2.Image");
            stopDownloadItem2.Location = new Point(765, 18);
            stopDownloadItem2.Name = "stopDownloadItem2";
            stopDownloadItem2.Size = new Size(32, 32);
            stopDownloadItem2.SizeMode = PictureBoxSizeMode.StretchImage;
            stopDownloadItem2.TabIndex = 26;
            stopDownloadItem2.TabStop = false;
            // 
            // downloadSpeed2
            // 
            downloadSpeed2.AutoSize = true;
            downloadSpeed2.BackColor = Color.Transparent;
            downloadSpeed2.Location = new Point(155, 54);
            downloadSpeed2.Name = "downloadSpeed2";
            downloadSpeed2.Size = new Size(36, 15);
            downloadSpeed2.TabIndex = 7;
            downloadSpeed2.Text = "data3";
            // 
            // downloadSize2
            // 
            downloadSize2.AutoSize = true;
            downloadSize2.BackColor = Color.Transparent;
            downloadSize2.Location = new Point(155, 31);
            downloadSize2.Name = "downloadSize2";
            downloadSize2.Size = new Size(36, 15);
            downloadSize2.TabIndex = 6;
            downloadSize2.Text = "data2";
            // 
            // downloadFilename2
            // 
            downloadFilename2.BackColor = Color.Transparent;
            downloadFilename2.Location = new Point(155, 9);
            downloadFilename2.Name = "downloadFilename2";
            downloadFilename2.Size = new Size(560, 15);
            downloadFilename2.TabIndex = 5;
            downloadFilename2.Text = "data1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label13.Location = new Point(16, 53);
            label13.Name = "label13";
            label13.Size = new Size(134, 17);
            label13.TabIndex = 4;
            label13.Text = "Prędkość pobierania:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label14.Location = new Point(16, 76);
            label14.Name = "label14";
            label14.Size = new Size(79, 17);
            label14.TabIndex = 3;
            label14.Text = "Ukończono:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label15.Location = new Point(16, 30);
            label15.Name = "label15";
            label15.Size = new Size(61, 17);
            label15.TabIndex = 3;
            label15.Text = "Rozmiar:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label16.Location = new Point(16, 9);
            label16.Name = "label16";
            label16.Size = new Size(98, 17);
            label16.TabIndex = 2;
            label16.Text = "Pobierany plik:";
            // 
            // downloadedItem1
            // 
            downloadedItem1.BackgroundImage = Properties.Resources.hover;
            downloadedItem1.BackgroundImageLayout = ImageLayout.Stretch;
            downloadedItem1.Controls.Add(downloadBar1);
            downloadedItem1.Controls.Add(downloadComplete1);
            downloadedItem1.Controls.Add(downloadSpeed1);
            downloadedItem1.Controls.Add(downloadSize1);
            downloadedItem1.Controls.Add(removeDownloadItem1);
            downloadedItem1.Controls.Add(downloadFilename1);
            downloadedItem1.Controls.Add(label8);
            downloadedItem1.Controls.Add(stopDownloadItem1);
            downloadedItem1.Controls.Add(label7);
            downloadedItem1.Controls.Add(label6);
            downloadedItem1.Controls.Add(label5);
            downloadedItem1.Location = new Point(19, 76);
            downloadedItem1.Name = "downloadedItem1";
            downloadedItem1.Size = new Size(859, 103);
            downloadedItem1.TabIndex = 1;
            downloadedItem1.Visible = false;
            // 
            // downloadBar1
            // 
            downloadBar1.Location = new Point(154, 83);
            downloadBar1.Name = "downloadBar1";
            downloadBar1.Size = new Size(635, 10);
            downloadBar1.TabIndex = 9;
            // 
            // downloadComplete1
            // 
            downloadComplete1.AutoSize = true;
            downloadComplete1.BackColor = Color.Transparent;
            downloadComplete1.Location = new Point(795, 78);
            downloadComplete1.Name = "downloadComplete1";
            downloadComplete1.Size = new Size(36, 15);
            downloadComplete1.TabIndex = 8;
            downloadComplete1.Text = "data4";
            // 
            // downloadSpeed1
            // 
            downloadSpeed1.AutoSize = true;
            downloadSpeed1.BackColor = Color.Transparent;
            downloadSpeed1.Location = new Point(155, 54);
            downloadSpeed1.Name = "downloadSpeed1";
            downloadSpeed1.Size = new Size(36, 15);
            downloadSpeed1.TabIndex = 7;
            downloadSpeed1.Text = "data3";
            // 
            // downloadSize1
            // 
            downloadSize1.AutoSize = true;
            downloadSize1.BackColor = Color.Transparent;
            downloadSize1.Location = new Point(155, 31);
            downloadSize1.Name = "downloadSize1";
            downloadSize1.Size = new Size(36, 15);
            downloadSize1.TabIndex = 6;
            downloadSize1.Text = "data2";
            // 
            // removeDownloadItem1
            // 
            removeDownloadItem1.BackColor = Color.Transparent;
            removeDownloadItem1.Cursor = Cursors.Hand;
            removeDownloadItem1.Image = Properties.Resources.del;
            removeDownloadItem1.Location = new Point(803, 14);
            removeDownloadItem1.Name = "removeDownloadItem1";
            removeDownloadItem1.Size = new Size(32, 32);
            removeDownloadItem1.SizeMode = PictureBoxSizeMode.StretchImage;
            removeDownloadItem1.TabIndex = 3;
            removeDownloadItem1.TabStop = false;
            // 
            // downloadFilename1
            // 
            downloadFilename1.BackColor = Color.Transparent;
            downloadFilename1.Location = new Point(155, 9);
            downloadFilename1.Name = "downloadFilename1";
            downloadFilename1.Size = new Size(560, 15);
            downloadFilename1.TabIndex = 5;
            downloadFilename1.Text = "data1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label8.Location = new Point(16, 53);
            label8.Name = "label8";
            label8.Size = new Size(134, 17);
            label8.TabIndex = 4;
            label8.Text = "Prędkość pobierania:";
            // 
            // stopDownloadItem1
            // 
            stopDownloadItem1.BackColor = Color.Transparent;
            stopDownloadItem1.Cursor = Cursors.Hand;
            stopDownloadItem1.Image = (Image)resources.GetObject("stopDownloadItem1.Image");
            stopDownloadItem1.Location = new Point(765, 14);
            stopDownloadItem1.Name = "stopDownloadItem1";
            stopDownloadItem1.Size = new Size(32, 32);
            stopDownloadItem1.SizeMode = PictureBoxSizeMode.StretchImage;
            stopDownloadItem1.TabIndex = 1;
            stopDownloadItem1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.Location = new Point(16, 77);
            label7.Name = "label7";
            label7.Size = new Size(79, 17);
            label7.TabIndex = 3;
            label7.Text = "Ukończono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(16, 30);
            label6.Name = "label6";
            label6.Size = new Size(61, 17);
            label6.TabIndex = 3;
            label6.Text = "Rozmiar:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.Location = new Point(16, 9);
            label5.Name = "label5";
            label5.Size = new Size(98, 17);
            label5.TabIndex = 2;
            label5.Text = "Pobierany plik:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(16, 14);
            label4.Name = "label4";
            label4.Size = new Size(211, 30);
            label4.TabIndex = 0;
            label4.Text = "Aktywne pobierania";
            // 
            // FilesDownloaded
            // 
            FilesDownloaded.Controls.Add(infoHTML2);
            FilesDownloaded.Controls.Add(btngoBackDownload);
            FilesDownloaded.Controls.Add(fileD10);
            FilesDownloaded.Controls.Add(openFolder);
            FilesDownloaded.Controls.Add(fileD9);
            FilesDownloaded.Controls.Add(fileD8);
            FilesDownloaded.Controls.Add(fileD7);
            FilesDownloaded.Controls.Add(fileD6);
            FilesDownloaded.Controls.Add(fileD5);
            FilesDownloaded.Controls.Add(fileD4);
            FilesDownloaded.Controls.Add(fileD3);
            FilesDownloaded.Controls.Add(fileD2);
            FilesDownloaded.Controls.Add(fileD1);
            FilesDownloaded.Controls.Add(label9);
            FilesDownloaded.Location = new Point(138, 43);
            FilesDownloaded.Name = "FilesDownloaded";
            FilesDownloaded.Size = new Size(10, 10);
            FilesDownloaded.TabIndex = 26;
            FilesDownloaded.Visible = false;
            // 
            // infoHTML2
            // 
            infoHTML2.AllowExternalDrop = true;
            infoHTML2.CreationProperties = null;
            infoHTML2.DefaultBackgroundColor = Color.Transparent;
            infoHTML2.Enabled = false;
            infoHTML2.Location = new Point(10, 20);
            infoHTML2.Name = "infoHTML2";
            infoHTML2.Size = new Size(863, 528);
            infoHTML2.TabIndex = 22;
            infoHTML2.Visible = false;
            infoHTML2.ZoomFactor = 1D;
            // 
            // btngoBackDownload
            // 
            btngoBackDownload.FlatStyle = FlatStyle.Flat;
            btngoBackDownload.Location = new Point(278, 583);
            btngoBackDownload.Name = "btngoBackDownload";
            btngoBackDownload.Size = new Size(252, 28);
            btngoBackDownload.TabIndex = 16;
            btngoBackDownload.Text = "Powrót do menu pobierania";
            btngoBackDownload.UseVisualStyleBackColor = true;
            btngoBackDownload.Click += btngoBackDownload_Click;
            // 
            // fileD10
            // 
            fileD10.BackgroundImage = Properties.Resources.hover;
            fileD10.BackgroundImageLayout = ImageLayout.Stretch;
            fileD10.BorderStyle = BorderStyle.FixedSingle;
            fileD10.Controls.Add(FileTime10);
            fileD10.Controls.Add(FileTag10);
            fileD10.Location = new Point(18, 495);
            fileD10.Name = "fileD10";
            fileD10.Size = new Size(845, 43);
            fileD10.TabIndex = 15;
            fileD10.Visible = false;
            // 
            // FileTime10
            // 
            FileTime10.BackColor = Color.Transparent;
            FileTime10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime10.Location = new Point(567, 12);
            FileTime10.Name = "FileTime10";
            FileTime10.Size = new Size(233, 17);
            FileTime10.TabIndex = 5;
            FileTime10.Text = "Pobrano:";
            // 
            // FileTag10
            // 
            FileTag10.BackColor = Color.Transparent;
            FileTag10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag10.Location = new Point(20, 12);
            FileTag10.Name = "FileTag10";
            FileTag10.Size = new Size(541, 17);
            FileTag10.TabIndex = 1;
            FileTag10.Text = "Plik: XXX";
            // 
            // openFolder
            // 
            openFolder.FlatStyle = FlatStyle.Flat;
            openFolder.Location = new Point(20, 583);
            openFolder.Name = "openFolder";
            openFolder.Size = new Size(252, 28);
            openFolder.TabIndex = 14;
            openFolder.Text = "Otwórz folder zawierający";
            openFolder.UseVisualStyleBackColor = true;
            openFolder.Click += openFolder_Click;
            // 
            // fileD9
            // 
            fileD9.BackgroundImage = Properties.Resources.hover;
            fileD9.BackgroundImageLayout = ImageLayout.Stretch;
            fileD9.BorderStyle = BorderStyle.FixedSingle;
            fileD9.Controls.Add(FileTime9);
            fileD9.Controls.Add(FileTag9);
            fileD9.Location = new Point(18, 447);
            fileD9.Name = "fileD9";
            fileD9.Size = new Size(845, 43);
            fileD9.TabIndex = 13;
            fileD9.Visible = false;
            // 
            // FileTime9
            // 
            FileTime9.BackColor = Color.Transparent;
            FileTime9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime9.Location = new Point(567, 12);
            FileTime9.Name = "FileTime9";
            FileTime9.Size = new Size(233, 17);
            FileTime9.TabIndex = 5;
            FileTime9.Text = "Pobrano:";
            // 
            // FileTag9
            // 
            FileTag9.BackColor = Color.Transparent;
            FileTag9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag9.Location = new Point(20, 12);
            FileTag9.Name = "FileTag9";
            FileTag9.Size = new Size(541, 17);
            FileTag9.TabIndex = 1;
            FileTag9.Text = "Plik: XXX";
            // 
            // fileD8
            // 
            fileD8.BackgroundImage = Properties.Resources.hover;
            fileD8.BackgroundImageLayout = ImageLayout.Stretch;
            fileD8.BorderStyle = BorderStyle.FixedSingle;
            fileD8.Controls.Add(FileTime8);
            fileD8.Controls.Add(FileTag8);
            fileD8.Location = new Point(18, 399);
            fileD8.Name = "fileD8";
            fileD8.Size = new Size(845, 43);
            fileD8.TabIndex = 12;
            fileD8.Visible = false;
            // 
            // FileTime8
            // 
            FileTime8.BackColor = Color.Transparent;
            FileTime8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime8.Location = new Point(567, 12);
            FileTime8.Name = "FileTime8";
            FileTime8.Size = new Size(233, 17);
            FileTime8.TabIndex = 5;
            FileTime8.Text = "Pobrano:";
            // 
            // FileTag8
            // 
            FileTag8.BackColor = Color.Transparent;
            FileTag8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag8.Location = new Point(20, 12);
            FileTag8.Name = "FileTag8";
            FileTag8.Size = new Size(541, 17);
            FileTag8.TabIndex = 1;
            FileTag8.Text = "Plik: XXX";
            // 
            // fileD7
            // 
            fileD7.BackgroundImage = Properties.Resources.hover;
            fileD7.BackgroundImageLayout = ImageLayout.Stretch;
            fileD7.BorderStyle = BorderStyle.FixedSingle;
            fileD7.Controls.Add(FileTime7);
            fileD7.Controls.Add(FileTag7);
            fileD7.Location = new Point(18, 350);
            fileD7.Name = "fileD7";
            fileD7.Size = new Size(845, 43);
            fileD7.TabIndex = 11;
            fileD7.Visible = false;
            // 
            // FileTime7
            // 
            FileTime7.BackColor = Color.Transparent;
            FileTime7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime7.Location = new Point(567, 12);
            FileTime7.Name = "FileTime7";
            FileTime7.Size = new Size(233, 17);
            FileTime7.TabIndex = 5;
            FileTime7.Text = "Pobrano:";
            // 
            // FileTag7
            // 
            FileTag7.BackColor = Color.Transparent;
            FileTag7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag7.Location = new Point(20, 12);
            FileTag7.Name = "FileTag7";
            FileTag7.Size = new Size(541, 17);
            FileTag7.TabIndex = 1;
            FileTag7.Text = "Plik: XXX";
            // 
            // fileD6
            // 
            fileD6.BackgroundImage = Properties.Resources.hover;
            fileD6.BackgroundImageLayout = ImageLayout.Stretch;
            fileD6.BorderStyle = BorderStyle.FixedSingle;
            fileD6.Controls.Add(FileTime6);
            fileD6.Controls.Add(FileTag6);
            fileD6.Location = new Point(18, 301);
            fileD6.Name = "fileD6";
            fileD6.Size = new Size(845, 43);
            fileD6.TabIndex = 10;
            fileD6.Visible = false;
            // 
            // FileTime6
            // 
            FileTime6.BackColor = Color.Transparent;
            FileTime6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime6.Location = new Point(567, 12);
            FileTime6.Name = "FileTime6";
            FileTime6.Size = new Size(233, 17);
            FileTime6.TabIndex = 5;
            FileTime6.Text = "Pobrano:";
            // 
            // FileTag6
            // 
            FileTag6.BackColor = Color.Transparent;
            FileTag6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag6.Location = new Point(20, 12);
            FileTag6.Name = "FileTag6";
            FileTag6.Size = new Size(541, 17);
            FileTag6.TabIndex = 1;
            FileTag6.Text = "Plik: XXX";
            // 
            // fileD5
            // 
            fileD5.BackgroundImage = Properties.Resources.hover;
            fileD5.BackgroundImageLayout = ImageLayout.Stretch;
            fileD5.BorderStyle = BorderStyle.FixedSingle;
            fileD5.Controls.Add(FileTime5);
            fileD5.Controls.Add(FileTag5);
            fileD5.Location = new Point(18, 252);
            fileD5.Name = "fileD5";
            fileD5.Size = new Size(845, 43);
            fileD5.TabIndex = 9;
            fileD5.Visible = false;
            // 
            // FileTime5
            // 
            FileTime5.BackColor = Color.Transparent;
            FileTime5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime5.Location = new Point(567, 12);
            FileTime5.Name = "FileTime5";
            FileTime5.Size = new Size(233, 17);
            FileTime5.TabIndex = 5;
            FileTime5.Text = "Pobrano:";
            // 
            // FileTag5
            // 
            FileTag5.BackColor = Color.Transparent;
            FileTag5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag5.Location = new Point(20, 12);
            FileTag5.Name = "FileTag5";
            FileTag5.Size = new Size(541, 17);
            FileTag5.TabIndex = 1;
            FileTag5.Text = "Plik: XXX";
            // 
            // fileD4
            // 
            fileD4.BackgroundImage = Properties.Resources.hover;
            fileD4.BackgroundImageLayout = ImageLayout.Stretch;
            fileD4.BorderStyle = BorderStyle.FixedSingle;
            fileD4.Controls.Add(FileTime4);
            fileD4.Controls.Add(FileTag4);
            fileD4.Location = new Point(18, 204);
            fileD4.Name = "fileD4";
            fileD4.Size = new Size(845, 43);
            fileD4.TabIndex = 8;
            fileD4.Visible = false;
            // 
            // FileTime4
            // 
            FileTime4.BackColor = Color.Transparent;
            FileTime4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime4.Location = new Point(567, 12);
            FileTime4.Name = "FileTime4";
            FileTime4.Size = new Size(233, 17);
            FileTime4.TabIndex = 5;
            FileTime4.Text = "Pobrano:";
            // 
            // FileTag4
            // 
            FileTag4.BackColor = Color.Transparent;
            FileTag4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag4.Location = new Point(20, 12);
            FileTag4.Name = "FileTag4";
            FileTag4.Size = new Size(541, 17);
            FileTag4.TabIndex = 1;
            FileTag4.Text = "Plik: XXX";
            // 
            // fileD3
            // 
            fileD3.BackgroundImage = Properties.Resources.hover;
            fileD3.BackgroundImageLayout = ImageLayout.Stretch;
            fileD3.BorderStyle = BorderStyle.FixedSingle;
            fileD3.Controls.Add(FileTime3);
            fileD3.Controls.Add(FileTag3);
            fileD3.Location = new Point(18, 155);
            fileD3.Name = "fileD3";
            fileD3.Size = new Size(845, 43);
            fileD3.TabIndex = 7;
            fileD3.Visible = false;
            // 
            // FileTime3
            // 
            FileTime3.BackColor = Color.Transparent;
            FileTime3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime3.Location = new Point(567, 12);
            FileTime3.Name = "FileTime3";
            FileTime3.Size = new Size(233, 17);
            FileTime3.TabIndex = 5;
            FileTime3.Text = "Pobrano:";
            // 
            // FileTag3
            // 
            FileTag3.BackColor = Color.Transparent;
            FileTag3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag3.Location = new Point(20, 12);
            FileTag3.Name = "FileTag3";
            FileTag3.Size = new Size(541, 17);
            FileTag3.TabIndex = 1;
            FileTag3.Text = "Plik: XXX";
            // 
            // fileD2
            // 
            fileD2.BackgroundImage = Properties.Resources.hover;
            fileD2.BackgroundImageLayout = ImageLayout.Stretch;
            fileD2.BorderStyle = BorderStyle.FixedSingle;
            fileD2.Controls.Add(FileTime2);
            fileD2.Controls.Add(FileTag2);
            fileD2.Location = new Point(18, 106);
            fileD2.Name = "fileD2";
            fileD2.Size = new Size(845, 43);
            fileD2.TabIndex = 6;
            fileD2.Visible = false;
            // 
            // FileTime2
            // 
            FileTime2.BackColor = Color.Transparent;
            FileTime2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime2.Location = new Point(567, 12);
            FileTime2.Name = "FileTime2";
            FileTime2.Size = new Size(233, 17);
            FileTime2.TabIndex = 5;
            FileTime2.Text = "Pobrano:";
            // 
            // FileTag2
            // 
            FileTag2.BackColor = Color.Transparent;
            FileTag2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag2.Location = new Point(20, 12);
            FileTag2.Name = "FileTag2";
            FileTag2.Size = new Size(541, 17);
            FileTag2.TabIndex = 1;
            FileTag2.Text = "Plik: XXX";
            // 
            // fileD1
            // 
            fileD1.BackgroundImage = Properties.Resources.hover;
            fileD1.BackgroundImageLayout = ImageLayout.Stretch;
            fileD1.BorderStyle = BorderStyle.FixedSingle;
            fileD1.Controls.Add(FileTime1);
            fileD1.Controls.Add(FileTag1);
            fileD1.Location = new Point(18, 57);
            fileD1.Name = "fileD1";
            fileD1.Size = new Size(845, 43);
            fileD1.TabIndex = 0;
            fileD1.Visible = false;
            // 
            // FileTime1
            // 
            FileTime1.BackColor = Color.Transparent;
            FileTime1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTime1.Location = new Point(567, 12);
            FileTime1.Name = "FileTime1";
            FileTime1.Size = new Size(233, 17);
            FileTime1.TabIndex = 5;
            FileTime1.Text = "Pobrano:";
            // 
            // FileTag1
            // 
            FileTag1.BackColor = Color.Transparent;
            FileTag1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            FileTag1.Location = new Point(20, 12);
            FileTag1.Name = "FileTag1";
            FileTag1.Size = new Size(541, 17);
            FileTag1.TabIndex = 1;
            FileTag1.Text = "Plik: XXX";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label9.Location = new Point(14, 13);
            label9.Name = "label9";
            label9.Size = new Size(143, 30);
            label9.TabIndex = 5;
            label9.Text = "Pobrane pliki";
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(setHolderWindow);
            settingsPanel.Controls.Add(barMainSet);
            settingsPanel.Location = new Point(175, 43);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(10, 10);
            settingsPanel.TabIndex = 27;
            settingsPanel.Visible = false;
            // 
            // setHolderWindow
            // 
            setHolderWindow.AutoScroll = true;
            setHolderWindow.AutoScrollMargin = new Size(0, 50);
            setHolderWindow.Controls.Add(portableMake);
            setHolderWindow.Controls.Add(DefaultThemePlaceHolder);
            setHolderWindow.Controls.Add(label44);
            setHolderWindow.Controls.Add(set16);
            setHolderWindow.Controls.Add(label40);
            setHolderWindow.Controls.Add(set15);
            setHolderWindow.Controls.Add(fixApp);
            setHolderWindow.Controls.Add(label39);
            setHolderWindow.Controls.Add(label38);
            setHolderWindow.Controls.Add(label37);
            setHolderWindow.Controls.Add(set14label);
            setHolderWindow.Controls.Add(label36);
            setHolderWindow.Controls.Add(set8);
            setHolderWindow.Controls.Add(label35);
            setHolderWindow.Controls.Add(checkForUpdates);
            setHolderWindow.Controls.Add(verLabel);
            setHolderWindow.Controls.Add(setUITheme);
            setHolderWindow.Controls.Add(label34);
            setHolderWindow.Controls.Add(locationTextBox);
            setHolderWindow.Controls.Add(selectLocation);
            setHolderWindow.Controls.Add(label28);
            setHolderWindow.Controls.Add(label27);
            setHolderWindow.Controls.Add(label26);
            setHolderWindow.Controls.Add(label25);
            setHolderWindow.Controls.Add(setServerlabel);
            setHolderWindow.Controls.Add(setServer);
            setHolderWindow.Controls.Add(set14);
            setHolderWindow.Controls.Add(set13label);
            setHolderWindow.Controls.Add(set13);
            setHolderWindow.Controls.Add(set12label);
            setHolderWindow.Controls.Add(set12);
            setHolderWindow.Controls.Add(set7label);
            setHolderWindow.Controls.Add(set7);
            setHolderWindow.Controls.Add(set6label);
            setHolderWindow.Controls.Add(set6);
            setHolderWindow.Controls.Add(set5label);
            setHolderWindow.Controls.Add(set5);
            setHolderWindow.Controls.Add(set4label);
            setHolderWindow.Controls.Add(set4);
            setHolderWindow.Controls.Add(set3label);
            setHolderWindow.Controls.Add(set3);
            setHolderWindow.Controls.Add(set2label);
            setHolderWindow.Controls.Add(set2);
            setHolderWindow.Controls.Add(set1label);
            setHolderWindow.Controls.Add(set1);
            setHolderWindow.Controls.Add(label19);
            setHolderWindow.Controls.Add(setBarH1);
            setHolderWindow.Controls.Add(setBarH4);
            setHolderWindow.Controls.Add(setBarH2);
            setHolderWindow.Controls.Add(setBarH5);
            setHolderWindow.Controls.Add(setBarH3);
            setHolderWindow.Controls.Add(downloadSpeedControl);
            setHolderWindow.Location = new Point(13, 49);
            setHolderWindow.Name = "setHolderWindow";
            setHolderWindow.Size = new Size(873, 569);
            setHolderWindow.TabIndex = 17;
            // 
            // portableMake
            // 
            portableMake.BackColor = Color.SteelBlue;
            portableMake.BackgroundColor = Color.SteelBlue;
            portableMake.BorderColor = Color.LightSteelBlue;
            portableMake.BorderRadius = 5;
            portableMake.BorderSize = 0;
            portableMake.Cursor = Cursors.Hand;
            portableMake.FlatAppearance.BorderSize = 0;
            portableMake.FlatStyle = FlatStyle.Flat;
            portableMake.ForeColor = Color.White;
            portableMake.Location = new Point(584, 789);
            portableMake.Name = "portableMake";
            portableMake.Size = new Size(256, 32);
            portableMake.TabIndex = 63;
            portableMake.Text = "Utwórz wersję przenośną programu";
            portableMake.TextColor = Color.White;
            portableMake.UseVisualStyleBackColor = false;
            portableMake.Click += portableMake_Click;
            // 
            // DefaultThemePlaceHolder
            // 
            DefaultThemePlaceHolder.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DefaultThemePlaceHolder.ForeColor = Color.DarkGray;
            DefaultThemePlaceHolder.Location = new Point(270, 791);
            DefaultThemePlaceHolder.Name = "DefaultThemePlaceHolder";
            DefaultThemePlaceHolder.Size = new Size(157, 19);
            DefaultThemePlaceHolder.TabIndex = 22;
            DefaultThemePlaceHolder.Text = "Domyślny";
            // 
            // label44
            // 
            label44.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label44.Location = new Point(92, 870);
            label44.Name = "label44";
            label44.Size = new Size(731, 23);
            label44.TabIndex = 70;
            label44.Text = "Pokazuj ekran wczytywania aplikacji i zezwól na automatyczne aktualizacje aplikacji";
            // 
            // set16
            // 
            set16.AutoSize = true;
            set16.Cursor = Cursors.Hand;
            set16.Location = new Point(34, 870);
            set16.MinimumSize = new Size(45, 22);
            set16.Name = "set16";
            set16.OffBackColor = Color.Gray;
            set16.OffToggleColor = Color.Gainsboro;
            set16.OnBackColor = Color.SteelBlue;
            set16.OnToggleColor = Color.WhiteSmoke;
            set16.Size = new Size(45, 22);
            set16.TabIndex = 69;
            set16.UseVisualStyleBackColor = true;
            // 
            // label40
            // 
            label40.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label40.Location = new Point(92, 835);
            label40.Name = "label40";
            label40.Size = new Size(631, 23);
            label40.TabIndex = 68;
            label40.Text = "Uzyskaj dostęp do najnowszej wersji oprogramowania przed innymi użytkownikami";
            // 
            // set15
            // 
            set15.AutoSize = true;
            set15.Cursor = Cursors.Hand;
            set15.Location = new Point(34, 834);
            set15.MinimumSize = new Size(45, 22);
            set15.Name = "set15";
            set15.OffBackColor = Color.Gray;
            set15.OffToggleColor = Color.Gainsboro;
            set15.OnBackColor = Color.SteelBlue;
            set15.OnToggleColor = Color.WhiteSmoke;
            set15.Size = new Size(45, 22);
            set15.TabIndex = 67;
            set15.UseVisualStyleBackColor = true;
            // 
            // fixApp
            // 
            fixApp.BackColor = Color.SteelBlue;
            fixApp.BackgroundColor = Color.SteelBlue;
            fixApp.BorderColor = Color.LightSteelBlue;
            fixApp.BorderRadius = 5;
            fixApp.BorderSize = 0;
            fixApp.Cursor = Cursors.Hand;
            fixApp.FlatAppearance.BorderSize = 0;
            fixApp.FlatStyle = FlatStyle.Flat;
            fixApp.ForeColor = Color.White;
            fixApp.Location = new Point(584, 751);
            fixApp.Name = "fixApp";
            fixApp.Size = new Size(256, 32);
            fixApp.TabIndex = 62;
            fixApp.Text = "Uruchom narzędzie naprawcze";
            fixApp.TextColor = Color.White;
            fixApp.UseVisualStyleBackColor = false;
            fixApp.Click += fixApp_Click;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label39.ForeColor = Color.LightSkyBlue;
            label39.Location = new Point(798, 1088);
            label39.Name = "label39";
            label39.Size = new Size(53, 15);
            label39.TabIndex = 19;
            label39.Text = "10 MB/s";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label38.ForeColor = Color.LightSteelBlue;
            label38.Location = new Point(682, 1088);
            label38.Name = "label38";
            label38.Size = new Size(46, 15);
            label38.TabIndex = 18;
            label38.Text = "1 MB/s";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label37.ForeColor = Color.SlateGray;
            label37.Location = new Point(520, 1088);
            label37.Name = "label37";
            label37.Size = new Size(50, 15);
            label37.TabIndex = 17;
            label37.Text = "16 KB/s";
            // 
            // set14label
            // 
            set14label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set14label.Location = new Point(87, 1105);
            set14label.Name = "set14label";
            set14label.Size = new Size(340, 23);
            set14label.TabIndex = 48;
            set14label.Text = "Użyj starszej metody pobierania (User-Agent)";
            // 
            // label36
            // 
            label36.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label36.Location = new Point(34, 754);
            label36.Name = "label36";
            label36.Size = new Size(425, 23);
            label36.TabIndex = 65;
            label36.Text = "Usuń pliki tymczasowe aplikacji oraz napraw dane Cache";
            // 
            // set8
            // 
            set8.AutoSize = true;
            set8.Cursor = Cursors.Hand;
            set8.Location = new Point(34, 905);
            set8.MinimumSize = new Size(45, 22);
            set8.Name = "set8";
            set8.OffBackColor = Color.Gray;
            set8.OffToggleColor = Color.Gainsboro;
            set8.OnBackColor = Color.SteelBlue;
            set8.OnToggleColor = Color.WhiteSmoke;
            set8.Size = new Size(45, 22);
            set8.TabIndex = 64;
            set8.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            label35.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label35.Location = new Point(92, 905);
            label35.Name = "label35";
            label35.Size = new Size(420, 23);
            label35.TabIndex = 62;
            label35.Text = "Zawsze pokazuj powiadomienia statusu pobierania";
            // 
            // checkForUpdates
            // 
            checkForUpdates.BackColor = Color.SteelBlue;
            checkForUpdates.BackgroundColor = Color.SteelBlue;
            checkForUpdates.BorderColor = Color.LightSteelBlue;
            checkForUpdates.BorderRadius = 5;
            checkForUpdates.BorderSize = 0;
            checkForUpdates.Cursor = Cursors.Hand;
            checkForUpdates.FlatAppearance.BorderSize = 0;
            checkForUpdates.FlatStyle = FlatStyle.Flat;
            checkForUpdates.ForeColor = Color.White;
            checkForUpdates.Location = new Point(584, 713);
            checkForUpdates.Name = "checkForUpdates";
            checkForUpdates.Size = new Size(257, 32);
            checkForUpdates.TabIndex = 60;
            checkForUpdates.Text = "Uruchom aktualizator programu";
            checkForUpdates.TextColor = Color.White;
            checkForUpdates.UseVisualStyleBackColor = false;
            checkForUpdates.Click += checkForUpdates_Click;
            // 
            // verLabel
            // 
            verLabel.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Italic, GraphicsUnit.Point, 238);
            verLabel.ForeColor = Color.Gray;
            verLabel.Location = new Point(34, 718);
            verLabel.Name = "verLabel";
            verLabel.Size = new Size(544, 23);
            verLabel.TabIndex = 59;
            verLabel.Text = "Aktualna wersja programu:";
            // 
            // setUITheme
            // 
            setUITheme.BackColor = Color.FromArgb(33, 42, 50);
            setUITheme.BorderColor = Color.LightSteelBlue;
            setUITheme.BorderSize = 1;
            setUITheme.Cursor = Cursors.Hand;
            setUITheme.DropDownStyle = ComboBoxStyle.DropDown;
            setUITheme.Font = new Font("Segoe UI", 10F);
            setUITheme.ForeColor = Color.White;
            setUITheme.IconColor = Color.GhostWhite;
            setUITheme.ListBackColor = Color.FromArgb(20, 25, 30);
            setUITheme.ListTextColor = Color.DimGray;
            setUITheme.Location = new Point(259, 785);
            setUITheme.MinimumSize = new Size(200, 30);
            setUITheme.Name = "setUITheme";
            setUITheme.Padding = new Padding(1);
            setUITheme.Size = new Size(200, 30);
            setUITheme.TabIndex = 58;
            setUITheme.Texts = "";
            // 
            // label34
            // 
            label34.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label34.Location = new Point(35, 791);
            label34.Name = "label34";
            label34.Size = new Size(220, 23);
            label34.TabIndex = 57;
            label34.Text = "Wygląd programu:";
            // 
            // locationTextBox
            // 
            locationTextBox.BackColor = Color.FromArgb(33, 42, 50);
            locationTextBox.BorderStyle = BorderStyle.None;
            locationTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            locationTextBox.ForeColor = Color.White;
            locationTextBox.Location = new Point(34, 124);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.Size = new Size(760, 25);
            locationTextBox.TabIndex = 56;
            locationTextBox.Text = "C:\\";
            // 
            // selectLocation
            // 
            selectLocation.BackColor = Color.LightSlateGray;
            selectLocation.BackgroundColor = Color.LightSlateGray;
            selectLocation.BorderColor = Color.SteelBlue;
            selectLocation.BorderRadius = 0;
            selectLocation.BorderSize = 0;
            selectLocation.Cursor = Cursors.Hand;
            selectLocation.FlatAppearance.BorderSize = 0;
            selectLocation.FlatStyle = FlatStyle.Flat;
            selectLocation.ForeColor = Color.White;
            selectLocation.Location = new Point(800, 119);
            selectLocation.Name = "selectLocation";
            selectLocation.Size = new Size(45, 34);
            selectLocation.TabIndex = 55;
            selectLocation.Text = ". . .";
            selectLocation.TextColor = Color.White;
            selectLocation.UseVisualStyleBackColor = false;
            selectLocation.Click += selectLocation_Click;
            // 
            // label28
            // 
            label28.ForeColor = Color.LightSkyBlue;
            label28.Location = new Point(34, 1000);
            label28.Name = "label28";
            label28.Size = new Size(790, 20);
            label28.TabIndex = 54;
            label28.Text = "Ostatnia sekcja ustawień, która zawiera pozostałe i archiwalne opcje dot. modułu pobierającego oraz interfejsu aplikacji.";
            // 
            // label27
            // 
            label27.ForeColor = Color.LightSkyBlue;
            label27.Location = new Point(38, 689);
            label27.Name = "label27";
            label27.Size = new Size(785, 20);
            label27.TabIndex = 53;
            label27.Text = "W tej sekcji ustawień możesz zarządzać głównymi aspektami tego programu.";
            // 
            // label26
            // 
            label26.ForeColor = Color.LightSkyBlue;
            label26.Location = new Point(29, 522);
            label26.Name = "label26";
            label26.Size = new Size(790, 20);
            label26.TabIndex = 52;
            label26.Text = "Tutaj możesz zdecydować o tym, czy program ma analizować pobierane pliki.";
            // 
            // label25
            // 
            label25.ForeColor = Color.LightSkyBlue;
            label25.Location = new Point(31, 237);
            label25.Name = "label25";
            label25.Size = new Size(790, 20);
            label25.TabIndex = 51;
            label25.Text = "Za pomocą poniższych opcji możesz zoptymalizować moduł pobierający pliki do własnych preferencji.";
            // 
            // setServerlabel
            // 
            setServerlabel.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            setServerlabel.Location = new Point(37, 1141);
            setServerlabel.Name = "setServerlabel";
            setServerlabel.Size = new Size(494, 23);
            setServerlabel.TabIndex = 50;
            setServerlabel.Text = "Wybierz serwer z którego chcesz pobierać pliki (Tylko baza główna)";
            // 
            // setServer
            // 
            setServer.BackColor = Color.FromArgb(33, 42, 50);
            setServer.BorderColor = Color.LightSteelBlue;
            setServer.BorderSize = 1;
            setServer.Cursor = Cursors.Hand;
            setServer.DropDownStyle = ComboBoxStyle.DropDown;
            setServer.Font = new Font("Segoe UI", 10F);
            setServer.ForeColor = Color.White;
            setServer.IconColor = Color.GhostWhite;
            setServer.Items.AddRange(new object[] { "#1- US - Serwer zapasowy (Archive.org)", "#2- PL - Serwer główny (WindowsBASE.pl)" });
            setServer.ListBackColor = Color.FromArgb(20, 25, 30);
            setServer.ListTextColor = Color.DimGray;
            setServer.Location = new Point(537, 1137);
            setServer.MinimumSize = new Size(200, 30);
            setServer.Name = "setServer";
            setServer.Padding = new Padding(1);
            setServer.Size = new Size(308, 30);
            setServer.TabIndex = 49;
            setServer.Texts = "";
            // 
            // set14
            // 
            set14.AutoSize = true;
            set14.Cursor = Cursors.Hand;
            set14.Location = new Point(34, 1104);
            set14.MinimumSize = new Size(45, 22);
            set14.Name = "set14";
            set14.OffBackColor = Color.Gray;
            set14.OffToggleColor = Color.Gainsboro;
            set14.OnBackColor = Color.SteelBlue;
            set14.OnToggleColor = Color.WhiteSmoke;
            set14.Size = new Size(45, 22);
            set14.TabIndex = 47;
            set14.UseVisualStyleBackColor = true;
            // 
            // set13label
            // 
            set13label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set13label.Location = new Point(87, 1069);
            set13label.Name = "set13label";
            set13label.Size = new Size(333, 23);
            set13label.TabIndex = 46;
            set13label.Text = "Ogranicz prędkość pobierania (w KB/s)";
            // 
            // set13
            // 
            set13.AutoSize = true;
            set13.Cursor = Cursors.Hand;
            set13.Location = new Point(34, 1068);
            set13.MinimumSize = new Size(45, 22);
            set13.Name = "set13";
            set13.OffBackColor = Color.Gray;
            set13.OffToggleColor = Color.Gainsboro;
            set13.OnBackColor = Color.SteelBlue;
            set13.OnToggleColor = Color.WhiteSmoke;
            set13.Size = new Size(45, 22);
            set13.TabIndex = 45;
            set13.UseVisualStyleBackColor = true;
            // 
            // set12label
            // 
            set12label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set12label.Location = new Point(87, 1034);
            set12label.Name = "set12label";
            set12label.Size = new Size(340, 23);
            set12label.TabIndex = 44;
            set12label.Text = "Włącz zapis logów informacyjnych";
            // 
            // set12
            // 
            set12.AutoSize = true;
            set12.Cursor = Cursors.Hand;
            set12.Location = new Point(34, 1033);
            set12.MinimumSize = new Size(45, 22);
            set12.Name = "set12";
            set12.OffBackColor = Color.Gray;
            set12.OffToggleColor = Color.Gainsboro;
            set12.OnBackColor = Color.SteelBlue;
            set12.OnToggleColor = Color.WhiteSmoke;
            set12.Size = new Size(45, 22);
            set12.TabIndex = 43;
            set12.UseVisualStyleBackColor = true;
            // 
            // set7label
            // 
            set7label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set7label.Location = new Point(87, 587);
            set7label.Name = "set7label";
            set7label.Size = new Size(512, 23);
            set7label.TabIndex = 32;
            set7label.Text = "Włącz weryfikację sumy kontrolnej pobranego pliku";
            // 
            // set7
            // 
            set7.AutoSize = true;
            set7.Cursor = Cursors.Hand;
            set7.Location = new Point(34, 586);
            set7.MinimumSize = new Size(45, 22);
            set7.Name = "set7";
            set7.OffBackColor = Color.Gray;
            set7.OffToggleColor = Color.Gainsboro;
            set7.OnBackColor = Color.SteelBlue;
            set7.OnToggleColor = Color.WhiteSmoke;
            set7.Size = new Size(45, 22);
            set7.TabIndex = 31;
            set7.UseVisualStyleBackColor = true;
            // 
            // set6label
            // 
            set6label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set6label.Location = new Point(87, 551);
            set6label.Name = "set6label";
            set6label.Size = new Size(512, 23);
            set6label.TabIndex = 30;
            set6label.Text = "Włącz wznawianie pobierania od miejsca ostatniego zatrzymania";
            // 
            // set6
            // 
            set6.AutoSize = true;
            set6.Cursor = Cursors.Hand;
            set6.Location = new Point(34, 550);
            set6.MinimumSize = new Size(45, 22);
            set6.Name = "set6";
            set6.OffBackColor = Color.Gray;
            set6.OffToggleColor = Color.Gainsboro;
            set6.OnBackColor = Color.SteelBlue;
            set6.OnToggleColor = Color.WhiteSmoke;
            set6.Size = new Size(45, 22);
            set6.TabIndex = 29;
            set6.UseVisualStyleBackColor = true;
            // 
            // set5label
            // 
            set5label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set5label.Location = new Point(87, 417);
            set5label.Name = "set5label";
            set5label.Size = new Size(463, 23);
            set5label.TabIndex = 28;
            set5label.Text = "Włącz funkcję pomijania sprawdzenia certyfikatów serwera";
            // 
            // set5
            // 
            set5.AutoSize = true;
            set5.Cursor = Cursors.Hand;
            set5.Location = new Point(34, 416);
            set5.MinimumSize = new Size(45, 22);
            set5.Name = "set5";
            set5.OffBackColor = Color.Gray;
            set5.OffToggleColor = Color.Gainsboro;
            set5.OnBackColor = Color.SteelBlue;
            set5.OnToggleColor = Color.WhiteSmoke;
            set5.Size = new Size(45, 22);
            set5.TabIndex = 27;
            set5.UseVisualStyleBackColor = true;
            // 
            // set4label
            // 
            set4label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set4label.Location = new Point(87, 381);
            set4label.Name = "set4label";
            set4label.Size = new Size(562, 23);
            set4label.TabIndex = 26;
            set4label.Text = "Włącz system automatycznego utrzymania stabilności łącza internetowego";
            // 
            // set4
            // 
            set4.AutoSize = true;
            set4.Cursor = Cursors.Hand;
            set4.Location = new Point(34, 380);
            set4.MinimumSize = new Size(45, 22);
            set4.Name = "set4";
            set4.OffBackColor = Color.Gray;
            set4.OffToggleColor = Color.Gainsboro;
            set4.OnBackColor = Color.SteelBlue;
            set4.OnToggleColor = Color.WhiteSmoke;
            set4.Size = new Size(45, 22);
            set4.TabIndex = 25;
            set4.UseVisualStyleBackColor = true;
            // 
            // set3label
            // 
            set3label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set3label.Location = new Point(87, 342);
            set3label.Name = "set3label";
            set3label.Size = new Size(463, 23);
            set3label.TabIndex = 24;
            set3label.Text = "Włącz przedwczesną rezerwację miejsca na dysku";
            // 
            // set3
            // 
            set3.AutoSize = true;
            set3.Cursor = Cursors.Hand;
            set3.Location = new Point(34, 341);
            set3.MinimumSize = new Size(45, 22);
            set3.Name = "set3";
            set3.OffBackColor = Color.Gray;
            set3.OffToggleColor = Color.Gainsboro;
            set3.OnBackColor = Color.SteelBlue;
            set3.OnToggleColor = Color.WhiteSmoke;
            set3.Size = new Size(45, 22);
            set3.TabIndex = 23;
            set3.UseVisualStyleBackColor = true;
            // 
            // set2label
            // 
            set2label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set2label.Location = new Point(85, 305);
            set2label.Name = "set2label";
            set2label.Size = new Size(498, 23);
            set2label.TabIndex = 22;
            set2label.Text = "Włącz dzielenie pobranych danych na mniejsze pakiety blokowe";
            // 
            // set2
            // 
            set2.AutoSize = true;
            set2.Cursor = Cursors.Hand;
            set2.Location = new Point(32, 305);
            set2.MinimumSize = new Size(45, 22);
            set2.Name = "set2";
            set2.OffBackColor = Color.Gray;
            set2.OffToggleColor = Color.Gainsboro;
            set2.OnBackColor = Color.SteelBlue;
            set2.OnToggleColor = Color.WhiteSmoke;
            set2.Size = new Size(45, 22);
            set2.TabIndex = 21;
            set2.UseVisualStyleBackColor = true;
            // 
            // set1label
            // 
            set1label.Font = new Font("Segoe UI Semibold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            set1label.Location = new Point(85, 268);
            set1label.Name = "set1label";
            set1label.Size = new Size(463, 23);
            set1label.TabIndex = 20;
            set1label.Text = "Włącz rezerwowanie pasma łącza internetowego";
            // 
            // set1
            // 
            set1.AutoSize = true;
            set1.Cursor = Cursors.Hand;
            set1.Location = new Point(32, 267);
            set1.MinimumSize = new Size(45, 22);
            set1.Name = "set1";
            set1.OffBackColor = Color.Gray;
            set1.OffToggleColor = Color.Gainsboro;
            set1.OnBackColor = Color.SteelBlue;
            set1.OnToggleColor = Color.WhiteSmoke;
            set1.Size = new Size(45, 22);
            set1.TabIndex = 19;
            set1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.ForeColor = Color.LightSkyBlue;
            label19.Location = new Point(31, 74);
            label19.Name = "label19";
            label19.Size = new Size(790, 32);
            label19.TabIndex = 18;
            label19.Text = "Wybierz folder, do którego mają zostać pobrane pliki. Możesz użyć zmiennych wpisująć ją recznie lub wybrać automatycznie za pomocą przycisku wyboru lokalizacji.";
            // 
            // setBarH1
            // 
            setBarH1.BackColor = Color.FromArgb(20, 25, 30);
            setBarH1.Controls.Add(pictureBox7);
            setBarH1.Controls.Add(label11);
            setBarH1.Location = new Point(9, 6);
            setBarH1.Name = "setBarH1";
            setBarH1.Size = new Size(838, 52);
            setBarH1.TabIndex = 12;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.folder;
            pictureBox7.Location = new Point(14, 9);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(32, 32);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 6;
            pictureBox7.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label11.Location = new Point(60, 11);
            label11.Name = "label11";
            label11.Size = new Size(167, 25);
            label11.TabIndex = 7;
            label11.Text = "Ścieżka docelowa";
            // 
            // setBarH4
            // 
            setBarH4.BackColor = Color.FromArgb(20, 25, 30);
            setBarH4.Controls.Add(label20);
            setBarH4.Controls.Add(pictureBox6);
            setBarH4.Location = new Point(9, 936);
            setBarH4.Name = "setBarH4";
            setBarH4.Size = new Size(836, 52);
            setBarH4.TabIndex = 16;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label20.Location = new Point(60, 12);
            label20.Name = "label20";
            label20.Size = new Size(97, 25);
            label20.TabIndex = 10;
            label20.Text = "Pozostałe";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.more;
            pictureBox6.Location = new Point(14, 12);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(32, 32);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            // 
            // setBarH2
            // 
            setBarH2.BackColor = Color.FromArgb(20, 25, 30);
            setBarH2.Controls.Add(pictureBox2);
            setBarH2.Controls.Add(label12);
            setBarH2.Location = new Point(9, 174);
            setBarH2.Name = "setBarH2";
            setBarH2.Size = new Size(836, 52);
            setBarH2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.speedometer;
            pictureBox2.Location = new Point(14, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label12.Location = new Point(60, 14);
            label12.Name = "label12";
            label12.Size = new Size(213, 25);
            label12.TabIndex = 8;
            label12.Text = "Akceleracja pobierania";
            // 
            // setBarH5
            // 
            setBarH5.BackColor = Color.FromArgb(20, 25, 30);
            setBarH5.Controls.Add(pictureBox5);
            setBarH5.Controls.Add(label18);
            setBarH5.Location = new Point(9, 627);
            setBarH5.Name = "setBarH5";
            setBarH5.Size = new Size(836, 52);
            setBarH5.TabIndex = 15;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.verified;
            pictureBox5.Location = new Point(14, 10);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(32, 32);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label18.Location = new Point(60, 12);
            label18.Name = "label18";
            label18.Size = new Size(92, 25);
            label18.TabIndex = 10;
            label18.Text = "Aplikacja";
            // 
            // setBarH3
            // 
            setBarH3.BackColor = Color.FromArgb(20, 25, 30);
            setBarH3.Controls.Add(pictureBox4);
            setBarH3.Controls.Add(label17);
            setBarH3.Location = new Point(9, 459);
            setBarH3.Name = "setBarH3";
            setBarH3.Size = new Size(836, 52);
            setBarH3.TabIndex = 14;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.recovery;
            pictureBox4.Location = new Point(14, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label17.Location = new Point(60, 13);
            label17.Name = "label17";
            label17.Size = new Size(286, 25);
            label17.TabIndex = 9;
            label17.Text = "Weryfikacja pobranych danych";
            // 
            // downloadSpeedControl
            // 
            downloadSpeedControl.Location = new Point(527, 1056);
            downloadSpeedControl.Minimum = 1;
            downloadSpeedControl.Name = "downloadSpeedControl";
            downloadSpeedControl.Size = new Size(318, 45);
            downloadSpeedControl.TabIndex = 66;
            downloadSpeedControl.Value = 1;
            // 
            // barMainSet
            // 
            barMainSet.BackColor = Color.Black;
            barMainSet.Controls.Add(pictureBox8);
            barMainSet.Controls.Add(label10);
            barMainSet.Location = new Point(0, 0);
            barMainSet.Name = "barMainSet";
            barMainSet.Size = new Size(894, 41);
            barMainSet.TabIndex = 0;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.settings;
            pictureBox8.Location = new Point(13, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(32, 32);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 7;
            pictureBox8.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label10.ForeColor = Color.Gainsboro;
            label10.Location = new Point(54, 7);
            label10.Name = "label10";
            label10.Size = new Size(198, 30);
            label10.TabIndex = 1;
            label10.Text = "Ustawienia aplikacji";
            // 
            // extensionsMarketplace
            // 
            extensionsMarketplace.Controls.Add(extensionsMarketplaceWebView);
            extensionsMarketplace.Controls.Add(extensionsInstalled);
            extensionsMarketplace.Controls.Add(uninstallLabel);
            extensionsMarketplace.Controls.Add(refreshExt);
            extensionsMarketplace.Controls.Add(manageExt);
            extensionsMarketplace.Controls.Add(closewebViewMar);
            extensionsMarketplace.Controls.Add(label33);
            extensionsMarketplace.Controls.Add(gotoMarketplace);
            extensionsMarketplace.Location = new Point(197, 43);
            extensionsMarketplace.Name = "extensionsMarketplace";
            extensionsMarketplace.Size = new Size(10, 10);
            extensionsMarketplace.TabIndex = 28;
            extensionsMarketplace.Visible = false;
            // 
            // extensionsMarketplaceWebView
            // 
            extensionsMarketplaceWebView.AllowExternalDrop = true;
            extensionsMarketplaceWebView.CreationProperties = null;
            extensionsMarketplaceWebView.DefaultBackgroundColor = Color.White;
            extensionsMarketplaceWebView.Location = new Point(3, 55);
            extensionsMarketplaceWebView.Name = "extensionsMarketplaceWebView";
            extensionsMarketplaceWebView.Size = new Size(889, 571);
            extensionsMarketplaceWebView.TabIndex = 3;
            extensionsMarketplaceWebView.Visible = false;
            extensionsMarketplaceWebView.ZoomFactor = 1D;
            // 
            // extensionsInstalled
            // 
            extensionsInstalled.AutoScroll = true;
            extensionsInstalled.AutoScrollMinSize = new Size(0, 50);
            extensionsInstalled.Controls.Add(extInfoNone);
            extensionsInstalled.Location = new Point(6, 59);
            extensionsInstalled.Name = "extensionsInstalled";
            extensionsInstalled.Size = new Size(881, 563);
            extensionsInstalled.TabIndex = 21;
            // 
            // extInfoNone
            // 
            extInfoNone.Controls.Add(extNoInfo3);
            extInfoNone.Controls.Add(extNoInfo1);
            extInfoNone.Controls.Add(extNoInfo2);
            extInfoNone.Location = new Point(3, 3);
            extInfoNone.Name = "extInfoNone";
            extInfoNone.Size = new Size(845, 536);
            extInfoNone.TabIndex = 6;
            // 
            // extNoInfo3
            // 
            extNoInfo3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            extNoInfo3.Location = new Point(145, 310);
            extNoInfo3.Name = "extNoInfo3";
            extNoInfo3.Size = new Size(545, 112);
            extNoInfo3.TabIndex = 5;
            extNoInfo3.Text = resources.GetString("extNoInfo3.Text");
            extNoInfo3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // extNoInfo1
            // 
            extNoInfo1.Image = Properties.Resources.extensions;
            extNoInfo1.Location = new Point(315, 53);
            extNoInfo1.Name = "extNoInfo1";
            extNoInfo1.Size = new Size(200, 200);
            extNoInfo1.SizeMode = PictureBoxSizeMode.Zoom;
            extNoInfo1.TabIndex = 3;
            extNoInfo1.TabStop = false;
            // 
            // extNoInfo2
            // 
            extNoInfo2.AutoSize = true;
            extNoInfo2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            extNoInfo2.Location = new Point(237, 270);
            extNoInfo2.Name = "extNoInfo2";
            extNoInfo2.Size = new Size(366, 25);
            extNoInfo2.TabIndex = 4;
            extNoInfo2.Text = "Nie posiadasz zainstalowanych dodatków";
            // 
            // uninstallLabel
            // 
            uninstallLabel.AutoSize = true;
            uninstallLabel.ForeColor = Color.DeepSkyBlue;
            uninstallLabel.Location = new Point(356, 47);
            uninstallLabel.Name = "uninstallLabel";
            uninstallLabel.Size = new Size(231, 15);
            uninstallLabel.TabIndex = 25;
            uninstallLabel.Text = "Kliknij w wybrany dodatek, aby go usunąć!";
            uninstallLabel.Visible = false;
            // 
            // refreshExt
            // 
            refreshExt.FlatStyle = FlatStyle.Flat;
            refreshExt.Location = new Point(356, 13);
            refreshExt.Name = "refreshExt";
            refreshExt.Size = new Size(160, 28);
            refreshExt.TabIndex = 24;
            refreshExt.Text = "Odśwież dodatki";
            refreshExt.UseVisualStyleBackColor = true;
            refreshExt.Visible = false;
            refreshExt.Click += refreshExt_Click;
            // 
            // manageExt
            // 
            manageExt.FlatStyle = FlatStyle.Flat;
            manageExt.Location = new Point(522, 13);
            manageExt.Name = "manageExt";
            manageExt.Size = new Size(160, 28);
            manageExt.TabIndex = 23;
            manageExt.Text = "Usuń dodatki";
            manageExt.UseVisualStyleBackColor = true;
            manageExt.Visible = false;
            manageExt.Click += manageExt_Click;
            // 
            // closewebViewMar
            // 
            closewebViewMar.BackColor = Color.FromArgb(30, 41, 61);
            closewebViewMar.BackgroundImage = Properties.Resources.x_icon;
            closewebViewMar.BackgroundImageLayout = ImageLayout.Zoom;
            closewebViewMar.Cursor = Cursors.Hand;
            closewebViewMar.Location = new Point(854, 12);
            closewebViewMar.Name = "closewebViewMar";
            closewebViewMar.Size = new Size(28, 28);
            closewebViewMar.TabIndex = 20;
            closewebViewMar.TabStop = false;
            closewebViewMar.Click += closewebViewMar_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label33.Location = new Point(14, 12);
            label33.Name = "label33";
            label33.Size = new Size(207, 30);
            label33.TabIndex = 0;
            label33.Text = "Centrum rozszerzeń";
            // 
            // gotoMarketplace
            // 
            gotoMarketplace.FlatStyle = FlatStyle.Flat;
            gotoMarketplace.Location = new Point(688, 13);
            gotoMarketplace.Name = "gotoMarketplace";
            gotoMarketplace.Size = new Size(160, 28);
            gotoMarketplace.TabIndex = 2;
            gotoMarketplace.Text = "Pobierz dodatki";
            gotoMarketplace.UseVisualStyleBackColor = true;
            gotoMarketplace.Click += gotoMarketplace_Click;
            // 
            // connectivityPanel
            // 
            connectivityPanel.Controls.Add(aboutAppRedirect);
            connectivityPanel.Controls.Add(action6);
            connectivityPanel.Controls.Add(action7);
            connectivityPanel.Controls.Add(action5);
            connectivityPanel.Controls.Add(action4);
            connectivityPanel.Controls.Add(action3);
            connectivityPanel.Controls.Add(action2);
            connectivityPanel.Controls.Add(action1);
            connectivityPanel.Controls.Add(label41);
            connectivityPanel.Location = new Point(218, 43);
            connectivityPanel.Name = "connectivityPanel";
            connectivityPanel.Size = new Size(10, 10);
            connectivityPanel.TabIndex = 29;
            connectivityPanel.Visible = false;
            // 
            // aboutAppRedirect
            // 
            aboutAppRedirect.FlatStyle = FlatStyle.Flat;
            aboutAppRedirect.Location = new Point(34, 558);
            aboutAppRedirect.Name = "aboutAppRedirect";
            aboutAppRedirect.Size = new Size(260, 32);
            aboutAppRedirect.TabIndex = 44;
            aboutAppRedirect.Text = "Informacje o aplikacji";
            aboutAppRedirect.UseVisualStyleBackColor = true;
            aboutAppRedirect.Click += aboutAppRedirect_Click;
            // 
            // action6
            // 
            action6.BackColor = Color.Transparent;
            action6.BackgroundImage = Properties.Resources.img51;
            action6.BackgroundImageLayout = ImageLayout.Stretch;
            action6.Cursor = Cursors.Hand;
            action6.Location = new Point(596, 247);
            action6.Name = "action6";
            action6.Size = new Size(260, 166);
            action6.TabIndex = 43;
            // 
            // action7
            // 
            action7.BackColor = Color.Transparent;
            action7.BackgroundImage = Properties.Resources.img71;
            action7.BackgroundImageLayout = ImageLayout.Stretch;
            action7.Cursor = Cursors.Hand;
            action7.Enabled = false;
            action7.Location = new Point(316, 438);
            action7.Name = "action7";
            action7.Size = new Size(540, 166);
            action7.TabIndex = 42;
            action7.Visible = false;
            // 
            // action5
            // 
            action5.BackColor = Color.Transparent;
            action5.BackgroundImage = Properties.Resources.img21;
            action5.BackgroundImageLayout = ImageLayout.Stretch;
            action5.Cursor = Cursors.Hand;
            action5.Enabled = false;
            action5.Location = new Point(596, 247);
            action5.Name = "action5";
            action5.Size = new Size(260, 166);
            action5.TabIndex = 40;
            action5.Visible = false;
            // 
            // action4
            // 
            action4.BackColor = Color.Transparent;
            action4.BackgroundImage = Properties.Resources.img02;
            action4.BackgroundImageLayout = ImageLayout.Stretch;
            action4.Cursor = Cursors.Hand;
            action4.Location = new Point(316, 247);
            action4.Name = "action4";
            action4.Size = new Size(260, 166);
            action4.TabIndex = 41;
            // 
            // action3
            // 
            action3.BackColor = Color.Transparent;
            action3.BackgroundImage = Properties.Resources.img11;
            action3.BackgroundImageLayout = ImageLayout.Stretch;
            action3.Cursor = Cursors.Hand;
            action3.Location = new Point(34, 247);
            action3.Name = "action3";
            action3.Size = new Size(260, 166);
            action3.TabIndex = 40;
            // 
            // action2
            // 
            action2.BackColor = Color.Transparent;
            action2.BackgroundImage = Properties.Resources.img81;
            action2.BackgroundImageLayout = ImageLayout.Stretch;
            action2.Cursor = Cursors.Hand;
            action2.Location = new Point(596, 57);
            action2.Name = "action2";
            action2.Size = new Size(260, 166);
            action2.TabIndex = 39;
            // 
            // action1
            // 
            action1.BackColor = Color.Transparent;
            action1.BackgroundImage = Properties.Resources.img61;
            action1.BackgroundImageLayout = ImageLayout.Stretch;
            action1.Cursor = Cursors.Hand;
            action1.Location = new Point(34, 58);
            action1.Name = "action1";
            action1.Size = new Size(540, 166);
            action1.TabIndex = 38;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label41.Location = new Point(11, 13);
            label41.Name = "label41";
            label41.Size = new Size(149, 30);
            label41.TabIndex = 30;
            label41.Text = "Centrum akcji";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label47.Location = new Point(45, 120);
            label47.Name = "label47";
            label47.Size = new Size(158, 30);
            label47.TabIndex = 48;
            label47.Text = "Kontakt z nami";
            // 
            // newsHTML
            // 
            newsHTML.AllowExternalDrop = true;
            newsHTML.CreationProperties = null;
            newsHTML.DefaultBackgroundColor = Color.White;
            newsHTML.Location = new Point(13, 90);
            newsHTML.Name = "newsHTML";
            newsHTML.Size = new Size(864, 526);
            newsHTML.Source = new Uri("https://windowsbase.pl/centrum_app", UriKind.Absolute);
            newsHTML.TabIndex = 30;
            newsHTML.Visible = false;
            newsHTML.ZoomFactor = 1D;
            // 
            // appchangesPanel
            // 
            appchangesPanel.AutoScroll = true;
            appchangesPanel.AutoScrollMargin = new Size(0, 50);
            appchangesPanel.Controls.Add(label42);
            appchangesPanel.Controls.Add(label43);
            appchangesPanel.Location = new Point(13, 82);
            appchangesPanel.Name = "appchangesPanel";
            appchangesPanel.Size = new Size(864, 544);
            appchangesPanel.TabIndex = 31;
            // 
            // label42
            // 
            label42.BackColor = Color.Transparent;
            label42.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label42.ForeColor = Color.White;
            label42.Location = new Point(37, 64);
            label42.Name = "label42";
            label42.Size = new Size(788, 1886);
            label42.TabIndex = 12;
            label42.Text = resources.GetString("label42.Text");
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.BackColor = Color.Tomato;
            label43.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label43.ForeColor = Color.White;
            label43.Location = new Point(19, 18);
            label43.Name = "label43";
            label43.Size = new Size(160, 21);
            label43.TabIndex = 11;
            label43.Text = "Nowość- Wersja 2.10";
            // 
            // dbUpdateNews
            // 
            dbUpdateNews.BackColor = Color.CornflowerBlue;
            dbUpdateNews.BackgroundColor = Color.CornflowerBlue;
            dbUpdateNews.BorderColor = Color.PaleVioletRed;
            dbUpdateNews.BorderRadius = 3;
            dbUpdateNews.BorderSize = 0;
            dbUpdateNews.FlatAppearance.BorderSize = 0;
            dbUpdateNews.FlatStyle = FlatStyle.Flat;
            dbUpdateNews.ForeColor = Color.White;
            dbUpdateNews.Location = new Point(478, 38);
            dbUpdateNews.Name = "dbUpdateNews";
            dbUpdateNews.Size = new Size(173, 34);
            dbUpdateNews.TabIndex = 34;
            dbUpdateNews.Text = "Aktualizacje bazy danych";
            dbUpdateNews.TextColor = Color.White;
            dbUpdateNews.UseVisualStyleBackColor = false;
            dbUpdateNews.Click += dbUpdateNews_Click;
            // 
            // appUpdateNews
            // 
            appUpdateNews.BackColor = Color.CornflowerBlue;
            appUpdateNews.BackgroundColor = Color.CornflowerBlue;
            appUpdateNews.BorderColor = Color.PaleVioletRed;
            appUpdateNews.BorderRadius = 3;
            appUpdateNews.BorderSize = 0;
            appUpdateNews.FlatAppearance.BorderSize = 0;
            appUpdateNews.FlatStyle = FlatStyle.Flat;
            appUpdateNews.ForeColor = Color.White;
            appUpdateNews.Location = new Point(307, 38);
            appUpdateNews.Name = "appUpdateNews";
            appUpdateNews.Size = new Size(165, 34);
            appUpdateNews.TabIndex = 33;
            appUpdateNews.Text = "Aktualizacje programu";
            appUpdateNews.TextColor = Color.White;
            appUpdateNews.UseVisualStyleBackColor = false;
            appUpdateNews.Click += appUpdateNews_Click;
            // 
            // newsPanel
            // 
            newsPanel.Controls.Add(label46);
            newsPanel.Controls.Add(appchangesPanel);
            newsPanel.Controls.Add(label45);
            newsPanel.Controls.Add(newsHTML);
            newsPanel.Controls.Add(dbUpdateNews);
            newsPanel.Controls.Add(appUpdateNews);
            newsPanel.Location = new Point(238, 43);
            newsPanel.Name = "newsPanel";
            newsPanel.Size = new Size(10, 10);
            newsPanel.TabIndex = 35;
            newsPanel.Visible = false;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label46.Location = new Point(13, 13);
            label46.Name = "label46";
            label46.Size = new Size(134, 30);
            label46.TabIndex = 36;
            label46.Text = "Co nowego?";
            // 
            // label45
            // 
            label45.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label45.Location = new Point(13, 48);
            label45.Name = "label45";
            label45.Size = new Size(286, 25);
            label45.TabIndex = 35;
            label45.Text = "Pokaż zmiany dla wybranego zakresu:";
            // 
            // searchfilesPanel
            // 
            searchfilesPanel.Controls.Add(search_WebView);
            searchfilesPanel.Location = new Point(254, 43);
            searchfilesPanel.Name = "searchfilesPanel";
            searchfilesPanel.Size = new Size(10, 10);
            searchfilesPanel.TabIndex = 36;
            searchfilesPanel.Visible = false;
            // 
            // search_WebView
            // 
            search_WebView.AllowExternalDrop = true;
            search_WebView.CreationProperties = null;
            search_WebView.DefaultBackgroundColor = Color.White;
            search_WebView.Location = new Point(13, 11);
            search_WebView.Name = "search_WebView";
            search_WebView.Size = new Size(864, 605);
            search_WebView.Source = new Uri("https://windowsbase.pl/search_app", UriKind.Absolute);
            search_WebView.TabIndex = 30;
            search_WebView.ZoomFactor = 1D;
            // 
            // contactPanel
            // 
            contactPanel.Controls.Add(contactFormWebView);
            contactPanel.Location = new Point(270, 43);
            contactPanel.Name = "contactPanel";
            contactPanel.Size = new Size(10, 10);
            contactPanel.TabIndex = 37;
            contactPanel.Visible = false;
            // 
            // contactFormWebView
            // 
            contactFormWebView.AllowExternalDrop = true;
            contactFormWebView.CreationProperties = null;
            contactFormWebView.DefaultBackgroundColor = Color.White;
            contactFormWebView.Location = new Point(8, 6);
            contactFormWebView.Name = "contactFormWebView";
            contactFormWebView.Size = new Size(875, 612);
            contactFormWebView.Source = new Uri("https://windowsbase.pl/contact_app", UriKind.Absolute);
            contactFormWebView.TabIndex = 0;
            contactFormWebView.ZoomFactor = 1D;
            // 
            // faqAppPanel
            // 
            faqAppPanel.Controls.Add(faqAppWebView);
            faqAppPanel.Location = new Point(286, 44);
            faqAppPanel.Name = "faqAppPanel";
            faqAppPanel.Size = new Size(10, 10);
            faqAppPanel.TabIndex = 38;
            faqAppPanel.Visible = false;
            // 
            // faqAppWebView
            // 
            faqAppWebView.AllowExternalDrop = true;
            faqAppWebView.CreationProperties = null;
            faqAppWebView.DefaultBackgroundColor = Color.White;
            faqAppWebView.Location = new Point(12, 8);
            faqAppWebView.Name = "faqAppWebView";
            faqAppWebView.Size = new Size(872, 611);
            faqAppWebView.Source = new Uri("https://windowsbase.pl/apphelp.html", UriKind.Absolute);
            faqAppWebView.TabIndex = 38;
            faqAppWebView.ZoomFactor = 1D;
            // 
            // mainPanelRedirectPanel
            // 
            mainPanelRedirectPanel.BackColor = Color.FromArgb(31, 38, 45);
            mainPanelRedirectPanel.Controls.Add(userDbFlowPage);
            mainPanelRedirectPanel.Controls.Add(ftpFlowPage);
            mainPanelRedirectPanel.Controls.Add(dbSiteFlowPage);
            mainPanelRedirectPanel.Location = new Point(302, 44);
            mainPanelRedirectPanel.Name = "mainPanelRedirectPanel";
            mainPanelRedirectPanel.Size = new Size(10, 10);
            mainPanelRedirectPanel.TabIndex = 39;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 50);
            ClientSize = new Size(1000, 670);
            ControlBox = false;
            Controls.Add(mainPanelRedirectPanel);
            Controls.Add(faqAppPanel);
            Controls.Add(contactPanel);
            Controls.Add(searchfilesPanel);
            Controls.Add(newsPanel);
            Controls.Add(connectivityPanel);
            Controls.Add(extensionsMarketplace);
            Controls.Add(settingsPanel);
            Controls.Add(FilesDownloaded);
            Controls.Add(downloadPanel);
            Controls.Add(browserPanel);
            Controls.Add(mainPanel);
            Controls.Add(panel_leftMenu);
            Controls.Add(panel_Header);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1000, 670);
            MinimumSize = new Size(1000, 670);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menedżer pobierania - WindowsBASE.pl";
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimalizeApp).EndInit();
            browserPanel.ResumeLayout(false);
            browserPanelNavigation.ResumeLayout(false);
            browserPanelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)browserRefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)favouritesIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)homePageRedirect).EndInit();
            ((System.ComponentModel.ISupportInitialize)browserGoNext).EndInit();
            ((System.ComponentModel.ISupportInitialize)browserGoBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)browserWindowWebView).EndInit();
            panel_leftMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)searchIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolsIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)homeIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingsIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)browserIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)newsIcon).EndInit();
            welcomeHeader.ResumeLayout(false);
            dbSiteFlowPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)goBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeDBViewer).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseViewer).EndInit();
            mainPanel.ResumeLayout(false);
            ftpFlowPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ftpgoBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)ftpClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)ftpViewer).EndInit();
            userDbFlowPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userDbgoBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)userDbClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)userDbViewer).EndInit();
            downloadPanel.ResumeLayout(false);
            downloadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)infoHTML1).EndInit();
            downloadControlPanel.ResumeLayout(false);
            downloadControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            downloadedItem4.ResumeLayout(false);
            downloadedItem4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem4).EndInit();
            downloadedItem3.ResumeLayout(false);
            downloadedItem3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem3).EndInit();
            downloadedItem2.ResumeLayout(false);
            downloadedItem2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem2).EndInit();
            downloadedItem1.ResumeLayout(false);
            downloadedItem1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)removeDownloadItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopDownloadItem1).EndInit();
            FilesDownloaded.ResumeLayout(false);
            FilesDownloaded.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)infoHTML2).EndInit();
            fileD10.ResumeLayout(false);
            fileD9.ResumeLayout(false);
            fileD8.ResumeLayout(false);
            fileD7.ResumeLayout(false);
            fileD6.ResumeLayout(false);
            fileD5.ResumeLayout(false);
            fileD4.ResumeLayout(false);
            fileD3.ResumeLayout(false);
            fileD2.ResumeLayout(false);
            fileD1.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            setHolderWindow.ResumeLayout(false);
            setHolderWindow.PerformLayout();
            setBarH1.ResumeLayout(false);
            setBarH1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            setBarH4.ResumeLayout(false);
            setBarH4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            setBarH2.ResumeLayout(false);
            setBarH2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            setBarH5.ResumeLayout(false);
            setBarH5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            setBarH3.ResumeLayout(false);
            setBarH3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)downloadSpeedControl).EndInit();
            barMainSet.ResumeLayout(false);
            barMainSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            extensionsMarketplace.ResumeLayout(false);
            extensionsMarketplace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)extensionsMarketplaceWebView).EndInit();
            extensionsInstalled.ResumeLayout(false);
            extInfoNone.ResumeLayout(false);
            extInfoNone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)extNoInfo1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closewebViewMar).EndInit();
            connectivityPanel.ResumeLayout(false);
            connectivityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)newsHTML).EndInit();
            appchangesPanel.ResumeLayout(false);
            appchangesPanel.PerformLayout();
            newsPanel.ResumeLayout(false);
            newsPanel.PerformLayout();
            searchfilesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)search_WebView).EndInit();
            contactPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)contactFormWebView).EndInit();
            faqAppPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)faqAppWebView).EndInit();
            mainPanelRedirectPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Header;
        private Panel panel_leftMenu;
        private Panel panel_ContentBox;
        private PictureBox searchIcon;
        private PictureBox toolsIcon;
        private PictureBox homeIcon;
        private PictureBox settingsIcon;
        private PictureBox browserIcon;
        private PictureBox newsIcon;
        private Panel welcomeHeader;
        private System.Windows.Forms.Label label2;
        private Button dbuserButton;
        private Button dbsiteButton;
        private Button dbftpButton;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private Panel dbSiteFlowPage;
        private System.Windows.Forms.Label infoSelect;
        private Microsoft.Web.WebView2.WinForms.WebView2 databaseViewer;
        private Panel mainPanel;
        private CustomControls.RJControls.RJComboBox selectCategory;
        private PictureBox closeDBViewer;
        private PictureBox goBack;
        private PictureBox minimalizeApp;
        private PictureBox closeApp;
        private Panel userDbFlowPage;
        private System.Windows.Forms.Label userDbHeader;
        private PictureBox userDbClose;
        private PictureBox userDbgoBack;
        private Panel ftpFlowPage;
        private PictureBox ftpgoBack;
        private PictureBox ftpClose;
        private System.Windows.Forms.Label label3;
        private Panel browserPanel;
        private Panel browserPanelNavigation;
        private PictureBox browserGoBack;
        private PictureBox homePageRedirect;
        private PictureBox browserGoNext;
        private PictureBox favouritesIcon;
        public Microsoft.Web.WebView2.WinForms.WebView2 browserWindowWebView;
        private PictureBox browserRefresh;
        private TextBox textBox1;
        public TextBox linkComboBox;
        private TextBox textBox2;
        public System.Windows.Forms.Label label1;
        private Panel downloadPanel;
        private System.Windows.Forms.Label label4;
        private Panel downloadedItem1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Panel downloadedItem2;
        private System.Windows.Forms.Label downloadComplete2;
        private System.Windows.Forms.Label downloadSpeed2;
        private System.Windows.Forms.Label downloadSize2;
        private System.Windows.Forms.Label downloadFilename2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label downloadComplete1;
        private System.Windows.Forms.Label downloadSpeed1;
        private System.Windows.Forms.Label downloadSize1;
        private System.Windows.Forms.Label downloadFilename1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label downloadMoreLabel;
        private Panel downloadedItem4;
        private System.Windows.Forms.Label downloadComplete4;
        private System.Windows.Forms.Label downloadSpeed4;
        private System.Windows.Forms.Label downloadSize4;
        private System.Windows.Forms.Label downloadFilename4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private Panel downloadedItem3;
        private System.Windows.Forms.Label downloadComplete3;
        private System.Windows.Forms.Label downloadSpeed3;
        private System.Windows.Forms.Label downloadSize3;
        private System.Windows.Forms.Label downloadFilename3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private Panel downloadControlPanel;
        private Button stopDownload;
        private PictureBox removeDownloadItem1;
        private PictureBox pictureBox3;
        private PictureBox stopDownloadItem1;
        private PictureBox pictureBox1;
        private Button resumeDownload;
        private PictureBox removeDownloadItem3;
        private PictureBox stopDownloadItem3;
        private PictureBox removeDownloadItem2;
        private PictureBox stopDownloadItem2;
        private PictureBox removeDownloadItem4;
        private PictureBox stopDownloadItem4;
        private System.Windows.Forms.Label downloadStopLabel;
        private Panel FilesDownloaded;
        private Panel container1;
        private System.Windows.Forms.Label label9;
        private Panel fileD1;
        private System.Windows.Forms.Label FileTag1;
        private Panel fileD10;
        private System.Windows.Forms.Label FileTime10;
        private System.Windows.Forms.Label FileTag10;
        private Button openFolder;
        private Panel fileD9;
        private System.Windows.Forms.Label FileTime9;
        private System.Windows.Forms.Label FileTag9;
        private Panel fileD8;
        private System.Windows.Forms.Label FileTime8;
        private System.Windows.Forms.Label FileTag8;
        private Panel fileD7;
        private System.Windows.Forms.Label FileTime7;
        private System.Windows.Forms.Label FileTag7;
        private Panel fileD6;
        private System.Windows.Forms.Label FileTime6;
        private System.Windows.Forms.Label FileTag6;
        private Panel fileD5;
        private System.Windows.Forms.Label FileTime5;
        private System.Windows.Forms.Label FileTag5;
        private Panel fileD4;
        private System.Windows.Forms.Label FileTime4;
        private System.Windows.Forms.Label FileTag4;
        private Panel fileD3;
        private System.Windows.Forms.Label FileTime3;
        private System.Windows.Forms.Label FileTag3;
        private Panel fileD2;
        private System.Windows.Forms.Label FileTime2;
        private System.Windows.Forms.Label FileTag2;
        private System.Windows.Forms.Label FileTime1;
        private Button showDownloadedItems;
        private System.Windows.Forms.Label overallLabelStatus;
        private CustomControls.RJControls.RJProgressBar overallProgressBar;
        private Button btngoBackDownload;
        private System.Windows.Forms.Label downloadCompleteLabel;
        private Microsoft.Web.WebView2.WinForms.WebView2 infoHTML2;
        private Microsoft.Web.WebView2.WinForms.WebView2 infoHTML1;
        private Panel settingsPanel;
        private Panel barMainSet;
        private System.Windows.Forms.Label label10;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private PictureBox pictureBox4;
        private Panel setBarH2;
        private Panel setBarH1;
        private Panel setHolderWindow;
        private Panel setBarH4;
        private System.Windows.Forms.Label label20;
        private Panel setBarH5;
        private Panel setBarH3;
        private CustomControls.RJControls.RJToggleButton set1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label set1label;
        private System.Windows.Forms.Label set5label;
        private CustomControls.RJControls.RJToggleButton set5;
        private System.Windows.Forms.Label set4label;
        private CustomControls.RJControls.RJToggleButton set4;
        private System.Windows.Forms.Label set3label;
        private CustomControls.RJControls.RJToggleButton set3;
        private System.Windows.Forms.Label set2label;
        private CustomControls.RJControls.RJToggleButton set2;
        private System.Windows.Forms.Label set6label;
        private CustomControls.RJControls.RJToggleButton set6;
        private System.Windows.Forms.Label set7label;
        private CustomControls.RJControls.RJToggleButton set7;
        private System.Windows.Forms.Label setServerlabel;
        private CustomControls.RJControls.RJComboBox setServer;
        private System.Windows.Forms.Label set14label;
        private CustomControls.RJControls.RJToggleButton set14;
        private System.Windows.Forms.Label set13label;
        private CustomControls.RJControls.RJToggleButton set13;
        private System.Windows.Forms.Label set12label;
        private CustomControls.RJControls.RJToggleButton set12;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private CustomControls.RJControls.RJButton selectLocation;
        private TextBox locationTextBox;
        private Panel extensionsMarketplace;
        private System.Windows.Forms.Label label33;
        private Button gotoMarketplace;
        private System.Windows.Forms.Label extNoInfo3;
        private System.Windows.Forms.Label extNoInfo2;
        private PictureBox extNoInfo1;
        private Microsoft.Web.WebView2.WinForms.WebView2 extensionsMarketplaceWebView;
        private PictureBox closewebViewMar;
        private FlowLayoutPanel extensionsInstalled;
        private Panel extInfoNone;
        private Button manageExt;
        private Button refreshExt;
        private System.Windows.Forms.Label uninstallLabel;
        private ProgressBar downloadBar1;
        private ProgressBar downloadBar4;
        private ProgressBar downloadBar3;
        private ProgressBar downloadBar2;
        private CustomControls.RJControls.RJButton checkForUpdates;
        private System.Windows.Forms.Label verLabel;
        private CustomControls.RJControls.RJComboBox setUITheme;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label changedInfo;
        private CustomControls.RJControls.RJToggleButton set8;
        private System.Windows.Forms.Label label36;
        private TrackBar downloadSpeedControl;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private PictureBox pictureBox9;
        public Microsoft.Web.WebView2.WinForms.WebView2 userDbViewer;
        public Microsoft.Web.WebView2.WinForms.WebView2 ftpViewer;
        private Panel connectivityPanel;
        private System.Windows.Forms.Label label41;
        private Panel action2;
        private Panel action1;
        private Panel action5;
        private Panel action4;
        private Panel action3;
        private Panel action7;
        private System.Windows.Forms.Label label47;
        private Panel action6;
        private CustomControls.RJControls.RJButton fixApp;
        private Button aboutAppRedirect;
        private CustomControls.RJControls.RJButton newUpdateNotifier;
        private Microsoft.Web.WebView2.WinForms.WebView2 newsHTML;
        private Panel appchangesPanel;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private CustomControls.RJControls.RJButton dbUpdateNews;
        private CustomControls.RJControls.RJButton appUpdateNews;
        private Panel newsPanel;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private Panel faqAppPanel;
        private System.Windows.Forms.Label label44;
        private Panel panel2;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private CustomControls.RJControls.RJButton betaStatus;
        private CustomControls.RJControls.RJButton rjButton2;
        private Panel searchfilesPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 search_WebView;
        private System.Windows.Forms.Label label40;
        private CustomControls.RJControls.RJToggleButton set15;
        private Panel contactPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 contactFormWebView;
        private CustomControls.RJControls.RJToggleButton set16;
        private System.Windows.Forms.Label DefaultThemePlaceHolder;
        private CustomControls.RJControls.RJButton portableMake;
        private Microsoft.Web.WebView2.WinForms.WebView2 faqAppWebView;
        private Microsoft.Web.WebView2.WinForms.WebView2 logoIcon;
        private Panel mainPanelRedirectPanel;
    }
}
