using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class BuildScript
    {
        [MenuItem("Build/Build Development For Windows")]
        public static void BuildDevelopmentForWindows()
        {
            Build(
                "Builds/Windows/Development/MyGame_Dev.exe",
                BuildTarget.StandaloneWindows,
                BuildOptions.Development | BuildOptions.AllowDebugging,
                "DEV_BUILD_WINDOWS",
                "devConfig.json"
                );
        }

        [MenuItem("Build/Build Production For Windows")]
        public static void BuildProductionForWindows()
        {
            Build(
                "Builds/Windows/Production/MyGame.exe",
                BuildTarget.StandaloneWindows,
                BuildOptions.None, "PROD_BUILD_WINDOWS",
                "prodConfig.json"
                );
        }
        
        [MenuItem("Build/Build Development For WebGL")]
        public static void BuildDevelopmentForWebGL()
        {
            
            Build(
                "Builds/WebGL/Development/MyGame_Dev.exe",
                BuildTarget.WebGL,
                BuildOptions.Development | BuildOptions.AllowDebugging,
                "DEV_BUILD_WEBGL",
                "devConfig.json"
                );
        }
        
        [MenuItem("Build/Build Production For WebGL")]
        public static void BuildProductionForWebGL()
        {
            Build(
                "Builds/WebGL/Production/MyGame.exe",
                BuildTarget.WebGL,
                BuildOptions.None,
                "PROD_BUILD_WEBGL",
                "prodConfig.json"
                );
        }
        
        private static void Build(string locationPathName, BuildTarget buildTarget, BuildOptions buildOptions, string symbol, string configFileName)
        {
            var targetGroup = BuildPipeline.GetBuildTargetGroup(buildTarget);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, symbol);
            
            SetConfig(configFileName);
            
            var playerOptions = new BuildPlayerOptions
            {
                scenes = new[] { "Assets/Scenes/Main.unity" },
                locationPathName = locationPathName,
                target = buildTarget,
                options = buildOptions
            };
            
            BuildPipeline.BuildPlayer(playerOptions);
        }

        private static void SetConfig(string configFileName)
        {
            var sourcePath = Path.Combine(Application.dataPath, "Configs", configFileName);
            var targetPath = Path.Combine(Application.streamingAssetsPath, "Configs", "AppConfig.json");

            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
            
            File.Copy(sourcePath, targetPath, overwrite: true);
        }
    }
}