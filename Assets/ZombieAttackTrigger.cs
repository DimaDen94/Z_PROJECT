using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieAttackTrigger : MonoBehaviour
{
    [SerializeField] Zombie _zombie;
    public UnityEvent Attacked;
     private void OnTriggerEnter(Collider other)
     {
        Enemy target;
        other.gameObject.TryGetComponent(out target);
        if (target != null)
        {
            target.ApplyDamage(_zombie.Damage);
            Attacked?.Invoke();
        }
     }


}