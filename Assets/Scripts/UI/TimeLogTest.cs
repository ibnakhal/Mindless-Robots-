using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class TimeLogTest 
    : MonoBehaviour 
{
    private DataManager m_dManager;
    [SerializeField]
    private Text timeText;
    private void Start()
    {
        m_dManager = GameObject.FindGameObjectWithTag("GCD").GetComponent<DataManager>();

        float time;
        bool success = m_dManager.LoadFloat("TimeStamp", out time);

        timeText.text = (time.ToString());
        time = ((float)System.DateTime.Now.Hour + ((float)System.DateTime.Now.Minute * 0.01f));

        bool trial = m_dManager.SaveFloat("TimeStamp", time);
    }

    private void Update()
    {

    }
   
    
}
