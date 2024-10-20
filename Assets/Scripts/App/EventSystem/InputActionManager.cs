using System;
using App.Space3D.Object3D;
using Test;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace App.EventSystem
{
    public class InputActionManager : MonoBehaviour
    {
        public InputActionAsset inputActionAsset;

        private float lastClickTime = 0f;  // 마지막 클릭 시간
        private float doubleClickThreshold = 0.3f; 
        
        private void Awake()
        {
            
            
            inputActionAsset.FindAction("LeftClick").performed += OnClickPerformed;

            // inputActionAsset.FindAction("LeftPress").performed += (c) =>
            // {
            //     Debug.Log("press");
            // };

        }

        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            var timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickThreshold)
            {
                OnDoubleClick();
            }
            else
            {
                OnSingleClick();
            }

            // 마지막 클릭 시간 업데이트
            lastClickTime = Time.time;
        }
        
        private void OnSingleClick()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            
            foreach (var hit in hits)
            {
                Debug.Log(hit.transform.name);
                var obj = hit.transform.GetComponent<TestObject>();
                if (obj is IClickActionHandler handler)
                {
                    handler.Click(new EvtArgs(obj));
                }
                
            }
            
        }

        private void OnDoubleClick()
        {
            Debug.Log("Double Click Detected");
        }
    }
}