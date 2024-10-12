using System;
using System.Collections;
using System.Threading;
using App.Utils;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace App.Test
{
    public struct MyJob : IJob
    {
        public void Execute()
        {
            Thread.Sleep(3000);
            Debug.Log("wait");
        }
    }
    
    
    public class AssetLoadTest : MonoBehaviour
    {
        
        
        
        private Hash128 _hash;
        private void Start()
        {
            StartCoroutine(RunJob());
            
            Caching.ClearCache();
            _hash = new Hash128();

            StartCoroutine(AssetBundleLoader.LoadAsync("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle", (obj) =>
            {
                Debug.Log("완료되면 실행");
                // Instantiate<GameObject>(obj as GameObject);
            }));
            //
            // StartCoroutine(Load<GameObject>("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle"));
            // StartCoroutine(Load<GameObject>("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle"));
            // StartCoroutine(Load<GameObject>("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle"));
            // StartCoroutine(Load<GameObject>("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle"));
            // StartCoroutine(Load<GameObject>("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle"));
            
            
            
                
        }

        public IEnumerator RunJob()
        {
            var job = new MyJob();
            
            
            var handle= job.Schedule();
            while (!handle.IsCompleted)
            {
                yield return null;
            }
            
            Debug.Log("com");
                        
        }
        
        public IEnumerator Load<T>(string url, UnityAction<T> onSuccess = null, UnityAction<string> onError= null) where T : UnityEngine.Object
        {
            // //에셋 이름이 유니크하지 않을수있으니, 번들이름먼저 매치시킬필요가 있음 
            // if (!TryGetLoadedAssetBundle(bundleName, out var assetBundle))
            // {
            //     using var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
            //         
            //     yield return uwr.SendWebRequest();
            //         
            //     if (uwr.result == UnityWebRequest.Result.Success)
            //     {
            //         assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
            //     }
            //     else
            //     {
            //         onError?.Invoke(uwr.error);
            //         yield break;
            //     }
            // // }
            //
        
            using var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url, _hash);
                
            yield return uwr.SendWebRequest();

            AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);

            var objects = assetBundle.LoadAllAssets();
            
            foreach (var o in objects)
            {
                Instantiate(o);
            }
            
            assetBundle.Unload(true);

            // if (uwr.result == UnityWebRequest.Result.Success)
            // {
            //     assetBundle = 
            // }
            // else
            // {
            //     onError?.Invoke(uwr.error);
            //     yield break;
            // }
            //
            // if (assetBundle is null)
            // {
            //     onError?.Invoke("AssetBundle is null");
            //     yield break;
            // }
            //
            // // assets/prefabs/tile.prefab
            // foreach (var assetName in assetBundle.GetAllAssetNames())
            // {
            //     
            //     Debug.Log(assetName);
            // }

            // var asset = assetBundle.LoadAsset<T>(assetName);
            //
            // if (asset is null)
            // {
            //     onError?.Invoke("Asset is null");
            //     yield break;
            // }
            //     
            // onSuccess?.Invoke(asset);
        } 
    }
    
}