using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSprite : MonoBehaviour {

	/*
	private Object[] Sprites;
	private static Vector2 aspectRatio;

	// Use this for initialization
	void Start () {
		aspectRatio = AspectRatio.GetAspectRatio (Screen.width, Screen.height);

		Camera.main.orthographicSize = (1080 * (aspectRatio.y / 9f) / 2) / 100;
		Sprites = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject Sprit in Sprites) {
			if (Sprit.GetComponent<SpriteRenderer> () && !Sprit.transform.parent) {
				Sprit.transform.localScale = new Vector3 (Sprit.transform.localScale.x * (aspectRatio.x / 16f), Sprit.transform.localScale.y * (aspectRatio.y / 9f), Sprit.transform.localScale.z);
				Sprit.transform.position = new Vector3 (Sprit.transform.position.x * (aspectRatio.x / 16f), Sprit.transform.position.y * (aspectRatio.y / 9f), Sprit.transform.position.z);
			}
		}
	}

	public static Vector2 getTransVel(Vector2 Velocity){
		aspectRatio = AspectRatio.GetAspectRatio (Screen.width, Screen.height);
		return new Vector2 (Velocity.x*(aspectRatio.x / 16f),Velocity.y*(aspectRatio.y / 9f));
	}




	
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		//float aspectRatio = worldScreenWidth / worldScreenHeight;

		transform.localScale = new Vector3(worldScreenWidth / sr.sprite.bounds.size.x, worldScreenHeight / sr.sprite.bounds.size.y, 1);
		//transform.localScale = new Vector3(aspectRatio*sr.sprite.bounds.size.x, aspectRatio*sr.sprite.bounds.size.y, 1);

	}
*/ 


}
