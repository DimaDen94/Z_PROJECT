using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieGameUI : MonoBehaviour
{

    [SerializeField] private Image _preview;
    [SerializeField] private Text _manaCoast;

    [SerializeField] private ZombieSO _zombieSO;
    private int _zombieLvl;
    private UnityAction<ZombieSO, int> _chooseZobmie;

    public UnityAction<ZombieSO, int> ChooseZobmie { get => _chooseZobmie; set => _chooseZobmie = value; }

    public void Init(ZombieSO zombieSO, int zombieLvl) {
        _zombieLvl = zombieLvl;
        _zombieSO = zombieSO;
        _preview.sprite = _zombieSO.Preview;
        _manaCoast.text = _zombieSO.DefaultManaCost.ToString();
    }
    public void ClickItem() {
        _chooseZobmie.Invoke(_zombieSO,_zombieLvl);
    }
}
