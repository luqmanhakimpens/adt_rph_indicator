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
        String appVersion = "Version: 2.0";
        DateTime tt;
        DateTime timerLastDecision;
        DateTime timerSingleTask;
        DateTime startTime;
        DateTime timerAllTask;
        
        TimeSpan td,last_td;

        private static System.Timers.Timer aTimer;

        bool timerRunning = false, timerstarted = false, indicator_is_rph = false;
        
        UInt32 submitted,skipped;
        double indicator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelVersion.Text = appVersion;
            //timer1.Stop();
            SetTimer();

            timerAllTask = Settings.Default.timeAllTask;
            timerSingleTask = Settings.Default.timeSingleTask;
            timerLastDecision = Settings.Default.timeLastDecision;
            skipped = Settings.Default.skip;
            submitted = Settings.Default.submit;
            indicator = Settings.Default.indicator;

            textBoxTimerAllTask.Text = timerAllTask.TimeOfDay.ToString();
            textBoxSubmitted.Text = submitted.ToString();
            textBoxSkipped.Text = skipped.ToString();
            
            show_indicator();
        }

        private void show_indicator()
        {
            if (indicator_is_rph) textBoxIndicator.Text = indicator_to_rph(indicator).ToString() + " T/h";
            else textBoxIndicator.Text = indicator.ToString() + " s/T";
        }
        private int indicator_to_rph(double ind)
        {
            return 3600 / (int)ind;
        }

        private void SetTimer()
        {
            // Create a timer with a second interval.
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
            timerAllTask = timerAllTask.Add(timediff);
            timerSingleTask = timerSingleTask.Add(timediff);

            Console.Write(timediff.ToString());
            Console.Write(" - ");
            Console.Write(timerSingleTask.TimeOfDay.ToString());
            Console.Write(" - ");
            Console.WriteLine(timerAllTask.TimeOfDay.ToString());
            //Console.WriteLine("t  = {0:HH:mm:ss.fff}", timerDecision);

            if (textBoxTimerSingleTask.InvokeRequired)
            {
                textBoxTimerAllTask.BeginInvoke(new MethodInvoker(() => textBoxTimerSingleTask.Text = timerSingleTask.TimeOfDay.ToString()));
            }
            if (textBoxTimerAllTask.InvokeRequired)
            {
                textBoxTimerAllTask.BeginInvoke(new MethodInvoker(() => textBoxTimerAllTask.Text = timerAllTask.TimeOfDay.ToString()));
            }
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
                timerSingleTask = timerAllTask = DateTime.MinValue;
                textBoxTimerAllTask.Text = timerSingleTask.TimeOfDay.ToString();

                indicator = 0;
                textBoxIndicator.Text = indicator.ToString();

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
            timerLastDecision = timerAllTask;
            timerSingleTask = DateTime.MinValue;

            textBoxTimerSingleTask.Text = timerSingleTask.TimeOfDay.ToString();

            indicator = Math.Round(getTotalSeconds(timerAllTask) / submitted, 1);
            show_indicator();
            //textBoxIndicator.Text = indicator.ToString();

            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Speech On.wav");
            simpleSound.Play();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            skipped++;
            textBoxSkipped.Text = skipped.ToString();
            timerAllTask = timerLastDecision;
            textBoxTimerAllTask.Text = timerAllTask.TimeOfDay.ToString();

            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Balloon.wav");
            simpleSound.Play();
        }

        private void buttonConvertToSecond_Click(object sender, EventArgs e)
        {
            textBoxTimerAllTask.Text = getTotalSeconds(timerAllTask).ToString();
        }

        private void textBoxTimerDecision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimeSpan ts = TimeSpan.Parse(textBoxTimerAllTask.Text);
                timerAllTask = timerAllTask.Date + ts;
                MessageBox.Show(timerAllTask.TimeOfDay.ToString());
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

        private void labelVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(appVersion + "\n" +
                "https://github.com/luqmanhakimpens");
        }

        private void readme_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[indicator]        {Start/Stop}   {Reset}\n" +
                            "[overall Timer]  [Skip Counter] {Skip}\n" +
                            "[Single Timer]   [Task Counter] {Submit}\n\n" +
                            "double click to switch mode(adt/rph)");
        }

        private void textBoxIndicator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            indicator_is_rph ^= true;
            show_indicator();
        }

        private void textBoxSkipped_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStartStop_MouseHover(object sender, EventArgs e)
        {

        }

        private void textBoxTimerDecision_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            getTotalSeconds(timerAllTask);
            textBoxTimerAllTask.Text = getTotalSeconds(timerAllTask).ToString();
        }

        private static double getTotalSeconds(DateTime date)
        {
            DateTime origin = DateTime.MinValue;
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private void save_state()
        {
            Settings.Default.timeAllTask = timerAllTask;
            Settings.Default.timeSingleTask = timerSingleTask;
            Settings.Default.timeLastDecision = timerLastDecision;
            Settings.Default.skip = skipped;
            Settings.Default.submit = submitted;
            Settings.Default.indicator = indicator;
            Settings.Default.Save();
        }
    }
}
