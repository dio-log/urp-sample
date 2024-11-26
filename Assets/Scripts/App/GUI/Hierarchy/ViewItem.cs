using App.Core.Shared.DI;
using UnityEngine;
using UnityEngine.UI;

namespace App.GUI.Hierarchy
{
    public class ViewItem : MonoBehaviour
    {
        [InjectComponents("ExpandToggle")]
        private Toggle _expandToggle;

        [InjectComponents("Children")]
        private VerticalLayoutGroup _children;
        
        public int sibilngIndex;

        
        
        private void Awake()
        {
            Injector.Inject(this);
            
            
            _expandToggle.onValueChanged.AddListener(isOn =>
            {
            });

            sibilngIndex = transform.GetSiblingIndex();
        }

        private void Update()
        {
            transform.SetSiblingIndex(sibilngIndex);
        }
    }
}