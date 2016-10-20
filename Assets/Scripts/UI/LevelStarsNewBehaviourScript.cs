using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelStarsNewBehaviourScript : MonoBehaviour {
    private PlayPref pp;
    public string[] levelCode;
    public int[] levelStar;
    // Use this for initialization
    public void Start () {
        pp = GameObject.FindGameObjectWithTag("pp").GetComponent<PlayPref>();
        Debug.Log("Cycling Stars");
        Debug.Log(pp.curL);
        for(int x = 0; x < (pp.curL-3); x++ )
        {
            pp.LNSKey = levelCode[x].ToString();
            pp.GetStuff();
            levelStar[x] = pp.star;
            Debug.Log(levelCode[x] + " Score: " + levelStar[x]);

        } 


    }

}
