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

    public UnityEvent UpdateData;

    private ZombieSO _zombieSO;
    public void Init(ZombieSO zombieSO) {
        _preview.sprite = zombieSO.Preview;
        _name.text = zombieSO.Name;
        _description.text = zombieSO.Descripription;
        _zombieSO = zombieSO;
        UpdateNonStaticUI();
    }
    private void UpdateNonStaticUI() {
        UserCharacter userCharacter = DataService.TryToFindZombiInInventoryById(_zombieSO.Name);
        SetLvl(userCharacter);
        SetStatusForBayBtn(userCharacter,_zombieSO.Name);
        UpdateData.Invoke();

        if(userCharacter != null)
            _parametersContainer.Render(GenerateFullParams(_zombieSO.Parameters,userCharacter.lvl));
        else
            _parametersContainer.Render(GenerateFullParams(_zombieSO.Parameters));
    }
    private List<FullUnitParametersValue> GenerateFullParams(List<UnitParametersValue> parameters, int lvl = -1) {
        List<FullUnitParametersValue> fullUnitParameters = new List<FullUnitParametersValue>();
        foreach (UnitParametersValue parameter in parameters) {
            fullUnitParameters.Add(new FullUnitParametersValue(MultiplierService.GetValueByParameterAndLvl(parameter, lvl),parameter.parameterType, MultiplierService.GetNewLvlBonusValueByParameterAndLvl(parameter,lvl)));
        }
        return fullUnitParameters;
    }
    
    private void SetLvl(UserCharacter userCharacter)
    {
        if (userCharacter != null)
            _lvl.text = "lvl:" + userCharacter.lvl.ToString();
        else
            _lvl.text = "need to purchase";
    }

    private void SetAction(Action action) {
        _upgradeBtn.ClearListeners();
        _upgradeBtn.SetAction(action);
        _upgradeBtn.SetAction(UpdateNonStaticUI);

    }
    private void SetStatusForBayBtn(UserCharacter userCharacter, string characterId) {
        if (userCharacter != null)
            SetUpgradeStatusData(userCharacter);
        else
            SetBuyStatusData(characterId);
    }

    private void SetUpgradeStatusData(UserCharacter userCharacter) {
        if (userCharacter.lvl <= 10)
        {
            int price = MultiplierService.GetPriceForNewLvlByCurrentLvl(userCharacter.lvl);
            _upgradeBtn.SetPrice(price);
            bool isEnoughMoney = price <= DataService.CoinBalance;
            SetEnoughMoneyStatus(isEnoughMoney);
            if (isEnoughMoney)
                TryToUpgradeCharacter(userCharacter);
            else
                PlayWrongAudio();
        }
        else
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.MaxLvl);
    }
    private void SetBuyStatusData(string characterId)
    {
        int price = DataService.GetPriceForCharacterById(characterId);
        _upgradeBtn.SetPrice(price);
        bool isEnoughMoney = price <= DataService.CoinBalance;
        SetEnoughMoneyStatus(isEnoughMoney);
        if (isEnoughMoney)
            TryToBuyCharacter(characterId, price);
        else
            PlayWrongAudio();
    }

    private void TryToBuyCharacter(string characterId, int price)
    {
        SetAction(()=> {
            Debug.Log("TryToBuyCharacter");
            _upgradeBtn.DeactivateBtn();
            PlayfabManager.TryToBuyCharacter(characterId, price, SuccessAction, PlayWrongAudio);
        });
        
    }

    private void TryToUpgradeCharacter(UserCharacter userCharacter)
    {
        SetAction(() => {
            Debug.Log("TryToUpgradeCharacter");
            _upgradeBtn.DeactivateBtn();
            PlayfabManager.TryToUpgradeCharacter(userCharacter, MultiplierService.GetPriceForNewLvlByCurrentLvl(userCharacter.lvl),SuccessAction, PlayWrongAudio);
        });
    }
    private void PlayWrongAudio()
    {
        _upgradeBtn.ActivateBtn();
        //todo playAudio

    }
    private void SuccessAction()
    {
        
        UpdateNonStaticUI();
        _upgradeBtn.ActivateBtn();
    }

   

    private void SetEnoughMoneyStatus(bool isEnoughMoney) {
        if (isEnoughMoney)
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.EnoughMoney);
        else
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.NotEnoughMoney);
    }

    

}
