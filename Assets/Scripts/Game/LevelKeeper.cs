using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelKeeper : MonoBehaviour {
    public GameObject[] buottons;
    PlayPref pp;
    [SerializeField]

    private int mod;
	// Use this for initialization
	void Start () {
        pp = GameObject.FindGameObjectWithTag("pp").GetComponent<PlayPref>();
        for (int x = 0; x < (pp.curL - mod); x++)
        {

            buottons[x].GetComponent<Button>().interactable = true;
            buottons[x].GetComponentInChildren<Text>().color = Color.white;
            if (!string.IsNullOrEmpty(buottons[x].GetComponent<levelbuttonScreen>().key))
            {
                buottons[x].GetComponent<levelbuttonScreen>().GetPurchasedLevels();
            }
        }
        //NOTE: Have here some store integration. if you don't own it don't play it
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
