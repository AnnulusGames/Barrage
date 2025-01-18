using System;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Barrage.Unity.Editor
{
    public class BarrageHierarchyWindow : EditorWindow
    {
        [MenuItem("Window/Barrage Hierarchy")]
        public static BarrageHierarchyWindow Open()
        {
            var window = GetWindow<BarrageHierarchyWindow>(false, " Barrage Hierarchy", true);
            window.titleContent.image = EditorGUIUtility.IconContent("UnityEditor.HierarchyWindow").image;
            window.Show();
            return window;
        }

        int selectedWorldId;
        HierarchyTreeView treeView;
        TreeViewState treeViewState;

        void OnEnable()
        {
            treeViewState = new TreeViewState();
            treeView = new HierarchyTreeView(treeViewState);

            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        void OnDisable()
        {
            treeView.Dispose();
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        void OnPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            treeView.SetSelection(Array.Empty<int>());
            Repaint();
        }

        void OnGUI()
        {
            var worlds = World.Worlds.ToArray();

            using (new EditorGUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                if (worlds.Length == 0)
                {
                    GUILayout.Button("No World", EditorStyles.toolbarPopup, GUILayout.Width(100f));
                }
                else
                {
                    var displayedOptions = worlds.Select(x => $"World {WorldEx.IndexOf(x)}").ToArray();
                    var id = EditorGUILayout.IntPopup(selectedWorldId, displayedOptions, Enumerable.Range(0, worlds.Length).ToArray(), EditorStyles.toolbarPopup, GUILayout.Width(100f));
                    if (id != selectedWorldId)
                    {
                        treeView.SetSelection(Array.Empty<int>());
                        selectedWorldId = id;
                    }
                }

                GUILayout.FlexibleSpace();
            }

            if (worlds.Length == 0) return;
            if (worlds.Length <= selectedWorldId)
            {
                selectedWorldId = 0;
            }

            treeView.SetWorld(worlds[selectedWorldId]);
            var treeViewRect = EditorGUILayout.GetControlRect(false, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            treeView.OnGUI(treeViewRect);
        }
    }
}