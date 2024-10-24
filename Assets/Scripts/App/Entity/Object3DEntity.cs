using UnityEngine;

namespace App.Entity
{
    public class Object3DEntity
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }
}