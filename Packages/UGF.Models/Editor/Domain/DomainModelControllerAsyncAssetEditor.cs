using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelControllerAsyncAsset), true)]
    internal class DomainModelControllerAsyncAssetEditor : UnityEditor.Editor
    {
        private ReorderableListKeyAndValueDrawer m_listControllers;
        private ReorderableListSelectionDrawerByPathGlobalId m_listControllersSelectionModel;
        private ReorderableListSelectionDrawerByPathGlobalId m_listControllersSelectionController;

        private void OnEnable()
        {
            m_listControllers = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_controllers"), "m_model", "m_controller");

            m_listControllersSelectionModel = new ReorderableListSelectionDrawerByPathGlobalId(m_listControllers, "m_model")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listControllersSelectionController = new ReorderableListSelectionDrawerByPathGlobalId(m_listControllers, "m_controller")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listControllers.Enable();
            m_listControllersSelectionModel.Enable();
            m_listControllersSelectionController.Enable();
        }

        private void OnDisable()
        {
            m_listControllers.Disable();
            m_listControllersSelectionModel.Disable();
            m_listControllersSelectionController.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
                m_listControllersSelectionModel.DrawGUILayout();
                m_listControllersSelectionController.DrawGUILayout();
            }
        }
    }
}
