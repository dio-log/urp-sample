using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using App.Core.Shared.Utils;
using UnityEngine;

namespace App.Core.Shared.DI
{
    public class Injector
    {

        public static void Inject(MonoBehaviour mono)
        {

            var type = mono.GetType();

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            
            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<InjectComponentsAttribute>();

                if(attr == null) continue;
                
                if (field.FieldType.IsArray)
                {
                    InjectArrayField(field, attr, mono);
                }
                else if(field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>)                )
                {
                    InjectListField(field, attr, mono);
                }
                else
                {
                    InjectSingleField(field, attr, mono);
                }
            }
        }

        private static void InjectArrayField(FieldInfo field, InjectComponentsAttribute attr, MonoBehaviour mono)
        {
            var type = field.FieldType.GetElementType();

            var components = new List<Component>();
            
            foreach (var name in attr.GameObjectNames)
            {
                var tr = TransformUtil.FindByName(name, mono.transform);
                
                if (tr == null)
                {
                    Debug.Log($"GameObject {name} not found");
                    continue;
                }

                var component = tr.GetComponent(type);

                if (component == null)
                {
                    Debug.Log($"Component {name} not found");
                    continue;
                }

                components.Add(component);
            }
            
            field.SetValue(mono, components.ToArray());
        }

        private static void InjectListField(FieldInfo field, InjectComponentsAttribute attr, MonoBehaviour mono)
        {
            var type = field.FieldType.GetGenericArguments()[0];
            
            var components = new List<Component>();
            
            foreach (var name in attr.GameObjectNames)
            {
                var tr = TransformUtil.FindByName(name, mono.transform);

                if (tr == null)
                {
                    Debug.Log($"GameObject {name} not found");
                    continue;
                }

                var component = tr.GetComponent(type);

                if (component == null)
                {
                    Debug.Log($"Component {name} not found");
                    continue;
                }

                components.Add(component);
            }
            
            field.SetValue(mono, components);
        }
        
        private static void InjectSingleField(FieldInfo field, InjectComponentsAttribute attr, MonoBehaviour mono)
        {
            var tr = TransformUtil.FindByName(attr.GameObjectNames[0], mono.transform);
            
            if (tr == null) return;
            
            var component = tr.GetComponent(field.FieldType);
            
            if (component == null) return;
            
            field.SetValue(mono, component);
        }
        
    }
}