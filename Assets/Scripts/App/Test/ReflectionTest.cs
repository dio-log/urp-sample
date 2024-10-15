using System;
using App.CustomAttribute;
using App.Utils;
using UnityEngine;

namespace App.Test
{
    public class ReflectionTest : MonoBehaviour
    {
        [FindComponent("Cube")] private GameObject go;


        private void Awake()
        {
            Injector.InjectComponent(this);
        }
    }
}