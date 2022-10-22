using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelControllerAsyncAsset), true)]
    internal class DomainModelExecuteControllerAsyncAssetEditor : UnityEditor.Editor
    {
        private ReorderableListKeyAndValueDrawer m_listControllers;

        private void OnEnable()
        {
            m_listControllers = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_controllers"), "m_model", "m_controller");
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
