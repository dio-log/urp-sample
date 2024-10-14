using UnityEngine;

namespace App.Entities
{
    public class FloorEntity : IEntity
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }
}