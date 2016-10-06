using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelStarsNewBehaviourScript : MonoBehaviour {
    private PlayPref pp;
    public string[] levelCode;
    public int[] levelStar;
    // Use this for initialization
    void Start () {
        pp = GameObject.FindGameObjectWithTag("pp").GetComponent<PlayPref>();

        for(int x = 0; x < (SceneManager.sceneCount-3); x++ )
        {
            pp.LNSKey = levelCode[x];
            pp.GetStuff();
            levelStar[x] = pp.star;

        } 


    }

}
