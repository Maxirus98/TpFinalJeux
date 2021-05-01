using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public abstract class LevelTrackerService
    {
        //Question Prof est-ce une bonne utilisation du static?
        public static string GetAll()
        {
            try
            {
                string path = Application.dataPath + "/Resources/LevelTracking.txt";
                string data = File.ReadAllText(path);
                return data;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return null;
        }

        public static string GetOne(string name)
        {
            string[] levels = GetAll().Split(',');

            foreach (var level in levels)
            {
                string dimensionName = level.Split(':')[0].ToLower().Trim();
                string status = level.Split(':')[1].ToLower().Trim();

                if (name.Trim().Equals(dimensionName) && status.Equals("unlocked"))
                {
                    return level;
                }
            }

            return String.Empty;
        }
    }
}