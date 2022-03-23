using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombiesGameBar : MonoBehaviour
{
    [SerializeField] private List<ZombieSO> zombieSOs;
    [SerializeField] private ZombieGameUI _zombieItemPrefab;
    [SerializeField] private ZombieSpawnArea _zombieSpawnArea;
    [SerializeField] private List<ZombieGameUI> _zombis;
    private int _chooseItemNumber = 0;

    void Start()
    {
        foreach (ZombieSO zombie in zombieSOs) {
            ZombieGameUI item = Instantiate(_zombieItemPrefab, transform);
            _zombieItemPrefab.Init(zombie, 1);
            item.ChooseZobmie += _zombieSpawnArea.SwitchZombie;
            item.ChooseZobmie += DeactivateAnotherItems;
            _zombis.Add(item);
        }
        _zombis[0].ClickItem();
       
    }
    private void OnDisable()
    {
        foreach (ZombieGameUI item in _zombis)
        {
            item.ChooseZobmie -= _zombieSpawnArea.SwitchZombie;
            item.ChooseZobmie -= DeactivateAnotherItems;
        }
    }
    private void DeactivateAnotherItems(ZombieSO zombie, int lvl) {
        foreach (ZombieGameUI item in _zombis)
        {
            if (item.ZombieSO != zombie) {
                item.DeactivateItem();
            }
        }
    }
    private List<ZombieSO> GetPlayersZombies() {
        
        return zombieSOs;
    }
}
