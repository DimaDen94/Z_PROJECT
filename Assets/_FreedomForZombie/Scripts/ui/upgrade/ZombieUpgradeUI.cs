using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieUpgradeUI : MonoBehaviour
{
    [SerializeField] private Image _preview;
    [SerializeField] private ZombieSO _zombieSO;
    [SerializeField] private GameObject _lvlContainer;
    [SerializeField] private Text _lvlNumber;
    [SerializeField] private Color _disableColor;

    private int _zombieLvl;
    private Button _button;
    public ZombieSO ZombieSO => _zombieSO;
    public UnityEvent<ZombieSO> OnChooseZombie;
    private bool _isContainsInInventory = false;
    public bool IsContainsInInventory => _isContainsInInventory;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=> {
            OnChooseZombie.Invoke(_zombieSO);
            Debug.Log("Click");
        });

    }
    public void Init(ZombieSO zombieSO, int zombieLvl = 1)
    {
        _zombieLvl = zombieLvl;
        _zombieSO = zombieSO;
        _preview.sprite = _zombieSO.Preview;
        if (DataService.TryToFindItemInInventoryById(zombieSO.Name) != null) {
            _isContainsInInventory = true;
            _zombieLvl = DataService.TryToFindItemInInventoryById(zombieSO.Name).lvl;
        }
        if (!_isContainsInInventory) {
            _preview.color = _disableColor;
        }
        else if(_lvlContainer != null)
        {
            _preview.color = Color.white;
            _lvlContainer.SetActive(true);
            _lvlNumber.text = _zombieLvl.ToString();
        }
    }
    public void Init(int zombieLvl = 1)
    {
        _zombieLvl = zombieLvl;
        _preview.sprite = _zombieSO.Preview;
        if (DataService.TryToFindItemInInventoryById(_zombieSO.Name) != null)
        {
            _isContainsInInventory = true;
            _zombieLvl = DataService.TryToFindItemInInventoryById(_zombieSO.Name).lvl;
        }
        if (!_isContainsInInventory)
        {
            _preview.color = _disableColor;
        }
        else if (_lvlContainer != null)
        {
            _preview.color = Color.white;
            _lvlContainer.SetActive(true);
            _lvlNumber.text = _zombieLvl.ToString();
        }
    }

}
