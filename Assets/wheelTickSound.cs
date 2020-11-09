using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelTickSound : MonoBehaviour {

	AudioSource wheelTick;

	// Use this for initialization
	void Start () {
		wheelTick = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Arrow"))   
		{
			wheelTick.Play();
			Debug.Log("arrow trigger!");
		}
	
	}
}

