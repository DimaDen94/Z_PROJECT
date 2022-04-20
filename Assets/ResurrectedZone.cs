using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectedZone : EntranceChecker
{
    [SerializeField] private Unit _unit;
    [SerializeField] private ZombieSO _zombieTemplate;
    private float _resurrectChance = 0;

    private void Start()
    {
        _resurrectChance = _unit.ResurrectChance;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Add(target);
            target.Dying.AddListener(TryToResurrect);
            target.Dying.AddListener(RemoveUnit);
            Debug.Log(target.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Remove(target);
        }
    }

    private void TryToResurrect(Unit unit)
    {
        if (_allDetectedEnemy.Contains(unit) && _resurrectChance >= Random.Range(0, 100) && !unit.IsResurrected)
        {
            unit.IsResurrected = true;
            Zombie spawnedZombie = Instantiate(_zombieTemplate.Prefab, unit.transform.position, Quaternion.identity);
            spawnedZombie.SetTargetAltar(_unit.TargetEnemy);
            spawnedZombie.SetNativeAltar(_unit.NativeAltar);
            spawnedZombie.SetDefaultParams(_zombieTemplate.GetDamageByLvl(unit.Lvl), _zombieTemplate.GetHealthByLvl(unit.Lvl), _zombieTemplate.DefaultSpeed, unit.Lvl);
        }
    }
}
