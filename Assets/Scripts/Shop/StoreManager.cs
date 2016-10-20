/**
 * $File: StoreManager.cs $
 * $Date: #CREATIONDATE# $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using UnityEngine.Purchasing;
using System;

/// <summary>
/// 
/// </summary>
public class StoreManager : MonoBehaviour , IStoreListener
{
    /// <summary>
    /// Reference to an object that keeps store info and processes requests
    /// </summary>
    private static IStoreController s_store_Controller;


    /// <summary>
    /// extension provider
    /// </summary>
    private static IExtensionProvider s_extensionsProvider;


    [SerializeField]
    private string[] m_skus = new string[] { "com.BlackTesseract.MindlessRobots.LP1" };

    /// <summary>
    /// initializes the Unity Services IAP plugin.
    /// </summary>
    private void Awake()
    {
        ConfigurationBuilder storeBuider = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            storeBuider.AddProduct("com.BlackTesseract.MindlessRobots.LP1", ProductType.NonConsumable);

        //Initialize the store.
        //first parameter indicates this script is for response processing
        // second item is what we are interested in purchasing
        UnityPurchasing.Initialize(this, storeBuider);
    }

    private void Update()
    {

    }
    /// <summary>
    /// Successful initialization
    /// Loads up important references
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="extensions"></param>
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Initialized!");


        s_store_Controller = controller;
        s_extensionsProvider = extensions;
    }

    /// <summary>
    /// Failed Initialization
    /// </summary>
    /// <param name="error"></param>
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialization failed. Error. " + error);

    }

    /// <summary>
    /// Successful Purchase
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        Debug.Log("Purchased!");

        //return that the process was a success.
        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Purchase Failed
    /// </summary>
    /// <param name="i"></param>
    /// <param name="p"></param>
    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.Log("Purchase failed. Error. " + p);

    }

    private void OnGUI()
    {
        if(GUILayout.Button("Buy", GUILayout.MinHeight(25)))
        {
            Product product = s_store_Controller.products.WithID("com.BlackTesseract.MindlessRobots.LP1");
            s_store_Controller.InitiatePurchase(product);
        }
    }

    //========================================
    //      Self-Define
    //------------------------------
    //----------------------
    // Public Functions

    //----------------------
    // Protected Functions

    //----------------------
    // Private Functions

}
