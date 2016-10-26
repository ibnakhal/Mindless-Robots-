using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayPref : MonoBehaviour {
    public int curL;
    string neme;

    public string LNSKey;
    public int star;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        curL = PlayerPrefs.GetInt(neme);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Updoot(int level)
    {
        PlayerPrefs.SetInt(neme, level);
        Debug.Log("Saving: Scene " + level);
        PlayerPrefs.Save();
        curL = PlayerPrefs.GetInt(neme);

    }
    public void LevelUpdate()
    {
        PlayerPrefs.SetInt(LNSKey, star);
        Debug.Log("Level Key is: " + LNSKey);
        PlayerPrefs.Save();
    }

    public void GetStuff()
    {
        Debug.Log(LNSKey);
       star = PlayerPrefs.GetInt(LNSKey);
    }
}
