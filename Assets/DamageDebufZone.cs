using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDebufZone : EntranceChecker
{
    [SerializeField]private Unit _unit;
    private float _timeBetweenDebuf = 1.5f;
    private float _countdown;
    private float _actionTime = 2;
    private float _damageDebufMultiplier = 1;

    private void Start()
    {
        _damageDebufMultiplier = _unit.DamageDebufMultiplier;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Add(target);
            target.Dying.AddListener(RemoveUnit);

            target.SetDamageDebuf(_actionTime, _damageDebufMultiplier);
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
        if (_countdown >= _timeBetweenDebuf)
        {
            _countdown = 0;
            foreach (Enemy enemy in _allDetectedEnemy)
            {
         
                enemy.SetDamageDebuf(_actionTime, _damageDebufMultiplier);
            }
        }
    }
}
