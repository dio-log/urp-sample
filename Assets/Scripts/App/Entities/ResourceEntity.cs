using App.Component3D;

namespace App.Entities
{
    public record ResourceEntity : IEntity
    {
        public string ID { get; set; }
        public string Label { get; set; }
    }
}