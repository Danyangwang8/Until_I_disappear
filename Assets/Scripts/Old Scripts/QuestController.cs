using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour {

	public GameObject questPanel;
	public GameObject wheelPrefab;
	private GameObject wheelPanel;
	private GameObject banner1;
	private GameObject banner2;
	public static int wheelSelection;
	public GameObject resultPanel;


	void Start(){
	

	}

	void Update(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) 
		{
			if (Physics.Raycast(ray, out hit, 100))
			{
				//not working when the search panel destroyed needs to be solved
				if (hit.collider.CompareTag("ExitButtonQuest"))
				{
					//close quest panel
					Destroy(questPanel);

				}
				if (hit.collider.CompareTag("Anger"))
				{
					//close quest panel
					wheelPanel = Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);

					//Destroy(questPanel);
					Destroy (BedroomQuest.banner1);
					Destroy (BedroomQuest.banner2);
					wheelSelection = 0;
					Debug.Log (hit);


				}

				if (hit.collider.CompareTag("Harmony"))
				{
					//close quest panel
					wheelPanel = Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);

					Destroy(questPanel);
					Destroy (BedroomQuest.banner1);
					Destroy (BedroomQuest.banner2);
					wheelSelection = 1;

				}
				if (hit.collider.CompareTag("Beauty"))
				{
					//close quest panel
					wheelPanel = Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);

					Destroy(questPanel);
					Destroy (BedroomQuest.banner1);
					Destroy (BedroomQuest.banner2);
					wheelSelection = 2;

				}
			}
		}

		//WheelResult ();
			
	}

	/*
	void WheelResult(){

		if(Trigger.canSeeWheelResult){
			Instantiate (resultPanel, new Vector2(0,0), Quaternion.identity);
		}
	
	}*/
		
}
