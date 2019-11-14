using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace LotsaRin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread[] threads1 = new Thread[8];
            for (int i = 0; i < threads1.Length; i++)
            {
                threads1[i] = new Thread(RunApp1);
                threads1[i].Start();
            }
            Thread[] threads2 = new Thread[8];
            for (int i = 0; i < threads2.Length; i++)
            {
                threads2[i] = new Thread( () => RunApp2(i) );
                threads2[i].Start();
                Thread.Sleep(50);
            }
            timer = new System.Timers.Timer();
            timer.Interval = Convert.ToInt32(1000.0 / 120.0);
            timer.Elapsed += Speen;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        static System.Timers.Timer timer;

        public static double angle = 0;
        public static Random random = new Random();
        static void RunApp1()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static void RunApp2(int angle)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2(angle));
        }
        static void Speen(object source, System.Timers.ElapsedEventArgs e)
        {
            angle += 0.05;
        }

    }
}
