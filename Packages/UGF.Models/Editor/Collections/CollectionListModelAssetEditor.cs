using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Collections;
using UnityEditor;

namespace UGF.Models.Editor.Collections
{
    [CustomEditor(typeof(CollectionListModelAsset), true)]
    internal class CollectionListModelAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listItems;

        private void OnEnable()
        {
            m_listItems = new ReorderableListDrawer(serializedObject.FindProperty("m_items"))
            {
                DisplayAsSingleLine = true
            };

            m_listItems.Enable();
        }

        private void OnDisable()
        {
            m_listItems.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listItems.DrawGUILayout();
            }
        }
    }
}
