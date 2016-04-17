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
            String checkpoint;
            var toastNotification1 = new Notification("", "", 0, Properties.Settings.Default.closeAllEnabled, Properties.Settings.Default.showHSEnabled, Properties.Settings.Default.notifBgColor, Properties.Settings.Default.notifTextColor);

            String hearthStoneInstallPath = getHearthstoneInstallPath();
            String logPath = hearthStoneInstallPath + @"\Logs";
            String logFileName = logPath + @"\Power.log";

            assertLogFile(logFileName, logPath);


            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CasualStoneForm(logFileName));
        }
        

        static void checkLogFile(String withName, String atPath)
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to create log file");
                    Console.WriteLine(ex.ToString()); //logdis
                }
                Console.WriteLine("Successfully created log file:" + withName); //logdis
            }
        }

        static void assertLogFile(String withLogName, String usingPath)
        {
            String logConfFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Blizzard\Hearthstone\log.config");

            Console.WriteLine("Checking for log configuration file: " + logConfFileName); //logdis
            checkLogConfFile(logConfFileName);
            Console.WriteLine("Checking for log file: " + withLogName); //logdis
            checkLogFile(withLogName, usingPath);
        }



        // Look for the logfile directory in the Hearthstone directory.
        // If the Hearthstone install path is not found, assume that the executable was copied 
        static String getHearthstoneInstallPath()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Hearthstone"))
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

        static void checkLogConfFile(String withName)
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

    private System.Drawing.Color bgColor;
    private System.Drawing.Color txtColor;

    private BackgroundWorker bgLogReader;
    //private static List<Notification> openNotifications = new List<Notification>();

    // The constructor obtains the state information and the
    // callback delegate.
    public HearthLogReader(string logFileName, bool hideNotifEnabled, bool closeAllNotifEnabled, bool showHSEnabled, bool autoFocusHSEnabled, int notifDuration, System.Drawing.Color bgColor, System.Drawing.Color txtColor)
    {
        this.logFileName = logFileName;
        this.hideNotifEnabled = hideNotifEnabled;
        this.closeAllNotifEnabled = closeAllNotifEnabled;
        this.showHSEnabled = showHSEnabled;
        this.autoFocusHSEnabled = autoFocusHSEnabled;
        this.notifDuration = notifDuration;
        this.bgColor = bgColor;
        this.txtColor = txtColor;

        bgLogReader = new BackgroundWorker();

        // Create a background worker thread that ReportsProgress &
        // SupportsCancellation
        // Hook up the appropriate events.
        bgLogReader.DoWork += new DoWorkEventHandler(startReader);
        bgLogReader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(queueReader);
        bgLogReader.WorkerSupportsCancellation = true;

    }

    public void updatePreferences(bool hideNotifEnabled, bool closeAllNotifEnabled, bool showHSEnabled, bool autoFocusHSEnabled, int notifDuration)
    {
        this.hideNotifEnabled = hideNotifEnabled;
        this.closeAllNotifEnabled = closeAllNotifEnabled;
        this.showHSEnabled = showHSEnabled;
        this.autoFocusHSEnabled = autoFocusHSEnabled;
        this.notifDuration = notifDuration;
    }

    public void getRolling()
    {
        Console.Write("Waiting for Hearthstone to start in order to start polling logs"); //logdis
        bgLogReader.RunWorkerAsync(this.logFileName);
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

            //TODO catch response array null case

            string text = "";
            string imageName = "";
            switch (results[0])
            {
                case "CREATE_GAME":
                    text = "Game is starting...";
                    imageName = "start";
                    break;
                case "CONCEDE":
                    text = results[1] + " conceded";
                    imageName = "concede";
                    break;
                case "START_TURN":
                    text = results[1] + "'s turn";
                    imageName = "turn";
                    break;
                default:
                    Console.WriteLine("Call back got an event that's not mapped. This should never happen"); //logdis
                    text = "Error occured";
                    imageName = "warning";
                    break;
            }
            if (!this.hideNotifEnabled || (this.hideNotifEnabled && !processIsFocused("Hearthstone")))
            {
                var toastNotification = new Notification(text, imageName, this.notifDuration, this.closeAllNotifEnabled, this.showHSEnabled, this.bgColor, this.txtColor);
                toastNotification.Show();
            }
        }
        
        bgLogReader.RunWorkerAsync(this.logFileName);

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

                                String[] responseArray = { "START_TURN", usernameTrimmed };
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

                                String[] responseArray = { "START_TURN", usernameTrimmed };
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

                            String[] responseArray = { "CONCEDE", usernameTrimmed };
                            e.Result = responseArray;
                            return;

                        }
                        // Look for create games and send it to constructor
                        else if (line.Contains("CREATE_GAME"))
                        {
                            String[] responseArray = { "CREATE_GAME", "" };
                            e.Result = responseArray;
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