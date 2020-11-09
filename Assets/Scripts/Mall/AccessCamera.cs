using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AccessCamera : MonoBehaviour {


	//static WebCamTexture backCam;

	public GameObject itemImagePanel;

	void Start()
	{

		/*
		if (backCam == null)
			backCam = new WebCamTexture();

		GetComponent<Renderer>().material.mainTexture = backCam;

		if (!backCam.isPlaying)
			backCam.Play();

		*/

		itemImagePanel.GetComponent<Image> ().sprite = GUIMall.bouthItem;

	}


	// Update is called once per frame
	void Update () {


	}

	public void TakePhotoClicked(){


		SceneManager.LoadScene ("mall");
	
	}



}
