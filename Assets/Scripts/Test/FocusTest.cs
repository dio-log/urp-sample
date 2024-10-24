using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Test
{
    public class FocusTest : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform content;

        private RectTransform target;

        private void Awake()
        {

            target = gameObject.GetComponent<RectTransform>();
        }

        private void Update()
        {

            if (Input.GetKey(KeyCode.A))
            {
                Focus();
            }
            
                
        }

        public void Focus()
        {
            float contentHeight = scrollRect.content.rect.height;
            float viewportHeight = scrollRect.viewport.rect.height;

            // 아이템의 위치 (콘텐츠 내에서의 로컬 좌표)
            float itemCenterY = -target.localPosition.y + (target.rect.height / 2);

            // 뷰포트의 절반 높이
            float viewportHalfHeight = viewportHeight / 2;

            // 노멀라이즈된 스크롤 위치 계산
            float normalizedPosition = (itemCenterY - viewportHalfHeight) / (contentHeight - viewportHeight);

            // 값 제한 및 방향 보정
            normalizedPosition = Mathf.Clamp01(normalizedPosition);
            scrollRect.verticalNormalizedPosition = 1 - normalizedPosition;
        }
        
        
    }
}