using System.Collections.Generic;
using App.EventSystem;
using App.Space3D.Component;
using App.Space3D.Object3D;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Test
{
    public class TestObject : MonoBehaviour, IClickActionHandler
    {
        
        private bool IsSelected = false;
        public event UnityAction OnClicked;

        private void Awake()
        {
            OnClicked += () =>
            {
                Debug.Log("click");
            };
        }

        public void Click(EvtArgs args)
        {
            if (!IsSelected)
            {
                OnClicked?.Invoke();
                IsSelected = true;

            }
        }

        public void AddComponent<T>(T component) where T : IComponent
        {
            throw new System.NotImplementedException();
        }
    }
}