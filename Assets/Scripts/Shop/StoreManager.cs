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
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class StoreManager : MonoBehaviour , IStoreListener
{


    [System.Serializable]
    private class UIInfo
    {
        public Text tileText;
        public Text priceText;
        public Text descriptionText;
    }

    [SerializeField]
    private UIInfo[] m_uiRefernces = null;
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

    private static ProductCollection s_pruductCollection = null;

    [SerializeField]
    private GameObject m_storePanel;


    /// <summary>
    /// initializes the Unity Services IAP plugin.
    /// </summary>
    private void Awake()
    {

        if(s_store_Controller == null)
        {

            ConfigurationBuilder storeBuider = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            storeBuider.AddProduct("com.BlackTesseract.MindlessRobots.LP1", ProductType.NonConsumable);
            storeBuider.AddProduct("com.BlackTesseract.MindlessRobots.LP2", ProductType.NonConsumable);

            //Initialize the store.
            //first parameter indicates this script is for response processing
            // second item is what we are interested in purchasing
            UnityPurchasing.Initialize(this, storeBuider);
        }
        else
        {
            PopulateUI();
        }

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

        PopulateUI();

    }

    private void PopulateUI()
    { 
        s_pruductCollection = s_store_Controller.products;

        Product[] products = s_pruductCollection.all;

        for(int i = 0; i<m_uiRefernces.Length; ++i)
        {
            if(i>=products.Length)
            {
                Destroy(m_uiRefernces[i].tileText.transform.parent.gameObject);
                continue;
            }
            Product product = products[i];
            ProductMetadata productData = product.metadata;

            string title = productData.localizedTitle;
            string price = productData.localizedPriceString;
            string description = productData.localizedDescription;

            Debug.Log("Title: " + title + ", Price: " + price + ", Description: " + description);


            UIInfo uiInfo = m_uiRefernces[i];

            uiInfo.tileText.text = title;
            uiInfo.priceText.text = price;
            uiInfo.descriptionText.text = description;


        }
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

    public void BuyButton(int listNum)
    {
        //if(GUILayout.Button("Buy", GUILayout.MinHeight(25)))
        {
            Product product = s_store_Controller.products.WithID(m_skus[listNum]);
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
