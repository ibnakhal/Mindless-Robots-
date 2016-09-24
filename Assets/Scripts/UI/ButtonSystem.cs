using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour {
    [SerializeField]
    private int EndlessLevel;
    [SerializeField]
    private int CampaignLevel;
    
public void Quit()
    {
        Application.Quit();
    }
    public void Campaign(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Endless()
    {
        Application.LoadLevel(EndlessLevel);
    }
}
