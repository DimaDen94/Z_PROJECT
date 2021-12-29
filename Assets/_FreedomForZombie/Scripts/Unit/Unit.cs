using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour 
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;

    private Unit _targetEnemy;
    public Unit TargetEnemy => _targetEnemy;

    public event UnityAction<float, float> DamageReceived;
    public void ApplyDamage(float damage)
    {
        _health -= damage;
        DamageReceived?.Invoke(_maxHealth, _health);
        if (_health <= 0 && gameObject != null)
            Destroy(gameObject);
    }
}
