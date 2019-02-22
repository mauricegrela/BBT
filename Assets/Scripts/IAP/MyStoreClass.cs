using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class MyStoreClass : MonoBehaviour, IStoreListener
{
    void Awake()
    {
        //Book One
        ConfigurationBuilder builder_LP = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder_LP.AddProduct("com.imaginecreatemedia.daisy.StickerSet", ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder_LP);


        //Book Two
        ConfigurationBuilder builder_K = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder_K.AddProduct("com.imaginecreatemedia.daisy.StickerSet", ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder_K);

    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) { }
    public void OnInitializeFailed(InitializationFailureReason error) { }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) { return PurchaseProcessingResult.Complete; }
    public void OnPurchaseFailed(Product item, PurchaseFailureReason r) { }
}
