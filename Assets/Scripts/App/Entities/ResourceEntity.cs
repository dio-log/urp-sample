using App.Component3D;
using UnityEngine;

namespace App.Entities
{
    public record ResourceEntity : IEntity
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string Type { get;set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public virtual bool Equals(ResourceEntity other)
        {
            return true;
        }
    }
}