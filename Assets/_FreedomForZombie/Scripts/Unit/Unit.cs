using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] private Unit _targetEnemy;
    [SerializeField] private Unit _nativeAltar;
    [SerializeField] Animator animator;
    protected int _lvl;

    public Unit TargetEnemy => _targetEnemy;
    public Unit NativeAltar => _nativeAltar;

    public UnityEvent<Unit> Dying;
    public event UnityAction<float, float> DamageReceived;

    public void SetUnitLvl( int unitLvl) {
        _lvl = unitLvl;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        DamageReceived?.Invoke(_maxHealth, _health);
        if (_health <= 0 && gameObject != null)
            Dying?.Invoke(this);
    }
    public void SetTargetAltar(Unit enemy)
    {
        _targetEnemy = enemy;
    }
    public void SetNativeAltar(Unit altar)
    {
        _nativeAltar = altar;
    }
}
