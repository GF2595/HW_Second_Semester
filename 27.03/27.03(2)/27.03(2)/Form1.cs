using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockHomeworkNamespace
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private string TimeCorrection(int time)
        {
            if ((time / 10) == 0)
            {
                return "0" + time;
            }

            return time.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour + ":" + TimeCorrection(DateTime.Now.Minute) + ":" + TimeCorrection(DateTime.Now.Second);
        }
    }
}
