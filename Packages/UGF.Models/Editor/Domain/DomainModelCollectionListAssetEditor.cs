using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelCollectionListAsset), true)]
    internal class DomainModelCollectionListAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listModels;
        private ReorderableListSelectionDrawerByPath m_listModelsSelection;

        private void OnEnable()
        {
            m_listModels = new ReorderableListDrawer(serializedObject.FindProperty("m_models"))
            {
                DisplayAsSingleLine = true
            };

            m_listModelsSelection = new ReorderableListSelectionDrawerByPath(m_listModels, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
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
