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

using System.Linq;
using UnityEditor;
using UnityEngine;
using TooltipSystems;
using System;
using TryItCompatibilityEditor;

namespace TooltipSystemsEditor
{
    /// <summary>
    /// Opens example scene picker
    /// </summary>
    [InitializeOnLoad]
    class OpenScenesEditorWindow
    {
        static OpenScenesEditorWindow()
        {
            //Debug.Log("OpenScenesEditorWindow UpdateShowPrompt");
            ExampleScenesWindow.newsletterSignupUrl = "http://eepurl.com/bPDq3P";
            ExampleScenesWindow.isFullVersion = !TooltipSystemsSettings.Instance.GetTryIt();
            ExampleScenesWindow.packageName = "Mobile Tooltip Systems";
            ExampleScenesWindow.buttonTexts = new SceneButton[]
            {
                new SceneButton("Open Example Scene", "Example Scene", "Assets/TooltipSystems/Scenes/Example Scene.unity",
                    "This scene, Example Scene, is intended to show how to utilize the Tooltip Systems component system.  Each UI GameObject has a Tooltip component attached.  Some tooltips are shown via user input and others via UnityEngine.Events system.  This asset is intended to give you a powerful yet easy way to show tooltips without the need for scripting."),
                new SceneButton("Open AddOns Example", "AddOns ShowOnStart", "Assets/TooltipSystems/Scenes/AddOns Example.unity",
                    "This scene, AddOns Example, shows a tooltip on MonoBehaviour Start message call also executes tooltip on MonoBehaviour messages/events.  Select the Main Camera to see the Tooltip On Start component.  Select the Trigger Cube to see the Events Tooltip and the Collision Tooltip component in use using UnityEngine.Events.  Also you can use the Tooltip Expanded Canvas to add and use multiple tooltip types including a persistant tooltip that the user must click on to close.  This tooltip will show when the cube collides with the sphere."),
                new SceneButton("Open 3D Example", "3D Interface Example", "Assets/TooltipSystems/External/Scenes/Example External 3D.unity",
                    "This scene, Example External 3D, shows the use of External namespace to integrate TooltipSystems into a 3D environment.  There are components that exposes tooltips using UnityEngine.Events interactions via object collisions and triggers.  This namespace offers mouse interactions with the 3D world.  Click on the ground plane to move the cube to that location.  Hover the mouse pointer over any object to show it's tooltip."),
            };

            ExampleScenesWindow.fullVersionUrl = "http://u3d.as/fVy";
        }

        [MenuItem("Window/Mobile Tooltip Systems/Example Scenes")]
        internal static void Init()
        {
            ExampleScenesWindow.Init();
        }
    }
}