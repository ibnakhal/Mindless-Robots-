/**
 * $File: MusicActivate.cs $
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
public class MusicActivate 
    : MonoBehaviour 
{

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("pp").GetComponent<AudioSource>().Play();
    }

    private void Update()
    {

    }
    
    
}
