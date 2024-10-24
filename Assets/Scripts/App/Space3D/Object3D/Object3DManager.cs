using System.Collections.Generic;

namespace App.Space3D.Object3D
{
    public class Object3DManager
    {
        private Dictionary<string, BaseObject3D> _objectMap = new Dictionary<string, BaseObject3D>();
        private IGenerator _idGenerator;

        public Object3DManager(IGenerator generator)
        {
            _idGenerator = generator;
        }
        


        public void Register(BaseObject3D object3D)
        {
            _objectMap.Add(_idGenerator.GenerateID(), object3D);
        }

        public void Unregister(BaseObject3D object3D)
        {
            
        }

        public void Remove(BaseObject3D object3D)
        {
            
        }
        
        
    }
}