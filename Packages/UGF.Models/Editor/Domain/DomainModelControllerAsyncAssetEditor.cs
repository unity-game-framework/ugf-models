using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelControllerAsyncAsset), true)]
    internal class DomainModelControllerAsyncAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listControllers;

        private void OnEnable()
        {
            m_listControllers = new ReorderableListDrawer(serializedObject.FindProperty("m_controllers"))
            {
                DisplayAsSingleLine = true
            };

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
