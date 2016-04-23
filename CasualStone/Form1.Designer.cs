namespace CasualStone
{
    partial class CasualStoneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasualStoneForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gameStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showForPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showForOpponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showForPlayerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showForOpponentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showForBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.concedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showForPlayerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showForOpponentToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showForBothToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.preferenceTabPage = new System.Windows.Forms.TabPage();
            this.preferenceErrorLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.notificationTextColorLabel = new System.Windows.Forms.Label();
            this.notificationTextColorPanel = new System.Windows.Forms.Panel();
            this.notifBackgroundColorLabel = new System.Windows.Forms.Label();
            this.notificationBackgroundColorPanel = new System.Windows.Forms.Panel();
            this.autoFocusCheckBox = new System.Windows.Forms.CheckBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationDescriptionLabel = new System.Windows.Forms.Label();
            this.durationBar = new System.Windows.Forms.TrackBar();
            this.closeAllNotifCheckBox = new System.Windows.Forms.CheckBox();
            this.showHSCheckBox = new System.Windows.Forms.CheckBox();
            this.hideNotifCheckBox = new System.Windows.Forms.CheckBox();
            this.accountTabPage = new System.Windows.Forms.TabPage();
            this.clearUsernameButton = new System.Windows.Forms.Button();
            this.removeUsernameButton = new System.Windows.Forms.Button();
            this.usernameErrorLabel = new System.Windows.Forms.Label();
            this.addUsernameButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameListBox = new System.Windows.Forms.ListBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.hearthstoneInstallPathErrorLabel = new System.Windows.Forms.Label();
            this.browseInstallPathButton = new System.Windows.Forms.Button();
            this.hearthstoneInstallPathTextBox = new System.Windows.Forms.TextBox();
            this.hearthstoneInstallPathLabel = new System.Windows.Forms.Label();
            this.updatesTabPage = new System.Windows.Forms.TabPage();
            this.updateLinkLabel = new System.Windows.Forms.LinkLabel();
            this.updateLabel = new System.Windows.Forms.Label();
            this.updatePictureBox = new System.Windows.Forms.PictureBox();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.versionLabel = new System.Windows.Forms.Label();
            this.casualStoneLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hearthstoneInstallPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.preferenceTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationBar)).BeginInit();
            this.accountTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.updatesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).BeginInit();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.mainMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Casual Stone";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStartToolStripMenuItem,
            this.turnStartToolStripMenuItem,
            this.concedeToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(212, 223);
            this.mainMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.mainMenuStrip_Opening);
            // 
            // gameStartToolStripMenuItem
            // 
            this.gameStartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem,
            this.showForOpponentToolStripMenuItem,
            this.showForToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.gameStartToolStripMenuItem.Name = "gameStartToolStripMenuItem";
            this.gameStartToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.gameStartToolStripMenuItem.Text = "Game Start";
            this.gameStartToolStripMenuItem.Click += new System.EventHandler(this.startTurnToolStripMenuItem_Click);
            // 
            // showForPlayerToolStripMenuItem
            // 
            this.showForPlayerToolStripMenuItem.CheckOnClick = true;
            this.showForPlayerToolStripMenuItem.Name = "showForPlayerToolStripMenuItem";
            this.showForPlayerToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.showForPlayerToolStripMenuItem.Text = "Show for Player";
            this.showForPlayerToolStripMenuItem.Click += new System.EventHandler(this.showForPlayerToolStripMenuItem_Click);
            // 
            // showForOpponentToolStripMenuItem
            // 
            this.showForOpponentToolStripMenuItem.CheckOnClick = true;
            this.showForOpponentToolStripMenuItem.Name = "showForOpponentToolStripMenuItem";
            this.showForOpponentToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.showForOpponentToolStripMenuItem.Text = "Show for Opponent";
            this.showForOpponentToolStripMenuItem.Click += new System.EventHandler(this.showForOpponentToolStripMenuItem_Click);
            // 
            // showForToolStripMenuItem
            // 
            this.showForToolStripMenuItem.CheckOnClick = true;
            this.showForToolStripMenuItem.Name = "showForToolStripMenuItem";
            this.showForToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.showForToolStripMenuItem.Text = "Show for Both";
            this.showForToolStripMenuItem.Click += new System.EventHandler(this.showForToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.CheckOnClick = true;
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // turnStartToolStripMenuItem
            // 
            this.turnStartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem1,
            this.showForOpponentToolStripMenuItem1,
            this.showForBothToolStripMenuItem,
            this.noneToolStripMenuItem1});
            this.turnStartToolStripMenuItem.Name = "turnStartToolStripMenuItem";
            this.turnStartToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.turnStartToolStripMenuItem.Text = "Turn Start";
            // 
            // showForPlayerToolStripMenuItem1
            // 
            this.showForPlayerToolStripMenuItem1.Name = "showForPlayerToolStripMenuItem1";
            this.showForPlayerToolStripMenuItem1.Size = new System.Drawing.Size(256, 30);
            this.showForPlayerToolStripMenuItem1.Text = "Show for Player";
            this.showForPlayerToolStripMenuItem1.Click += new System.EventHandler(this.showForPlayerToolStripMenuItem1_Click);
            // 
            // showForOpponentToolStripMenuItem1
            // 
            this.showForOpponentToolStripMenuItem1.Name = "showForOpponentToolStripMenuItem1";
            this.showForOpponentToolStripMenuItem1.Size = new System.Drawing.Size(256, 30);
            this.showForOpponentToolStripMenuItem1.Text = "Show for Opponent";
            this.showForOpponentToolStripMenuItem1.Click += new System.EventHandler(this.showForOpponentToolStripMenuItem1_Click);
            // 
            // showForBothToolStripMenuItem
            // 
            this.showForBothToolStripMenuItem.Name = "showForBothToolStripMenuItem";
            this.showForBothToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.showForBothToolStripMenuItem.Text = "Show for Both";
            this.showForBothToolStripMenuItem.Click += new System.EventHandler(this.showForBothToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem1
            // 
            this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
            this.noneToolStripMenuItem1.Size = new System.Drawing.Size(256, 30);
            this.noneToolStripMenuItem1.Text = "None";
            this.noneToolStripMenuItem1.Click += new System.EventHandler(this.noneToolStripMenuItem1_Click);
            // 
            // concedeToolStripMenuItem
            // 
            this.concedeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem2,
            this.showForOpponentToolStripMenuItem2,
            this.showForBothToolStripMenuItem1,
            this.noneToolStripMenuItem2});
            this.concedeToolStripMenuItem.Name = "concedeToolStripMenuItem";
            this.concedeToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.concedeToolStripMenuItem.Text = "Concede";
            // 
            // showForPlayerToolStripMenuItem2
            // 
            this.showForPlayerToolStripMenuItem2.Name = "showForPlayerToolStripMenuItem2";
            this.showForPlayerToolStripMenuItem2.Size = new System.Drawing.Size(256, 30);
            this.showForPlayerToolStripMenuItem2.Text = "Show for Player";
            this.showForPlayerToolStripMenuItem2.Click += new System.EventHandler(this.showForPlayerToolStripMenuItem2_Click);
            // 
            // showForOpponentToolStripMenuItem2
            // 
            this.showForOpponentToolStripMenuItem2.Name = "showForOpponentToolStripMenuItem2";
            this.showForOpponentToolStripMenuItem2.Size = new System.Drawing.Size(256, 30);
            this.showForOpponentToolStripMenuItem2.Text = "Show for Opponent";
            this.showForOpponentToolStripMenuItem2.Click += new System.EventHandler(this.showForOpponentToolStripMenuItem2_Click);
            // 
            // showForBothToolStripMenuItem1
            // 
            this.showForBothToolStripMenuItem1.Name = "showForBothToolStripMenuItem1";
            this.showForBothToolStripMenuItem1.Size = new System.Drawing.Size(256, 30);
            this.showForBothToolStripMenuItem1.Text = "Show for Both";
            this.showForBothToolStripMenuItem1.Click += new System.EventHandler(this.showForBothToolStripMenuItem1_Click);
            // 
            // noneToolStripMenuItem2
            // 
            this.noneToolStripMenuItem2.Name = "noneToolStripMenuItem2";
            this.noneToolStripMenuItem2.Size = new System.Drawing.Size(256, 30);
            this.noneToolStripMenuItem2.Text = "None";
            this.noneToolStripMenuItem2.Click += new System.EventHandler(this.noneToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.preferenceTabPage);
            this.tabControl.Controls.Add(this.accountTabPage);
            this.tabControl.Controls.Add(this.settingsTabPage);
            this.tabControl.Controls.Add(this.updatesTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(30, 100);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(703, 497);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            // 
            // preferenceTabPage
            // 
            this.preferenceTabPage.Controls.Add(this.preferenceErrorLabel);
            this.preferenceTabPage.Controls.Add(this.previewButton);
            this.preferenceTabPage.Controls.Add(this.notificationTextColorLabel);
            this.preferenceTabPage.Controls.Add(this.notificationTextColorPanel);
            this.preferenceTabPage.Controls.Add(this.notifBackgroundColorLabel);
            this.preferenceTabPage.Controls.Add(this.notificationBackgroundColorPanel);
            this.preferenceTabPage.Controls.Add(this.autoFocusCheckBox);
            this.preferenceTabPage.Controls.Add(this.durationLabel);
            this.preferenceTabPage.Controls.Add(this.durationDescriptionLabel);
            this.preferenceTabPage.Controls.Add(this.durationBar);
            this.preferenceTabPage.Controls.Add(this.closeAllNotifCheckBox);
            this.preferenceTabPage.Controls.Add(this.showHSCheckBox);
            this.preferenceTabPage.Controls.Add(this.hideNotifCheckBox);
            this.preferenceTabPage.Location = new System.Drawing.Point(104, 4);
            this.preferenceTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.preferenceTabPage.Name = "preferenceTabPage";
            this.preferenceTabPage.Size = new System.Drawing.Size(595, 489);
            this.preferenceTabPage.TabIndex = 0;
            this.preferenceTabPage.Text = "Preferences";
            this.preferenceTabPage.UseVisualStyleBackColor = true;
            this.preferenceTabPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // preferenceErrorLabel
            // 
            this.preferenceErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.preferenceErrorLabel.Location = new System.Drawing.Point(16, 136);
            this.preferenceErrorLabel.Name = "preferenceErrorLabel";
            this.preferenceErrorLabel.Size = new System.Drawing.Size(500, 20);
            this.preferenceErrorLabel.TabIndex = 16;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(20, 442);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(95, 32);
            this.previewButton.TabIndex = 15;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // notificationTextColorLabel
            // 
            this.notificationTextColorLabel.Location = new System.Drawing.Point(16, 250);
            this.notificationTextColorLabel.Name = "notificationTextColorLabel";
            this.notificationTextColorLabel.Size = new System.Drawing.Size(550, 20);
            this.notificationTextColorLabel.TabIndex = 14;
            this.notificationTextColorLabel.Text = "Select notification text color:";
            // 
            // notificationTextColorPanel
            // 
            this.notificationTextColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationTextColorPanel.Location = new System.Drawing.Point(20, 273);
            this.notificationTextColorPanel.Name = "notificationTextColorPanel";
            this.notificationTextColorPanel.Size = new System.Drawing.Size(157, 36);
            this.notificationTextColorPanel.TabIndex = 13;
            // 
            // notifBackgroundColorLabel
            // 
            this.notifBackgroundColorLabel.Location = new System.Drawing.Point(16, 167);
            this.notifBackgroundColorLabel.Name = "notifBackgroundColorLabel";
            this.notifBackgroundColorLabel.Size = new System.Drawing.Size(550, 20);
            this.notifBackgroundColorLabel.TabIndex = 12;
            this.notifBackgroundColorLabel.Text = "Select notification background color:";
            // 
            // notificationBackgroundColorPanel
            // 
            this.notificationBackgroundColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationBackgroundColorPanel.Location = new System.Drawing.Point(20, 190);
            this.notificationBackgroundColorPanel.Name = "notificationBackgroundColorPanel";
            this.notificationBackgroundColorPanel.Size = new System.Drawing.Size(157, 36);
            this.notificationBackgroundColorPanel.TabIndex = 11;
            this.notificationBackgroundColorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.notificationBackgroundColorPanel_Paint);
            // 
            // autoFocusCheckBox
            // 
            this.autoFocusCheckBox.Location = new System.Drawing.Point(20, 100);
            this.autoFocusCheckBox.Name = "autoFocusCheckBox";
            this.autoFocusCheckBox.Size = new System.Drawing.Size(550, 24);
            this.autoFocusCheckBox.TabIndex = 10;
            this.autoFocusCheckBox.Text = "Bring Hearthstone to the top when player turn begins";
            this.autoFocusCheckBox.UseVisualStyleBackColor = true;
            this.autoFocusCheckBox.CheckedChanged += new System.EventHandler(this.autoFocusCheckBox_CheckedChanged);
            // 
            // durationLabel
            // 
            this.durationLabel.Location = new System.Drawing.Point(380, 378);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(150, 20);
            this.durationLabel.TabIndex = 9;
            this.durationLabel.Text = "           ";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.durationLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // durationDescriptionLabel
            // 
            this.durationDescriptionLabel.Location = new System.Drawing.Point(16, 324);
            this.durationDescriptionLabel.Name = "durationDescriptionLabel";
            this.durationDescriptionLabel.Size = new System.Drawing.Size(550, 20);
            this.durationDescriptionLabel.TabIndex = 5;
            this.durationDescriptionLabel.Text = "Select duration notifications will stay open:";
            this.durationDescriptionLabel.Click += new System.EventHandler(this.durationDescriptionLabel_Click);
            // 
            // durationBar
            // 
            this.durationBar.Location = new System.Drawing.Point(20, 355);
            this.durationBar.Maximum = 300;
            this.durationBar.Name = "durationBar";
            this.durationBar.Size = new System.Drawing.Size(354, 69);
            this.durationBar.TabIndex = 4;
            this.durationBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // closeAllNotifCheckBox
            // 
            this.closeAllNotifCheckBox.Checked = true;
            this.closeAllNotifCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeAllNotifCheckBox.Location = new System.Drawing.Point(20, 40);
            this.closeAllNotifCheckBox.Name = "closeAllNotifCheckBox";
            this.closeAllNotifCheckBox.Size = new System.Drawing.Size(550, 24);
            this.closeAllNotifCheckBox.TabIndex = 2;
            this.closeAllNotifCheckBox.Text = "Close all notification when a single notification is clicked";
            this.closeAllNotifCheckBox.UseVisualStyleBackColor = true;
            this.closeAllNotifCheckBox.CheckedChanged += new System.EventHandler(this.closeAllNotifCheckBox_CheckedChanged);
            // 
            // showHSCheckBox
            // 
            this.showHSCheckBox.Checked = true;
            this.showHSCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHSCheckBox.Location = new System.Drawing.Point(20, 70);
            this.showHSCheckBox.Name = "showHSCheckBox";
            this.showHSCheckBox.Size = new System.Drawing.Size(550, 24);
            this.showHSCheckBox.TabIndex = 1;
            this.showHSCheckBox.Text = "Bring Hearthstone to the top when a notification is clicked";
            this.showHSCheckBox.UseVisualStyleBackColor = true;
            this.showHSCheckBox.CheckedChanged += new System.EventHandler(this.showHSCheckBox_CheckedChanged);
            // 
            // hideNotifCheckBox
            // 
            this.hideNotifCheckBox.Location = new System.Drawing.Point(20, 10);
            this.hideNotifCheckBox.Name = "hideNotifCheckBox";
            this.hideNotifCheckBox.Size = new System.Drawing.Size(550, 24);
            this.hideNotifCheckBox.TabIndex = 0;
            this.hideNotifCheckBox.Text = "Do not show notifications if Hearthstone already has focus";
            this.hideNotifCheckBox.UseVisualStyleBackColor = true;
            this.hideNotifCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // accountTabPage
            // 
            this.accountTabPage.Controls.Add(this.clearUsernameButton);
            this.accountTabPage.Controls.Add(this.removeUsernameButton);
            this.accountTabPage.Controls.Add(this.usernameErrorLabel);
            this.accountTabPage.Controls.Add(this.addUsernameButton);
            this.accountTabPage.Controls.Add(this.usernameTextBox);
            this.accountTabPage.Controls.Add(this.usernameListBox);
            this.accountTabPage.Controls.Add(this.accountLabel);
            this.accountTabPage.Location = new System.Drawing.Point(104, 4);
            this.accountTabPage.Name = "accountTabPage";
            this.accountTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.accountTabPage.Size = new System.Drawing.Size(595, 489);
            this.accountTabPage.TabIndex = 3;
            this.accountTabPage.Text = "Accounts";
            this.accountTabPage.UseVisualStyleBackColor = true;
            this.accountTabPage.Click += new System.EventHandler(this.accountTabPage_Click);
            // 
            // clearUsernameButton
            // 
            this.clearUsernameButton.Location = new System.Drawing.Point(262, 318);
            this.clearUsernameButton.Name = "clearUsernameButton";
            this.clearUsernameButton.Size = new System.Drawing.Size(95, 32);
            this.clearUsernameButton.TabIndex = 6;
            this.clearUsernameButton.Text = "Clear";
            this.clearUsernameButton.UseVisualStyleBackColor = true;
            this.clearUsernameButton.Click += new System.EventHandler(this.clearUsernameButton_Click);
            // 
            // removeUsernameButton
            // 
            this.removeUsernameButton.Location = new System.Drawing.Point(262, 280);
            this.removeUsernameButton.Name = "removeUsernameButton";
            this.removeUsernameButton.Size = new System.Drawing.Size(95, 32);
            this.removeUsernameButton.TabIndex = 5;
            this.removeUsernameButton.Text = "Remove";
            this.removeUsernameButton.UseVisualStyleBackColor = true;
            this.removeUsernameButton.Click += new System.EventHandler(this.removeUsernameButton_Click);
            // 
            // usernameErrorLabel
            // 
            this.usernameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameErrorLabel.Location = new System.Drawing.Point(32, 195);
            this.usernameErrorLabel.Name = "usernameErrorLabel";
            this.usernameErrorLabel.Size = new System.Drawing.Size(500, 20);
            this.usernameErrorLabel.TabIndex = 4;
            // 
            // addUsernameButton
            // 
            this.addUsernameButton.Location = new System.Drawing.Point(262, 222);
            this.addUsernameButton.Name = "addUsernameButton";
            this.addUsernameButton.Size = new System.Drawing.Size(95, 32);
            this.addUsernameButton.TabIndex = 3;
            this.addUsernameButton.Text = "Add";
            this.addUsernameButton.UseVisualStyleBackColor = true;
            this.addUsernameButton.Click += new System.EventHandler(this.addUsernameButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(36, 222);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(202, 26);
            this.usernameTextBox.TabIndex = 2;
            // 
            // usernameListBox
            // 
            this.usernameListBox.FormattingEnabled = true;
            this.usernameListBox.ItemHeight = 20;
            this.usernameListBox.Location = new System.Drawing.Point(36, 280);
            this.usernameListBox.Name = "usernameListBox";
            this.usernameListBox.Size = new System.Drawing.Size(202, 104);
            this.usernameListBox.TabIndex = 1;
            // 
            // accountLabel
            // 
            this.accountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLabel.Location = new System.Drawing.Point(32, 35);
            this.accountLabel.MaximumSize = new System.Drawing.Size(500, 0);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(500, 175);
            this.accountLabel.TabIndex = 0;
            this.accountLabel.Text = resources.GetString("accountLabel.Text");
            this.accountLabel.Click += new System.EventHandler(this.accountLabel_Click);
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.hearthstoneInstallPathErrorLabel);
            this.settingsTabPage.Controls.Add(this.browseInstallPathButton);
            this.settingsTabPage.Controls.Add(this.hearthstoneInstallPathTextBox);
            this.settingsTabPage.Controls.Add(this.hearthstoneInstallPathLabel);
            this.settingsTabPage.Location = new System.Drawing.Point(104, 4);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Size = new System.Drawing.Size(595, 489);
            this.settingsTabPage.TabIndex = 4;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // hearthstoneInstallPathErrorLabel
            // 
            this.hearthstoneInstallPathErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.hearthstoneInstallPathErrorLabel.Location = new System.Drawing.Point(27, 123);
            this.hearthstoneInstallPathErrorLabel.Name = "hearthstoneInstallPathErrorLabel";
            this.hearthstoneInstallPathErrorLabel.Size = new System.Drawing.Size(500, 20);
            this.hearthstoneInstallPathErrorLabel.TabIndex = 3;
            // 
            // browseInstallPathButton
            // 
            this.browseInstallPathButton.Location = new System.Drawing.Point(445, 152);
            this.browseInstallPathButton.Name = "browseInstallPathButton";
            this.browseInstallPathButton.Size = new System.Drawing.Size(95, 31);
            this.browseInstallPathButton.TabIndex = 2;
            this.browseInstallPathButton.Text = "Browse...";
            this.browseInstallPathButton.UseVisualStyleBackColor = true;
            this.browseInstallPathButton.Click += new System.EventHandler(this.browseInstallPathButton_Click);
            // 
            // hearthstoneInstallPathTextBox
            // 
            this.hearthstoneInstallPathTextBox.Enabled = false;
            this.hearthstoneInstallPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hearthstoneInstallPathTextBox.Location = new System.Drawing.Point(32, 153);
            this.hearthstoneInstallPathTextBox.Name = "hearthstoneInstallPathTextBox";
            this.hearthstoneInstallPathTextBox.Size = new System.Drawing.Size(407, 26);
            this.hearthstoneInstallPathTextBox.TabIndex = 1;
            // 
            // hearthstoneInstallPathLabel
            // 
            this.hearthstoneInstallPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hearthstoneInstallPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hearthstoneInstallPathLabel.Location = new System.Drawing.Point(28, 99);
            this.hearthstoneInstallPathLabel.Name = "hearthstoneInstallPathLabel";
            this.hearthstoneInstallPathLabel.Size = new System.Drawing.Size(500, 20);
            this.hearthstoneInstallPathLabel.TabIndex = 0;
            this.hearthstoneInstallPathLabel.Text = "Install Path for HearthStone:";
            this.hearthstoneInstallPathLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // updatesTabPage
            // 
            this.updatesTabPage.Controls.Add(this.updateLinkLabel);
            this.updatesTabPage.Controls.Add(this.updateLabel);
            this.updatesTabPage.Controls.Add(this.updatePictureBox);
            this.updatesTabPage.Location = new System.Drawing.Point(104, 4);
            this.updatesTabPage.Name = "updatesTabPage";
            this.updatesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.updatesTabPage.Size = new System.Drawing.Size(595, 489);
            this.updatesTabPage.TabIndex = 2;
            this.updatesTabPage.Text = "Updates";
            this.updatesTabPage.UseVisualStyleBackColor = true;
            this.updatesTabPage.Click += new System.EventHandler(this.updatesTabPage_Click);
            // 
            // updateLinkLabel
            // 
            this.updateLinkLabel.AutoSize = true;
            this.updateLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.updateLinkLabel.Location = new System.Drawing.Point(55, 328);
            this.updateLinkLabel.Name = "updateLinkLabel";
            this.updateLinkLabel.Size = new System.Drawing.Size(0, 20);
            this.updateLinkLabel.TabIndex = 2;
            // 
            // updateLabel
            // 
            this.updateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.updateLabel.Location = new System.Drawing.Point(166, 191);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(400, 20);
            this.updateLabel.TabIndex = 1;
            this.updateLabel.Text = "Checking for updates...";
            // 
            // updatePictureBox
            // 
            this.updatePictureBox.Image = global::CasualStone.Properties.Resources.loading;
            this.updatePictureBox.Location = new System.Drawing.Point(19, 171);
            this.updatePictureBox.Name = "updatePictureBox";
            this.updatePictureBox.Size = new System.Drawing.Size(124, 124);
            this.updatePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.updatePictureBox.TabIndex = 0;
            this.updatePictureBox.TabStop = false;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.versionLabel);
            this.aboutTabPage.Controls.Add(this.casualStoneLabel);
            this.aboutTabPage.Controls.Add(this.pictureBox1);
            this.aboutTabPage.Location = new System.Drawing.Point(104, 4);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTabPage.Size = new System.Drawing.Size(595, 489);
            this.aboutTabPage.TabIndex = 1;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.versionLabel.Location = new System.Drawing.Point(163, 235);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(400, 100);
            this.versionLabel.TabIndex = 5;
            this.versionLabel.Text = "Copyright © Sean Konagaya. All Rights Reserved.\r\n\r\nVersion 0.0.1 | KONAGAYA.IO";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click_1);
            // 
            // casualStoneLabel
            // 
            this.casualStoneLabel.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casualStoneLabel.Location = new System.Drawing.Point(157, 158);
            this.casualStoneLabel.Name = "casualStoneLabel";
            this.casualStoneLabel.Size = new System.Drawing.Size(400, 49);
            this.casualStoneLabel.TabIndex = 4;
            this.casualStoneLabel.Text = "Casual Stone";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CasualStone.Properties.Resources.app;
            this.pictureBox1.Location = new System.Drawing.Point(23, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(519, 523);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 32);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(418, 523);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 32);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Okey";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(620, 523);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(95, 32);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(74, 4);
            // 
            // hearthstoneInstallPathDialog
            // 
            this.hearthstoneInstallPathDialog.HelpRequest += new System.EventHandler(this.hearthstoneInstallPathDialog_HelpRequest);
            // 
            // CasualStoneForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(728, 572);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.applyButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(500, 56);
            this.Name = "CasualStoneForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.CasualStoneForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.preferenceTabPage.ResumeLayout(false);
            this.preferenceTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationBar)).EndInit();
            this.accountTabPage.ResumeLayout(false);
            this.accountTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.updatesTabPage.ResumeLayout(false);
            this.updatesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).EndInit();
            this.aboutTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showForPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showForOpponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showForToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem concedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showForPlayerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showForOpponentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showForBothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showForPlayerToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showForOpponentToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showForBothToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage preferenceTabPage;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.CheckBox showHSCheckBox;
        private System.Windows.Forms.CheckBox hideNotifCheckBox;
        private System.Windows.Forms.CheckBox closeAllNotifCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label durationDescriptionLabel;
        private System.Windows.Forms.TrackBar durationBar;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.TabPage updatesTabPage;
        private System.Windows.Forms.TabPage accountTabPage;
        private System.Windows.Forms.CheckBox autoFocusCheckBox;
        private System.Windows.Forms.Label notifBackgroundColorLabel;
        private System.Windows.Forms.Panel notificationBackgroundColorPanel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label notificationTextColorLabel;
        private System.Windows.Forms.Panel notificationTextColorPanel;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox usernameListBox;
        private System.Windows.Forms.Button addUsernameButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameErrorLabel;
        private System.Windows.Forms.Button clearUsernameButton;
        private System.Windows.Forms.Button removeUsernameButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label casualStoneLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox updatePictureBox;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.LinkLabel updateLinkLabel;
        private System.Windows.Forms.Label preferenceErrorLabel;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Label hearthstoneInstallPathLabel;
        private System.Windows.Forms.FolderBrowserDialog hearthstoneInstallPathDialog;
        private System.Windows.Forms.TextBox hearthstoneInstallPathTextBox;
        private System.Windows.Forms.Button browseInstallPathButton;
        private System.Windows.Forms.Label hearthstoneInstallPathErrorLabel;
    }
}

