Mobile Tooltip Systems
--------------------------------------------------------------------------------
Unity Game Engine 
UI Scripting
Written in Unity Version 5.0.1f1
*Requires Unity 5.0.1f1 or higher


Version 1.0.0        Release Date: 05/07/2015
Initial Release

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Version 2.0.0        Release Date: 10/02/2015

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
DOCUMENTATION, TUTORIALS
--------------------------------------------------------------------------------
Documentation
http://www.dyamondrose.com/callowcreation/products/unity/mobiletooltipsystems/documentation/html/R_Project_MobileTooltipSystemsPlugin.htm


Web Demo
http://www.dyamondrose.com/callowcreation/products/unity/mobiletooltipsystems/deploy/deploy.html


Mobile Demo (Android OS)
https://play.google.com/store/apps/details?id=callowcreation.android.demo.mobiletooltipsystems


Slide Tutorial
https://sites.google.com/site/callowcreation/products/mobile-tooltip-systems#slide-tutorial



WHAT IT DOES
--------------------------------------------------------------------------------
Mobile Tooltip Systems uses Unity’s Event System to track touches/clicks long press and long click to show a popup tooltip style message overlaying the screen.  The system offers additional functionality for Standalone builds with a Hover to show the tooltip.

Mobile Tooltip Systems is a cross-platform popup tooltip system.  Providing a consistent Unity Editor experience with custom property drawers to maintain familiar interface allows the entire development team to use it.  The accompanying API is designed to be extensible and flexible so your specific needs can be implemented.

The asset contains prefabs for all required items so your experience will be consistent with Unity’s workflow.  Using these prefabs to get a working tooltip system requires NO coding.  There are nonetheless scripts provided as usable examples to roll your own tooltip system.

The tooltip system uses an animator with two animations one for showing/hiding and another for destroying the tooltip.  These animations are standard Unity animations and animator controller and can be changed to fit your different projects.


GENERAL USAGE NOTES
--------------------------------------------------------------------------------
Add a TooltipBaseCanvas prefab to the active scene.  This is a Unity Canvas and the Render Mode needs to be set to any existing canvas that will use the tooltip system.

Add a TooltipBaseUI component to any UI GameObject that you want to show a tooltip for.  Set the tooltip message and how it will be shown using the show condition dropdown, long press/hover etc.

Run your project, perform the selected show condition and the tooltip will popup for a default 5 seconds if hide time was not changed.
There are two demo scenes with the asset that show how to utilize all default functionality.

EXTRAS
--------------------------------------------------------------------------------
Features Include: (but not limited to)
* Ready to use components and prefabs
* Auto positioning to keep popup on screen from touch/click point
* Animated show and hide
* Individual show timer per tooltip
* Dynamic ShowTooltip functions to use with Unity UI components EventSystem
* Multiple tooltips can be on screen

SHOW CONDITIONS
--------------------------------------------------------------------------------
* LongPress- Long press on a touchscreen device and long click for a standalone PC build to show tooltip.
* Click- Touch/Press on a touchscreen device and click for a standalone PC build to show tooltip.
* Hover- Standalone PC build hover mouse to show tooltip for touchscreen it works like Click.


CONTACT
--------------------------------------------------------------------------------
Questions, Comments, Concerns, Requests:
email:  callowcreation@gmail.com
web:  www.callowcreation.com
Customer Support:  https://sites.google.com/site/callowcreation/products/mobile-tooltip-systems/customer-support

