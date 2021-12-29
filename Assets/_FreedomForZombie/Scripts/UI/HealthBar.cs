using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;

    [SerializeField] private Unit _unit;


    private void OnEnable()
    {
        _healthBar = GetComponent<Slider>();
        if(_unit)
            _unit.DamageReceived += OnHealthChange;
    }
    private void OnDisable()
    {
        if (_unit)
            _unit.DamageReceived -= OnHealthChange;
    }
    public void OnHealthChange(float maxHealth, float currentHealth) {
        Debug.Log(" " + currentHealth / maxHealth);
        _healthBar.value = currentHealth / maxHealth;
    }
}
