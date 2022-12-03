using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain.Systems;
using UnityEditor;

namespace UGF.Models.Editor.Domain.Systems
{
    [CustomEditor(typeof(DomainSystemModelAsset), true)]
    internal class DomainSystemModelAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listModels;
        private ReorderableListSelectionDrawerByElementGlobalId m_listModelsSelection;

        private void OnEnable()
        {
            m_listModels = new ReorderableListDrawer(serializedObject.FindProperty("m_models"))
            {
                DisplayAsSingleLine = true
            };

            m_listModelsSelection = new ReorderableListSelectionDrawerByElementGlobalId(m_listModels)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listModels.Enable();
            m_listModelsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listModels.Disable();
            m_listModelsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listModels.DrawGUILayout();
                m_listModelsSelection.DrawGUILayout();
            }
        }
    }
}
