using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SearchNetPanel : MonoBehaviour {

	public Text searchingText;
	public GameObject doneButton;
	public GameObject startFlag;
	public GameObject searchPanelPrefab;
	//public GameObject wheelPrefab;
	//private GameObject wheelPanel;

	public GameObject quest_event;


	// Use this for initialization
	void Start () {
		doneButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) 
		{
			if (Physics.Raycast(ray, out hit, 100))
			{
				
				if (hit.collider.CompareTag("StartQuest"))
				{
					StartCoroutine(StartQuest ());
				}

				//not working when the search panel destroyed needs to be solved
				if (hit.collider.CompareTag("ExitButtonQuest"))
				{
					//close quest panel
					Destroy(quest_event);
					Debug.Log("Exit Button");

				}

			}
		}
	}

	IEnumerator StartQuest(){
		Destroy (startFlag);
		searchingText.text = " SEARCHING FOR QUEST!...";
		yield return new WaitForSeconds(3);
		int luck = Random.Range (0, 100);
		if (luck <= 80) {

			searchingText.text = " Success: Be ready for a quest";
			//wheelPanel = Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);
			//TODO quest should come now

			//doneButton.SetActive (true);

			Instantiate (quest_event, new Vector2 (0, 0), Quaternion.identity);
			Destroy (searchPanelPrefab);


		}
		else{
			searchingText.text = " Fail. Try again.";
			doneButton.SetActive (true);

		}

	}

	public void DoneClicked(){

		Destroy (searchPanelPrefab);
	
	}


}
