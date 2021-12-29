using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelExecuteControllerAsset), true)]
    internal class DomainModelExecuteControllerAssetEditor : UnityEditor.Editor
    {
        private DomainModelExecuteControllerListDrawer m_listControllers;

        private void OnEnable()
        {
            m_listControllers = new DomainModelExecuteControllerListDrawer(serializedObject.FindProperty("m_controllers"));
            m_listControllers.Enable();
        }

        private void OnDisable()
        {
            m_listControllers.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
            }
        }
    }
}
