using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEntranceChecker : EntranceChecker
{


    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
        if (target != null) {
            CollisionEnter?.Invoke(target);
            _allDetectedEnemy.Add(target);
            target.Dying.AddListener(RemoveUnit); 
            Debug.Log(target.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
        if (target != null)
        {
            _allDetectedEnemy.Remove(target);
        }
    }
    
}
