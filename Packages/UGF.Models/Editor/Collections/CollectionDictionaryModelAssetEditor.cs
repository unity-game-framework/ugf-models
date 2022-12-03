using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Collections;
using UnityEditor;

namespace UGF.Models.Editor.Collections
{
    [CustomEditor(typeof(CollectionDictionaryModelAsset), true)]
    internal class CollectionDictionaryModelAssetEditor : UnityEditor.Editor
    {
        private ReorderableListKeyAndValueDrawer m_listItems;
        private ReorderableListSelectionDrawerByPathGlobalId m_listItemsSelection;

        private void OnEnable()
        {
            m_listItems = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_items"));

            m_listItemsSelection = new ReorderableListSelectionDrawerByPathGlobalId(m_listItems, "m_value")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listItems.Enable();
            m_listItemsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listItems.Disable();
            m_listItemsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listItems.DrawGUILayout();
                m_listItemsSelection.DrawGUILayout();
            }
        }
    }
}
