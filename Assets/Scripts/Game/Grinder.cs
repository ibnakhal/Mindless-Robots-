﻿using UnityEngine;
using System.Collections;

public class Grinder : MonoBehaviour {


    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(Vector3.forward * Time.deltaTime * speed);


	}

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Flock")
        {
            Other.GetComponent<DroneMovement>().Death();
        }
    }
}
