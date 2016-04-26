using UnityEngine;
using System.Collections;

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
        Application.LoadLevel(CampaignLevel);
    }
    public void Endless()
    {
        Application.LoadLevel(EndlessLevel);
    }
}
