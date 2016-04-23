using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {
    [SerializeField]
    private Manager manage;


    public void Start()
    {
        manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    public void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Flock")
        {
            Other.GetComponent<DroneMovement>().Collect();
            manage.Collected();
        }
    }
}
