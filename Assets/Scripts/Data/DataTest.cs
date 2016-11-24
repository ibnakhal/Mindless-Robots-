/**
 * $File: DataTest.cs $
 * $Date: #CREATIONDATE# $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;


/// <summary>
/// 
/// </summary>
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
      //  bool success = m_dataManager.LoadFloat
    }
   
    
}
