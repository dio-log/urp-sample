using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Rendering.Universal;
using Object = UnityEngine.Object;

namespace App.Utils
{
    public class AssetBundleLoader2 : MonoBehaviour
    {
        private AssetBundle _assetBundle;
        
        public static AssetBundleLoader2 FormWeb(string url) => new AssetBundleLoader2().Load(url);
        public static AssetBundleLoader2 FormLocal(string path, string fileName) => new AssetBundleLoader2().Load(path, fileName);
      
        private AssetBundleLoader2 Load(string url)
        {
            var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
            var operation = uwr.SendWebRequest();
            while (!operation.isDone)
            {
                Task.Yield();
            }
            Debug.Log("1");
            Debug.Log(uwr.result);
            Debug.Log(uwr.error);
            _assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
            
            return this;
        }
        
        private AssetBundleLoader2 Load(string path, string fileName)
        {
            
            var uwr = UnityWebRequestAssetBundle.GetAssetBundle(Path.Combine(path, fileName));
            var operation = uwr.SendWebRequest();
            while (!operation.isDone)
            {
                // yield return ;
                Task.Yield();
            }
            Debug.Log("1");
            _assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
            
            return this;
        }

        public void FromWeb(string url, UnityAction callback)
        {
            // StartCoroutine(Load(url, callback));
        }
        
        private IEnumerator Load(string url, UnityAction onComplete)
        {
            
            Debug.Log("1");
            Thread.Sleep(3000);
            // Task.Delay(10000);
            Debug.Log("2");
            var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
            yield return uwr.SendWebRequest();

            var bundles =  AssetBundle.GetAllLoadedAssetBundles();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                var assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var objs = assetBundle.LoadAllAssets();
                foreach (var o in objs)
                {
                    Debug.Log(o.name);
                    Instantiate(o);
                }
                
                onComplete.Invoke();
            }
                
        }

        public T LoadAsset<T>(string assetName) where T : Object
        {
            return _assetBundle.LoadAsset<T>(assetName);
        }

        public void LoadAllAssets()
        {
            Debug.Log("2");
            var objects = _assetBundle.LoadAllAssets();

            foreach (var o in objects)
            {
                Debug.Log(o.name);
            }
        }
        
    }
}