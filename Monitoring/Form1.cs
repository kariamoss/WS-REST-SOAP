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

        private void Clear_chart(Chart chart)
        {
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }
        
        private void CreateRequestsChart(Request[] requests)
        {
            chart1.ChartAreas[0].AxisX.Maximum = data.GetTimeForRequests();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            double Percentage = 0;
            for (double i = 0; i <= data.GetTimeForRequests(); i = data.GetTimeForRequests() * Percentage)
            {
                int nbRequests = 0;
                DateTime beginOfTimeSection = DateTime.Now.AddSeconds(-data.GetTimeForRequests() * (Percentage + 0.1));
                DateTime endOfTimeSection = DateTime.Now.AddSeconds(-i);
                foreach (Request req in requests)
                {
                    if (req.Date >= beginOfTimeSection && req.Date < endOfTimeSection)
                    {
                        nbRequests++;
                    }
                }
                Percentage += 0.1;
                Debug.Print("i : " + i);
                chart1.Series[0].Points.AddXY(i, nbRequests);
            }
        }

        private void CreateCacheRequestsChart(Request[] requests)
        {
            chart3.ChartAreas[0].AxisX.Maximum = data.GetTimeForRequests();
            chart3.ChartAreas[0].AxisX.Minimum = 0;
            double Percentage = 0;
            for (double i = 0; i <= data.GetTimeForRequests(); i = data.GetTimeForRequests() * Percentage)
            {
                int nbRequests = 0;
                DateTime beginOfTimeSection = DateTime.Now.AddSeconds(-data.GetTimeForRequests() * (Percentage + 0.1));
                DateTime endOfTimeSection = DateTime.Now.AddSeconds(-i);
                foreach (Request req in requests)
                {
                    if (req.Date >= beginOfTimeSection && req.Date < endOfTimeSection && req.IsCached)
                    {
                        nbRequests++;
                    }
                }
                Percentage += 0.1;
                Debug.Print("i : " + i);
                chart3.Series[0].Points.AddXY(i, nbRequests);
            }
        }

        private void RefreshChartAllRequests(Request[] requests) 
        {
            Clear_chart(chart1);
            CreateRequestsChart(requests);
            Clear_chart(chart3);
            CreateCacheRequestsChart(requests);
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
