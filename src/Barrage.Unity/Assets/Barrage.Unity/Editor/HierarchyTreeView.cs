using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Barrage.Unity.Editor
{
    public sealed class HierarchyTreeView : TreeView, IDisposable
    {
        public enum ItemType
        {
            World,
            Entity
        }

        public sealed class Item : TreeViewItem
        {
            Item() { }

            static readonly Stack<Item> pool = new();
            public static Item GetOrCreate()
            {
                if (!pool.TryPop(out var item)) item = new();
                return item;
            }

            public static void Return(Item item)
            {
                item.parent = null;
                item.children?.Clear();
                pool.Push(item);
            }

            public ItemType itemType;
            public Entity entity;
        }

        public HierarchyTreeView(TreeViewState state) : base(state)
        {

        }

        public void SetWorld(World world)
        {
            var changed = TargetWorld != world;

            TargetWorld = world;
            Reload();

            if (changed)
            {
                SetExpanded(-2, true);
                SetExpanded(-1, true);
            }
        }

        World TargetWorld { get; set; }

        EntitySelectionProxy currentSelection;
        Item root;
        readonly List<Item> items = new();

        protected override TreeViewItem BuildRoot()
        {
            foreach (var item in items) Item.Return(item);
            items.Clear();

            root = Item.GetOrCreate();
            root.id = -2;
            root.depth = -1;
            root.displayName = "Root";
            items.Add(root);

            var hierarchyRoot = Item.GetOrCreate();
            hierarchyRoot.id = -1;
            hierarchyRoot.depth = 0;
            hierarchyRoot.displayName = $"World {WorldEx.IndexOf(TargetWorld)}";
            hierarchyRoot.itemType = ItemType.World;
            items.Add(hierarchyRoot);
            root.AddChild(hierarchyRoot);

            foreach (var archetype in TargetWorld.Archetypes)
            {
                foreach (var chunk in archetype.Chunks)
                {
                    var entities = chunk.GetEntities();

                    for (int i = 0; i < chunk.Count; i++)
                    {
                        hierarchyRoot.AddChild(CreateItem(entities[i]));
                    }
                }
            }
            return root;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (Item)args.item;
            var disabled = TargetWorld.Exists(item.entity) && TargetWorld.HasComponent<GameObjectDisabled>(item.entity);

            using (new EditorGUI.DisabledScope(disabled))
            {
                var iconImage = item.itemType == ItemType.World ? Styles.ModelImporterIcon.image : Styles.GameObjectIcon.image;
                var iconRect = args.rowRect;
                iconRect.x += GetContentIndent(args.item);
                iconRect.width = 16f;
                GUI.DrawTexture(iconRect, iconImage);

                extraSpaceBeforeIconAndLabel = iconRect.width + 2f;
                base.RowGUI(args);
            }
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            base.SelectionChanged(selectedIds);

            if (selectedIds.Count == 0) return;
            var item = (Item)FindItem(selectedIds[0], root);

            if (item.itemType == ItemType.World)
            {
                Selection.activeObject = null;
                return;
            }

            if (currentSelection == null) currentSelection = ScriptableObject.CreateInstance<EntitySelectionProxy>();

            currentSelection.world = TargetWorld;
            currentSelection.entity = item.entity;

            Selection.activeObject = currentSelection;
        }

        TreeViewItem CreateItem(Entity entity)
        {
            var hasName = TargetWorld.TryGetComponent(entity, out EntityName entityName);
            var item = Item.GetOrCreate();
            item.id = entity.Index;
            item.depth = 1;
            item.displayName = hasName ? entityName.ToString() : $"Entity({entity.Index}:{entity.Version})";
            item.itemType = ItemType.Entity;
            item.entity = entity;
            return item;
        }

        public void Dispose()
        {
            if (currentSelection != null) UnityEngine.Object.Destroy(currentSelection);
        }
    }
}