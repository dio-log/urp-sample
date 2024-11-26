using UnityEngine.Events;

namespace App.Bridge
{
    public interface IWebBridge
    {
        public event UnityAction OnDataChanged; 
        
    }
}