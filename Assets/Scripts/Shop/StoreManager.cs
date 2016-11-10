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


    [Serializable]
    private class UIInfo
    {
        public Text tileText;
        public Text priceText;
        public Text descriptionText;
        public Button buyButton;
        public Image icon;
    }

    [Serializable]
    private class ProductInfo
    {
        public string sku;
        public ProductType type;
        public string iconUrl;
        public string purchaseFunction;


        public bool WasPurchased { get { return isPurchased; } set { isPurchased = value; } }
        private bool isPurchased = false;

    }

    [SerializeField]
    private ProductInfo[] m_productInfos = null;

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
      


  //  [SerializeField]
   // private string[] m_skus = new string[] { "com.BlackTesseract.MindlessRobots.LP1" };

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

            int productCount = m_productInfos.Length;
            for(int i = 0; i< productCount; ++i)
            {
                // get the next product from the array
                ProductInfo currentProduct = m_productInfos[i];
                // pass the info to the builder
                storeBuider.AddProduct(currentProduct.sku, currentProduct.type);

                StartCoroutine(GetIcon(currentProduct.iconUrl, i));
            }

           // storeBuider.AddProduct("com.BlackTesseract.MindlessRobots.LP1", ProductType.NonConsumable);
          //  storeBuider.AddProduct("com.BlackTesseract.MindlessRobots.LP2", ProductType.NonConsumable);



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


    private IEnumerator GetIcon(string url, int panelNumber)
    {
        // send the request, wait until it's done
        WWW internetRequest = new WWW(url);
        yield return internetRequest;
        Texture2D Text2D = internetRequest.texture;

        Rect textureCoordinates = new Rect(0, 0, Text2D.width, Text2D.height);

        Sprite newsprite = Sprite.Create(Text2D, textureCoordinates,  Vector2.zero);

        m_uiRefernces[panelNumber].icon.sprite = newsprite;
    }


    private void Update()
    {
        if (s_store_Controller == null)
        {
            m_storePanel.SetActive(false);
            //make a loading thing here

        }
        else
        {
            m_storePanel.SetActive(true);

        }
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

            bool hasBeenPurchased = product.hasReceipt;
            ProductType type = product.definition.type;

            ProductMetadata productData = product.metadata;

            string title = productData.localizedTitle;
            string price = productData.localizedPriceString;
            string description = productData.localizedDescription;

            if (hasBeenPurchased && type != ProductType.Consumable)
            {
                //write to player prefs
                Debug.Log("ERROR. " + title + " was purchased");

            }

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



        Product purchasedProduct = e.purchasedProduct;

        //check the sku
        ProductDefinition productDefinition = purchasedProduct.definition;
        string purchasedSku = productDefinition.id;



        int productCount = m_productInfos.Length;
        for (int i = 0; i< productCount; ++i)
        {
            if(m_productInfos[i].sku == purchasedSku)
            {
                //playerpref unlock here...?
                pp(m_productInfos[i].purchaseFunction, 1);
            }
        }
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

    public void _Buy(int productIndex)
    {
        if(productIndex>= m_productInfos.Length)
        {
            // no item can exist here leave
            return;
        }
        //if(GUILayout.Button("Buy", GUILayout.MinHeight(25)))
        {
            Product product = s_store_Controller.products.WithID(m_productInfos[productIndex].sku);
            s_store_Controller.InitiatePurchase(product);
        }
    }


    public void pp (string key, int sitch)
    {
        PlayerPrefs.SetInt(key, sitch);  
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
