using App.Space3D.Object3D;
using UnityEngine;

namespace App.EventSystem
{
    public class EvtArgs
    {
        public IObject3D Object3D { get; }
        public Vector3 Position { get; }
        
        public EvtArgs(IObject3D object3D)
        {
            Object3D = object3D;
        }

        public EvtArgs(IObject3D object3D, Vector3 position)
        {
            Object3D = object3D;
            Position = position;
        }
    }
}