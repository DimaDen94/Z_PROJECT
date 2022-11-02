using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.Events;

public class PurchaseHandler : MonoBehaviour
{
    public UnityEvent PurchaseDone;
    public void BuySpecialOffer() {
        PlayerPrefsUtil.AddItem("Saddam", 0);
        PlayerPrefsUtil.AddItem("DisablingAds", 0);
        PlayerPrefsUtil.AddVirtualCurrency(5000);
        SaveVirtualCurrency();
    }
    public void BuyJohnny()
    {
        PlayerPrefsUtil.AddItem("Johnny", 0);
        PurchaseDone.Invoke();
    }
    public void BuySteve()
    {
        PlayerPrefsUtil.AddItem("Steve", 0);
        PurchaseDone.Invoke();
    }
    public void BuyAda()
    {
        PlayerPrefsUtil.AddItem("Ada", 0);
        PurchaseDone.Invoke();
    }
    public void BuyThomas()
    {
        PlayerPrefsUtil.AddItem("Thomas", 0);
        PurchaseDone.Invoke();
    }
    public void Buy1000Coins()
    {
        PlayerPrefsUtil.AddVirtualCurrency(1000);
        SaveVirtualCurrency();
    }
    public void Buy5000Coins()
    {
        PlayerPrefsUtil.AddVirtualCurrency(5000);
        SaveVirtualCurrency();
    }
    public void Buy10000Coins()
    {
        PlayerPrefsUtil.AddVirtualCurrency(10000);
        SaveVirtualCurrency();
    }
    public void Buy50000Coins()
    {
        PlayerPrefsUtil.AddVirtualCurrency(50000);
        SaveVirtualCurrency();

    }

    private void SaveVirtualCurrency()
    {
        DataService.CoinBalance = PlayerPrefsUtil.GetCurrencyBalance();
        PurchaseDone.Invoke();
    }


}
