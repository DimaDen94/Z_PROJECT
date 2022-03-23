using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Wave[] _wawes;
    [SerializeField] private List<Unit> _units;
    [SerializeField] private Transform _spawnPointDown;
    [SerializeField] private Transform _spawnPointUp;
    [SerializeField] private float _timeBetweenWawes = 5f;
    [SerializeField] private float _waweCountdown;
    [SerializeField] private SpawnState _currentState = SpawnState.COUNTING;

    [SerializeField] private int _currentWaweIndex = 0;
    [SerializeField] private Unit _targetAltar;
    [SerializeField] private EnemyAltar _nativeAltar;
    private Coroutine _spawnerCoroutine;

    public UnityEvent<float,float> WaveTimer;
    public UnityEvent<float,float> WaveCounter;
    public UnityEvent<float> WavePause;
    public UnityEvent WaveCompleted;

    private void Start()
    {
        _waweCountdown = _timeBetweenWawes;
        _units = new List<Unit>();
        
    }
    private void Update()
    {
        if (_currentState != SpawnState.STOP)
        {
            if (_currentState == SpawnState.WATING)
            {
                WaveComplete();
            }
            if (_waweCountdown <= 0)
            {
                if (_currentState != SpawnState.SPAWNING)
                {
                    _spawnerCoroutine = StartCoroutine(SpawnWawe(_wawes[_currentWaweIndex]));
                }
            }
            else
            {
                _waweCountdown -= Time.deltaTime;
                if(_currentState != SpawnState.STOP)
                    WavePause.Invoke((int)_waweCountdown);
            }
        }
    }
   
    void WaveComplete()
    {
        Debug.Log("Wawe complete");
        _currentState = SpawnState.COUNTING;

        _waweCountdown = _timeBetweenWawes;
        if (_currentWaweIndex + 1 > _wawes.Length - 1)
        {
            StopSpawner();
            Debug.Log("Completed all wawes");
            WaveCompleted.Invoke();
        }
        else
        {
            _currentWaweIndex++;
            WaveCounter.Invoke(_wawes.Length, _wawes.Length - _currentWaweIndex);
        }
    }

    private IEnumerator SpawnWawe(Wave wawe)
    {
        _currentState = SpawnState.SPAWNING;
        WaveCounter.Invoke(_wawes.Length, _wawes.Length - _currentWaweIndex);
        float totalWaveTime = CalculateTotalWaveTime(wawe)-1;
        float currentWaveTime = totalWaveTime;
        foreach (WaveUnit unit in wawe.waweUnit)
        {
            for (int i = 0; i < unit.delay; i++) {
                WaveTimer.Invoke(totalWaveTime, currentWaveTime);
                currentWaveTime--;
                yield return new WaitForSeconds(1);
            }
            SpawnEnemy(unit.enemy, unit.spawnPosition);
        }

        _currentState = SpawnState.WATING;
        yield break;
    }

    private float CalculateTotalWaveTime(Wave wave)
    {
        float totalDelay = 0;
        foreach (WaveUnit waweUnit in wave.waweUnit)
            totalDelay += waweUnit.delay;
        return totalDelay;
    }
    private void SpawnEnemy(Unit enemy, SpawnPosition spawnPosition)
    {
        //Spawn Enemy
        Vector3 spawnLocation;
        if (spawnPosition == SpawnPosition.DOWN)
            spawnLocation = _spawnPointDown.position;
        else
            spawnLocation = _spawnPointUp.position;
        Unit spawnedEnemy = Instantiate(enemy, spawnLocation, Quaternion.identity);
        spawnedEnemy.SetTargetAltar(_targetAltar);
        spawnedEnemy.SetNativeAltar(_nativeAltar);
        spawnedEnemy.Dying.AddListener(unit => { RemoveUnit(unit); });
        _units.Add(spawnedEnemy);
    }
    private void RemoveUnit(Unit unit)
    {
        _units.Remove(unit);
    }
    [System.Serializable]
    public class Wave
    {
        public string name;
        public WaveUnit[] waweUnit;
    }
    [System.Serializable]
    public class WaveUnit
    {
        public float delay;
        public Unit enemy;
        public SpawnPosition spawnPosition;
    }
    public enum SpawnState
    {
        SPAWNING, WATING, COUNTING, STOP
    }
    public enum SpawnPosition
    {
        UP, DOWN
    }
    public void KillAllUnits()
    {
        for (int i = _units.Count - 1; i >= 0; i--)
        {
            if (_units[i] != null)
                _units[i].Dying.Invoke(_units[i]);
        }
    }
    public void StopSpawner()
    {
        _currentState = SpawnState.STOP;
        StopCoroutine(_spawnerCoroutine);
    }
}
