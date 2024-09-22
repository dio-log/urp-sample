using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Tree
{
    public class Targeting : MonoBehaviour, IPointerMoveHandler, IPointerExitHandler
    {
        public Button mainButton;
        
        public void OnPointerMove(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.SetAsFirstSibling();
        }
    }
}