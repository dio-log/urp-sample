using System.Collections.Generic;
using UnityEngine;

namespace App.Space3D.Object3D
{
    public abstract class BaseObject3D : MonoBehaviour
    {
        public string ID { get; protected set; }
        public BaseObject3D Parent { get; set; }
        public List<BaseObject3D> Children { get; protected set; } = new List<BaseObject3D>();
        
    }
}