using System;
using App.Core.Shared.DI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Test
{
    public class Subscriber : MonoBehaviour
    {
        [InjectComponents("Publisher")] private Publisher _publisher;


        private void Awake()
        {
            Injector.Inject(this);
        }

        private void Start()
        {

            _publisher.OnClicked += OnPublisherClicked;
        }

        private void OnPublisherClicked(bool value)
        {
            Debug.Log(value);
        }
    }
}