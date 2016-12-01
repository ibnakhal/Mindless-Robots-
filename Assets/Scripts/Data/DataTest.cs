using UnityEngine;
using System.Collections;

public class DataTest 
    : MonoBehaviour
{
    [SerializeField]
    private DataManager m_dataManager = null;

    private void Start()
    {
        StartCoroutine(DelayedLoadAndSave());
    }

    private IEnumerator DelayedLoadAndSave()
    {
        yield return new WaitForSeconds(3);

        float testValue;
        bool success = m_dataManager.LoadFloat("Test", out testValue);
        print(testValue);
        testValue += 100;
        //  bool success = m_dataManager.LoadFloat
        m_dataManager.SaveFloat("Test", testValue);   
    }
   
    
}
