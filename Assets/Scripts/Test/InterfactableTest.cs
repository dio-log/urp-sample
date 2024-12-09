using App.Features.GUI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class InteractableTest : MonoBehaviour
    {

        public InteractableElement interactableElement;

        public Button _selectButton;
        public Button _deselectButton;
        public Button _disableButton;


        public InteractableGroup _group;
        public Image _image1;
        public Image _image2;
        public Image _image3;
        private void Awake()
        {
            _deselectButton.onClick.AddListener(() =>
            {
                interactableElement.Deselect();
            });
            
            _selectButton.onClick.AddListener(() =>
            {
                interactableElement.SelectWithoutNotify();
            });
            
            _disableButton.onClick.AddListener(() =>
            {
                interactableElement.SetInteractable(false);
            });


            // var go1 = new GameObject();
            var em1 = _image1.gameObject.GetComponent<InteractableElement>();
            // var go2 = new GameObject();
            var em2 = _image2.gameObject.GetComponent<InteractableElement>();
            // var go3 = new GameObject();
            var em3 = _image3.gameObject.GetComponent<InteractableElement>();
            _image1.transform.SetParent(_group.transform);
            _image2.transform.SetParent(_group.transform);
            _image3.transform.SetParent(_group.transform);
            
            _group.Register(em1);
            _group.Register(em2);
            _group.Register(em3);

        }
    }
}