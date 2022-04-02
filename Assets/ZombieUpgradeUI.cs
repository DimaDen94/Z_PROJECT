using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieUpgradeUI : MonoBehaviour
{
    [SerializeField] private Image _preview;
    [SerializeField] private ZombieSO _zombieSO;
    private int _zombieLvl;
    private Button _button;
    public ZombieSO ZombieSO => _zombieSO;
    public UnityEvent<ZombieSO> OnChooseZombie;
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
    }

}
