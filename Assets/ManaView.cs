using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ManaView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _manaText;

    private Slider _manaBar;
 
    private void OnEnable()
    {
        _manaBar = GetComponent<Slider>();
    }
    public void ChangeSliderValue(float _newManaValue, float _maxManaValue) {
        _manaText.text = ((int)_newManaValue).ToString();
        _manaBar.value = _newManaValue / _maxManaValue;
    }

}
