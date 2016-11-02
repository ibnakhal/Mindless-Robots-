using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Escape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            Menu();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);

    }
}
