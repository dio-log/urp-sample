using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace App.Utils
{
    
    //번들의 모든 에셋로드, 인스턴스화 x
    //번들을 로드하고 특정 에셋을 인스턴스화
    public class AssetBundleLoader
    {
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