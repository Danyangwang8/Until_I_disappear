using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointClickBedroom : MonoBehaviour {

	private GameObject searchNetPanel;
	public GameObject searchNetPanelPrefab;
	private Vector2 objectPoolPosition = new Vector2 (0,0);     //A holding position for our unused columns offscreen.


	void Start () {

	}
	
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) 
		{
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.collider.CompareTag("DoorInBedroom"))
				{
					SceneManager.LoadScene("Map Scene");

				}
				if (hit.collider.CompareTag("Computer"))
				{
					//open quest panel

					searchNetPanel= (GameObject) Instantiate (searchNetPanelPrefab, objectPoolPosition, Quaternion.identity);

				}
				if (hit.collider.CompareTag("ExitButton"))
				{
					//close quest panel
					Destroy(searchNetPanel);

				}
				else
				{
					
				}
			}
		}
	}
		
}
