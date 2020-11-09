using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {

	private bool camAvailable;
	private WebCamTexture frontCam;
	private Texture defaultBackground;

	public RawImage background;
	public AspectRatioFitter fit;

	// Use this for initialization
	void Start () {
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0) {
			Debug.Log ("No camera detected");
			camAvailable = false;
			return;
		
		}
		for(int i =0; i<devices.Length; i++){
			if (devices [i].isFrontFacing) { // changed from not equal to true
			
				frontCam = new WebCamTexture (devices [i].name, Screen.width, Screen.height);
			}

		}

		if (frontCam == null) {
			Debug.Log (	"Unable to find front camera");
			return;
		}

		frontCam.Play ();
		background.texture = frontCam;

		camAvailable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!camAvailable)
			return;

		float ratio = (float)frontCam.width / (float)frontCam.height;
		fit.aspectRatio = ratio;

		float scaleY = frontCam.videoVerticallyMirrored ? -1f: 1f;
		background.rectTransform.localScale = new Vector3 (-1f, scaleY, 1f);

		int orient = frontCam.videoRotationAngle; //TODO try making pozitive
		background.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);

	}
}
