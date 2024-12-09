using Modules.DataBinding.Binder;
using UnityEditor;
using UnityEngine;

namespace Modules.DataBinding.Editor
{
    [CustomPropertyDrawer(typeof(BindingType))]
    public class EnumDropdownDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Enum)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Not an Enum");
            }
        }
    }
}