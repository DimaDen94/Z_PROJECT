using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieGameUI : MonoBehaviour
{
    [SerializeField] private Image _preview;
    [SerializeField] private TextMeshProUGUI _manaCoast;
    [SerializeField] private Text _title;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    [SerializeField] private ZombieSO _zombieSO;
    private int _zombieLvl;
    private Image _border;
    [SerializeField] private UnityAction<ZombieSO, int> _chooseZobmie;

    public UnityAction<ZombieSO, int> ChooseZobmie { get => _chooseZobmie; set => _chooseZobmie = value; }
    public ZombieSO ZombieSO => _zombieSO;

    private void OnEnable()
    {
        _border = GetComponent<Image>();
    }
    public void Init(ZombieSO zombieSO, int zombieLvl) {
        _zombieLvl = zombieLvl;
        _zombieSO = zombieSO;
        _title.text = zombieSO.Name;
        _preview.sprite = _zombieSO.Preview;
        _manaCoast.text = _zombieSO.PowerCost.ToString();
    }
    public void ClickItem() {
        _chooseZobmie.Invoke(_zombieSO,_zombieLvl);
        _border.color = _activeColor;
    }
    public void DeactivateItem() {
        _border.color = _inactiveColor;
    }
}
