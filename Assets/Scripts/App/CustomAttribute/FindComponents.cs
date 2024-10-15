using System;

namespace App.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FindComponents : Attribute
    {
        public string[] GameObjectNames { get; }

        public FindComponents(params string[] gameObjectNames)
        {
            GameObjectNames = gameObjectNames;
        }
            
    }
}