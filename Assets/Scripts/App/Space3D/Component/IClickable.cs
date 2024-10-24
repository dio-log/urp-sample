using App.Space3D.Object3D;

namespace App.Space3D.Component
{
    public interface IClickable : IComponent
    {
        public void LeftClick(BaseObject3D object3D);
        
        public void RightClick(BaseObject3D object3D);
        
        public void DoubleClick(BaseObject3D object3D);
    }
}