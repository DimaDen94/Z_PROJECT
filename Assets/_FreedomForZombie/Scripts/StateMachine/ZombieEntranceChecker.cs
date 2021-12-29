using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieEntranceChecker : EntranceChecker
{
   

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null) {
            CollisionEnter?.Invoke(target);
            Debug.Log(target.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy target;
        other.gameObject.TryGetComponent<Enemy>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Remove(target);
        }
    }
}
