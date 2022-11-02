using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireZone : EntranceChecker
{
    [SerializeField] private float _fireDamage;

    private float _timeBetweenDamage = 1f;
    private float _countdown;

    private void OnTriggerEnter(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Add(target);
            target.Dying.AddListener(RemoveUnit);
            Debug.Log(target.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
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
            foreach (Zombie enemy in _allDetectedEnemy)
            {

                enemy.ApplyDamage(_fireDamage);
            }
        }
    }
}
