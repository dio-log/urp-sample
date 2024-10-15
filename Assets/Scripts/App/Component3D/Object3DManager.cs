using System.Collections.Generic;
using App.Entities;
using App.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace App.Component3D
{
    public class Object3DManager
    {
        private Dictionary<string, IObject3D> _objects = new();
        public SimpleHierarchy hierarchy;
        public AssetManager assetManager;

        private event UnityAction<IObject3D> _onCreate;
        public event UnityAction<IObject3D> OnCreate
        {
            add => _onCreate += value;
            remove => _onCreate -= value;
        }
        
        private event UnityAction<IObject3D> _onDelete;
        public event UnityAction<IObject3D> OnDelete
        {
            add => _onDelete += value;
            remove => _onDelete -= value;
        }

        public T Create<T>() where T : MonoBehaviour, IObject3D
        {
            var wrap = new GameObject();
            var obj = wrap.AddComponent<T>();
            _onCreate?.Invoke(obj);
            return obj;
        }
        
        public T CreateBy<T>(string assetBundleId) where T : MonoBehaviour, IMeshObject3D
        {
            var wrap = new GameObject();
            var obj = wrap.AddComponent<T>();
            obj.AssetBundleId = assetBundleId;
            _onCreate?.Invoke(obj);
            return obj;
        }

        public void CreateFrom(EntitySet entitySet, bool isManaged)
        {
            
        }
        

        public void Register(IObject3D object3D)
        {
            IEntity entity = null;
            
            switch (object3D)
            {
                case Resource resource:
                    entity = new ResourceEntity(){ ID = "testid"};
                    break;
                case Floor:
                    entity = new FloorEntity();
                    break; 
                default:
                    Debug.Log("지원하지 않는 오브젝트");
                    return;
            }

            Register(object3D, entity);
        }
        
        public void Register(IObject3D object3D, IEntity entity)
        {
            if (!Validate(object3D, entity))
            {
                Debug.Log($"오브젝트와 엔티티타입이 일치하지 않습니다. /n {object3D.GetType()} / {entity.GetType()}");
                return;
            }
            
            
            
            switch (object3D)
            {
                case Resource resource:
                    resource.Init(entity as ResourceEntity);
                    break;
                case Floor floor:
                    floor.Init(entity as FloorEntity);
                    break; 
            }
            _objects.Add(object3D.ID, object3D);
            Debug.Log("추가");
        }

        public void Delete(IObject3D object3D)
        {
            _objects.Remove(object3D.ID);
            
            _onDelete?.Invoke(object3D);
            
            Debug.Log("삭제");
        }

        public void DeleteAll()
        {
            
        }

        public void OnProjectChanged()
        {
            
        }

        private bool Validate(IObject3D object3D, IEntity entity)
        {
            switch (object3D)
            {
                case Resource:
                    return entity is ResourceEntity;
                case Floor:
                    return entity is FloorEntity;
                default:
                    return false;
            }
        }

        private void OnInstantiateCompleted(IObject3D object3D)
        {
            //component 초기화
            
            //트랜스폼 초기화
        }
        
    }
}