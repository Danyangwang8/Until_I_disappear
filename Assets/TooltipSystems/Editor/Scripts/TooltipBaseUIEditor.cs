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
    /// Draws custom TooltipBaseUI in the Editor
    /// </summary>
    [CustomEditor(typeof(TooltipBaseUI), true), CanEditMultipleObjects]
    public class TooltipBaseUIEditor : TooltipCoreUIEditor
    {

        /// <summary>
        /// Implement this function to make a custom inspector.
        /// Call to draw TooltipBaseUI editor.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

    }
}
