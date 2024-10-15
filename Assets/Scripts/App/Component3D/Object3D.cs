using System.Collections.Generic;
using App.Entities;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace App.Component3D
{
    public abstract class Object3D<T> : MonoBehaviour, IObject3D where T : IEntity
    {
        protected abstract T OriginEntity { get; set; }
        public string ID { get; set; }
        public string Label { get; set; }
        public IObject3D Parent { get; set; }
        public List<IObject3D> Children { get; set; }
        public GameObject GameObject
        {
            get => gameObject; 
        }

        public abstract void Init(T entity);
        public abstract T GetEntity();
        //클래스 타입별로 리스트를 뽑을거니까. 인터페이스에 없어도됨 
        public abstract bool TryGetEntityIfChanged(out T entity);
        //필드로 오리진 엔티티를 갖게되면 삭제(파괴)된 엔티티에 대해서는 체크를 할수없음 
        //active로 해야됨 ? 아니면 히스토리를 체크해서 알수 있음??
        protected void Parenting()
        {
        }

    }
}