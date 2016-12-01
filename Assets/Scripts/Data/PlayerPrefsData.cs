
using UnityEngine;
using System.Collections;
using System;

public class PlayerPrefsData
    : ADataPlugin
{
    public override void Init(DataManager manager)
    {

    }

    public override bool LoadFloat(string name, out float loadedValue)
    {
        loadedValue = PlayerPrefs.GetFloat(name);
        return true;
    }

    public override bool SaveFloat(string name, float newValue)
    {
        PlayerPrefs.SetFloat(name, newValue);
        return true;
    }
}
