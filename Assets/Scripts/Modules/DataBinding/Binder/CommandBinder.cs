using System;
using UnityEngine;

namespace Modules.DataBinding.Binder
{
    public class CommandBinder : MonoBehaviour
    {

        [SerializeField]
        private DataContext _dataSource;
        
        [SerializeField]
        private string _path;


        private void Start()
        {
            
            
        }

        private void Bind()
        {
            }
    }
}