
using System;
using System.Collections;
using System.Threading.Tasks;
using App.Utils;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    [SerializeField]
    private AssetBundleLoader assetBundleLoader;
    private void Start()
    {
        int i = 0;
        // while (i < 100)
        // {
        //     i++;
        //     assetBundleLoader.FromWeb("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle", () => {Debug.Log("com"+i);});
        //     
        // }

        // AssetBundleLoader.FormWeb("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle").LoadAllAssets();

        // StartCoroutine(AssetBundleLoader.Load("https://github.com/dio-log/dummy-data/tree/main/assetbundles"))
        

    }

    private void Update()
    {
        assetBundleLoader.FromWeb("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle", () => {});
    }
}