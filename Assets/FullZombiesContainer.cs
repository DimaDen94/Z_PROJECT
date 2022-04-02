using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FullZombiesContainer : MonoBehaviour
{
    [SerializeField] private List<ZombieUpgradeUI> _zombieUpgradeUIs;
    [SerializeField] private AllZombiesSO _allZombies;
    public UnityEvent<ZombieSO> OnChooseZombie;
    private void Start()
    {
        for (int i = 0; i < _allZombies.Zombies.Count; i++)
        {
            _zombieUpgradeUIs[i].Init(_allZombies.Zombies[i]);
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < _allZombies.Zombies.Count; i++)
        {
            _zombieUpgradeUIs[i].OnChooseZombie.AddListener(ChooseZombie);
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _allZombies.Zombies.Count; i++)
        {
            _zombieUpgradeUIs[i].OnChooseZombie.RemoveListener(ChooseZombie);
        }
    }
    private void ChooseZombie(ZombieSO zombieSO)
    {
        OnChooseZombie.Invoke(zombieSO);
    }
}
