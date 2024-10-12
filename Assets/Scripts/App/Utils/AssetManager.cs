using System.Collections.Generic;
using App.Entities;
using UnityEngine;

namespace App.Utils
{
    public class AssetManager
    {
        private static Dictionary<string, GameObject> _assets = new Dictionary<string, GameObject>();

        private Dictionary<string, AssetEntity> _entities;
        
        public GameObject Instantiate(string assetID)
        {
            
            // Object.Instantiate()
            return new GameObject();
        }

        public void OnProjectChanged(string corpID, string projectID, Dictionary<string, AssetEntity> entities)
        {
            _entities = entities;
            _assets.Clear();
            //unload가있나?
        }
        
    }
}