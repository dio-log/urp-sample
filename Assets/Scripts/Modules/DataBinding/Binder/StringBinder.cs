using System;
using Unity.Properties;
using UnityEngine;

namespace Modules.DataBinding.Binder
{
    public class StringBinder : MonoBehaviour
    {
        [SerializeField]
        private DataContext _dataSource;

        [SerializeField] private string _path;
        
        public string Path { get; set; }
        
        private void Awake()
        {
            DataContext.Find(_path);

            Debug.Log(nameof(Path));
            Debug.Log(nameof(_path));
            Debug.Log(nameof(Test.Value));
            Debug.Log(nameof(Test.ff));
            Debug.Log(nameof(Test.A) is string);
        }
    }

    public class Test
    {
        public int Value { get; set; }
        public string ff;
        public void A(){}
        
    }
}