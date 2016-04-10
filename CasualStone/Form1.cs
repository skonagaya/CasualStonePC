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

namespace CasualStone
{
    public partial class CasualStoneForm : Form
    {
        public CasualStoneForm()
        {
            InitializeComponent();
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
            Visible = false; // Hide form window.
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


    }
}
