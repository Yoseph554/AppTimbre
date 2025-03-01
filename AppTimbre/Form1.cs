using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace AppTimbre
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        private string soundFilePath = @"C:\Users\HP\Music\bell.mp3";

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 60000; // Chequear cada minuto
            timer.Elapsed += CheckTime;
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La aplicación está activa y tocará el timbre según lo esperado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CheckTime(null, null);
        }

        private void CheckTime(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("HH:mm");

            if (now.DayOfWeek == DayOfWeek.Friday)
            {
                if ((currentTime == "07:00" || currentTime == "09:00" || currentTime == "09:20" ||
                     currentTime == "12:00" || currentTime == "12:15"))
                {
                    PlayBellSound();
                }
                else if ((currentTime == "12:15" || currentTime == "12:50" ||
                          currentTime == "13:25" || currentTime == "14:00" ||
                          currentTime == "14:35" || currentTime == "14:55" ||
                          currentTime == "15:30" || currentTime == "16:05" ||
                          currentTime == "16:40" || currentTime == "17:15"))
                {
                    PlayBellSound();
                }
            }
            else
            {
                if (currentTime == "07:00" || currentTime == "09:00" || currentTime == "09:20" ||
                    currentTime == "12:00" || currentTime == "12:15" || currentTime == "12:55" ||
                    currentTime == "13:35" || currentTime == "14:15" || currentTime == "14:35" ||
                    currentTime == "15:15" || currentTime == "15:55" || currentTime == "16:35" ||
                    currentTime == "17:15")
                {
                    PlayBellSound();
                }
            }
        }

        private void PlayBellSound()
        {
            try
            {
                using (var outputDevice = new WaveOutEvent())
                using (var audioFile = new AudioFileReader(soundFilePath))
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayBellSound();
        }
    }
}
