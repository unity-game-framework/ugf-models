﻿using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Models.Runtime.Domain;
using UnityEditor;

namespace UGF.Models.Editor.Domain
{
    [CustomEditor(typeof(DomainModelAsset), true)]
    internal class DomainModelAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listModels;
        private ReorderableListSelectionDrawerByPath m_listModelsSelection;
        private AssetIdReferenceListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByPath m_listCollectionsSelection;
        private ReorderableListDrawer m_listModelCollections;
        private ReorderableListSelectionDrawerByElement m_listModelCollectionsSelection;

        private void OnEnable()
        {
            m_listModels = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_models"))
            {
                DisplayAsSingleLine = true
            };

            m_listModelsSelection = new ReorderableListSelectionDrawerByPath(m_listModels, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listCollections = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_collections"))
            {
                DisplayAsSingleLine = true
            };

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByPath(m_listCollections, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listModelCollections = new ReorderableListDrawer(serializedObject.FindProperty("m_modelCollections"));

            m_listModelCollectionsSelection = new ReorderableListSelectionDrawerByElement(m_listModelCollections)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listModels.Enable();
            m_listModelsSelection.Enable();
            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
            m_listModelCollections.Enable();
            m_listModelCollectionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listModels.Disable();
            m_listModelsSelection.Disable();
            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
            m_listModelCollections.Disable();
            m_listModelCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listModels.DrawGUILayout();
                m_listCollections.DrawGUILayout();
                m_listModelCollections.DrawGUILayout();

                m_listModelsSelection.DrawGUILayout();
                m_listCollectionsSelection.DrawGUILayout();
                m_listModelCollectionsSelection.DrawGUILayout();
            }
        }
    }
}
