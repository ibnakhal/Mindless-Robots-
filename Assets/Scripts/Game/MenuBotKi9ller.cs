using UnityEngine;
using System.Collections;

public class MenuBotKi9ller : MonoBehaviour {
    public GameObject confetti;


    public void OnTriggerEnter2D (Collider2D Other)
    {
        Debug.Log(Other.tag);
        if(Other.tag == "Flock" )
        {
            Destroy(Other.gameObject);
        }
    }

}
