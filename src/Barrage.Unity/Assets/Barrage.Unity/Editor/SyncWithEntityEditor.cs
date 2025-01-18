using Barrage.Unity.Conversion;
using UnityEditor;
using UnityEngine;

namespace Barrage.Unity.Editor
{
    [CustomEditor(typeof(SyncWithEntity))]
    [CanEditMultipleObjects]
    public sealed class SyncWithEntityEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (Application.isPlaying)
            {
                if (((SyncWithEntity)target).IsEntityExists())
                {
                    EditorGUILayout.HelpBox("This GameObject is synchronized with Entity.", MessageType.Info);
                }
                else
                {
                    EditorGUILayout.HelpBox("The Entity has been destroyed.", MessageType.Warning);
                }
            }
        }
    }
}