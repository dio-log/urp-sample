using System.Collections;
using UnityEngine;

namespace App.Utils
{
    public class CoroutineRunner : MonoBehaviour
    {

        public Coroutine Run(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }
    }
}