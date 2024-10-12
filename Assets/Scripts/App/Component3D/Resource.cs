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
    }
}