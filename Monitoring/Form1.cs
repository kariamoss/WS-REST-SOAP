using Monitoring.JCDecauxAdminService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Monitoring
{
    public partial class Form1 : Form
    {
        Data data;
        private Timer timer1;
        int i = 0;

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        public Form1()
        {
            data = new Data();
            InitializeComponent();
            InitTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeCached.Value = data.GetTimeCached();
            TimeRequests.Value = data.GetTimeForRequests();
        }
        
        private void RefreshChartAllRequests(Request[] requests) 
        {
            double Percentage = 0.1;
            for (double i = 0; i <= data.GetTimeForRequests(); i = data.GetTimeForRequests() * Percentage)
            {
                int nbRequests = 0;
                DateTime beginOfTimeSection = DateTime.Now.AddSeconds(data.GetTimeForRequests() * (Percentage + 0.1));
                DateTime endOfTimeSection = DateTime.Now.AddSeconds(i);
                foreach (Request req in requests)
                {
                    if (req.Date >= beginOfTimeSection && req.Date < endOfTimeSection)
                    {
                        nbRequests++;
                        //Debug.Print(nbRequests.ToString());
                    }
                }
                Percentage += 0.1;
                //Debug.Print("i : " + i);
                chart1.Series["Requêtes"].Points.AddXY(i, nbRequests);
            }
        }

        private void RefreshInfos()
        {
            TimeCached.Value = data.GetTimeCached();
            TimeRequests.Value = data.GetTimeForRequests();
            label5.Text = data.GetNbRequest().ToString();
            label6.Text = data.GetNbRequestOnCache().ToString();
            Request[] requests = data.GetRequest();
            if(requests != null)
            {
                RefreshChartAllRequests(requests);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            data.Refresh();
            RefreshInfos();
        }

        private void TimeCached_ValueChanged(object sender, EventArgs e)
        {
            int value = (int) ((NumericUpDown)sender).Value;
            data.SetTimeCachedSec(value);
        }

        private void TimeRequests_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)((NumericUpDown)sender).Value;
            data.SetTimeForRequests(value);
        }
    }
}
