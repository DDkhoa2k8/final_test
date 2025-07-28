using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Twilio.Rest.FlexApi.V1;
using Twilio.Rest.Studio.V1.Flow.Engagement.Step;

namespace final_test
{
    public partial class loading : Form
    {
        private int thoiGianLoad = 3000;//ms
        private int fps = 60;
        private int tickRate;
        private double step;
        private double loadingBarValue = 0;
        private int state = 0;

        public loading()
        {
            InitializeComponent();
            this.timer.Tick += new EventHandler(timer_Tick);
            this.text_timer.Tick += new EventHandler(text_timer_Tick);
        }

        private void loadingBar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void loading_Load(object sender, EventArgs e)
        {
            tickRate = 1000 / fps;
            step = 100.0 / (float)thoiGianLoad * (float)tickRate;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = 100;
            loadingBar.Value = 0;

            timer.Interval = tickRate;
            timer.Start();

            text_timer.Interval = 500;
            text_timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            loadingBarValue += step;

            if (loadingBar.Value < 100)
            {
                loadingBar.Value = (int)loadingBarValue;
            }
            else
            {
                timer.Stop();
                this.Close();
            }
        }

        private void text_timer_Tick(object sender, EventArgs e)
        {
            switch (state) {
                case 3:
                    state = 0;
                    break;
                default:
                    state++;
                    break;
            }

            label1.Text = "Đang tải" + string.Concat(Enumerable.Repeat(".", state));
        }
    }
}
