using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {



	void OnMouseOver(){

		if (CompareTag ("HomeOnMap")) {
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene("Bedroom Final");

			}
		}
		if (CompareTag ("MallOnMap")) {
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene("mall");

			}
		}
			
	}

}
