using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Collections;
using UnityEditor;

namespace UGF.Models.Editor.Collections
{
    [CustomEditor(typeof(CollectionDictionaryModelAsset), true)]
    internal class CollectionDictionaryModelAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listItems;
        private ReorderableListSelectionDrawerByPath m_listItemsSelection;

        private void OnEnable()
        {
            m_listItems = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_models"));

            m_listItemsSelection = new ReorderableListSelectionDrawerByPath(m_listItems, "m_asset")
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
