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

using UnityEngine;
using UnityEditor;
using TooltipSystems.Scripts;
using TooltipSystemsEditor.Core;

namespace TooltipSystemsEditor.Scripts
{

    /// <summary>
    /// Draws custom TooltipBasePanel in the Editor
    /// </summary>
    [CustomEditor(typeof(TooltipBasePanel), true), CanEditMultipleObjects]
    public class TooltipBasePanelEditor : TooltipCorePanelEditor
    {

        /// <summary>
        /// Implement this function to make a custom inspector.
        /// Call to draw TooltipBasePanel editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        /// <summary>
        /// Call to draw TooltipBasePanel editor for any editor script
        /// </summary>
        /// <param name="serializedObject">TooltipBasePanel serializedObject to be drawn</param>
        public static void DrawInspector(SerializedObject serializedObject)
        {
            serializedObject.Update();

            TooltipBasePanelEditor.HideDelayTimePropertyField(serializedObject);
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_TooltipText");
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_HideTrigger");
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_HideFastTrigger");

            serializedObject.ApplyModifiedProperties();
        }

        internal static void HideDelayTimePropertyField(SerializedObject serializedObject)
        {
            var hideDelayTimeProp = TooltipBasePanelEditor.PropertyField(serializedObject, "hideDelayTime");
            hideDelayTimeProp.floatValue = Mathf.Max(0.0f, hideDelayTimeProp.floatValue);
        }

        internal static SerializedProperty PropertyField(SerializedObject serializedObject, string fieldName)
        {
            var prop = serializedObject.FindProperty(fieldName);
            EditorGUILayout.PropertyField(prop);
            return prop;
        }
    }
}