// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ToastNotifications
{
    public partial class Notification : Form
    {
        private static List<Notification> openNotifications = new List<Notification>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="duration"></param>
        /// <param name="animation"></param>
        /// <param name="direction"></param>
        public Notification(string body, string imageName,  int duration)
        {
            InitializeComponent(imageName);


            if (duration < 0)
                duration = int.MaxValue;
            else
                duration = duration * 1000;

            lifeTimer.Interval = duration;
            labelTitle.Text = body;

            _animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Left, 500);
            //System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            //Region = Region.
            //Region = Region.FromHrgn(new IntPtr())

            //Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();


            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(   Screen.PrimaryScreen.WorkingArea.Width - Width - 10,
                                    10
                                    );

            // Move each open form downwards  to make room for this one
            foreach (Notification openForm in openNotifications)
            {
                openForm.Top += Height + 10;
            }

            openNotifications.Add(this);
            lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Right;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in openNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are above this one
                    break;
                }
                openForm.Top -= Height;
            }

            openNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelRO_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion // Event Handlers


        private void iconBox_Click(object sender, EventArgs e)
        {
            Console.WriteLine("clicked on the iconbox");
            FocusProcess("Hearthstone");
            Close();
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
        
    }
}