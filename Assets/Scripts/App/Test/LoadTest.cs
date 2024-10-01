
using App.Utils;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    
    [SerializeField] private CoroutineRunner _coroutineRunner;
    private void Start()
    {
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
        // assetBundleLoader2.FromWeb("https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle", () => {});

        // _coroutineRunner.Run(
        //     AssetBundleLoader.LoadAll<GameObject>(
        //         "https://github.com/dio-log/dummy-data/raw/main/assetbundles/testbundle",
        //         "testbundle",
        //         (args) =>
        //         {
        //             Debug.Log($"down : {args.Length}");
        //         })
        //     );
    }
}