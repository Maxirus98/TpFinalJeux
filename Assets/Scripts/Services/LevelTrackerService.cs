using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public abstract class LevelTrackerService
    {
        public static string Get(string nameOfDimension)
        {
            try
            {
                string path = Application.dataPath + "/Resources/LevelTracking.txt";
                string data = File.ReadAllText(path);
                string[] levels = data.Split(',');

                foreach (var level in levels)
                {
                    string dimensionName = level.Split(':')[0].ToLower().Trim();
                    string status = level.Split(':')[1].ToLower().Trim();

                    if (nameOfDimension.Trim().Equals(dimensionName) && status.Equals("unlocked"))
                    {
                        return level;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            return String.Empty;
        }
    }
}