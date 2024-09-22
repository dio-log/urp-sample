using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Hierarchy
{
    public class ViewItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _icon;
        [SerializeField] private Toggle _expandToggle;
        // [SerializeField] private Button _instance;

        private string _itemId;
        private bool _isFolder = false;
        private HierarchyEventSystem _eventSystem;
        
        public string ItemId => _itemId;
        public bool IsFolder => _isFolder;

        private void Awake()
        {
            
            
        }


        public void Initialize(string id, string label, bool isFolder, Sprite sprite, Toggle expandToggle, Button instance, HierarchyEventSystem eventSystem)
        {
            _itemId = id;
            _label.text = label;
            _isFolder = isFolder;
            _icon.sprite = sprite; 
            _expandToggle = expandToggle;
            // _instance = instance;

            _eventSystem = eventSystem;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("click");
        }
    }
}