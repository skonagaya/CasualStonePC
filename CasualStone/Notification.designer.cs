using System.Drawing;

namespace ToastNotifications
{
    partial class Notification
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
        private void InitializeComponent(string imageName, Color bgColor, Color txtColor)
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = bgColor;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = txtColor;
            this.labelTitle.Location = new System.Drawing.Point(161, 48);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(324, 47);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "title goes here";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // iconBox
            // 
            this.iconBox.BackColor = bgColor;
            this.iconBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("warning.Image")));
            this.iconBox.Image = ((System.Drawing.Image)(resources.GetObject(imageName)));
            this.iconBox.Location = new System.Drawing.Point(5, 5);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(134, 134);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 1;
            this.iconBox.TabStop = false;
            this.iconBox.Click += new System.EventHandler(this.iconBox_Click);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = bgColor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 144);
            this.ControlBox = false;
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.labelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Notification";
            //this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Look away. Nothing to see here.";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notification_FormClosed);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Notification_Click);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox iconBox;
    }
}