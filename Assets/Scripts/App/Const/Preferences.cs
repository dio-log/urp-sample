using UnityEngine;
using UnityEngine.Events;

namespace App.Const
{
    public class Preferences : MonoBehaviour
    {
        public bool AutoSave { private get; set; }

        public UnityAction<bool> OnAutoSaveChanged { get; set; }
        
        private void SetAutoSave(bool value)
        {
            AutoSave = value;
            OnAutoSaveChanged?.Invoke(AutoSave);
        }
        
        
    }
}