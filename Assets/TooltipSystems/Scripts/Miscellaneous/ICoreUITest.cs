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

namespace TooltipSystems.Extras
{
    /// <summary>
    /// Testing inheriting ITooltipCoreUI.  Incorrect usage of TooltipSystems inheritance interface.  This method is used to create your own compnents
    /// </summary>
    [AddComponentMenu("Mobile Tooltip Systems/Extras/ICoreUI Test", 3)]
    public class ICoreUITest : MonoBehaviour, ITooltipCoreUI
    {
        [SerializeField]
        TooltipInfo m_TooltipInfo;

        /// <summary>
        /// Button Click event associated with this ITooltipCoreUI returning null for this example
        /// </summary>
        public UnityEngine.UI.Button.ButtonClickedEvent onClickEvent
        {
            get { return null; }
        }

        /// <summary>
        /// Contains the tooltip information
        /// </summary>
        public TooltipInfo tooltipInfo
        {
            get
            {
                return m_TooltipInfo;
            }
            set
            {
                m_TooltipInfo = value;
            }
        }

        /// <summary>
        /// Shortcut to tooltip information message property
        /// </summary>
        public string tooltipMessage
        {
            get { return "ITooltipCoreUI test"; }
        }

        /// <summary>
        /// Shortcut to tooltip information visibleIcon property
        /// </summary>
        public bool visibleIcon
        {
            get { return false; }
        }

        /// <summary>
        /// Shortcut ICoreUI gameObject property allowing access through this interface
        /// </summary>
        public GameObject GetGameObject()
        {
            try
            {
                return gameObject;
            }
            catch(System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Shortcut ICoreUI name property allowing access to MonoBehaviour name through this interface
        /// </summary>
        public string GetName()
        {
            try
            {
                return name;
            }
            catch(System.Exception)
            {
                return string.Empty;
            }
        }
    }
}