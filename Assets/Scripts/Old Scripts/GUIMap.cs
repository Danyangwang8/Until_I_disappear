using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMap : MonoBehaviour {

	public float letterPause; //lenght of pause

	string myText = " You are getting cool! Start looking around!";		
	public Text introductionText;
	public GameObject canvas;
	public GameObject panelImage;

	void Start () {
	
		canvas.gameObject.SetActive (false);
		panelImage.gameObject.SetActive (false);
	}

	void OnMouseOver () {

		Debug.Log ("SoMe");
	
		if (CompareTag ("SoMe")) {
			if (Input.GetMouseButtonDown (0)) {
				canvas.gameObject.SetActive (true);
				panelImage.gameObject.SetActive (true);
			}
		}
	
	
	}
	

	public void NoClicked(){
		Debug.Log ("No pressed");
		canvas.gameObject.SetActive (false);
		panelImage.gameObject.SetActive (false);

	}

	public void YesClicked(){
		Debug.Log ("Yes Pressed");
		StartCoroutine(StartTyping());
		canvas.gameObject.SetActive (false);
		panelImage.gameObject.SetActive (false);

	}

	IEnumerator StartTyping()
	{
		introductionText.text = "";
		foreach (char letter in myText.ToCharArray())
		{
			introductionText.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
	}
		
}
