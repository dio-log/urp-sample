using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Assertions;

namespace Modules.DataBinding
{
    
    [CreateAssetMenu(fileName = "GlobalDataContext", menuName = "Scriptable Object/GlobalDataContext", order = int.MaxValue)]
    public class DataContext : ScriptableObject
    {
        // private Property<string, string> _master = new("dd","dd");

        // private DelegateProperty<string, string> _property = new DelegateProperty<string, string>();
        
        private static Dictionary<string, string> _context = new Dictionary<string, string>();


        public static void Register(string path, string value)
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("키가 null이거나 비어 있습니다.");
                return;
            }

            _context[path] = value;
        }
        
        public static string Find(string path)
        {
            if (_context.TryGetValue(path, out var value))
            {
                return value;
            }

            Debug.Log($"키를 찾을 수 없습니다: {path}");
            return null;
        }
        
        public static void Remove(string path)
        {
            if (_context.Remove(path))
            {
                Debug.Log($"삭제 완료: {path}");
            }
            else
            {
                Debug.LogWarning($"삭제 실패 - 키를 찾을 수 없습니다: {path}");
            }
        }
        
        public static void Clear()
        {
            _context.Clear();
        }
    }
}