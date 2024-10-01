using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Utils
{
    public class CoroutineRunner : MonoBehaviour
    {

        public Coroutine Run(List<Coroutine> coroutines)
        {
            return StartCoroutine(Coroutine(coroutines));
        }
        public IEnumerator Coroutine(List<Coroutine> coroutines)
        {
            foreach (var coroutine in coroutines)
            {
                yield return coroutine;
            }
        }

        public Coroutine Run(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}