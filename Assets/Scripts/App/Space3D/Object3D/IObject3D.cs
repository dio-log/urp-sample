using App.Space3D.Component;

namespace App.Space3D.Object3D
{
    public interface IObject3D
    {
        public void AddComponent<T>(T component) where T : IComponent;
    }
}