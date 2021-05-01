using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public abstract class LevelTrackerService
    {
        public static string Get()
        {
            try
            {
               string path = Application.dataPath + "/Resources/LevelTracking.txt";
               string data = File.ReadAllText(path);
               return data ;

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return null;
        }
        
        
    }
}