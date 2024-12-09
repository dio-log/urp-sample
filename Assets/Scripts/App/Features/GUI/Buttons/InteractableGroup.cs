using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Features.GUI.Buttons
{
    public class InteractableGroup : UIBehaviour
    {
        [SerializeField] 
        private bool _activateFirst = false; 
        
        [SerializeField]
        private List<InteractableElement> _elements = new List<InteractableElement>();
        
        public void Register(InteractableElement element)
        {
            if (_elements.Contains(element)) return;
            
            _elements.Add(element);
            element.OnStateChanged += OnElementStateChanged;
        }

        public void Unregister(InteractableElement element)
        {
            if (!_elements.Contains(element)) return;
            
            _elements.Remove(element);
            element.OnStateChanged -= OnElementStateChanged;
        }
        
        private void OnElementStateChanged(InteractableElement element, InteractiveState state)
        {
            if (state != InteractiveState.Selected) return;
            
            RemoveDestroyedElements(); 
            
            _elements.ForEach(em =>
            {
                if (em.Equals(element)) return;
                
                em.DeselectWithoutNotify();
            });
        }

        private void RemoveDestroyedElements()
        {
            _elements.RemoveAll(em => em == null || em.IsDestroyed());
        }

        protected override void Awake()
        {
            base.Awake();
            
            if(_activateFirst) _elements[0].SelectWithoutNotify();
            
            _elements.ForEach(em => em.OnStateChanged += OnElementStateChanged);
        }
        
        protected override void OnDestroy()
        {
            _elements.ForEach(em => em.OnStateChanged -= OnElementStateChanged);
            
            base.OnDestroy();
        }
    }
}