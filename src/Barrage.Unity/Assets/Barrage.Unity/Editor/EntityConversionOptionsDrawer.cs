using Barrage.Unity.Conversion;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Barrage.Unity.Editor
{
    [CustomPropertyDrawer(typeof(EntityConversionOptions))]
    public sealed class EntityConversionOptionsDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();

            root.Add(new PropertyField(property.FindPropertyRelative("conversionMode")));
            root.Add(new PropertyField(property.FindPropertyRelative("convertUnityComponents")));

            root.TrackPropertyValue(property, property =>
            {
                root[1].style.display = property.FindPropertyRelative("conversionMode").enumValueIndex == (int)ConversionMode.SyncWithEntity
                    ? DisplayStyle.Flex
                    : DisplayStyle.None;
            });

            return root;
        }
    }
}