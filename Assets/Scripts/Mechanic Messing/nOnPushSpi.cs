using UnityEngine;
using System.Collections;

public class nOnPushSpi : MonoBehaviour {
    public Vector3 OneVector;
    private bool moving;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!moving)
        {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;

        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            moving = true;
            this.gameObject.GetComponent<Rigidbody>().AddTorque(OneVector);
        }
        if (Input.touchCount !=1 )
        {
            moving = false;
        }
    }


}
