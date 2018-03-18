using JCDecauxLibrary;
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
        Station[] stations;
        JCDecauxLibrary.JCDecauxOperationsClient client = new JCDecauxLibrary.JCDecauxOperationsClient();

        public Form1()
        {
            InitializeComponent();

            Town[] towns = client.GetTowns(key);
            foreach (Town o in towns)
            {
                Villes.Items.Add((o.Name));
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

            stations = client.GetStationsFromTown(key, town);
            
            foreach (Station o in stations)
            {
                Stations.Items.Add(o.Name);
            }
        }

        private void Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelStation.Hide();
            string stationSelected = ((ListBox)sender).SelectedItem as string;
            Station station = null;
            foreach(Station stationS in stations)
            {
                if (stationS.Name == stationSelected)
                {
                    station = stationS;
                    break;
                }
            }
            
            if (station != null)
            {
                LabelStation.Text = "Il y a " + station.Available_bikes + " vélos disponibles." + Environment.NewLine
                + "On peut encore y ranger " + station.Available_bike_stands + " vélos.";
                LabelStation.Show();
            }
            else
            {
                LabelStation.Text = "Erreur interne, veuillez réessayer";
                LabelStation.Show();
            }
        }
    }
}
