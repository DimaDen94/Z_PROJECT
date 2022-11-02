using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieDescriptionPanel : MonoBehaviour
{
    [SerializeField] Image _preview;
    [SerializeField] Text _name;
    [SerializeField] Text _description;
    [SerializeField] Text _lvl;
    [SerializeField] ParamatersContainer _parametersContainer;
 
    [SerializeField] UpgradeOrBayBtn _upgradeBtn;
    [SerializeField] UISoundManager _soundManager;

    public UnityEvent UpdateData;
    public UnityEvent<string> BayItem;
    public UnityEvent<string> UpgradeItem;

    private InventoryItemSO _itemSO;

    public void Init(InventoryItemSO itemSO)
    {
        _preview.sprite = itemSO.Preview;
        _name.text = itemSO.Name;
        _description.text = itemSO.Descripription;
        _itemSO = itemSO;
        UpdateNonStaticUI();
    }

    private void UpdateNonStaticUI() {
            InventoryItem userCharacter = DataService.TryToFindItemInInventoryById(_itemSO.Name);
            SetLvl(userCharacter);
            SetStatusForBayBtn(userCharacter, _itemSO.Name);
            UpdateData.Invoke();

            if (userCharacter != null)
                _parametersContainer.Render(GenerateFullParams(_itemSO.Parameters, userCharacter.lvl));
            else
                _parametersContainer.Render(GenerateFullParams(_itemSO.Parameters));
    }
    private List<FullUnitParametersValue> GenerateFullParams(List<UnitParametersValue> parameters, int lvl = -1) {
        List<FullUnitParametersValue> fullUnitParameters = new List<FullUnitParametersValue>();
        foreach (UnitParametersValue parameter in parameters)
            fullUnitParameters.Add(new FullUnitParametersValue(MultiplierService.GetValueByParameterAndLvl(parameter, lvl),parameter.parameterType, MultiplierService.GetNewLvlBonusValueByParameterAndLvl(parameter,lvl)));
        return fullUnitParameters;
    }
    private void SetLvl(InventoryItem inventoryItem)
    {
        if (inventoryItem != null)
            _lvl.text = "lvl:" + inventoryItem.lvl.ToString();
        else
            _lvl.text = "need to purchase";
    }

    private void SetAction(Action action) {
        _upgradeBtn.ClearListeners();
        _upgradeBtn.SetAction(action);
        _upgradeBtn.SetAction(UpdateNonStaticUI);

    }
    private void SetStatusForBayBtn(InventoryItem userCharacter, string characterId) {
        if (userCharacter != null)
            SetUpgradeStatusData(userCharacter);
        else
            SetBuyStatusData(characterId);
    }

    private void SetUpgradeStatusData(InventoryItem userCharacter) {
        if (userCharacter.lvl < 10)
        {
            int price = MultiplierService.GetPriceForNewLvlByCurrentLvl(userCharacter.lvl);
            _upgradeBtn.SetPrice(price);
            bool isEnoughMoney = price <= DataService.CoinBalance;
            SetEnoughMoneyStatus(isEnoughMoney);
            if (isEnoughMoney)
                TryToUpgradeItem(userCharacter);
            else
                PlayWrongAudio();
        }
        else
        {
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.MaxLvl);
            PlayWrongAudio();
        }
    }
    private void SetBuyStatusData(string characterId)
    {
        int price = _itemSO.Price;
        _upgradeBtn.SetPrice(price);
        bool isEnoughMoney = price <= DataService.CoinBalance;
        SetEnoughMoneyStatus(isEnoughMoney);
        if (isEnoughMoney)
            TryToBuyItem(characterId, price);
        else

            PlayWrongAudio();
    }

    private void TryToBuyItem(string itemId, int price)
    {
        SetAction(()=> {
            BayItem?.Invoke(itemId);
            _upgradeBtn.DeactivateBtn();
            //PlayfabService.TryToBuyCharacter(itemId, price, SuccessAction, PlayWrongAudio);
            PlayerPrefsUtil.AddItem(itemId, price);
            SuccessAction();
        });
        
    }

    private void TryToUpgradeItem(InventoryItem item)
    {
        SetAction(() => {
            Debug.Log("TryToUpgrade");
            UpgradeItem?.Invoke(item.name);
            _upgradeBtn.DeactivateBtn();
            //PlayfabService.TryToInventory(item, MultiplierService.GetPriceForNewLvlByCurrentLvl(item.lvl),SuccessAction, PlayWrongAudio);
            if (DataService.CoinBalance >= MultiplierService.GetPriceForNewLvlByCurrentLvl(item.lvl))
            {
                PlayerPrefsUtil.UpgradeItem(item, MultiplierService.GetPriceForNewLvlByCurrentLvl(item.lvl));
                SuccessAction();
            }else
            {
                PlayWrongAudio();
            }
        });
    }
    private void PlayWrongAudio()
    {
        SetAction(() => {
            _upgradeBtn.ActivateBtn();
            _soundManager.PlaySound(SoundType.WrongUpgrade);
        });
     

    }
    private void SuccessAction()
    {
        UpdateNonStaticUI();
        _soundManager.PlaySound(SoundType.Upgrade);
        _upgradeBtn.ActivateBtn();
    }

   

    private void SetEnoughMoneyStatus(bool isEnoughMoney) {
        if (isEnoughMoney)
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.EnoughMoney);
        else
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.NotEnoughMoney);
    }

    

}
