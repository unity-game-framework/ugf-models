using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Models.Editor.Domain
{
    internal class DomainModelExecuteControllerListDrawer : ReorderableListDrawer
    {
        public DomainModelExecuteControllerListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override void OnDrawElementContent(Rect position, SerializedProperty serializedProperty, int index, bool isActive, bool isFocused)
        {
            SerializedProperty propertyModel = serializedProperty.FindPropertyRelative("m_model");
            SerializedProperty propertyController = serializedProperty.FindPropertyRelative("m_controller");

            float space = EditorGUIUtility.standardVerticalSpacing * 2F;
            float labelWidth = EditorGUIUtility.labelWidth + EditorIMGUIUtility.IndentPerLevel;

            var rectModel = new Rect(position.x, position.y, labelWidth, position.height);
            var rectController = new Rect(rectModel.xMax + space, position.y, position.width - rectModel.width - space, position.height);

            using (new LabelWidthScope(40F))
            {
                EditorGUI.PropertyField(rectModel, propertyModel);
            }

            using (new LabelWidthScope(60F))
            {
                EditorGUI.PropertyField(rectController, propertyController);
            }
        }

        protected override float OnElementHeightContent(SerializedProperty serializedProperty, int index)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        protected override bool OnElementHasVisibleChildren(SerializedProperty serializedProperty)
        {
            return false;
        }
    }
}
