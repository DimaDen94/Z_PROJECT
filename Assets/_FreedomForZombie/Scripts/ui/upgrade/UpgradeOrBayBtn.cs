using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOrBayBtn : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _price;

    public void SetPrice(int price) {
        if(price != 0)
            _price.text = price.ToString();
    }

    public void SetStatus(UpgradeOrBayBtnStatus status) {
        switch (status) {
            case UpgradeOrBayBtnStatus.EnoughMoney:
                _price.color = Color.black;
                break;
            case UpgradeOrBayBtnStatus.NotEnoughMoney:
                _price.color = Color.red;
                break;
            case UpgradeOrBayBtnStatus.MaxLvl:
                _price.text = "Max lvl";
                _price.color = Color.gray;
                break;
                
        }
    }
    public void SetAction(Action action) {
        GetComponent<Button>().onClick.AddListener(()=> { action.Invoke(); });
    }

    internal void ClearListeners()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    internal void DeactivateBtn()
    {
        GetComponent<Button>().interactable = false;
    }

    internal void ActivateBtn()
    {
        GetComponent<Button>().interactable = true;
    }
}
public enum UpgradeOrBayBtnStatus {
    EnoughMoney,
    NotEnoughMoney,
    MaxLvl
}
