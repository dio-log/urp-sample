using UnityEngine;

namespace App.Space3D.Object3D
{
    public class Object3DFactory
    {
        
        
        public static T CreateObject3D<T>() where T : BaseObject3D
        {
            
            var wrap = new GameObject();
            var object3D = wrap.AddComponent<T>();
            InitializeObject3D(object3D);

            var instance = new GameObject();
            instance.transform.SetParent(wrap.transform);
            
            
            return object3D;
        }

        private static void InitializeObject3D(BaseObject3D object3D)
        {
            // 바운드, 컴포넌트 등 
        }
    }
}