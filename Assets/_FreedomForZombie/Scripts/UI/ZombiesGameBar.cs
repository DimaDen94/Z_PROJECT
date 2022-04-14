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
    [SerializeField] private AllZombiesSO _allZombies;
    private int _chooseItemNumber = 0;

    void Start()
    {
        LoadPlayerUnits();
        UpdateUI();
        _zombis[0].ClickItem();
       
    }
    private void UpdateUI() {
        foreach (ZombieSO zombie in zombieSOs)
        {
            ZombieGameUI item = Instantiate(_zombieItemPrefab, transform);
            item.Init(zombie, DataService.GetUnitLvlById(zombie.Name));
            item.ChooseZobmie += _zombieSpawnArea.SwitchZombie;
            item.ChooseZobmie += DeactivateAnotherItems;

            _zombis.Add(item);
        }
    }
    private void LoadPlayerUnits()
    {
        List<string> unitSequence = PlayerPrefsUtil.GetUnitSequence();

        for (int i = 0; i < unitSequence.Count; i++)
        {
            zombieSOs.Add(_allZombies.GetZombiByID(unitSequence[i]));
            Debug.Log(zombieSOs[i].Name);
            Debug.Log(unitSequence[i]);
        }
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
