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
        PlayerPrefs.Save();
    }
    public void LevelUpdate()
    {
        PlayerPrefs.SetInt(LNSKey, star);
        PlayerPrefs.Save();
    }

    public void GetStuff()
    {
        PlayerPrefs.GetInt(LNSKey, star);
    }
}
