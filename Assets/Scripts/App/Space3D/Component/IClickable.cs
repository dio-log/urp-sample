using App.Space3D.Object3D;

namespace App.Space3D.Component
{
    public interface IClickable : IComponent
    {
        public void LeftClick(IObject3D object3D);
        
        public void RightClick(IObject3D object3D);
        
        public void DoubleClick(IObject3D object3D);
    }
}