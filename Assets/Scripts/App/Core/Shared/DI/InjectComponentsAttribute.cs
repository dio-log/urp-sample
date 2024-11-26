using System;
using System.Collections.Generic;

namespace App.Core.Shared.DI
{
    public class InjectComponentsAttribute : Attribute
    {
        public string[] GameObjectNames { get; private set; }
        
        public bool UseFieldType => GameObjectNames == null || GameObjectNames.Length == 0;

        public InjectComponentsAttribute() { }
        
        public InjectComponentsAttribute(params string[] gameObjectNames)
        {
            GameObjectNames = gameObjectNames;
        }
        
    }
}