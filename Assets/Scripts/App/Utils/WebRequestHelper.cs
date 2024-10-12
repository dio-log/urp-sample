using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace App.Utils
{
    public class WebRequestHelper : MonoBehaviour
    {

        private IEnumerator _sendGetRequest;
        private IEnumerator _sendPostRequest;

        private void Awake()
        {
            // _sendPostRequest = SendGetRequest();

        }

        public Coroutine SendAsync(HttpMethod method, string url, Dictionary<string, string> body = null, UnityAction<string> onSuccess = null)
        {
            switch (method)
            {
                case HttpMethod.GET:
                    return StartCoroutine(SendGetRequest(url, onSuccess));
                case HttpMethod.POST:
                    return StartCoroutine(SendPostRequest(url, body, onSuccess));
                default:
                    Debug.LogError("지원하지 않는 HTTP 메소드입니다.");
                    return null;
            }
        }

        public IEnumerator SendGetRequest(string url, UnityAction<string> onSuccess)
        {

            using var uwr = UnityWebRequest.Get(url);

            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + uwr.error);
                yield break;
            }

            // var bytes = uwr.downloadHandler.data;
            Debug.Log(uwr.downloadHandler.text);
            onSuccess?.Invoke(uwr.downloadHandler.text);
            
        }
        //
        // public IEnumerator SendPostRequest(string url, List<IMultipartFormSection> body, UnityAction<string> onSuccess = null)
        // {
        //     using var uwr = UnityWebRequest.Post(url, body);
        //     
        //     yield return uwr.SendWebRequest();
        //     
        //     if (uwr.result != UnityWebRequest.Result.Success)
        //     {
        //         Debug.Log("Error: " + uwr.error);
        //         yield break;
        //     }
        //
        //     onSuccess?.Invoke(uwr.downloadHandler.text);
        // }
        
        public IEnumerator SendPostRequest(string url, Dictionary<string, string> body, UnityAction<string> onSuccess)
        {
            using var uwr = UnityWebRequest.Post(url, body ?? new Dictionary<string, string>());
            
            yield return uwr.SendWebRequest();
            
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + uwr.error);
                yield break;
            }
            Debug.Log(uwr.downloadHandler.text);
            onSuccess?.Invoke(uwr.downloadHandler.text);
        }
        
        private string AppendQueryParameters(string url, Dictionary<string, string> parameters)
        {
            var sb = new StringBuilder();
            sb.Append(url);
            if (!url.Contains("?"))
            {
                sb.Append("?");
            }
            else if (!url.EndsWith("&"))
            {
                sb.Append("&");
            }

            foreach (var kvp in parameters)
            {
                sb.AppendFormat("{0}={1}&", UnityWebRequest.EscapeURL(kvp.Key), UnityWebRequest.EscapeURL(kvp.Value));
            }

            // 마지막 '&' 문자 제거
            if (sb[sb.Length - 1] == '&')
            {
                sb.Length--;
            }

            return sb.ToString();
        }

    }

    public enum HttpMethod
    {
        GET,
        POST,
    }
}