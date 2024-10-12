using UnityEngine.Events;

namespace App.Bridge
{
    public class DMFBridge : IWebBridge
    {
        
        public event UnityAction OnDataChanged { add { } remove { } }
    }
}