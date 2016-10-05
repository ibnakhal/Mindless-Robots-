using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    [Header("Robot Stats")]
    [SerializeField]
    private int collected;
    [SerializeField]
    private int goal;
    [SerializeField]
    private int maxGoal;
    private EveryoneJumps jumps;

    [Header("End-Level Stats")]
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
    private Text goalText;
    [SerializeField]
    private float time;
    [SerializeField]
    public bool spawnActive = true;
    [Header("End-Level Images")]
    [SerializeField]
    private Image winImage;
    [SerializeField]
    private Image loseImage;
    [SerializeField]
    private Sprite[] sprite;
	void Start () {
        jumps = gameObject.GetComponent<EveryoneJumps>();
        goalText.text = ("Goal: " + goal);
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
                EndGame(winText);
            }
            else
            {
                EndGame(loseText);
            }
        }
	}
    public void Collected()
    {
        collected++;
    }


    public void EndGame(string words)
    {
        if(collected == (goal))
        {
            winImage.gameObject.SetActive(true);
            winImage.sprite = sprite[0];
        }
        if (collected < (maxGoal) && collected > (goal))
        {
            winImage.gameObject.SetActive(true);
            winImage.sprite = sprite[1];
        }
        if (collected == (maxGoal))
        {
            winImage.gameObject.SetActive(true);
            winImage.sprite = sprite[2];
        }
        else if (collected<goal)
        {
            loseImage.gameObject.SetActive(true);
            gameText.text = loseText;
        }
        GameObject pp = GameObject.FindGameObjectWithTag("pp");
        if (pp.GetComponent<PlayPref>().curL < (SceneManager.GetActiveScene().buildIndex+1))
        {
            pp.GetComponent<PlayPref>().Updoot((SceneManager.GetActiveScene().buildIndex+1));
        }
    }

    public void SceneLoader(int level)
    {
        SceneManager.LoadScene(level);
    }

}
