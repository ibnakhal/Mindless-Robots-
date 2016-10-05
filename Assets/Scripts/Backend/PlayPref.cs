using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayPref : MonoBehaviour {
    public int curL;
    string neme;

    public List<int> level;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        curL = PlayerPrefs.GetInt(neme);
        for (int x = 3; x < SceneManager.sceneCount; x++)
        {
            level.Add(x);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Updoot(int level)
    {
        PlayerPrefs.SetInt(neme, level);
        PlayerPrefs.Save();
    }
}
