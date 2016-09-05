using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    [SerializeField]
    private int collected;
    [SerializeField]
    private int goal;
    [SerializeField]
    private int maxGoal;
    private EveryoneJumps jumps;
    [SerializeField]
    private bool end = false;
    [SerializeField]
    private int nextLevel;
    [SerializeField]
    private string winText;
    [SerializeField]
    private string loseText;
    [SerializeField]
    private Text gameText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float time;
    [SerializeField]
    public bool spawnActive = true;
	void Start () {
        jumps = gameObject.GetComponent<EveryoneJumps>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = ("Bots: " + collected + "/" + goal);
        if (jumps.bots.Count <= 0 || jumps.bots == null)
        {
            if (!spawnActive)
            {
                end = true;
            }
        }
        if(end)
        {
            if(collected >= goal)
            {
                StartCoroutine(EndGame(winText, nextLevel));
            }
            else
            {

                StartCoroutine(EndGame(loseText, SceneManager.GetActiveScene().buildIndex ));
            }
        }
	}
    public void Collected()
    {
        collected++;
    }


    public IEnumerator EndGame(string words, int level)
    {
        gameText.text = words;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }



}
