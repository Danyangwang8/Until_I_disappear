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
using TooltipSystems.Core;

namespace TooltipSystems.Scripts
{
    /// <summary>
    /// Add this component to any UnityEngine.UI GameObject that has a RectTransform Component.  This component allows the editing of a tooltip
    /// </summary>
    [AddComponentMenu("Mobile Tooltip Systems/Tooltip Base UI", 1)]
    public class TooltipBaseUI : TooltipCoreUI
    {

        // To add custom functionality, create a class and inherit TooltipBaseUI or TooltipCoreUI.
        // Functionality added to this class may be overridden when the package is reimported.
        // Use this class and others provided as examples

        /// <summary>
        /// Reset is used as an example that changes the sprite color from clear to white 
        /// when this component is added for the first time.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            m_TooltipInfo.color = Color.white;
        }
    }
}
