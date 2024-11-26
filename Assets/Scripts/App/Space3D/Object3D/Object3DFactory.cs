using App.Entity;
using UnityEngine;

namespace App.Space3D.Object3D
{
    public class Object3DFactory
    {
        private AssetManager _assetManager;

        public Object3DFactory(AssetManager assetManager)
        {
            _assetManager = assetManager;
        }
        public T Create<T>() where T : BaseObject3D
        {
            var warp = new GameObject();
            
            var object3D = InitializeInstance<T>(warp);

            return object3D;
        }
        
        public T Create<T>(string assetId) where T : BaseMeshObject3D
        {
            var wrap = new GameObject();
            var object3D = InitializeInstance<T>(wrap);
            
            var instance = new GameObject(); //에셋에서 로드
            object3D.RenderTarget = instance.GetComponent<Renderer>();
            instance.transform.SetParent(wrap.transform);
            
            return object3D;
        }
        
        public T Create<T>(IEntity entity) where T : BaseMeshObject3D
        {
            var wrap = new GameObject();
            var object3D = InitializeInstance<T>(wrap, entity);
            
            var instance = new GameObject(); //에셋에서 로드
            object3D.RenderTarget = instance.GetComponent<Renderer>();
            instance.transform.SetParent(wrap.transform);
            
            return object3D;
        }
        
        

        private T InitializeInstance<T>(GameObject instance) where T : BaseObject3D
        {

            return instance.AddComponent<T>();
        }
        
        private T InitializeInstance<T>(GameObject instance, IEntity entity) where T : BaseObject3D
        {

            return instance.AddComponent<T>();
        }
    }
}