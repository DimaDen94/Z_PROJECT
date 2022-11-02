using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAltar : Enemy
{
    [SerializeField] private MeshFilter meshRenderer;
    public void Init(EnemyAltarModelSO model) {
        meshRenderer.mesh = model.Mesh;
        _health = model.Health;
        _maxHealth = model.Health;
    }
    private void OnEnemyDie() {
            
    }
}
