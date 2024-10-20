using System.IO;
using UnityEngine;

namespace App.Env.Config
{
    public class Configuration
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var configPath = Path.Combine(Application.streamingAssetsPath, "Configs", "AppConfig.json");
            
            #if UNITY_EDITOR
                Debug.Log("ddd");
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    var config = JsonUtility.FromJson<ConfigProperties>(json);
                    Debug.Log("환경 설정이 성공적으로 로드되었습니다.");
                    
                }
                else
                {
                    Debug.LogError($"환경 설정 파일을 찾을 수 없습니다: {configPath}");
                }
            #elif BUILD_DEV_WEBGL || BUILD_PROD_WEBGL
                
            #elif BUILD_DEV_WINDOWS || BUILD_PROD_WINDOWS
            
            #endif
        }
    }
}