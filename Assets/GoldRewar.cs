using UnityEngine;
using UnityEngine.Events;

public class GoldRewar : MonoBehaviour
{
    public UnityEvent UpdateGold;
    public void Add200Gold() {
        PlayerPrefsUtil.AddVirtualCurrency(200);
        DataService.CoinBalance = PlayerPrefsUtil.GetCurrencyBalance();
        UpdateGold?.Invoke();
    }
}
