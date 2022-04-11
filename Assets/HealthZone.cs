using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : EntranceChecker
{
    private float _timeBetweenHealth = 1f;
    private float _countdown;
    private float _health = 2;
    private void OnTriggerEnter(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
        if (target != null)
        {
            CollisionEnter?.Invoke(target);
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
        if (_countdown >= _timeBetweenHealth) {
            _countdown = 0;
            foreach(Zombie zombie in _allDetectedEnemy) {
                zombie.ApplyHealth(_health);
            }
        }
    }
}
