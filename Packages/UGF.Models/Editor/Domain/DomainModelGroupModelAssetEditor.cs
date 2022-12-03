using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelGroupModelAsset), true)]
    internal class DomainModelGroupModelAssetEditor : UnityEditor.Editor
    {
        private ReorderableListKeyAndValueDrawer m_listModels;
        private ReorderableListSelectionDrawerByPathGlobalId m_listModelsSelectionKey;
        private ReorderableListSelectionDrawerByPathGlobalId m_listModelsSelectionValue;

        private void OnEnable()
        {
            m_listModels = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_models"));

            m_listModelsSelectionKey = new ReorderableListSelectionDrawerByPathGlobalId(m_listModels, "m_key")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listModelsSelectionValue = new ReorderableListSelectionDrawerByPathGlobalId(m_listModels, "m_value")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listModels.Enable();
            m_listModelsSelectionKey.Enable();
            m_listModelsSelectionValue.Enable();
        }

        private void OnDisable()
        {
            m_listModels.Disable();
            m_listModelsSelectionKey.Disable();
            m_listModelsSelectionValue.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listModels.DrawGUILayout();
                m_listModelsSelectionKey.DrawGUILayout();
                m_listModelsSelectionValue.DrawGUILayout();
            }
        }
    }
}
