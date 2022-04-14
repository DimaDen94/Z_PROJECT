using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackTrigger : MonoBehaviour
{
    [SerializeField] Zombie _zombie;
     private void OnTriggerEnter(Collider other)
     {
        Enemy target;
        other.gameObject.TryGetComponent(out target);
        if (target != null)
        {
            target.ApplyDamage(_zombie.Damage);
        }
     }


}