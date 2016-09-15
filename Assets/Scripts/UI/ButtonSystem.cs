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
    public void Campaign()
    {
        SceneManager.LoadScene(CampaignLevel);
    }
    public void Endless()
    {
        Application.LoadLevel(EndlessLevel);
    }
}
