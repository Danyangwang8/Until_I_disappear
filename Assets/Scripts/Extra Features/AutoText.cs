using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour {

	public float letterPause; //lenght of pause

	string myText = " You are getting cool! Start looking around!";		
	//public GameObject yesButton;
	public Text introductionText;
	//AudioSource sound;

	void Start () {

		//startButton.SetActive(false);
		//sound = GetComponent<AudioSource>();

		StartCoroutine(StartTyping());

	}


	IEnumerator StartTyping()
	{
		introductionText.text = "";
		foreach (char letter in myText.ToCharArray())
		{
			//sound.Play();
			introductionText.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
		//startButton.SetActive(true);
	}
}
