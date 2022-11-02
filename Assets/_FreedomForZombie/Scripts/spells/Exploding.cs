using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    [SerializeField] Zombie _zombie;
    [SerializeField] float _damageMultiplayer;
    private void OnTriggerEnter(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent(out target);
        if (target != null)
        {
            target.ApplyDamage(_zombie.Damage * _damageMultiplayer);
            
        }
    }
}
