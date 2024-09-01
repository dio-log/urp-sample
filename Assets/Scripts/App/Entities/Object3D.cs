using UnityEngine;

namespace App.Entities
{
    public class Object3D
    {
        public string Id { get; set; }  //nodeId
        public string ThumbnailId { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }
}