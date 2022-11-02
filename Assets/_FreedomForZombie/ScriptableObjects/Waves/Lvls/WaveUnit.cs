using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaveUnit 
{
    public float delay;
    public int enemyLvl;
    public Enemy enemy;
    public SpawnPosition spawnPosition;
}
public enum SpawnPosition
{
    UP, DOWN
}
