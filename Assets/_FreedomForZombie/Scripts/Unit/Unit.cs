using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour 
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;

    [SerializeField]private Unit _targetEnemy;
    public Unit TargetEnemy => _targetEnemy;

    [SerializeField] private Unit _nativeAltar;
    public Unit NativeAltar => _nativeAltar;

    public event UnityAction<float, float> DamageReceived;


    public UnityEvent<Unit> Dying;
    [SerializeField] Animator animator;
 
    public void ApplyDamage(float damage)
    {
        _health -= damage;
        DamageReceived?.Invoke(_maxHealth, _health);
        if (_health <= 0 && gameObject != null)
        {
            Dying?.Invoke(this);
            //Destroy(gameObject);
        }
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
