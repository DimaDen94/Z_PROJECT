using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitsContainer : MonoBehaviour
{
    [SerializeField] private List<ZombieUpgradeUI> _zombieUpgardeUIs;
    [SerializeField] private List<ZombieSO> _playerUnitInventory = new List<ZombieSO>();
    [SerializeField] private AllZombiesSO _allZombies;

    private void Start()
    {
        LoadPlayerUnits();
        CreateList();
    }

    private void CreateList()
    {
        for (int i = 0; i < _playerUnitInventory.Count; i++) {
            _zombieUpgardeUIs[i].Init(_playerUnitInventory[i], 1);
            _zombieUpgardeUIs[i].GetComponent<DropItem>().OnDropItem.AddListener(ChangInventoryItem);
        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < _playerUnitInventory.Count; i++)
            _zombieUpgardeUIs[i].GetComponent<DropItem>().OnDropItem.RemoveListener(ChangInventoryItem);
    }

    private void LoadPlayerUnits() {
        List<string> unitSequence = PlayerPrefsUtil.GetUnitSequence();
        for (int i = 0; i < unitSequence.Count; i++) {
            _playerUnitInventory.Add(_allZombies.GetZombiByID(unitSequence[i]));
        }
    }
    private void ChangInventoryItem(ZombieSO zombieSO,int position) {
        ZombieSO previusZombie;
        int previusPosition = -1;
        for (int i = 0; i < _zombieUpgardeUIs.Count; i++) {
            if (_zombieUpgardeUIs[i].ZombieSO == zombieSO && i != position)
            {
                previusPosition = i;
            }
        }
        if (previusPosition != -1)
        {
            previusZombie = _zombieUpgardeUIs[position].ZombieSO;
            _zombieUpgardeUIs[previusPosition].Init(previusZombie);
        }
        _zombieUpgardeUIs[position].Init(zombieSO);

        PlayerPrefsUtil.SaveUnitSequence(GenerateUnitSequenceForSave());

    }
    private List<string> GenerateUnitSequenceForSave() {
        List<string> unitSequence = new List<string>();
        foreach (ZombieUpgradeUI zombieUpgradeUI in _zombieUpgardeUIs) {
            unitSequence.Add(zombieUpgradeUI.ZombieSO.Name);
        }
        return unitSequence;
    }

}
