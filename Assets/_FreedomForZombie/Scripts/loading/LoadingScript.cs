using System;
using System.Collections.Generic;
using DG.Tweening;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    //[SerializeField] private Slider _loader;
    private float _totalLoadPartsCount = 5f;
    private float _currentLoadingProgress = 0f;
    private void Awake()
    {
        UpdateUserBalance(PlayerPrefsUtil.GetCurrencyBalance());
        UpdateCharacterList(PlayerPrefsUtil.GetUserInventory());
        UpdateProgressData(PlayerPrefsUtil.GetUserProgress());
    }
    public void Start()
    {
        
        //SceneManager.LoadScene("MapScene");
        //        PlayfabService.Login(OnLoginSuccess);
    }

    private void OnLoginSuccess(LoginResult result)
    {
       

        //PlayfabService.LoadUnitsCatalog(UpdateCatalog);
    }

    private void UpdateCatalog(GetCatalogItemsResult catalog)
    {
        //DataService.Catalog = catalog.Catalog;
        Debug.Log("Catalog size - " + catalog.Catalog.Count);
        foreach (CatalogItem catalogItem in catalog.Catalog)
                Debug.Log(catalogItem.ItemId);
        IncrementSlider();
    }

    private void UpdateUserData(List<InventoryItem> characters, List<ProgressStage> progress)
    {
        
    }

    private void UpdateProgressData(List<ProgressStage> progressStages)
    {
        DataService.Progress = progressStages;
        IncrementSlider();
    }
    private void UpdateCharacterList(List<InventoryItem> list)
    {
        DataService.InventoryItems = list;
        IncrementSlider();
    }
    private void UpdateUserBalance(int balance) {
        Debug.Log("balance - " + balance);
        DataService.CoinBalance = balance;
        IncrementSlider();
    }
    private void IncrementSlider() {
        _currentLoadingProgress++;
        //_loader.DOValue(_currentLoadingProgress / _totalLoadPartsCount,1);
        if (_currentLoadingProgress == _totalLoadPartsCount) {
            SceneManager.LoadScene("MapScene");
        }
    }

}

