using System.Collections;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private CoinsHandller _coinsHandller;

    public void IncremetCurency() {

        DataService.CoinBalance += _coinsHandller.EarnedCoins / 2;
        PlayerPrefsUtil.AddVirtualCurrency(_coinsHandller.EarnedCoins/2);
        SaveVirtualCurrency();
    }

    private void SaveVirtualCurrency()
    {
        DataService.CoinBalance = PlayerPrefsUtil.GetCurrencyBalance();
    }
}
