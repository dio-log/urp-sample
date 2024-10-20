
using System;
using System.Collections.Generic;
using App.Entity;
using App.Space3D.Component;
using UnityEngine.Events;

namespace App.Space3D.Object3D
{
    public class Object3D<T> : IObject3D where T : IEntity
    {
        private Dictionary<Type, List<IComponent>> _components = new Dictionary<Type, List<IComponent>>();
        
        
        public T Entity { get; set; }



        // private event UnityAction<IObject3D> _click;
        // public event UnityAction<IObject3D> OnClick
        // {
        //     add => _click += value;
        //     remove => _click -= value;
        // } 
        //
        
        public void AddComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            var type = typeof(TComponent);
            if (!_components.ContainsKey(type))
            {
                _components[type] = new List<IComponent>();
            }

            if (!_components[type].Contains(component))
            {
                _components[type].Add(component);
            }
            else
            {
                Console.WriteLine($"Component of type {type.Name} is already added.");
            }
        }
        
        public void RemoveComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            var type = typeof(TComponent);
            if (_components.ContainsKey(type))
            {
                _components[type].Remove(component);
                if (_components[type].Count == 0)
                {
                    _components.Remove(type);
                }
            }
        }

        // 특정 타입의 모든 컴포넌트 가져오기
        public IEnumerable<TComponent> GetComponents<TComponent>() where TComponent : class, IComponent
        {
            var type = typeof(TComponent);
            if (!_components.TryGetValue(type, out var components)) yield break;

            foreach (var component in components)
            {
                yield return component as TComponent;
            }
        }


        public void Click()
        {
           
        }
    }
}