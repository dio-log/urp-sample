using System.Collections.Generic;
using App.Entities;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace App.Component3D
{
    public abstract class Object3D<T> : MonoBehaviour, IObject3D where T : IEntity
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public IObject3D Parent { get; set; }
        public List<IObject3D> Children { get; set; }
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public bool IsInitialized { get; protected set; }

        public abstract void Init(T entity);

        protected void Parenting()
        {
        }

    }
}