using System;
using System.Collections.Generic;
using DG.Tweening;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    [SerializeField] private Slider _loader;
    private float _totalLoadPartsCount = 4f;
    private float _currentLoadingProgress = 0f;

    public void Start()
    {
        PlayfabManager.Login(OnLoginSuccess);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        IncrementSlider();
        PlayfabManager.GetCurrencyBalance(UpdateUserBalance);
        PlayfabManager.GetUserData(UpdateUserData);
    }

    private void UpdateUserData(List<UserCharacter> characters, List<ProgressStage> progress)
    {
        UpdateCharacterList(characters);
        UpdateProgressData(progress);
    }

    private void UpdateProgressData(List<ProgressStage> progressStages)
    {
        DataService.Progress = progressStages;
        IncrementSlider();
    }
    private void UpdateCharacterList(List<UserCharacter> list)
    {
        DataService.UserCharacters = list;
        IncrementSlider();
    }
    private void UpdateUserBalance(int balance) {
        Debug.Log("balance - " + balance);
        DataService.CoinBalance = balance;
        IncrementSlider();
    }
    private void IncrementSlider() {
        _currentLoadingProgress++;
        _loader.DOValue(_totalLoadPartsCount/_currentLoadingProgress,1);
        if (_currentLoadingProgress == _totalLoadPartsCount) {
            SceneManager.LoadScene("MapScene");
        }
    }

}

