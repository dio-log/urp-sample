using System.Collections.Generic;
using System.Reflection;
using App.CustomAttribute;
using UnityEngine;

namespace App.Utils
{
    public static class Injector
    {
        //파라미터 타입 Mono여도 될 것 같은데 
        public static void InjectComponent(object o)
        {
            var type = o.GetType();
            if (o is not MonoBehaviour mono) return;

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attr = (FindComponent)field.GetCustomAttribute(typeof(FindComponent));
                
                if (attr == null) continue;

                if (field.FieldType.IsArray)
                {
                    InjectArrayField(field, attr, mono);
                }
                else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    InjectListField(field, attr, mono);
                }
                else
                {
                    InjectSingleField(field, attr, mono);
                }
            }
        }

        private static void InjectArrayField(FieldInfo field, FindComponent attr, MonoBehaviour mono)
        {
        }

        private static void InjectListField(FieldInfo field, FindComponent attr, MonoBehaviour mono)
        {
            
        }

        private static void InjectSingleField(FieldInfo field, FindComponent attr, MonoBehaviour mono)
        {
            var tr = FindChildByName(attr.GameObjectName, mono.transform);
            
            if (tr == null) return;
            
            var component = tr.GetComponent(field.FieldType);
            
            if (component == null) return;
            
            field.SetValue(mono, component);
        }
        
        
        

        /// <param name="name"> GameObject.name </param>
        /// <param name="tr"> Transform </param>
        /// <returns> Transform </returns>
        public static Transform FindChildByName(string name, Transform tr)
        {
            if (tr.name.Equals(name)) return tr;

            for (var i = 0; i < tr.childCount; i++)
            {
                var found = FindChildByName(name, tr.GetChild(i));
                if(found != null) return found;
            }
            
            return null;
        }
        
        
    }
}