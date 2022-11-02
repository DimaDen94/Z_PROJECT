using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mana : MonoBehaviour
{
    [SerializeField]private float _value;
    private float _maxValue = 10;
    private float _manaSpawnTime = 1f;
    private float _lastManaSpawnTime;

    public UnityEvent<float, float> ManaChanged;
 

    private void Start()
    {
        ChangeMana(_maxValue);
    }

    public bool TryUseMana(int count) {
        if (_value >= count) {
            ChangeMana(-count);
            return true;
        }
        return false;
    }
    public void RestoreFullPower() {
        _value = _maxValue;
        ManaChanged?.Invoke(_value, _maxValue);
    }
    private void ChangeMana(float count) {
        _value += count;
        ManaChanged?.Invoke(_value,_maxValue);
    }
    private void Update()
    {
        if (_value < _maxValue)
        {
            _lastManaSpawnTime += Time.deltaTime;
            if (_lastManaSpawnTime >= _manaSpawnTime) {
                ChangeMana(1);
                _lastManaSpawnTime = 0;
            }

        }
    }

}
