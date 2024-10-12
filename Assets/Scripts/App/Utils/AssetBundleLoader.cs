using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

namespace App.Utils
{
    
    //번들의 모든 에셋로드, 인스턴스화 x
    //번들을 로드하고 특정 에셋을 인스턴스화
    public class AssetBundleLoader
    {
        public static IEnumerator LoadAsync(string url, UnityAction<object> callback)
        {
            using var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
                
            yield return uwr.SendWebRequest();

            AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);

            var objects = assetBundle.LoadAllAssets();

            GameObject prefab = new();
            foreach (var o in objects)
            {
                prefab = o as GameObject;
                
                // Instantiate(o);
            }

            yield return InstantiateMultiple(prefab, 17);

            
            callback?.Invoke(prefab);
            
            assetBundle.Unload(true);
        }

        private static int batchSize = 5;
        private static IEnumerator InstantiateMultiple(GameObject prefab, int count)
        {
            int instanceCount = 0;
            while (count > instanceCount)
            {
                var min = (count - instanceCount) < batchSize ? count - instanceCount : batchSize;
                // 한 프레임에 batchSize만큼 인스턴스화
                for (int i = 0; i < min ; i++)
                {
                    Object.Instantiate(prefab);
                    instanceCount++;
                }
                //
                // for (int i = 0; i < count; i++)
                // {
                //     GameObject instance = GameObject.Instantiate(prefab, parent);
                //     instances.Add(instance);
                //
                //     // 인스턴스화 작업을 분할하여 프레임 드롭 방지 (옵션)
                //     if (i % 10 == 0)
                //     {
                //         yield return null; // 다음 프레임까지 대기
                //     }
                // }

                // 다음 프레임으로 넘어가기 전에 대기
                yield return null;
            }
        
            Debug.Log("All instances created : " + instanceCount);
        }
        
        
        public static IEnumerator Load<T>(string url, string bundleName, string assetName, UnityAction<T> onSuccess = null, UnityAction<string> onError = null) where T : UnityEngine.Object
        {
            //에셋 이름이 유니크하지 않을수있으니, 번들이름먼저 매치시킬필요가 있음 
            if (!TryGetLoadedAssetBundle(bundleName, out var assetBundle))
            {
                using var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
                
                yield return uwr.SendWebRequest();
                
                if (uwr.result == UnityWebRequest.Result.Success)
                {
                    assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
                }
                else
                {
                    onError?.Invoke(uwr.error);
                    yield break;
                }
            }

            if (assetBundle is null)
            {
                onError?.Invoke("AssetBundle is null");
                yield break;
            }
            
            var asset = assetBundle.LoadAsset<T>(assetName);

            if (asset is null)
            {
                onError?.Invoke("Asset is null");
                yield break;
            }
            
            onSuccess?.Invoke(asset);
        } 
        

        public static IEnumerator LoadAll<T>(string url, string bundleName, UnityAction<T[]> onSuccess = null, UnityAction<string> onError = null) where T : UnityEngine.Object
        {
            if (!TryGetLoadedAssetBundle(bundleName, out var assetBundle))
            {
                using var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
                var operation = uwr.SendWebRequest();
                yield return operation;

                if (uwr.result == UnityWebRequest.Result.Success)
                {
                    assetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
                }
                else
                {
                    onError?.Invoke(uwr.error);
                    yield break;
                }
            }
            
            if (assetBundle is null)
            {
                onError?.Invoke("Asset is null");
                yield break;
            }
            onSuccess?.Invoke(assetBundle.LoadAllAssets<T>());
        }

        private static bool TryGetLoadedAssetBundle(string bundleName, out AssetBundle assetBundle)
        {
            assetBundle = default;
            foreach (var loadedBundle in AssetBundle.GetAllLoadedAssetBundles())
            {
                if (loadedBundle.name.Equals(bundleName))
                {
                    assetBundle = loadedBundle;
                    return true;
                }
            }

            return false;
        }

    }
}