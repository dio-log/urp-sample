using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Features.GUI.Buttons
{
    [DisallowMultipleComponent]
    public class InteractableElement 
        : 
            UIBehaviour,
            IPointerDownHandler,
            IPointerUpHandler,
            IPointerEnterHandler,
            IPointerExitHandler
    {
        [SerializeField] 
        private bool _interactable = true;
        
        [SerializeField] 
        private bool _isSelected = false;
        
        [SerializeField] 
        private Image _targetGraphic;
        
        [SerializeField] 
        private ColorBlock _colorBlock;
        
        [SerializeField] 
        private UnityEvent<InteractableElement, InteractiveState> _onStateChanged;

        private bool _isPressed = false;
        private bool _isHighlighted = false;
        private InteractiveState _prevState = InteractiveState.Normal;

        public event UnityAction<InteractableElement, InteractiveState> OnStateChanged
        {
            add => _onStateChanged.AddListener(value);
            remove => _onStateChanged.RemoveListener(value);
        }
        
        public bool Interactable => _interactable;
        public bool IsSelected => _isSelected;
        
        public void SetInteractable(bool interactable)
        {
            _interactable = interactable;
            ClearState();
            VerityAndTransition(false);
        }
            
        public void SelectWithoutNotify()
        {
            _isSelected = true;
            
            VerityAndTransition(false);
        }
        
        public void Select()
        {
            _isSelected = true;

            VerityAndTransition();
        }

        public void DeselectWithoutNotify()
        {
            _isSelected = false;
            
            VerityAndTransition(false);
        }
        
        public void Deselect()
        {
            _isSelected = false;
            
            VerityAndTransition();
        }

        public void Highlight()
        {
            _isHighlighted = true;
            
            VerityAndTransition();
        }

        public void Unhighlight()
        {
            _isHighlighted = false;

            VerityAndTransition();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            _isPressed = true;
            
            VerityAndTransition();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;
            
            _isPressed = false;
            
            Select();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Highlight();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Unhighlight();
        }

        private void TransitionTo(InteractiveState state)
        {
            Color color;
            switch (state)
            {
                case InteractiveState.Normal:
                    color = _colorBlock.normalColor;
                    break;
                case InteractiveState.Highlighted:
                    color = _colorBlock.highlightedColor;
                    break;
                case InteractiveState.Pressed:
                    color = _colorBlock.pressedColor;
                    break;
                case InteractiveState.Selected:
                    color = _colorBlock.selectedColor;
                    break;
                case InteractiveState.Disabled:
                    color = _colorBlock.disabledColor;
                    break;
                default:
                    color = Color.grey;
                    break;
            }
            
            TwinColor(color);
        }

        
        private void TwinColor(Color color)
        {
            _targetGraphic.CrossFadeColor(color, 0f, true, true);
        }

        private bool CanTransition()
        {
            if (!isActiveAndEnabled) return false;

            var current = ResolveState();

            if (_prevState == current) return false;
            
            return true;
        }

        private void VerityAndTransition(bool triggerEvent = true)
        {
            if (!CanTransition()) return;
            
            _prevState = ResolveState();
            
            TransitionTo(_prevState);
            
            if(triggerEvent)
                _onStateChanged.Invoke(this, _prevState);
        }

        private InteractiveState ResolveState()
        {
            if (!Interactable) return InteractiveState.Disabled;
            
            if(!_isSelected && _isPressed) return InteractiveState.Pressed;

            if (!_isSelected && _isHighlighted) return InteractiveState.Highlighted;

            if (_isSelected) return InteractiveState.Selected;

            return InteractiveState.Normal;
        }

        private void ClearState()
        {
            _isPressed = false;
            _isHighlighted = false;
            _isSelected = false;
        }

        protected override void Awake()
        {
            base.Awake();
            VerityAndTransition();
        }

        protected override void OnDestroy()
        {
            ClearState();
            _onStateChanged.RemoveAllListeners();
            base.OnDestroy();
        }
    }
    
    [System.Serializable]
    public class ColorBlock
    {
        public Color normalColor = Color.white;
        public Color highlightedColor = Color.gray;
        public Color pressedColor = Color.black;
        public Color selectedColor = Color.blue;
        public Color disabledColor = Color.gray;
    
        // [Range(0, 1)]
        // public float colorMultiplier = 1f;
    }

    //custom 드로워 만들어야함 
    public enum TransitionType
    {
        None,
        Fade,
    }

    public enum InteractiveState
    {
        Normal,
        Highlighted,
        Pressed,
        Selected,
        Disabled
    }
}