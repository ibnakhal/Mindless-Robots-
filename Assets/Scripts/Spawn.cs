using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {


    [SerializeField]
    private int spawnNo;
    [SerializeField]
    private int spawnCount;
    [SerializeField]
    private bool active = true;
    [SerializeField]
    private GameObject bot;
    [SerializeField]
    private float wait;
	// Use this for initialization
	void Start () {
        spawnCount = 0;
        StartCoroutine(Spawning());

	}
	
	// Update is called once per frame
    void Update()
    {
        if (spawnCount >= spawnNo)
        {
            active = false;
        }
    }

    public IEnumerator Spawning()
    {
        while (active)
        {
            GameObject clone = Instantiate(bot, this.transform.position, this.transform.rotation) as GameObject;
            yield return new WaitForSeconds(wait);
            spawnCount++;
        }
    }


}
