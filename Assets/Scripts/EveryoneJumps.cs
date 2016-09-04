using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EveryoneJumps : MonoBehaviour {

    [SerializeField]
    public List<GameObject> bots;
    [SerializeField]
    private DroneMovement move;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private int var;
	// Use this for initialization
	void Start () {
//        Screen.height = var
	}
	
	// Update is called once per frame
	void Update () {

        

		if (Input.GetKey(KeyCode.Space)) 
		{
            Debug.Log("Jump!");
           
            foreach (GameObject bot in bots)
            {
                bot.GetComponent<DroneMovement>().Jump(jumpSpeed);
            }

		}


	}
}
