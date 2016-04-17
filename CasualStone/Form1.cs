using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastNotifications;

namespace CasualStone
{
    public partial class CasualStoneForm : Form
    {
        private HearthLogReader sasquatch;

        public CasualStoneForm(string logFileName)
        {
            InitializeComponent();
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            durationBar.ValueChanged +=  new System.EventHandler(durationBar_ValueChanged);
            notificationBackgroundColorPanel.Click += new System.EventHandler(notificationBackgroundColorPanel_Clicked);
            notificationTextColorPanel.Click += new System.EventHandler(notificationTextColorPanel_Clicked);

            // Disable close/minimuze buttons
            this.ControlBox = false;

            // Load user defaults settings
            loadDefaultSettings();

            // Initialize the log reader
            sasquatch = new HearthLogReader(
                logFileName,
                Properties.Settings.Default.hideNotifEnabled,
                Properties.Settings.Default.closeAllEnabled,
                Properties.Settings.Default.showHSEnabled,
                Properties.Settings.Default.autoFocusEnabled,
                Properties.Settings.Default.autoCloseDuration,
                Properties.Settings.Default.notifBgColor,
                Properties.Settings.Default.notifTextColor);
            sasquatch.getRolling();
            

        }

        private void loadDefaultSettings()
        {
            hideNotifCheckBox.Checked = Properties.Settings.Default.hideNotifEnabled;
            showHSCheckBox.Checked = Properties.Settings.Default.showHSEnabled;
            autoFocusCheckBox.Checked = Properties.Settings.Default.autoFocusEnabled;
            closeAllNotifCheckBox.Checked = Properties.Settings.Default.closeAllEnabled;
            durationBar.Value = Properties.Settings.Default.autoCloseDuration;
            notificationBackgroundColorPanel.BackColor = Properties.Settings.Default.notifBgColor;
            notificationTextColorPanel.BackColor = Properties.Settings.Default.notifTextColor;


            if (durationBar.Value == 0) this.durationLabel.Text = "Click to close";
            else if (durationBar.Value == 1) this.durationLabel.Text = durationBar.Value.ToString() + " second";
            else this.durationLabel.Text = durationBar.Value.ToString() + " seconds";

        }

        private void saveDefaultSettings()
        {
            Properties.Settings.Default.hideNotifEnabled = hideNotifCheckBox.Checked;
            Properties.Settings.Default.showHSEnabled = showHSCheckBox.Checked;
            Properties.Settings.Default.autoFocusEnabled = autoFocusCheckBox.Checked;
            Properties.Settings.Default.closeAllEnabled = closeAllNotifCheckBox.Checked;
            Properties.Settings.Default.autoCloseDuration = durationBar.Value;
            Properties.Settings.Default.notifBgColor = notificationBackgroundColorPanel.BackColor;
            Properties.Settings.Default.notifTextColor = notificationTextColorPanel.BackColor;

            this.sasquatch.updatePreferences(
                Properties.Settings.Default.hideNotifEnabled,
                Properties.Settings.Default.closeAllEnabled,
                Properties.Settings.Default.showHSEnabled,
                Properties.Settings.Default.autoFocusEnabled,
                Properties.Settings.Default.autoCloseDuration
                );

            Properties.Settings.Default.Save();
        }

        private void tabControl_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(e.ForeColor);
                Brush testBrush = new SolidBrush(ColorTranslator.FromHtml("#3399FF"));
                g.FillRectangle(testBrush, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                //e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)15.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void mainMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.mainMenuStrip.Show();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.mainMenuStrip.Show();
        }

        private void startTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            //Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void CasualStoneForm_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showForPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            applyButton.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void durationDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            saveDefaultSettings();
            Hide();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            saveDefaultSettings();
            this.applyButton.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void durationBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.applyButton.Enabled = true;
            if (durationBar.Value == 0) this.durationLabel.Text = "Forever ever";
            else if (durationBar.Value == 1) this.durationLabel.Text = durationBar.Value.ToString() + " second";
            else this.durationLabel.Text = durationBar.Value.ToString() + " seconds";

        }

        private void showHSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.applyButton.Enabled = true;
        }

        private void closeAllNotifCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.applyButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefaultSettings();
            Show();
        }

        private void notificationBackgroundColorPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void notificationBackgroundColorPanel_Clicked(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                notificationBackgroundColorPanel.BackColor = colorDialog.Color;
            }
        }

        private void notificationTextColorPanel_Clicked(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                notificationTextColorPanel.BackColor = colorDialog.Color;
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {

            var previewNotification = new Notification("Is your fridge running?", "start", durationBar.Value, closeAllNotifCheckBox.Checked, showHSCheckBox.Checked, notificationBackgroundColorPanel.BackColor, notificationTextColorPanel.BackColor);
            previewNotification.Show();
        }

        private void accountLabel_Click(object sender, EventArgs e)
        {

        }

        private void addUsernameButton_Click(object sender, EventArgs e)
        {
            string usernameInput = this.usernameTextBox.Text.Trim();
            if (usernameInput == "")
            {
                usernameErrorLabel.Text = "Username cannot be empty";
            } else
            {
                usernameListBox.Items.Add(usernameInput);
            }
        }

        private void accountTabPage_Click(object sender, EventArgs e)
        {

        }

        private void removeUsernameButton_Click(object sender, EventArgs e)
        {

            usernameListBox.Items.Remove(usernameListBox.SelectedItem);
        }

        private void clearUsernameButton_Click(object sender, EventArgs e)
        {
            usernameListBox.Items.Clear();
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
