using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StopwatchGUI
{
    public partial class Form1 : Form
    {
        private Stopwatch _stopwatch;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();

            _stopwatch = new Stopwatch();
            _timer = new Timer();
            _timer.Interval = 50; // update every 50ms
            _timer.Tick += Timer_Tick;

            lblTime.Text = "00:00:00.00";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _stopwatch.Start();
            _timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _stopwatch.Reset();
            lblTime.Text = "00:00:00.00";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = _stopwatch.Elapsed;
            lblTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
    }
}
