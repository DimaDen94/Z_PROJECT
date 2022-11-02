using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ZombieSpawnArea : MonoBehaviour
{

    private Collider _collider;
    private Vector3 _worldPosition;
    private int _maxDistance = 1000;
    private Camera _mainCamera;
    [SerializeField] private Enemy _targetAltar;
    [SerializeField] private Altar _nativeAltar;
    [SerializeField] private ZombieSO _currentZombie;
    [SerializeField] private Mana _mana;
    [SerializeField] private List<Unit> _zombies;
    [SerializeField] private UISoundManager _soundManager;
    private bool _isGameStoped = false;
    private int _zombieLvl;

    void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _mainCamera = Camera.main;
        _zombies = new List<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameStoped)
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                /*if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("hit - " + hit.transform.name) ;
                    if (hit.transform.GetComponent<Unit>() != null)
                    {
                        Debug.Log("return - " + hit.transform.name);
                        PlayMissSpawningAudio();
                        return;
                    }
                }*/
                if (_collider.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit, _maxDistance))
                {
                    _worldPosition = hit.point;
                    if (_mana.TryUseMana(_currentZombie.PowerCost))
                    {

                        Zombie spawnedZombie = Instantiate(_currentZombie.Prefab, _worldPosition, Quaternion.LookRotation(_targetAltar.transform.position));
                        spawnedZombie.SetTargetAltar(_targetAltar);
                        spawnedZombie.SetNativeAltar(_nativeAltar);
                        spawnedZombie.SetDefaultParams(_currentZombie.GetDamageByLvl(_zombieLvl), _currentZombie.GetHealthByLvl(_zombieLvl), _currentZombie.DefaultSpeed,_zombieLvl);
                        spawnedZombie.SetDamageDebufPower(_currentZombie.GetDamageByLvl(_zombieLvl));
                        spawnedZombie.SetHealthPower(_currentZombie.GetHealingPowerByLvl(_zombieLvl));
                        spawnedZombie.SetResurrectChance(_currentZombie.GetResurrectChanceByLvl(_zombieLvl));
                        _zombies.Add(spawnedZombie);
                        PlaySpawningAudio();
                        spawnedZombie.Dying.AddListener(zombie =>
                        {
                            RemoveUnit(zombie);
                        });
                    }else
                        PlayMissSpawningAudio();
                    // TODO play sound and animation
                }
            }
    }

    private void PlayMissSpawningAudio()
    {
        _soundManager.PlaySound(SoundType.MissClick);
    }

    private void PlaySpawningAudio()
    {
        _soundManager.PlaySound(SoundType.Spawn);
    }

    private void RemoveUnit(Unit zombie)
    {
        _zombies.Remove(zombie);
    }
    public void KillAllZombie()
    {
        for (int i = _zombies.Count - 1; i >= 0; i--)
        {
            if (_zombies[i] != null)
                _zombies[i].Dying.Invoke(_zombies[i]);
        }
    }
    public void DeactivateSpawnArea()
    {
        _isGameStoped = true;
    }
    public void ActivateSpawnArea()
    {
        _isGameStoped = false;
    }
    public void SwitchZombie(ZombieSO zombieSO, int lvl)
    {
        _currentZombie = zombieSO;
        _zombieLvl = lvl;
    }
}
