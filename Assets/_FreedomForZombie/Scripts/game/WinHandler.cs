using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class WinHandler : MonoBehaviour
{
    [SerializeField] private StarContainer _starContainer;
    [SerializeField] private Altar _altar;
    [SerializeField] private CoinsHandller _coinsHandller;
    [SerializeField] private Text _bonusText;
    private void OnEnable()
    {
        TrySaveProgress(_altar.GetStars());
    }

    private void TrySaveProgress(int stars)
    {
        int bonus = DataService.GetBonusCoinsByCurrentStars(stars);
        PlayerPrefsUtil.AddVirtualCurrency(_coinsHandller.EarnedCoins + bonus);
        SaveVirtualCurrency();

        _bonusText.text = "bunus coins - " + bonus;
        bool isNewData = DataService.TryToSaveProgress(stars);
        if (isNewData) {
            PlayerPrefsUtil.SaveUserProgress(DataService.Progress);
            OnSavedSuccessfully();
        }
        else
            _starContainer.RenderStar(_altar.GetStars());
    }

    private void SaveVirtualCurrency()
    {
        DataService.CoinBalance = PlayerPrefsUtil.GetCurrencyBalance();
    }

    private void OnSaveError()
    {
        Debug.Log("Save Error");

    }

    private void OnSavedSuccessfully()
    {
        _starContainer.RenderStar(_altar.GetStars());

    }
}
