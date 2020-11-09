#region Author
/*
     
     Jones St. Lewis Cropper (caLLow)
     
     Another caLLowCreation
     
     Visit us on Google+ and other social media outlets @caLLowCreation
     
     Thanks for using our product.
     
     Send questions/comments/concerns/requests to 
      e-mail: caLLowCreation@gmail.com
      subject: Mobile Tooltip Systems     
     
*/
#endregion

using TooltipSystems.Scripts;
using TooltipSystemsEditor.Core;
using UnityEditor;
using UnityEngine;

namespace TooltipSystemsEditor.Scripts
{
    /// <summary>
    /// Draws custom TooltipBaseCanvas in the Editor
    /// </summary>
    [CustomEditor(typeof(TooltipBaseCanvas), true)]
    public class TooltipBaseCanvasEditor : TooltipCoreCanvasEditor
    {
        /// <summary>
        /// Implement this function to make a custom inspector.
        /// Call to draw tooltipcanvas editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            TooltipCoreEditorWindow.DrawOpenEditorWindowButton();
        }

        /// <summary>
        /// Call to draw TooltipBaseCanvas editor for any editor script
        /// </summary>
        /// <param name="serializedObject">TooltipBaseCanvas serializedObject to be drawn</param>
        public static void DrawInspector(SerializedObject serializedObject)
        {
            SerializedProperty m_TooltipPanelPrefabProp = serializedObject.FindProperty("m_TooltipPanelPrefab");
            SerializedProperty m_AutoScaleProp = serializedObject.FindProperty("m_AutoScale");
            SerializedProperty m_WrapLengthProp = serializedObject.FindProperty("m_WrapLength");
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_TooltipPanelPrefabProp);

            EditorGUILayout.PropertyField(m_AutoScaleProp, new GUIContent("Auto Scale", m_AutoScaleProp.tooltip));
            EditorGUILayout.PropertyField(m_WrapLengthProp, new GUIContent("Wrap Length", m_WrapLengthProp.tooltip));
            m_WrapLengthProp.intValue = Mathf.Max(0, m_WrapLengthProp.intValue);
            serializedObject.ApplyModifiedProperties();
        }

    }

}
