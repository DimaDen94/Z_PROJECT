using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Wawe[] _wawes;
    [SerializeField] private Transform _spawnPointDown;
    [SerializeField] private Transform _spawnPointUp;
    [SerializeField] private float _timeBetweenWawes = 5f;
    [SerializeField] private float _waweCountdown;
    [SerializeField] private SpawnState _currentState = SpawnState.COUNTING;

    [SerializeField] private int _currentWaweIndex = 0;
    [SerializeField] private Unit _targetAltar;


    private void Start()
    {
        _waweCountdown = _timeBetweenWawes;
    }
    private void Update()
    {
        if (_currentState == SpawnState.WATING) {
            WaweComplete();
        }
        if (_waweCountdown <= 0)
        {
            if (_currentState != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWawe(_wawes[_currentWaweIndex]));
            }
        }
        else {
            _waweCountdown -= Time.deltaTime;
        }
        
    }

    void WaweComplete() {
        Debug.Log("Wawe complete");
        _currentState = SpawnState.COUNTING;

        _waweCountdown = _timeBetweenWawes;
        if (_currentWaweIndex + 1 > _wawes.Length - 1) {
            _currentWaweIndex = 0;
            Debug.Log("Completed all wawes");
        }else
            _currentWaweIndex++;
    }

    private IEnumerator SpawnWawe(Wawe wawe) {
        _currentState = SpawnState.SPAWNING;
        foreach (WaweUnit unit in wawe.waweUnit) {
            yield return new WaitForSeconds(unit.delay);

            SpawnEnemy(unit.enemy,unit.spawnPosition);
        }

        _currentState = SpawnState.WATING;
        yield break;
    }
    private void SpawnEnemy(Unit enemy, SpawnPosition spawnPosition) {
        //Spawn Enemy
        Vector3 spawnLocation;
        if(spawnPosition == SpawnPosition.DOWN)
            spawnLocation = _spawnPointDown.position;
        else
            spawnLocation = _spawnPointUp.position;
        Unit spawnedEnemy = Instantiate(enemy, spawnLocation, Quaternion.identity);
        spawnedEnemy.SetTargetAltarPosition(_targetAltar);
    }

    [System.Serializable]
    public class Wawe
    {
        public string name;
        public WaweUnit[] waweUnit;
    }
    [System.Serializable]
    public class WaweUnit
    {
        public float delay;
        public Unit enemy;
        public SpawnPosition spawnPosition;
    }
    public enum SpawnState {
        SPAWNING,WATING,COUNTING
    }
    public enum SpawnPosition {
        UP,DOWN
    }
}
