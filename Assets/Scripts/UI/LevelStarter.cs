using UnityEngine;
using System.Collections;

public class LevelStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	

  public void Starter()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
