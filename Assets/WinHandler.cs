using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] private StarContainer _starContainer;
    [SerializeField] private Altar _altar;
    [SerializeField] private CoinsHandller _coinsHandller;
    private void OnEnable()
    {
        TrySaveProgress(_altar.GetStars());
    }

    private void TrySaveProgress(int stars)
    {
        PlayfabManager.AddVirtualCurrency(_coinsHandller.EarnedCoins, SaveVirtualCurrency);

        bool isNewData = DataService.TryToSaveProgress(stars);
        if (isNewData) {
            PlayfabManager.SaveUserProgress(DataService.Progress, OnSavedSuccessfully, OnSaveError);
        }else
            _starContainer.RenderStar(_altar.GetStars());
    }

    private void SaveVirtualCurrency(ModifyUserVirtualCurrencyResult result)
    {
        DataService.CoinBalance = result.Balance;
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
