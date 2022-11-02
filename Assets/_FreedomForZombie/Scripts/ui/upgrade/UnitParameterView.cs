using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitParameterView : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _value;
    [SerializeField] private Text _nextLvlBonusValue;
    [SerializeField] private Image _icon;
    public void Render(Sprite icon, string title, int value,int nextLvlBonusValue)
    {
        _icon.sprite = icon;
        _title.text = title;
        _value.text = value.ToString();
        if (nextLvlBonusValue > 0)
            _nextLvlBonusValue.text = "+" + nextLvlBonusValue.ToString();
        else if(nextLvlBonusValue < 0)
            _nextLvlBonusValue.text = nextLvlBonusValue.ToString();
    }
}



