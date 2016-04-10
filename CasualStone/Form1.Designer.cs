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
            this.usernameDisplayTextBox = new System.Windows.Forms.ToolStripTextBox();
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuStrip.SuspendLayout();
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
            this.usernameDisplayTextBox,
            this.toolStripSeparator2,
            this.gameStartToolStripMenuItem,
            this.turnStartToolStripMenuItem,
            this.concedeToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(241, 295);
            this.mainMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.mainMenuStrip_Opening);
            // 
            // usernameDisplayTextBox
            // 
            this.usernameDisplayTextBox.Name = "usernameDisplayTextBox";
            this.usernameDisplayTextBox.Size = new System.Drawing.Size(100, 35);
            this.usernameDisplayTextBox.Text = "Playing as";
            // 
            // gameStartToolStripMenuItem
            // 
            this.gameStartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem,
            this.showForOpponentToolStripMenuItem,
            this.showForToolStripMenuItem,
            this.noneToolStripMenuItem});
            this.gameStartToolStripMenuItem.Name = "gameStartToolStripMenuItem";
            this.gameStartToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.gameStartToolStripMenuItem.Text = "Game Start";
            this.gameStartToolStripMenuItem.Click += new System.EventHandler(this.startTurnToolStripMenuItem_Click);
            // 
            // showForPlayerToolStripMenuItem
            // 
            this.showForPlayerToolStripMenuItem.CheckOnClick = true;
            this.showForPlayerToolStripMenuItem.Name = "showForPlayerToolStripMenuItem";
            this.showForPlayerToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.showForPlayerToolStripMenuItem.Text = "Show for Player";
            this.showForPlayerToolStripMenuItem.Click += new System.EventHandler(this.showForPlayerToolStripMenuItem_Click);
            // 
            // showForOpponentToolStripMenuItem
            // 
            this.showForOpponentToolStripMenuItem.CheckOnClick = true;
            this.showForOpponentToolStripMenuItem.Name = "showForOpponentToolStripMenuItem";
            this.showForOpponentToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.showForOpponentToolStripMenuItem.Text = "Show for Opponent";
            // 
            // showForToolStripMenuItem
            // 
            this.showForToolStripMenuItem.CheckOnClick = true;
            this.showForToolStripMenuItem.Name = "showForToolStripMenuItem";
            this.showForToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.showForToolStripMenuItem.Text = "Show for Both";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.CheckOnClick = true;
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.noneToolStripMenuItem.Text = "None";
            // 
            // turnStartToolStripMenuItem
            // 
            this.turnStartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem1,
            this.showForOpponentToolStripMenuItem1,
            this.showForBothToolStripMenuItem,
            this.noneToolStripMenuItem1});
            this.turnStartToolStripMenuItem.Name = "turnStartToolStripMenuItem";
            this.turnStartToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.turnStartToolStripMenuItem.Text = "Turn Start";
            // 
            // showForPlayerToolStripMenuItem1
            // 
            this.showForPlayerToolStripMenuItem1.Name = "showForPlayerToolStripMenuItem1";
            this.showForPlayerToolStripMenuItem1.Size = new System.Drawing.Size(287, 34);
            this.showForPlayerToolStripMenuItem1.Text = "Show for Player";
            // 
            // showForOpponentToolStripMenuItem1
            // 
            this.showForOpponentToolStripMenuItem1.Name = "showForOpponentToolStripMenuItem1";
            this.showForOpponentToolStripMenuItem1.Size = new System.Drawing.Size(287, 34);
            this.showForOpponentToolStripMenuItem1.Text = "Show for Opponent";
            // 
            // showForBothToolStripMenuItem
            // 
            this.showForBothToolStripMenuItem.Name = "showForBothToolStripMenuItem";
            this.showForBothToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.showForBothToolStripMenuItem.Text = "Show for Both";
            // 
            // noneToolStripMenuItem1
            // 
            this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
            this.noneToolStripMenuItem1.Size = new System.Drawing.Size(287, 34);
            this.noneToolStripMenuItem1.Text = "None";
            // 
            // concedeToolStripMenuItem
            // 
            this.concedeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showForPlayerToolStripMenuItem2,
            this.showForOpponentToolStripMenuItem2,
            this.showForBothToolStripMenuItem1,
            this.noneToolStripMenuItem2});
            this.concedeToolStripMenuItem.Name = "concedeToolStripMenuItem";
            this.concedeToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.concedeToolStripMenuItem.Text = "Concede";
            // 
            // showForPlayerToolStripMenuItem2
            // 
            this.showForPlayerToolStripMenuItem2.Name = "showForPlayerToolStripMenuItem2";
            this.showForPlayerToolStripMenuItem2.Size = new System.Drawing.Size(287, 34);
            this.showForPlayerToolStripMenuItem2.Text = "Show for Player";
            // 
            // showForOpponentToolStripMenuItem2
            // 
            this.showForOpponentToolStripMenuItem2.Name = "showForOpponentToolStripMenuItem2";
            this.showForOpponentToolStripMenuItem2.Size = new System.Drawing.Size(287, 34);
            this.showForOpponentToolStripMenuItem2.Text = "Show for Opponent";
            // 
            // showForBothToolStripMenuItem1
            // 
            this.showForBothToolStripMenuItem1.Name = "showForBothToolStripMenuItem1";
            this.showForBothToolStripMenuItem1.Size = new System.Drawing.Size(287, 34);
            this.showForBothToolStripMenuItem1.Text = "Show for Both";
            // 
            // noneToolStripMenuItem2
            // 
            this.noneToolStripMenuItem2.Name = "noneToolStripMenuItem2";
            this.noneToolStripMenuItem2.Size = new System.Drawing.Size(287, 34);
            this.noneToolStripMenuItem2.Text = "None";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // CasualStoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 481);
            this.Name = "CasualStoneForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.CasualStoneForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox usernameDisplayTextBox;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

