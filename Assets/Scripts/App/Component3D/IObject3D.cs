using System.Collections.Generic;
using UnityEngine;

namespace App.Component3D
{
    public interface IObject3D
    {
        public string ID { get; set; }
        public string Label { get; set; }
        
        public IObject3D Parent { get; set; }
        public List<IObject3D> Children { get; set; }
        
        public GameObject GameObject { get; }

    }
}