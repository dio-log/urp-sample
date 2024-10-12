using App.Entities;

namespace App.Component3D
{
    public abstract class MeshObject3D<T> : Object3D<T>, IMeshObject3D where T : IEntity
    {
        public string AssetBundleId { get; set; }
    
    }
}