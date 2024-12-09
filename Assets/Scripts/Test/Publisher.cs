using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Test
{
    public class Publisher : MonoBehaviour, IPointerClickHandler
    {
        private event UnityAction<bool> _clicked;
        public event UnityAction<bool> OnClicked
        {
            add => _clicked += value;
            remove => _clicked -= value;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _clicked?.Invoke(true);
        }
        
    }
}