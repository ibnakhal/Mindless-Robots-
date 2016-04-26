using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int hour;
    [SerializeField]
    private int minute;
    [SerializeField]
    private float timeFrame;
    [SerializeField]
    private int increment;
    [SerializeField]
    private Text tText;
    [SerializeField]
    private int threshold;
    [SerializeField]
    private GameObject FadePanel;
    [SerializeField]
    private AudioSource clockSource;
    [SerializeField]
    private AudioSource alarmSource;

    private bool trigger = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(Timed());
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(minute == 60)
        {
            minute = 0;
            hour++;
        }
        if (hour < 10)
        {
            tText.text = ("0" + hour);
        }
        else
        {
            tText.text = (""+hour);
        }
        if(minute <10)
        {
            tText.text += (":0" + minute);
        }
        else
        {
            tText.text += (":" + minute);
        }

        if(hour==threshold && !trigger)
        {
            FadePanel.SetActive(true);
            clockSource.Pause();
            alarmSource.Play();
            trigger = true;
        }
    }

    public IEnumerator Timed()
    {
        while(isActiveAndEnabled)
        {
            yield return new WaitForSeconds(timeFrame);
            minute += increment;
        }
    }




}
