using UnityEngine.Events;

namespace App.Bridge
{
    public class DMFWebBridge : IWebBridge
    {
        
        public event UnityAction OnDataChanged { add { } remove { } }
    }
}