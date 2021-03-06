﻿using UnityEngine;
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
    [SerializeField]
    private EveryoneJumps jumpCommander;
    [SerializeField]
    private GameObject manager;
    [SerializeField]
    private bool alone = false;
	// Use this for initialization
	void Start () {
        spawnCount = 0;
        StartCoroutine(Spawning());
        if (manager != null)
        {
            spawnNo = manager.GetComponent<Manager>().SpawnCount;
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        if (spawnCount >= spawnNo)
        {
            active = false;
            manager.GetComponent<Manager>().spawnActive = false;
        }
    }

    public IEnumerator Spawning()
    {
        while (active)
        {
            GameObject clone = Instantiate(bot, this.transform.position, this.transform.rotation) as GameObject;
            if (manager != null)
            {
                clone.transform.SetParent(manager.transform);
                jumpCommander.bots.Add(clone);
                spawnCount++;
            }
            yield return new WaitForSeconds(wait);

        }
    }


}
