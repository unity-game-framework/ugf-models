using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelAsset), true)]
    internal class DomainModelAssetEditor : UnityEditor.Editor
    {
        private AssetReferenceListDrawer m_listModels;

        private void OnEnable()
        {
            m_listModels = new AssetReferenceListDrawer(serializedObject.FindProperty("m_models"));
            m_listModels.Enable();
        }

        private void OnDisable()
        {
            m_listModels.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listModels.DrawGUILayout();
            }
        }
    }
}
