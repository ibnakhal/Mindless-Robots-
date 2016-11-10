
using UnityEngine;
using System.Collections;


/// <summary>
/// 
/// </summary>
public class SpawnNo 
    : MonoBehaviour 
{

    public bool adWatched;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
   
}
