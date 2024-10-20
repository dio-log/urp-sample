using App.Space3D.Object3D;
using UnityEngine;

namespace App.Space3D.Component
{
    public class BasicClickable : IClickable
    {
        public void LeftClick(IObject3D object3D)
        {
            Debug.Log("click");
        }

        public void RightClick(IObject3D object3D)
        {
            Debug.Log("right click");
        }

        public void DoubleClick(IObject3D object3D)
        {
            Debug.Log("double click");
        }
    }
}