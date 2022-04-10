using System;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDescriptionPanel : MonoBehaviour
{
    [SerializeField] Image _preview;
    [SerializeField] Text _name;
    [SerializeField] Text _description;
    [SerializeField] Text _lvl;
    [SerializeField] Text _damage;
    [SerializeField] Text _health;
    [SerializeField] Text _speed;
    [SerializeField] UpgradeOrBayBtn _upgradeBtn;
    [SerializeField] DamageMultiplierSO _damageMultiplier;

    private ZombieSO _zombieSO;
    public void Init(ZombieSO zombieSO) {
        _preview.sprite = zombieSO.Preview;
        _name.text = zombieSO.Name;
        _description.text = zombieSO.Descripription;
        this._zombieSO = zombieSO;
        UpdateNonStaticUI();
    }
    private void UpdateNonStaticUI() {
        UserCharacter userCharacter = DataService.TryToFindZombiInInventoryById(_zombieSO.Name);
        float damageMultiplier = 1;
        if (userCharacter != null)
            damageMultiplier = _damageMultiplier.MultiplierList[userCharacter.lvl];

        _damage.text = ((int)(_zombieSO.DefaultDamage * damageMultiplier)).ToString();
        _health.text = _zombieSO.DefaultHealth.ToString();
        _speed.text = _zombieSO.DefaultSpeed.ToString();
        SetLvl(userCharacter);
        SetStatuForBayBtn(userCharacter);
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
    private void SetStatuForBayBtn(UserCharacter userCharacter) {
        if (userCharacter != null)
            SetUpgradeStatusData(userCharacter);
        else
            SetBuyStatusData(userCharacter);
    }

    private void SetUpgradeStatusData(UserCharacter userCharacter) {
        if (userCharacter.lvl <= 10)
        {
            int price = GetPriceForNewLvlByCurrentLvl(userCharacter.lvl);
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
    private void SetBuyStatusData(UserCharacter userCharacter)
    {
        int price = DataService.GetPriceForCharacterById(userCharacter.name);
        _upgradeBtn.SetPrice(price);
        bool isEnoughMoney = price <= DataService.CoinBalance;
        SetEnoughMoneyStatus(isEnoughMoney);
        if (isEnoughMoney)
            TryToBuyCharacter(userCharacter);
        else
            PlayWrongAudio();
    }

    private void TryToBuyCharacter(UserCharacter userCharacter)
    {
        SetAction(()=> {
            Debug.Log("TryToBuyCharacter");
            PlayfabManager.TryToBuyCharacter(userCharacter, SuccessAction, PlayWrongAudio);
        });
        
    }

    private void TryToUpgradeCharacter(UserCharacter userCharacter)
    {
        SetAction(() => {
            Debug.Log("TryToUpgradeCharacter");
            PlayfabManager.TryToUpgradeCharacter(userCharacter, GetPriceForNewLvlByCurrentLvl(userCharacter.lvl),SuccessAction, PlayWrongAudio);
        });
    }
    private void PlayWrongAudio()
    {
        SetAction(() => {
            //todo playAudio
        });
    }
    private void SuccessAction()
    {
        DataService.IncrementCharacterById(_zombieSO.Name);
        UpdateNonStaticUI();
    }

   

    private void SetEnoughMoneyStatus(bool isEnoughMoney) {
        if (isEnoughMoney)
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.EnoughMoney);
        else
            _upgradeBtn.SetStatus(UpgradeOrBayBtnStatus.NotEnoughMoney);
    }

    private int GetPriceForNewLvlByCurrentLvl(int lvl) {
        switch (lvl) {
            case 1:
                return 10;
            case 2:
                return 200;
            case 3:
                return 500;
            case 4:
                return 1000;
            case 5:
                return 2000;
            case 6:
                return 5000;
            case 7:
                return 10000;
            case 8:
                return 20000;
            case 9:
                return 50000;
            case 10:
                return 100000;
            default:
                return 0;
        }
    }

}
