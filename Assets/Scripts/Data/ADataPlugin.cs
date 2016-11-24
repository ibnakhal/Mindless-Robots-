
using UnityEngine;
using System.Collections;


public abstract class ADataPlugin 
    : MonoBehaviour 
{
    public abstract void Init(DataManager manager);

    public abstract bool SaveFloat(string name, float newValue);

    public abstract bool LoadFloat(string name, out float loadedValue);
}
