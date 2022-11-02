using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Altar : Zombie
{
    [SerializeField] private List<ZombieAltarModelSO> _models;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        int lvl = DataService.GetUnitLvlById("Altar");

        if(lvl > _models.Count)
            lvl = _models.Count;

        Instantiate(_models[lvl - 1].Model,transform);
        _health = _models[lvl - 1].Health;
        _maxHealth = _models[lvl - 1].Health;
    }
    public void RestoreAltar() {
        ApplyHealth(_maxHealth);
       
        transform.DOMoveY(0, 3);
    }
    public int GetStars()
    {
        if (_maxHealth == _health)
            return 3;
        else if (_maxHealth / 2 < _health)
            return 2;
        else
            return 1;

    }
}
