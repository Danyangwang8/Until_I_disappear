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

namespace TooltipSystems.Extras
{
    /// <summary>
    /// Add this component to a GameObject to allow for BackPress quit game including the Editor
    /// </summary>
    [AddComponentMenu("Mobile Tooltip Systems/Extras/Back Button Exit", 1)]
    public class BackButtonExit : MonoBehaviour
    {
        /// <summary>
        /// Delegate defining callback signature
        /// </summary>
        /// <param name="backTarget"></param>
        public delegate void BackButtonPressed(BackButtonExit backTarget);
        /// <summary>
        /// Event to allow callback subscription
        /// </summary>
        public static event BackButtonPressed OnBackButtonPressed;

        /// <summary>
        /// Update is used here to allow for keypress to not be missed
        /// </summary>
        void Update()
        {
            BackButton();
        }

        /// <summary>
        /// Designed for Android OS but can be adapted to be compatiable with other devices
        /// </summary>
        public void BackButton()
        {
            // To add compatability add platform here
            if(Application.platform == RuntimePlatform.Android
                || Application.platform == RuntimePlatform.WindowsEditor
                || Application.platform == RuntimePlatform.WindowsPlayer
                || Application.platform == RuntimePlatform.OSXEditor
                || Application.platform == RuntimePlatform.OSXPlayer)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    if(OnBackButtonPressed != null)
                    {
                        OnBackButtonPressed(this);
                    }
                    QuitGame();
                }
            }
        }

        /// <summary>
        /// Quit the application per platform
        /// </summary>
        public void QuitGame()
        {
            //Quit per platform
            //Add other platforms here
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        string webplayerQuitURL = "http://example.com";
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
        }
    }
}