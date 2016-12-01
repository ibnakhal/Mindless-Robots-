using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VersionLabeler : MonoBehaviour {
    public string version;
    Text t;
	// Use this for initialization
	void Start ()
    {
        version = Application.version.ToString();
        t = this.GetComponent<Text>();
        t.text = ("Version: " + version);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
