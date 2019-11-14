using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace LotsaRin
{
    public partial class SoundStuff : Form
    {
        public SoundStuff()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void SoundStuff_Load(object sender, EventArgs e)
        {

            this.Size = new Size(0, 0);

            MemoryStream parity = new MemoryStream(Properties.Resources.parity);
            Mp3FileReader mp3reader = new Mp3FileReader(parity);
            WaveOutEvent waveout = new WaveOutEvent();
            waveout.Init(mp3reader);
            waveout.Play();
        }

        private void SoundStuff_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Process.GetCurrentProcess()).Kill();
        }
    }
}
