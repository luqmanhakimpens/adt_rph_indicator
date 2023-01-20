using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using timer_and_counter.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace timer_and_counter
{
    public partial class Form1 : Form
    {
        String appVersion = "v1.1";
        DateTime tt;
        DateTime timerLastDecision;
        DateTime timerTotalReview;
        DateTime startTime;
        DateTime timerDecision;
        
        TimeSpan td,last_td;

        private static System.Timers.Timer aTimer;

        bool timerRunning = false, timerstarted = false;
        
        UInt32 submitted,skipped;
        double adt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelVersion.Text = appVersion;
            timer1.Stop();
            SetTimer();

            timerDecision = Settings.Default.timeDecision;
            timerTotalReview = Settings.Default.timeReview;
            timerLastDecision = Settings.Default.timeLastDecision;
            skipped = Settings.Default.skip;
            submitted = Settings.Default.submit;
            adt = Settings.Default.adt;

            textBoxTimerDecision.Text = timerDecision.TimeOfDay.ToString();
            textBoxSubmitted.Text = submitted.ToString();
            textBoxSkipped.Text = skipped.ToString();
            textBoxAdt.Text = adt.ToString();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Stop();
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //tt = tt.AddSeconds(1);
            //timerDecision = timerDecision.AddSeconds(1);

            TimeSpan timediff = DateTime.Now - startTime;
            startTime = DateTime.Now;
            timerDecision = timerDecision.Add(timediff);

            Console.Write(timediff.ToString());
            Console.Write(" - ");
            Console.WriteLine(timerDecision.TimeOfDay.ToString());
            //Console.WriteLine("t  = {0:HH:mm:ss.fff}", timerDecision);

            if (textBoxTimerDecision.InvokeRequired)
            {
                textBoxTimerDecision.BeginInvoke(new MethodInvoker(() => textBoxTimerDecision.Text = timerDecision.TimeOfDay.ToString()));
            }
            save_state();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timerDecision = timerDecision.AddSeconds(1);

            DateTime now = DateTime.Now;
            TimeSpan timediff = now - startTime;
            timerDecision = timerDecision.Add(timediff);
            textBoxTimerDecision.Text = timerDecision.TimeOfDay.ToString();
            
            save_state();
        }


        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!timerRunning)
            {
                //timer1.Start();
                //if(timerstarted)
                startTime = DateTime.Now;
                aTimer.Start();
                timerRunning = true;
                buttonStartStop.BackgroundImage = global::timer_and_counter.Properties.Resources.pause_icon;
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Unlock.wav");
                simpleSound.Play();
            }
            else
            {
                //timer1.Stop();
                last_td = td;
                aTimer.Stop();
                timerRunning = false;
                buttonStartStop.BackgroundImage = global::timer_and_counter.Properties.Resources.play_icon;
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Pop-up Blocked.wav");
                simpleSound.Play();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Reset?", "Reset?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                timerTotalReview = timerDecision = DateTime.MinValue;
                textBoxTimerDecision.Text = timerTotalReview.TimeOfDay.ToString();

                adt = 0;
                textBoxAdt.Text = adt.ToString();

                submitted = skipped = 0;
                textBoxSkipped.Text = skipped.ToString();
                textBoxSubmitted.Text = submitted.ToString();

                save_state();
            }            
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            submitted++;
            textBoxSubmitted.Text = submitted.ToString();
            timerLastDecision = timerDecision;

            adt = Math.Round(getTotalSeconds(timerDecision) / submitted, 2);
            textBoxAdt.Text = adt.ToString();

            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Speech On.wav");
            simpleSound.Play();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            skipped++;
            textBoxSkipped.Text = skipped.ToString();
            timerDecision = timerLastDecision;
            textBoxTimerDecision.Text = timerDecision.TimeOfDay.ToString();

            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Balloon.wav");
            simpleSound.Play();
        }

        private void buttonConvertToSecond_Click(object sender, EventArgs e)
        {
            textBoxTimerDecision.Text = getTotalSeconds(timerDecision).ToString();
        }

        private void textBoxTimerDecision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimeSpan ts = TimeSpan.Parse(textBoxTimerDecision.Text);
                timerDecision = timerDecision.Date + ts;
                MessageBox.Show(timerDecision.TimeOfDay.ToString());
            }
        }

        private void textBoxSubmitted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitted = Convert.ToUInt32(textBoxSubmitted.Text);
            }
        }

        private void textBoxSkipped_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                skipped = Convert.ToUInt32(textBoxSkipped.Text);
            }
        }

        private void textBoxTimerDecision_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            getTotalSeconds(timerDecision);
            textBoxTimerDecision.Text = getTotalSeconds(timerDecision).ToString();
        }

        private static double getTotalSeconds(DateTime date)
        {
            DateTime origin = DateTime.MinValue;
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private void save_state()
        {
            Settings.Default.timeDecision = timerDecision;
            Settings.Default.timeReview = timerTotalReview;
            Settings.Default.timeLastDecision = timerLastDecision;
            Settings.Default.skip = skipped;
            Settings.Default.submit = submitted;
            Settings.Default.adt = adt;
            Settings.Default.Save();
        }
    }
}
