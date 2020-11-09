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

namespace TooltipSystemsEditor.Scripts
{
    /// <summary>
    /// Draws custom TooltipBaseIconPanel in the Editor
    /// </summary>
    [CustomEditor(typeof(TooltipBaseIconPanel), true), CanEditMultipleObjects]
    public class TooltipBaseIconPanelEditor : TooltipCorePanelEditor
    {
        /// <summary>
        /// Implement this function to make a custom inspector.
        /// Call to draw TooltipBaseIconPanel editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        /// <summary>
        /// Call to draw TooltipBaseIconPanel editor for any editor script
        /// </summary>
        /// <param name="serializedObject">TooltipBaseIconPanel serializedObject to be drawn</param>
        public static void DrawInspector(SerializedObject serializedObject)
        {
            serializedObject.Update();

            TooltipBasePanelEditor.HideDelayTimePropertyField(serializedObject);
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_TooltipText");
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_TooltipImage");
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_HideTrigger");
            TooltipBasePanelEditor.PropertyField(serializedObject, "m_HideFastTrigger");
            
            serializedObject.ApplyModifiedProperties();
        }

    }
}
