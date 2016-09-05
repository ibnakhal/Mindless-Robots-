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
    [SerializeField]
    private bool jumpTrigger;
	// Use this for initialization
	void Start () {
//        Screen.height = var
	}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumpTrigger)
        {
            jumpTrigger = true;
        }
    }
	// Update is called once per frame
	void FixedUpdate () 
            {

        

		if(jumpTrigger)
         {
            Debug.Log("Jump!");
           
            foreach (GameObject bot in bots)
            {
                bot.GetComponent<DroneMovement>().Jump(jumpSpeed);
            }
            jumpTrigger = false;

		}


	}
}
