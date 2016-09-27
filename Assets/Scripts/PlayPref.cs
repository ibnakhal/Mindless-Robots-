using UnityEngine;
using System.Collections;

public class PlayPref : MonoBehaviour {
    public int curL;
    string neme;
	// Use this for initialization
	void Start () {
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
}
