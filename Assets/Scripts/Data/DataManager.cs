using UnityEngine;
using System.Collections;


public class DataManager 
    : MonoBehaviour 
{
    [SerializeField]
    private GameObject m_debugDataPrefab = null;
    [SerializeField]
    private GameObject m_amazonGameCirclePrefab = null;

    private static ADataPlugin s_loadedPlugin = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (s_loadedPlugin != null)
            return;


#if UNITY_EDITOR
        s_loadedPlugin = Instantiate(m_debugDataPrefab).GetComponent<ADataPlugin>();

#elif AMAZON_GAMECIRCLE
         
        s_loadedPlugin = Instantiate(m_amazonGameCirclePrefab).GetComponent<ADataPlugin>();


#endif
        if(s_loadedPlugin == null)
        {
            Debug.Log("plugin failed to load.");
            return;
        }

        s_loadedPlugin.Init(this);
    }

    public bool LoadFloat(string name, out float loadedValue)
    {
        bool success = s_loadedPlugin.LoadFloat(name, out loadedValue);
        if(!success)
        {
            Debug.Log("Failed to load");

        }
        return success;
    }
    
   public bool SaveFloat(string name, float newValue)
    {
        bool success = s_loadedPlugin.SaveFloat(name, newValue);
        if (!success)
        {
            Debug.Log("Failed to save." + name);
        }
        return success;

    }
}
