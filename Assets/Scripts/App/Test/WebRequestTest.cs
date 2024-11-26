using System;
using System.Collections;
using App.Utils;
using UnityEngine;

namespace App.Test
{
    public class WebRequestTest : MonoBehaviour
    {
        [SerializeField]
        private WebRequestHelper webRequestHelper;
        private void Awake()
        {



            // StartCoroutine(Send());

        }


        // private IEnumerator Send()
        // {
            // yield return webRequestHelper.SendAsync(HttpMethod.GET,
            //     "https://raw.githubusercontent.com/dio-log/dummy-data/refs/heads/main/data/dummy.json");
            //
            // yield return webRequestHelper.SendAsync(HttpMethod.POST, "https://jsonplaceholder.typicode.com/posts");
            //
        // }
        
        
    }
}