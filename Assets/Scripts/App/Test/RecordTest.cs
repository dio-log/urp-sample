using System;
using App.Core.Shared.DI;
using App.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace App.Test
{
    public class RecordTest : MonoBehaviour
    {

        // [InjectComponent]
        // private Button _button;
        
        private void Start()
        {
            var entity1 = new ResourceEntity()
            {
                ID = "t1",
                Label = "label1",
                Position = new Vector3(1, 1, 1)
            };
            
            var entity2 = new ResourceEntity()
            {
                ID = "t1",
                Position = new Vector3(1, 2, 1)
            };
            
            Debug.Log(entity1.Equals(entity2));
            
        }

        public void Constructor()
        {
            
        }
    }
}