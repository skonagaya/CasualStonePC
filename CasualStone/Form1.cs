using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        private WebClient tenenbaum;

        public CasualStoneForm()
        {
            InitializeComponent();
            //this.MaximumSize = this.MinimumSize = this.Size;

            // initialize username list
            if (Properties.Settings.Default.Usernames == null)
            {
                Properties.Settings.Default.Usernames = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            string logPath;
            string hearthstoneInstallPath;
            if (Properties.Settings.Default.hearthstoneInstallPath != "" &&
                Properties.Settings.Default.hearthstoneInstallPath != null)
            {
                hearthstoneInstallPath = Properties.Settings.Default.hearthstoneInstallPath;
            }
            else
            {
                string hearthstoneRegistryPath;
                if (userRunning64Bit())
                { // 64-bit
                    Console.WriteLine("Runtime detected 64-bit machine"); //logdis
                    hearthstoneRegistryPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Hearthstone";
                }
                else
                { // 32-bit
                    Console.WriteLine("Runtime detected non-64-bit machine. Assuming 32-bit machine"); //logdis
                    hearthstoneRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Hearthstone";
                }

                Console.WriteLine("Using registry path: " + hearthstoneRegistryPath); //logdis
                hearthstoneInstallPath = getHearthstoneInstallPath(hearthstoneRegistryPath);
                if (hearthstoneInstallPath == null || hearthstoneInstallPath == "")
                {
                    Console.WriteLine("Unable to locate Hearthstone install path using registries"); //logdis
                    hearthstoneInstallPathErrorLabel.Text = "Unable to auto-detect Hearthstone install path. Browse to path below.";
                    tabControl.SelectTab(settingsTabPage);
                    Show();
                } else
                {
                    Properties.Settings.Default.hearthstoneInstallPath = hearthstoneInstallPath;
                    Properties.Settings.Default.Save();
                }
            }

            logPath = hearthstoneInstallPath + @"\Logs";
            String logFileName = logPath + @"\Power.log";

            assertLogFile(logFileName, logPath);

            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            durationBar.ValueChanged +=  new System.EventHandler(durationBar_ValueChanged);
            notificationBackgroundColorPanel.Click += new System.EventHandler(notificationBackgroundColorPanel_Clicked);
            notificationTextColorPanel.Click += new System.EventHandler(notificationTextColorPanel_Clicked);
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            tenenbaum = new WebClient();
            tenenbaum.DownloadStringCompleted += DownloadDataCompleted;

            versionLabel.Text = "Copyright © Sean Konagaya. All Rights Reserved.\r\n\r\nVersion "+ getVersion()+ " | KONAGAYA.IO";

            // Prevent menustrip from closing after a selection is made
            gameStartToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            turnStartToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            concedeToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);

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
                Properties.Settings.Default.notifTextColor,
                Properties.Settings.Default.GAME_START,
                Properties.Settings.Default.TURN_START,
                Properties.Settings.Default.CONCEDE,
                Properties.Settings.Default.Usernames
                );
            sasquatch.getRolling();
            Hide();
        }

        // Initialize all the preference settings from properties default settings
        private void loadDefaultSettings()
        {

            usernameListBox.Items.Clear();
            foreach (string username in Properties.Settings.Default.Usernames)
            {
                usernameListBox.Items.Add(username);
            }

            hideNotifCheckBox.Checked = Properties.Settings.Default.hideNotifEnabled;
            showHSCheckBox.Checked = Properties.Settings.Default.showHSEnabled;
            autoFocusCheckBox.Checked = Properties.Settings.Default.autoFocusEnabled;
            closeAllNotifCheckBox.Checked = Properties.Settings.Default.closeAllEnabled;
            durationBar.Value = Properties.Settings.Default.autoCloseDuration;
            notificationBackgroundColorPanel.BackColor = Properties.Settings.Default.notifBgColor;
            notificationTextColorPanel.BackColor = Properties.Settings.Default.notifTextColor;

            hearthstoneInstallPathTextBox.Text = Properties.Settings.Default.hearthstoneInstallPath;

            // Set default check boxes on menu strip of the events captured from HS logs
            if      (Properties.Settings.Default.GAME_START == "Show for Player"  ) { showForPlayerToolStripMenuItem.Checked = true; }
            else if (Properties.Settings.Default.GAME_START == "Show for Opponent") { showForOpponentToolStripMenuItem.Checked = true; }
            else if (Properties.Settings.Default.GAME_START == "Show for Both"    ) { showForToolStripMenuItem.Checked = true; }
            else { noneToolStripMenuItem.Checked = true; }

            if      (Properties.Settings.Default.TURN_START == "Show for Player") { showForPlayerToolStripMenuItem1.Checked = true; }
            else if (Properties.Settings.Default.TURN_START == "Show for Opponent") { showForOpponentToolStripMenuItem1.Checked = true; }
            else if (Properties.Settings.Default.TURN_START == "Show for Both") { showForBothToolStripMenuItem.Checked = true; }
            else { noneToolStripMenuItem1.Checked = true; }

            if (Properties.Settings.Default.CONCEDE == "Show for Player") { showForPlayerToolStripMenuItem2.Checked = true; }
            else if (Properties.Settings.Default.CONCEDE == "Show for Opponent") { showForOpponentToolStripMenuItem2.Checked = true; }
            else if (Properties.Settings.Default.CONCEDE == "Show for Both") { showForBothToolStripMenuItem1.Checked = true; }
            else { noneToolStripMenuItem2.Checked = true; }



            if (durationBar.Value == 0) this.durationLabel.Text = "Forever ever";
            else if (durationBar.Value == 1) this.durationLabel.Text = durationBar.Value.ToString() + " second";
            else this.durationLabel.Text = durationBar.Value.ToString() + " seconds";

        }

        // called everytime user clicks apply or save on the prefernce page
        // This also propagates the settings to the notification delegate aka abominable snowman
        private void saveDefaultSettings()
        {


            Properties.Settings.Default.hideNotifEnabled = hideNotifCheckBox.Checked;
            Properties.Settings.Default.showHSEnabled = showHSCheckBox.Checked;
            Properties.Settings.Default.autoFocusEnabled = autoFocusCheckBox.Checked;
            Properties.Settings.Default.closeAllEnabled = closeAllNotifCheckBox.Checked;
            Properties.Settings.Default.autoCloseDuration = durationBar.Value;
            Properties.Settings.Default.notifBgColor = notificationBackgroundColorPanel.BackColor;
            Properties.Settings.Default.notifTextColor = notificationTextColorPanel.BackColor;

            if (hearthstoneInstallPathTextBox.Text != Properties.Settings.Default.hearthstoneInstallPath)
            {

                String logPath = hearthstoneInstallPathTextBox.Text + @"\Logs";
                String logFileName = logPath + @"\Power.log";

                assertLogFile(logFileName, logPath);
                Properties.Settings.Default.hearthstoneInstallPath = hearthstoneInstallPathTextBox.Text;
            }

            StringCollection temp = new StringCollection();
            foreach (string username in usernameListBox.Items) { temp.Add(username.Trim()); }

            Properties.Settings.Default.Usernames = temp;

            this.sasquatch.updatePreferences(
                Properties.Settings.Default.hearthstoneInstallPath+@"\Logs\Power.log",
                Properties.Settings.Default.hideNotifEnabled,
                Properties.Settings.Default.closeAllEnabled,
                Properties.Settings.Default.showHSEnabled,
                Properties.Settings.Default.autoFocusEnabled,
                Properties.Settings.Default.autoCloseDuration,
                Properties.Settings.Default.notifBgColor,
                Properties.Settings.Default.notifTextColor,
                Properties.Settings.Default.GAME_START,
                Properties.Settings.Default.TURN_START,
                Properties.Settings.Default.CONCEDE,
                Properties.Settings.Default.Usernames
                );

            Properties.Settings.Default.Save();
        }



        private void checkLogFile(String withName, String atPath)
        {
            // Create the logs folder if it ain't there
            if (!Directory.Exists(atPath))
            {
                try
                {
                    Directory.CreateDirectory(atPath);
                    Console.WriteLine("Successfully created log folder");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to create log folder");
                    Console.WriteLine(ex.ToString()); //logdis
                }
            }

            if (File.Exists(withName))
            {
                Console.WriteLine("Log file found"); //logdis
            }
            else // If the log file doesnt exist, create it
            {
                try
                {
                    File.Create(withName).Dispose();
                    if (processRunning("Hearthstone"))
                    {
                        MessageBox.Show("Hearthstone must be restarted in order to receive notifications.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to create log file");
                    Console.WriteLine(ex.ToString()); //logdis
                }
                Console.WriteLine("Successfully created log file:" + withName); //logdis
            }
        }

        private bool processRunning(string procName)
        {
            return System.Diagnostics.Process.GetProcessesByName(procName).Length > 0;
        }

        private void assertLogFile(String withLogName, String usingPath)
        {
            String logConfFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Blizzard\Hearthstone\log.config");

            Console.WriteLine("Checking for log configuration file: " + logConfFileName); //logdis
            checkLogConfFile(logConfFileName);
            Console.WriteLine("Checking for log file: " + withLogName); //logdis
            checkLogFile(withLogName, usingPath);
        }

        private bool userRunning64Bit()
        {
            return IntPtr.Size == 8;
        }

        // Look for the logfile directory in the Hearthstone directory.
        // If the Hearthstone install path is not found, assume that the executable was copied 
        private String getHearthstoneInstallPath(string registryPath)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("InstallLocation");
                        if (o != null)
                        {
                            Console.WriteLine(o as String);

                            return o as String;
                        }
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                Console.WriteLine("Unable to locate path for Hearthstone"); //logdis
                Console.WriteLine(ex.ToString()); //logdis
            }
            return null;
        }

        private void checkLogConfFile(String withName)
        {
            if (File.Exists(withName))
            {
                Console.WriteLine("Log configuration file found"); //logdis

                // Check to see if the conf file we found actually contains required settings
                if (File.ReadAllText(withName).Contains(@"[Power]"))
                {

                    Console.WriteLine("Log configuration file contains required [Power] settings"); //logdis
                }
                else
                {
                    try
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(withName))
                        {
                            file.WriteLine("[Power]");
                            file.WriteLine("FilePrinting=true");
                            file.WriteLine("ConsolePrinting=true");
                            file.WriteLine("ScreenPrinting=false");

                        }
                        Console.WriteLine("Successfully wrote to log configuration");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unable to write to log configuration");
                        Console.WriteLine(ex.ToString()); //logdis
                    }
                }
            }
            else //If the conf file doesn't exist, create it with the required settings.
            {
                Console.WriteLine("Log configuration file is missing"); //logdis

                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(withName))
                    {
                        file.WriteLine("[Power]");
                        file.WriteLine("FilePrinting=true");
                        file.WriteLine("ConsolePrinting=true");
                        file.WriteLine("ScreenPrinting=false");
                    }
                    Console.WriteLine("Successfully created log configuration");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to create log configuration file: " + withName);
                    Console.WriteLine(ex.ToString()); //logdis
                }

            }
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
            //this.mainMenuStrip.Show();
        }

        private void startTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            ShowInTaskbar = true; // Remove from taskbar.
            //Visible = false; // Hide form window.

            base.OnLoad(e);
            //this.Visible = false;
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
            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForOpponentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void radioClickMenuItem(ToolStripMenuItem sender)
        {
            // User must provide at least one valid username before using this setting
            // Redirect them to the username configuration form
            if ((sender.Text == "Show for Player" || sender.Text == "Show for Opponent") &&
                (Properties.Settings.Default.Usernames.Count < 1))
            {
                Show();
                tabControl.SelectTab(accountTabPage);
                usernameErrorLabel.Text = "At least one valid username required to set \"" + sender.Text + "\"";
                sender.Checked = false;
            }
            else
            {
                foreach (ToolStripMenuItem sibling in sender.GetCurrentParent().Items)
                {
                    sibling.Checked = false;
                }
                sender.Checked = true;
                saveNotificationSetting(sender.OwnerItem.Text, sender.Text);
            }
        }

        private void saveNotificationSetting(string eventName, string filterName)
        {
            if      (eventName == "Game Start") { Properties.Settings.Default.GAME_START = filterName; }
            else if (eventName == "Turn Start") { Properties.Settings.Default.TURN_START = filterName; }
            else if (eventName == "Concede") { Properties.Settings.Default.CONCEDE = filterName; }
            else { Console.WriteLine(eventName + " is not one of the events that we use."); /*//logdis*/ }
            Properties.Settings.Default.Save();
            this.sasquatch.updatePreferences(
                Properties.Settings.Default.hearthstoneInstallPath + @"\Logs\Power.log",
                Properties.Settings.Default.hideNotifEnabled,
                Properties.Settings.Default.closeAllEnabled,
                Properties.Settings.Default.showHSEnabled,
                Properties.Settings.Default.autoFocusEnabled,
                Properties.Settings.Default.autoCloseDuration,
                Properties.Settings.Default.notifBgColor,
                Properties.Settings.Default.notifTextColor,
                Properties.Settings.Default.GAME_START,
                Properties.Settings.Default.TURN_START,
                Properties.Settings.Default.CONCEDE,
                Properties.Settings.Default.Usernames
                );
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
            // If username is emptied, revert filters to "Show for Both" or "None" to prevent unexpected behaviors
            if (Properties.Settings.Default.Usernames.Count > 0 && usernameListBox.Items.Count < 1)
            {
                DialogResult dresult = MessageBox.Show("Username list is now empty.\r\n\r\nClick OK to reverting notifications to \"Show for Both\".", "Philistine Philter"
                                              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dresult != DialogResult.OK)
                {
                    return;
                }
            }
            saveDefaultSettings();
            Hide();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            // If username is emptied, revert filters to "Show for Both" or "None" to prevent unexpected behaviors
            if (Properties.Settings.Default.Usernames.Count > 0 && usernameListBox.Items.Count < 1)
            {
                DialogResult dresult = MessageBox.Show("Username list is now empty.\r\n\r\nClick OK to reverting notifications to \"Show for Both\".", "Philistine Philter"
                                              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dresult != DialogResult.OK)
                {
                    return;
                }
            }
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
            applyButton.Enabled = false;
            Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefaultSettings();
            applyButton.Enabled = false;
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
            this.applyButton.Enabled = true;
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
            this.applyButton.Enabled = true;
            usernameListBox.Items.Remove(usernameListBox.SelectedItem);
            if (usernameListBox.Items.Count < 1)
            {
                if (autoFocusCheckBox.Checked)
                {
                    usernameErrorLabel.Text = "Auto-focus on turn start has been unchecked on Preference Tab";
                    autoFocusCheckBox.Checked = false;
                }
            }
        }

        private void clearUsernameButton_Click(object sender, EventArgs e)
        {
            this.applyButton.Enabled = true;
            usernameListBox.Items.Clear();
            if (usernameListBox.Items.Count < 1)
            {
                if (autoFocusCheckBox.Checked)
                {
                    usernameErrorLabel.Text = "Auto-focus on turn start has been unchecked";
                    autoFocusCheckBox.Checked = false;
                }
            }
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {

        }

        private void updatesTabPage_Click(object sender, EventArgs e)
        {
        }
        private void tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            usernameErrorLabel.Text = "";
            preferenceErrorLabel.Text = "";
            hearthstoneInstallPathErrorLabel.Text = "";
            if ((sender as TabControl).SelectedTab.Text == "Updates")
            {
                tenenbaum.DownloadStringAsync(new System.Uri("https://raw.githubusercontent.com/skonagaya/CasualStonePC/master/CasualStone/Properties/AssemblyInfo.cs"));
            }
        }
        private void DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string assemblyContent = e.Result;
            Regex regex = new Regex(@"AssemblyFileVersion.*");
            Match match = regex.Match(assemblyContent);
            if (match.Success)
            {
                Regex versionFormat = new Regex("[0-9].[0-9].[0-9].[0-9]");
                Match versionMatch = versionFormat.Match(match.Value);
                if (versionMatch.Success)
                {
                    Console.WriteLine("Online version is: " + versionMatch.Value); //logdis
                    Console.WriteLine("Local  version is: " + getVersion()); //logdis
                    
                    if (versionMatch.Value == getVersion())
                    {
                        updatePictureBox.Image = global::CasualStone.Properties.Resources.check;
                        updateLabel.Text = "CasualStone is up-to-date";
                    } else 
                    {
                        updatePictureBox.Image = global::CasualStone.Properties.Resources.info;
                        updateLabel.Text = "Newer version available.\r\n\r\n\r\nClick the link below:";
                        updateLinkLabel.Text = "https://github.com/skonagaya/CasualStonePC/releases";
                    }
                }
            }
        }
        private string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        private void autoFocusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (usernameListBox.Items.Count < 1)
            {
                autoFocusCheckBox.Checked = false;
                preferenceErrorLabel.Text = "Username required. Click Accounts tab on the left.";
            } else
            {
                this.applyButton.Enabled = true;
            }
        }
        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        private void showForToolStripMenuItem_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForOpponentToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForBothToolStripMenuItem_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForPlayerToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForOpponentToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void showForBothToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            tabControl.SelectTab(aboutTabPage);
        }

        private void versionLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void noneToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void noneToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            radioClickMenuItem((ToolStripMenuItem)sender);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void hearthstoneInstallPathDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void browseInstallPathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = hearthstoneInstallPathDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(hearthstoneInstallPathDialog.SelectedPath))
            {
                hearthstoneInstallPathTextBox.Text = hearthstoneInstallPathDialog.SelectedPath;

            }
        }
    }
}
