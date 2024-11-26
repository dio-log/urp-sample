using System;
using App.Core.Shared.DI;
using App.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace App.GUI.Widget
{
    public class SavePopup : MonoBehaviour
    {
        [InjectComponents("SaveButton")] private Button _saveButton;
        [InjectComponents("cancelButton")] private Button _cancelButton;

        public event UnityAction<string> OnSaveButtonClicked;

        public event UnityAction OnBeforeSave;

        public event UnityAction OnSaveSuccessed;
        public event UnityAction OnSaveFailed;
        
        public string Body { get; set; }
        
        private void Awake()
        {
            Injector.Inject(this);
            
            _saveButton.onClick.AddListener(OnSaveButtonClick);

            OnSaveButtonClicked += (data) =>
            {
                Debug.Log("clicked"); 
            };
        }


        private async void OnSaveButtonClick()
        {
            if (!ValidateBody(Body)) return;
            //로딩스크린 인 
            using var uwr = UnityWebRequest.PostWwwForm("test", Body);
            
            await uwr.SendWebRequest();
            //로딩 스크린 아웃 
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log(uwr.error);
            }
            
            
            OnSaveButtonClicked?.Invoke("dd");
        }

        private bool ValidateBody(string body)
        {
            return !string.IsNullOrEmpty(body);
        }
    }
}