using App.Entities;

namespace App.Component3D
{
    public class Resource : MeshObject3D<ResourceEntity>
    {
        public override void Init(ResourceEntity entity)
        {
            ID = entity.ID;
            Label = entity.Label;
        }

        protected override ResourceEntity OriginEntity { get; set; }

        public override ResourceEntity GetEntity()
        {
            return new ResourceEntity()
            {
                ID = ID,
                Label = Label,
                Type = "Resource",
                Position = transform.localPosition,
                Rotation = transform.localRotation.eulerAngles,
                Scale = transform.localScale
            };
        }

        public override bool TryGetEntityIfChanged(out ResourceEntity entity)
        {
            entity = GetEntity();

            return OriginEntity.Equals(entity);
        }

        
    }
}