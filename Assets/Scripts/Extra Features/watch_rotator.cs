﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watch_rotator : MonoBehaviour {

    public int rotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
	}
}
