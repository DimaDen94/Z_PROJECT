using System;
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
    [SerializeField] DamageMultiplierSO _damageMultiplierSO;
    [SerializeField] protected float _damage;
    protected int _lvl;
    [SerializeField] private float _damageDebuf = 1;
    [SerializeField]private float _damageDebufCounter = 0;
    private float _damageDebufPower = 0;
    private float _healthPower = 0;
    private float _resurrectChance = 0;


    public float Damage => _damage * _damageMultiplierSO.MultiplierList[_lvl] * _damageDebuf;
    public float DamageDebufMultiplier => 1 - (_damageDebufPower / 100);
    public float HealthPower => _healthPower; 
    public float ResurrectChance => _resurrectChance; 

    public UnityEvent<int> LvlUpdate;

    public Unit TargetEnemy => _targetEnemy;
    public Unit NativeAltar => _nativeAltar;

    public Animator Animator => animator;

    public int Lvl  => _lvl;

    public UnityEvent<Unit> Dying;
    public UnityEvent TakeDamage;


    private bool _isResurrected = false;

    public bool IsResurrected { get => _isResurrected; set => _isResurrected = value; }


    public event UnityAction<float, float> HealthChange;

    private void Update()
    {
        if (_damageDebuf == 1)
            return;
        if (_damageDebufCounter > 0)
        {
            _damageDebufCounter -= Time.deltaTime;
        }
        else {
            _damageDebuf = 1;
        }
    }
    public void SetDamageDebuf(float time, float damageMultiplier) {
        _damageDebufCounter = time;
        _damageDebuf = damageMultiplier;
    }
    public void SetDamageDebufPower(float power) {
        _damageDebufPower = power;
    }
    public void SetHealthPower(float healthPower)
    {
        _healthPower = healthPower;
    }
    public void SetResurrectChance(float chance)
    {
        _resurrectChance = chance;
    }
    public void SetUnitLvl( int unitLvl) {
        _lvl = unitLvl;
        LvlUpdate.Invoke(_lvl);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        HealthChange?.Invoke(_maxHealth, _health);
        TakeDamage?.Invoke();
        if (_health <= 0 && gameObject != null)
            Dying?.Invoke(this);
    }
    public void ApplyHealth(float health)
    {
        
        _health += health;
        if (_health > _maxHealth)
            _health = _maxHealth;
        HealthChange?.Invoke(_maxHealth, _health);
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

