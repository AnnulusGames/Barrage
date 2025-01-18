using Barrage.Unity.Conversion;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Barrage.Unity.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EntityConverter))]
    public sealed class EntityConverterEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var field = new PropertyField(serializedObject.FindProperty("options"));
            field.schedule.Execute(() =>
            {
                field.enabledSelf = !Application.isPlaying;
            }).Every(10);
            return field;
        }
    }
}