using System;
using App.Component3D;
using App.Entities;
using UnityEngine;

namespace App.Test
{
    public class DestroyObject3DTest : MonoBehaviour
    {
        private void Start()
        {

            Object3DManager manager = new();

            var obj = manager.Create<Resource>();
            var entity = new ResourceEntity()
            {
                ID = "Test",
                Label = "Test",
            };
            
            manager.Register(obj, entity);
            
            manager.Delete(obj);
        }
    }
}