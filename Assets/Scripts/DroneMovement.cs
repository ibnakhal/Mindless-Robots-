using UnityEngine;
using System.Collections;

public class DroneMovement : MonoBehaviour {


    [Header("Controls")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private CharacterController controller = null;


    [Header("Effects")]
    [SerializeField]
    private GameObject boom;
	// Use this for initialization
	void Start () 
    {
        controller = this.GetComponent<CharacterController>();
	}

    public void ZeroOutVelocity()
    {
        velocity.z = 0;
        velocity.x = 0;

        if (controller.isGrounded == true)
        {
            velocity.y = 0;
        }
    }
    
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        ZeroOutVelocity();


	}
    public void LateUpdate()
    {
        velocity += Physics.gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Death ()
    {
            GameObject clone = Instantiate(boom, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.gameObject);
    }

    public void Jump(float speed)
    {
        Debug.Log("Input Received" + speed);
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed);
    }



}
