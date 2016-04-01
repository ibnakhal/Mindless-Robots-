using UnityEngine;
using System.Collections;

public class EveryoneJumps : MonoBehaviour {

    [SerializeField]
    private GameObject[] bots;
    [SerializeField]
    private DroneMovement move;
    [SerializeField]
    private float jumpSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        

		if (Input.GetKey(KeyCode.Space)) 
		{
            Debug.Log("Jump!");
            bots = GameObject.FindGameObjectsWithTag("Flock");
            
            for(int x=0; x< bots.Length; x++)
            {
                bots[x].GetComponent<DroneMovement>().Jump(jumpSpeed);
            }

		}


	}
}
