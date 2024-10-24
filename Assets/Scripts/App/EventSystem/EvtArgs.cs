using App.Space3D.Object3D;
using UnityEngine;

namespace App.EventSystem
{
    public class EvtArgs
    {
        public BaseObject3D Object3D { get; }
        public Vector3 Position { get; }
        
        public EvtArgs(BaseObject3D object3D)
        {
            Object3D = object3D;
        }

        public EvtArgs(BaseObject3D object3D, Vector3 position)
        {
            Object3D = object3D;
            Position = position;
        }
    }
}