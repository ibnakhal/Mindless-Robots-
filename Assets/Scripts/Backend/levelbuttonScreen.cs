
using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class levelbuttonScreen 
    : MonoBehaviour 
{
    public string key;
    private int sitch;

    private void Awake()
    {

    }

    private void Update()
    {

    }
    public void GetPurchasedLevels()
    {
        sitch = PlayerPrefs.GetInt(key);
        if (sitch != 1)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
}
