#if AMAZON_GAMECIRCLE
using UnityEngine;
using System.Collections;
using System;


/// <summary>
/// 
/// </summary>
public class GameCircleData 
    : ADataPlugin 
{
    [SerializeField]
    private bool m_useLeaderboard = false;
    [SerializeField]
    private bool m_useAcheivements = false;
    [SerializeField]
    private bool m_useWhispersync = true;
    [SerializeField]
    private AGSGameDataMap dataMap = null;

    public override void Init(DataManager manager)
    {
        AGSClient.ServiceReadyEvent += OnServiceReady;

        AGSClient.ServiceNotReadyEvent += OnServiceNotReady;

        AGSClient.Init(m_useLeaderboard, m_useAcheivements, m_useWhispersync);

        dataMap = AGSWhispersyncClient.GetGameData();
    }

    // called when GameCircle Service successfully loads
    private void OnServiceReady()
    {
        Debug.Log("GameCirlce Online");
    }


    // called when GC Service fails on load
    private void OnServiceNotReady(string message)
    {
        Debug.Log(" GameCircle Offline. Message: " + message);
    }

    public override bool LoadFloat(string name, out float loadedValue)
    {
        if (dataMap == null)
        {
            Debug.Log("ERROR: GameCircle Not Loaded Properly");
            loadedValue = 0;
            return false;
        }

        AGSSyncableNumber syncNumber = dataMap.GetHighestNumber(name);

        loadedValue = (float)syncNumber.AsDouble();

        return true;
    }

    public override bool SaveFloat(string name, float newValue)
    {
        if (dataMap == null)
        {
            Debug.Log("ERROR: GameCircle Not Loaded Properly");
            return false;
        }

        AGSSyncableNumber syncNumber = dataMap.GetHighestNumber(name);

        syncNumber.Set(newValue);
        return true;
    }
}
#endif