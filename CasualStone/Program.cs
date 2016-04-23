using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using ToastNotifications;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Drawing;

namespace CasualStone
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var toastNotification1 = new Notification("", "", 0, Properties.Settings.Default.closeAllEnabled, Properties.Settings.Default.showHSEnabled, Properties.Settings.Default.notifBgColor, Properties.Settings.Default.notifTextColor);



            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new CasualStoneForm());
        }
        
    }
}




public class HearthLogReader
{
    // State information used in the task.
    private string logFileName;

    private bool hideNotifEnabled;
    private bool closeAllNotifEnabled;
    private bool showHSEnabled;
    private bool autoFocusHSEnabled;
    private int notifDuration;
    private int usernameMissCount;

    private bool spectatorModeEnabled;

    private string gameStartFilter;
    private string turnStartFilter;
    private string concedeFilter;

    private StringCollection usernames;

    private System.Drawing.Color bgColor;
    private System.Drawing.Color txtColor;

    private BackgroundWorker bgLogReader;
    //private static List<Notification> openNotifications = new List<Notification>();

    // The constructor obtains the state information and the
    // callback delegate.
    public HearthLogReader(
        string logFileName, 
        bool hideNotifEnabled, 
        bool closeAllNotifEnabled, 
        bool showHSEnabled, 
        bool autoFocusHSEnabled, 
        int notifDuration, 
        Color bgColor, 
        Color txtColor,
        string gameStartFilter,
        string turnStartFilter,
        string concedeFilter,
        StringCollection usernames
        )
    {
        this.logFileName = logFileName;
        this.hideNotifEnabled = hideNotifEnabled;
        this.closeAllNotifEnabled = closeAllNotifEnabled;
        this.showHSEnabled = showHSEnabled;
        this.autoFocusHSEnabled = autoFocusHSEnabled;
        this.notifDuration = notifDuration;
        this.bgColor = bgColor;
        this.txtColor = txtColor;

        this.gameStartFilter = gameStartFilter;
        this.turnStartFilter = turnStartFilter;
        this.concedeFilter = concedeFilter;

        this.spectatorModeEnabled = false;

        this.usernames = usernames;

        bgLogReader = new BackgroundWorker();

        // We tally the number of times an event occured that requires a username.
        // If the number of miss count reaches 2, we know each player in a game had played a turn
        // and that the username that is saved in the casualstone settings is invalid
        // We then throw an appropriate error.
        usernameMissCount = 0;

        // Create a background worker thread that ReportsProgress &
        // SupportsCancellation
        // Hook up the appropriate events.
        bgLogReader.DoWork += new DoWorkEventHandler(startReader);
        bgLogReader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(queueReader);
        bgLogReader.WorkerSupportsCancellation = true;

    }

    public void updatePreferences(
        string logFileName,
        bool hideNotifEnabled, 
        bool closeAllNotifEnabled, 
        bool showHSEnabled, 
        bool autoFocusHSEnabled, 
        int notifDuration,
        Color bgColor,
        Color txtColor,
        string gameStartFilter,
        string turnStartFilter,
        string concedeFilter,
        StringCollection usernames
        )
    {
        this.logFileName = logFileName;
        this.hideNotifEnabled = hideNotifEnabled;
        this.closeAllNotifEnabled = closeAllNotifEnabled;
        this.showHSEnabled = showHSEnabled;
        this.autoFocusHSEnabled = autoFocusHSEnabled;
        this.notifDuration = notifDuration;

        this.bgColor = bgColor;
        this.txtColor = txtColor;

        this.gameStartFilter = gameStartFilter;
        this.turnStartFilter = turnStartFilter;
        this.concedeFilter = concedeFilter;

        this.usernames = usernames;

    }

    public void getRolling()
    {
        Console.Write("Waiting for Hearthstone to start in order to start polling logs"); //logdis
        bgLogReader.RunWorkerAsync(this.logFileName);
    }


    private bool showNotification(string eventName, string userName, bool focusTurn)
    {
        bool showNotification = false;
        List<String> usernameList = this.usernames.Cast<String>().ToList();
        switch (eventName)
        {
            case "Show for Player":
                if (usernameList.Contains(userName.Trim(), StringComparer.OrdinalIgnoreCase))
                {
                    if (focusTurn) { FocusProcess("Hearthstone"); }
                    this.spectatorModeEnabled = false;
                    showNotification = true;
                    this.usernameMissCount = 0;
                } else { this.usernameMissCount++; }
                break;
            case "Show for Opponent":
                if (usernameList.Contains(userName.Trim(), StringComparer.OrdinalIgnoreCase))
                {
                    if (focusTurn) { FocusProcess("Hearthstone"); }
                    this.usernameMissCount = 0;
                    this.spectatorModeEnabled = false;

                } else
                {
                    this.usernameMissCount++;
                    showNotification = true;
                }
                break;
            case "Show for Both":
                showNotification = true;
                break;
            case "None":
                showNotification = false;
                break;
            default:
                showNotification = false;
                Console.WriteLine("Event: \"" + eventName + "\"  doesn't map to anything"); //logdis
                break;
        }
        return showNotification;
    }

    /// <summary>
    /// On completed do the appropriate task
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void queueReader(object sender, RunWorkerCompletedEventArgs e)
    {
        string[] results = (string[])e.Result;
        if (results != null)
        {
            Console.WriteLine(results[0] + ": " + results[1]);
            Console.WriteLine("gameStartFilter: " + gameStartFilter);
            Console.WriteLine("turnStartFilter: " + turnStartFilter);
            Console.WriteLine("concedefilter: " + concedeFilter);

            string eventFilter = results[0]; // let's assume results[1] is the username

            //TODO catch response array null case //logdis

            if (spectatorModeEnabled) Console.WriteLine("Spectator mode detected. Notifications supressed."); //logdis

            string text = "";
            string imageName = "";
            bool eventEnabled = true;
            switch (eventFilter)
            {
                case "Game Start":

                    this.usernameMissCount = 0;

                    if (this.gameStartFilter == "None") eventEnabled = false;
                    else
                    {
                        text = "Game is starting..."; imageName = "start";
                    }
                    break;
                case "Concede":
                    eventEnabled = showNotification(this.concedeFilter, results[1], false);
                    text = results[1] + " conceded"; imageName = "concede";
                    break;
                case "Turn Start":
                    eventEnabled = showNotification(this.turnStartFilter, results[1], this.autoFocusHSEnabled);
                    text = results[1] + "'s turn"; imageName = "turn";
                    break;
                default:
                    Console.WriteLine("Call back got an event that's not mapped. This should never happen"); //logdis
                    text = "Error occured";
                    imageName = "warning";
                    break;
            }
            if (this.usernameMissCount > 2)
            {
                var warningNotification = new Notification("User not found. Set up in Settings.", "warning1", this.notifDuration, this.closeAllNotifEnabled, this.showHSEnabled, this.bgColor, this.txtColor);
                warningNotification.Show();

            }
            else if (!spectatorModeEnabled && eventEnabled && (!this.hideNotifEnabled || (this.hideNotifEnabled && !processIsFocused("Hearthstone"))))
            {
                var toastNotification = new Notification(text, imageName, this.notifDuration, this.closeAllNotifEnabled, this.showHSEnabled, this.bgColor, this.txtColor);
                toastNotification.Show();
            }
        }
        
        bgLogReader.RunWorkerAsync(this.logFileName);

    }

    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr WindowHandle);
    public const int SW_RESTORE = 9;
    private void FocusProcess(string procName)
    {
        Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName(procName); if (objProcesses.Length > 0)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = objProcesses[0].MainWindowHandle;
            ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
            SetForegroundWindow(objProcesses[0].MainWindowHandle);
        }
    }

    private bool processRunning(string procName)
    {
        return System.Diagnostics.Process.GetProcessesByName(procName).Length > 0;
    }

    private bool processIsFocused(string procName)
    {

        IntPtr hWnd = GetForegroundWindow();
        uint procId = 0;
        GetWindowThreadProcessId(hWnd, out procId);
        var proc = Process.GetProcessById((int)procId);
        return proc.MainModule.ToString().Contains(procName);
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// Time consuming operations go here </br>
    /// i.e. Database operations,Reporting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void startReader(object sender, DoWorkEventArgs e)
    {
        try
        {
            if (!processRunning("Hearthstone"))
            {
                System.Threading.Thread.Sleep(3000);
                Console.Write(".");
                this.spectatorModeEnabled = false;
                this.usernameMissCount = 0;
                return;
            } else
            {
                Console.WriteLine("");
                Console.WriteLine("Found Hearthstone. Starting StreamReader.");
            }
            using (StreamReader reader = new StreamReader(new FileStream(this.logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //start at the end of the file
                long lastMaxOffset = reader.BaseStream.Length;
                bool waitingForNextLine = false; // Used to wait for next line from stream in case of IO latency

                while (true)
                {
                    //Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                    //Console.Write("!");

                    if (!processRunning("Hearthstone"))
                    {
                        Console.WriteLine("Hearthstone process was not found");
                        return;
                    }


                    //if the file size has not changed, idle
                    if (reader.BaseStream.Length == lastMaxOffset)
                    {
                        continue;
                    }else if (reader.BaseStream.Length < lastMaxOffset)
                    {
                        Console.WriteLine("Setting new offset because log file was truncated"); //logdis
                        lastMaxOffset = 0;//reader.BaseStream.Length;
                        this.usernameMissCount = 0;
                        this.spectatorModeEnabled = false;
                    }

                    //seek to the last max offset
                    reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                    //read out of the file until the EOF
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.Contains("GameState.DebugPrintPower")) { continue; }
                        //Console.WriteLine(line);
                        // This is the Hard Coded stuff that you'll spend most of the time
                        // The moment Hearthstone devs changes the Log output, we're doomed

                        // Parse of next turns
                        if (line.Contains("TAG_CHANGE Entity=GameEntity tag=STEP value=MAIN_READY"))
                        {
                            waitingForNextLine = true;
                            line = reader.ReadLine();

                            // We are expecting the username to be in the next line
                            // If this is null, that means there is IO latency
                            // So we pass till we get the next line
                            if (line == null)
                            {
                                continue;
                            }
                            // Next line contains the username
                            if (line.Contains("ACTION_START BlockType=TRIGGER Entity="))
                            {
                                waitingForNextLine = false;
                                // Snip out everything surrounding the Username
                                string pattern = "(.*Entity=)|( Effect.*)";
                                string usernameTrimmed = Regex.Replace(line, pattern, "");

                                String[] responseArray = { "Turn Start", usernameTrimmed };
                                e.Result = responseArray;
                                return;
                            }
                        }
                        // If this is reached, it means there was IO latency last iteration start turn
                        else if (waitingForNextLine)
                        {
                            waitingForNextLine = false;
                            if (line.Contains("ACTION_START BlockType=TRIGGER Entity="))
                            {
                                // Snip out everything surrounding the Username
                                string pattern = "(.*Entity=)|( Effect.*)";
                                string usernameTrimmed = Regex.Replace(line, pattern, "");

                                String[] responseArray = { "Turn Start", usernameTrimmed };
                                e.Result = responseArray;
                                return;
                            }
                        }
                        // Look for concede lines and send back username to constructor
                        else if (line.Contains("tag=PLAYSTATE value=CONCEDED"))
                        {
                            // Snip out everything surrounding the Username
                            string pattern = "(.*Entity=)|(tag=PLAYSTATE.*)";
                            string usernameTrimmed = Regex.Replace(line, pattern, "");

                            String[] responseArray = { "Concede", usernameTrimmed };
                            e.Result = responseArray;
                            return;

                        }
                        // Look for create games and send it to constructor
                        else if (line.Contains("CREATE_GAME"))
                        {
                            String[] responseArray = { "Game Start", "" };
                            e.Result = responseArray;
                            return;
                        }
                        // Look for create games and send it to constructor
                        else if (line.Contains("Begin Spectating"))
                        {
                            this.spectatorModeEnabled = false;
                            return;
                        }
                        // Look for create games and send it to constructor
                        else if (line.Contains("End Spectator"))
                        {
                            this.spectatorModeEnabled = false;
                            return;
                        }
                    }

                    //update the last max offset
                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unable to read log file"); //logdis
            Console.WriteLine(ex.ToString());
        }
    }
}