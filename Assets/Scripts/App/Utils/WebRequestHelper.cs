using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace App.Utils
{
    public class WebRequestHelper 
    {
        public static async Task<ResponseData> SendRequestAsync(HttpMethod method, string url, Dictionary<string, string> body = null)
        {
            switch (method)
            {
                case HttpMethod.GET:
                    return await SendGetRequest(url);
                case HttpMethod.POST:
                    return await SendPostRequest(url, " ");
                default:
                    return null;
            }
        }

        private static async Task<ResponseData> SendGetRequest(string url)
        {
            using var uwr = UnityWebRequest.Get(url);
            
            await uwr.SendWebRequest();

            var responseData = new ResponseData();
            
            if(uwr.result == UnityWebRequest.Result.Success)
            {   
                responseData.RawData = uwr.downloadHandler.data;
                responseData.Text = uwr.downloadHandler.text;
                
                return responseData;
            }
            
            responseData.Error = uwr.error;
            return responseData;
        }

        private static async Task<ResponseData> SendPostRequest(string url, string body)
        {
            using var uwr = UnityWebRequest.PostWwwForm(url, body);
            
            await uwr.SendWebRequest();

            var responseData = new ResponseData();
            
            if(uwr.result == UnityWebRequest.Result.Success)
            {   
                responseData.RawData = uwr.downloadHandler.data;
                responseData.Text = uwr.downloadHandler.text;
                
                return responseData;
            }
            
            responseData.Error = uwr.error;
            return responseData;
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

    public class ResponseData
    {
        public bool IsSuccess => Error == null;
        public byte[] RawData { get; set; }
        public string Text { get; set; }
        public string Error { get; set; }
    }

    public enum HttpMethod
    {
        GET,
        POST,
    }
}