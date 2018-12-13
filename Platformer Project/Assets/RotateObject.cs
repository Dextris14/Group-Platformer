using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
    public float spinSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        { transform.Rotate(0, 0, spinSpeed, Space.World);
        }
        

	}
}
