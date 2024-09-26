using System;
using System.Collections.Generic;
using SimpleMan.CoroutineExtensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Tree
{
    public class Targeting : MonoBehaviour, IPointerMoveHandler, IPointerExitHandler
    {
        public Button mainButton;


        private void Awake()
        {
            // this.Delay();
        }

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