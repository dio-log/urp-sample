using System.Collections.Generic;
using App.Entity;
using App.Space3D.Object3D.Validator;
using UnityEditor;

namespace App.Space3D.Object3D
{
    public class Object3DManager
    {
        private Dictionary<string, BaseObject3D> _objectMap = new Dictionary<string, BaseObject3D>();

        private Object3DFactory _factory;
        private BaseValidator _validator;
        
        
        public Object3DManager(Object3DFactory factory, BaseValidator validator)
        {
            _factory = factory;
            _validator = validator;
        }

        public T Create<T>() where T : BaseObject3D
        {
            return _factory.Create<T>();   
        }

        public T Create<T>(string assetId) where T : BaseMeshObject3D
        {
            return _factory.Create<T>(assetId);
        }

        public T CreateFromEntity<T>(IEntity entity)
        {
            return default;
        }
        

        public void Register(BaseObject3D object3D)
        {
        }

        public void Unregister(BaseObject3D object3D)
        {
            
        }

        
        /// <summary>
        /// Unregister And Destroy
        /// </summary>
        public void Destroy(BaseObject3D object3D)
        {
            
        }
        
        
        
        
    }
}