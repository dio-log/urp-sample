using UnityEngine;

namespace App.Core.Shared.Utils
{
    public class TransformUtil
    {
        public static Transform FindByName(string name, Transform tr)
        {
            if (tr.name.Equals(name)) return tr;

            for (var i = 0; i < tr.childCount; i++)
            {
                var found = FindByName(name, tr.GetChild(i));
                if(found != null) return found;
            }
            
            return null;
        }
    }
}