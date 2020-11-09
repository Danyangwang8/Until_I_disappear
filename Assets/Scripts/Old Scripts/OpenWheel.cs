using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWheel : MonoBehaviour {

	public GameObject guiCanvas;
	public GameObject backgroud;
	public GameObject wheel;
	public GameObject arrow;
	public GameObject labels;

	// Use this for initialization
	void Start () {
		guiCanvas.SetActive (false);
		backgroud.SetActive (false);
		wheel.SetActive (false);
		arrow.SetActive (false);
		labels.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){

		if (CompareTag ("Wheel")) {
			if (Input.GetMouseButtonDown (0)) {
				guiCanvas.SetActive (true);
				backgroud.SetActive (true);
				wheel.SetActive (true);
				arrow.SetActive (true);
				labels.SetActive (false);
			}
		}
			
	}

	public void DoneClicked(){

		guiCanvas.SetActive (false);
		backgroud.SetActive (false);
		wheel.SetActive (false);
		arrow.SetActive (false);
		labels.SetActive (true);

	}
}
