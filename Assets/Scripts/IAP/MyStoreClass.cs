using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class MyStoreClass : MonoBehaviour, IStoreListener
{
    void Awake()
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("com.imaginecreatemedia.daisy.StickerSet", ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) { }
    public void OnInitializeFailed(InitializationFailureReason error) { }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) { return PurchaseProcessingResult.Complete; }
    public void OnPurchaseFailed(Product item, PurchaseFailureReason r) { }
}
