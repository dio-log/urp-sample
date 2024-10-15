using System;

namespace App.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FindComponent : Attribute
    {
        public string GameObjectName { get; }

        public FindComponent(string gameObjectName)
        {
            GameObjectName = gameObjectName;
        }
    }
}