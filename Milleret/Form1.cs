using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milleret
{
    public partial class Form1 : Form
    {
        String key = "0fd193fbd29d80003eca2314c7a382831b9eb03f";
        String town;
        JCDecauxLibrary.JCDecauxOperationsClient client = new JCDecauxLibrary.JCDecauxOperationsClient();

        public Form1()
        {
            InitializeComponent();

            String responseFromServer = client.GetContracts(key);
            JArray jArray = JArray.Parse(responseFromServer);
            foreach (JObject o in jArray)
            {
                Villes.Items.Add(o.GetValue("name"));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Villes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stations.Items.Clear();
            town = ((ListBox)sender).SelectedItem.ToString();
            
            String responseFromServer = client.GetStationsFromTown(key, town);
            JArray jArray = JArray.Parse(responseFromServer);
            foreach (JObject o in jArray)
            {
                Stations.Items.Add(o.GetValue("name"));
            }
        }

        private void Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            String station = ((ListBox)sender).SelectedItem.ToString();
            String responseFromServer = client.GetStationsFromTown(key, town);

            JArray jArray = JArray.Parse(responseFromServer);
            foreach (JObject o in jArray)
            {
                if (o.GetValue("name").ToString().Equals(station))
                {
                    LabelStation.Text = "Il y a " + o.GetValue("available_bikes") + " vélos disponibles." + Environment.NewLine
                        + "On peut encore y ranger " + o.GetValue("available_bike_stands") + " vélos.";
                    LabelStation.Show();
                    break;
                }
            }
        }
    }
}
