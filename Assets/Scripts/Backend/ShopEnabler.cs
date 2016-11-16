using UnityEngine;
using System.Collections;

public class ShopEnabler : MonoBehaviour {
    public GameObject[] toActivate;

    // Use this for initialization
    void Start () {
#if STORE_ENABLED
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].gameObject.SetActive(true);
        }
#endif

    }


    // Update is called once per frame
    void Update () {
	
	}

}
