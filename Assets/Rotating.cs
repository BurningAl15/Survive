using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

    Rigidbody2D rgb;
    Quaternion quat;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        //rgb.rotation = quat;
	}
}
