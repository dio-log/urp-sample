using App.Env.Config;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Env
{
    public class Environment
    {
        private const string ConfigPath = "Config/config";
        private static ConfigProperties ConfigProperties { get; set; }
        
        public static string ActiveProfile { get; private set; }
        public static string DataSourceURL { get; private set; }
        public static string UserID { get; private set; }

        public Environment(string userID)
        {
            UserID = userID;

            LoadProperties();
        }

        private void LoadProperties()
        {
            var json = Resources.Load<TextAsset>(ConfigPath);
            var config =  JsonConvert.DeserializeObject<Configuration>(json.text);

            // ActiveProfile = config.ActiveProfile;
            // ConfigProperties = ActiveProfile.Equals("development") ? config.Development : config.Production;
            // DataSourceURL = ConfigProperties.apiUrl;
        }
        
        
    }
}