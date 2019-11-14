using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Timers;
using System.Diagnostics;

namespace AThing
{
    public partial class Form1 : Form
    {
        private static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private static int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private float xSpeed = 0;
        private float ySpeed = 0;
        private PointF flocation = new PointF((float)0, (float)0);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Location = new Point(0, 0);
            this.Size = new Size(Convert.ToInt32((screenHeight * ((double)Properties.Resources.rin.Width / (double)Properties.Resources.rin.Height)) / 4.0), Convert.ToInt32(screenHeight / 4.0));
            pictureBox1.Size = this.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.rin;
            Program.random.Next();
            this.Location = new Point(Program.random.Next(screenWidth - this.Width), Program.random.Next(screenHeight - this.Height));
            flocation = this.Location;
            xSpeed = Convert.ToSingle(5 + Program.random.NextDouble() * 20);
            ySpeed = Convert.ToSingle(5 + Program.random.NextDouble() * 20);
        }
        private System.Timers.Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = Convert.ToInt32(1000.0/60.0);
            timer.Elapsed += Bounce;
            timer.AutoReset = true;
            timer.Enabled = true;
            this.TopMost = true;
        }

        private void Bounce(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                if (((flocation.X + xSpeed) + this.Width > screenWidth && xSpeed > 0) || ((flocation.X + xSpeed) < 0 && xSpeed < 0))
                {
                    xSpeed *= -1;
                }
                if (((flocation.Y + ySpeed) + this.Height > screenHeight && ySpeed > 0) || ((flocation.Y + ySpeed) < 0 && ySpeed < 0))
                {
                    ySpeed *= -1;
                }
                flocation.X += xSpeed;
                flocation.Y += ySpeed;
                this.Invoke(new Action(() => { this.Location = Point.Round(flocation); }));
                timer.Enabled = true;
            }
            catch
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Process.GetCurrentProcess()).Kill();
        }
    }
}
