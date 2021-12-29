using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombiesGameBar : MonoBehaviour
{
    [SerializeField] private List<ZombieSO> zombieSOs;
    [SerializeField] private ZombieGameUI _zombieItemPrefab;
    [SerializeField] private ZombieSpawnArea _zombieSpawnArea;
    private int _chooseItemNumber = 0;

    void Start()
    {
        foreach (ZombieSO zombie in zombieSOs) {
            ZombieGameUI item = Instantiate(_zombieItemPrefab, transform);
            _zombieItemPrefab.Init(zombie, 1);
            //_zombieSpawnArea.SwitchZombie(zombie, 1);
            item.ChooseZobmie += _zombieSpawnArea.SwitchZombie;
        }
    }

    private List<ZombieSO> GetPlayersZombies() {
        
        return zombieSOs;
    }
}
