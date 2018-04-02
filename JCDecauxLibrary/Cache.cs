using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace JCDecauxLibrary
{
    class Cache
    {
        private static Cache instance = null;
        private DataTable cacheStation = null;

        public static Cache GetInstance()
        {
            if (instance == null)
            {
                instance = new Cache();
            }
            return instance;
        }

        public Cache()
        {
            this.cacheStation = new DataTable();
            cacheStation.Columns.Add("Town", typeof(Town));
            cacheStation.Columns.Add("DateAdded", typeof(DateTime));
        }

        private bool IsStillCached(DataRow row)
        {
            return ((DateTime)row["DateAdded"]).AddSeconds(AdminStats.GetInstance().TimeCachedSec).CompareTo(DateTime.Now) >= 0;
        }

        public void AddStationsForTown(string town, Station[] stations)
        {
            Town townToAdd = new Town();
            townToAdd.stations = stations;
            townToAdd.Name = town;
            cacheStation.Rows.Add(townToAdd, DateTime.Now);
        }
        
        public Station[] GetStations(String town)
        {
            foreach (DataRow row in cacheStation.Rows)
            {
                if (((Town)row["Town"]).Name == town)
                {
                    if (IsStillCached(row) && ((Town)row["Town"]).stations != null)
                    {
                        return ((Town)row["Town"]).stations;
                    }
                    // Not cached anymore, we reset stations
                    row.Delete();
                    break;
                }
            }
            return null;
        }
        
        public Station GetStation(String town, String station)
        {
            foreach (DataRow row in cacheStation.Rows)
            {
                if (((Town)row["Town"]).Name == town)
                {
                    if (IsStillCached(row))
                    {
                        foreach(Station stationCached in ((Town)row["Town"]).stations)
                        {
                            if (stationCached.Name.ToLower().Contains(station.ToLower()))
                            {
                                return stationCached;
                            }
                        }
                    }
                    // Delete now useless row
                    row.Delete();
                    break;
                }
            }
            return null;
        }
    }
}
