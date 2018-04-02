using JCDecauxLibrary;
using Milleret.JCDecauxLibraryService;
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
        String town;
        Station[] stations;
        JCDecauxLibraryService.JCDecauxOperationsClient client = new JCDecauxLibraryService.JCDecauxOperationsClient();

        public Form1()
        {
            InitializeComponent();

            Town[] towns = client.GetTowns();
            foreach (Town o in towns)
            {
                Villes.Items.Add((o.Name));
            }
        }

        private void Villes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stations.Items.Clear();
            
            town = ((ListBox)sender).SelectedItem.ToString();

            stations = client.GetStationsFromTown(town);

            Stations.Items.Clear();
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
