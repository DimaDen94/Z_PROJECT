using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    public UnityEvent Attacked;
    private void OnTriggerEnter(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent(out target);
        if (target != null)
        {
            target.ApplyDamage(_enemy.Damage);
            Attacked?.Invoke();
        }
    }
}
