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
    private bool isGrounded;


    [Header("Effects")]
    [SerializeField]
    private GameObject boom;
	// Use this for initialization
	void Start () 
    {
        
	}

    public void OnCollisionEnter2D(Collision2D collided)
    {
        print(collided.collider.tag);
        if(collided.collider.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collided)
    {
        if (collided.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
    public void ZeroOutVelocity()
    {
        velocity.z = 0;
        velocity.x = 0;

        if (isGrounded == true)
        {
            velocity.y = 0;
        }
    }
    
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        ZeroOutVelocity();


	}
    public void LateUpdate()
    {
        velocity += Physics.gravity * Time.deltaTime;

    }

    public void Death ()
    {
        GameObject clone = Instantiate(boom, this.transform.position, this.transform.rotation) as GameObject;
        this.GetComponentInParent<EveryoneJumps>().bots.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public void Collect()
    {
        this.GetComponentInParent<EveryoneJumps>().bots.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    public void Jump(float speed)
    {
        if (isGrounded)
        {
            Debug.Log("Input Received" + speed);
            this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * speed);
        }
    }



}
