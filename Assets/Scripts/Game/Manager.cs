using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Manager : MonoBehaviour {
    [Header("Robot Stats")]
    [SerializeField]
    private int collected;
    [SerializeField]
    private int goal;
    [SerializeField]
    private int maxGoal;
    private EveryoneJumps jumps;
    [SerializeField]
    public int SpawnCount = 6;

    [Header("End-Level Stats")]
    [SerializeField]
    private bool end = false;
    [SerializeField]
    private int nextLevel;
    [SerializeField]
    private int finalizedLevel;
    [SerializeField]
    private string levelKeyCode;
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
    [SerializeField]
    private bool lastLevel = false;

    [Header("End-Level Images")]
    [SerializeField]
    private Image winImage;
    [SerializeField]
    private Image loseImage;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Image[] gears;

    private PlayPref pp;

    private SpawnNo spawnNo;

    [SerializeField]
    private bool adShown = false;


    public void Awake()
    {
#if AD_ENABLED
        if (GameObject.FindGameObjectWithTag("pp") != null)
        {
            spawnNo = GameObject.FindGameObjectWithTag("pp").GetComponent<SpawnNo>();
            if (spawnNo.adWatched)
            {
                SpawnCount += 1;
            }
        }
        else
        {
            SpawnCount = 6;
        }
#endif
        if(!lastLevel)
        {
            nextLevel = (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Start ()
    {
        jumps = gameObject.GetComponent<EveryoneJumps>();
        goalText.text = ("Goal: " + goal + "\n 3 Stars: " + maxGoal);
        pp = GameObject.FindGameObjectWithTag("pp").GetComponent<PlayPref>();
        Debug.Log(pp.name);
    }

    void Update ()
    {
        if(Input.GetKeyDown("escape"))
        {
            Menu();
        }
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
            //      winImage.sprite = sprite[0];
            gears[0].sprite = sprite;
            gears[1].sprite = sprite;
            pp.LNSKey = levelKeyCode;
            pp.star = 1;
        }
        if (collected < (maxGoal) && collected > (goal))
        {
            winImage.gameObject.SetActive(true);
            //           winImage.sprite = sprite[1];
            gears[1].sprite = sprite;
            pp.LNSKey = levelKeyCode;
            pp.star = 2;
        }
        if (collected >= (maxGoal))
        {
            winImage.gameObject.SetActive(true);
  //          winImage.sprite = sprite[2];
            pp.LNSKey = levelKeyCode;
            pp.star = 3;
        }
        else if (collected<goal)
        {
            loseImage.gameObject.SetActive(true);
            gameText.text = loseText;
        }
        pp.LevelUpdate();
        if (pp.curL < (nextLevel))
        {
            pp.Updoot((nextLevel));
        }
    }

    public void SceneLoader()
    {
        finalizedLevel = nextLevel;
        if (!adShown)
        {
#if AD_ENABLED
            adShown = true;
            ShowRewardedAd();
#endif
            if (!adShown)
            {
                LoadLevel(finalizedLevel);
            }
        }
    }

    public void Reset()
    {
        finalizedLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(finalizedLevel);
        if (!adShown)
        {

#if AD_ENABLED
            adShown = true;
            ShowRewardedAd();
#endif
            if (!adShown)
            {
                LoadLevel(finalizedLevel);
            }
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);

    }
#if AD_ENABLED
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
    public void ShowRewardedAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = OnVideoComplete;
        Advertisement.Show("rewardedVideo", options);
    }

    private void OnVideoComplete(ShowResult result)

    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Failed");
                spawnNo.adWatched = false;
                SceneManager.LoadScene(finalizedLevel);
                adShown = false;
                break;

            case ShowResult.Finished:
                Debug.Log("Finsihed");
                spawnNo.adWatched = true;
                adShown = false;
                SceneManager.LoadScene(finalizedLevel);
                break;

            case ShowResult.Skipped:
                Debug.Log("Skipped");
                spawnNo.adWatched = false;
                adShown = false;
                SceneManager.LoadScene(finalizedLevel);
                break;
        }
    }
#endif
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
