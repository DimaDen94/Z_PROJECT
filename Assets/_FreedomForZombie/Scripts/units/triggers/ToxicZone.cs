using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZone : EntranceChecker
{
    [SerializeField] private Unit _unit;
    private float _timeBetweenDamage = 1f;
    private float _countdown;
    private float _toxicDamage;
    private void Start()
    {
        _toxicDamage = _unit.Damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Add(target);
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

    private void Update()
    {
        _countdown += Time.deltaTime;
        if (_countdown >= _timeBetweenDamage)
        {
            _countdown = 0;
            foreach (Enemy enemy in _allDetectedEnemy)
            {

                enemy.ApplyDamage(_toxicDamage);
            }
        }
    }
}
