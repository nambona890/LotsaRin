﻿using System;
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

namespace LotsaRin
{
    public partial class Form2 : Form
    {
        private static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private static int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private PointF flocation = new PointF((float)0, (float)0);
        private int angleind;
        public Form2(int angle)
        {
            InitializeComponent();
            pictureBox1.Location = new Point(0, 0);
            this.Size = new Size(Convert.ToInt32((screenHeight * ((double)Properties.Resources.rin.Width / (double)Properties.Resources.rin.Height)) / 4.0), Convert.ToInt32(screenHeight / 4.0));
            pictureBox1.Size = this.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.rin;
            this.angleind = angle;
        }
        private System.Timers.Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = Convert.ToInt32(1000.0/60.0);
            timer.Elapsed += Speen;
            timer.AutoReset = true;
            timer.Enabled = true;
            this.TopMost = true;
        }

        private void Speen(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                double angle = (Math.PI * (angleind / 4.0))+Program.angle;
                flocation.X = Convert.ToSingle((Math.Sin(angle) * ((screenWidth - (this.Width / 2.0)) / 3.0)) + (screenWidth / 2.0) - (this.Width / 2));
                flocation.Y = Convert.ToSingle((Math.Cos(angle) * ((screenHeight - (this.Height / 2.0)) / 3.0)) + (screenHeight / 2.0) - (this.Height / 2));
                this.Invoke(new Action(() => { this.Location = Point.Round(flocation); }));
                timer.Enabled = true;
            }
            catch
            {

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Process.GetCurrentProcess()).Kill();
        }
    }
}
