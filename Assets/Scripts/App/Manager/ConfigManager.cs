using System;
using System.IO;
using App.Common;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Manager
{
    public class ConfigManager : MonoBehaviour
    {
        private const string ConfigFilePath = "Config/config";
        private void Awake()
        {
            
            var json = Resources.Load<TextAsset>(ConfigFilePath);
            Debug.Log(json.text);
            // var config =JsonUtility.FromJson<Config>(json.text);

            var config = JsonConvert.DeserializeObject<Config>(json.text);
            Debug.Log(JsonConvert.SerializeObject(config));
            Debug.Log(config.Environment);
        }
    }
}