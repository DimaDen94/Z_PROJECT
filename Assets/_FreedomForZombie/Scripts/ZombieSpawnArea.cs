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
    [SerializeField] private Enemy targetAltar;
    [SerializeField] private Zombie _tempZombie;
    [SerializeField] private ZombieSO _currentZombie;
    [SerializeField] private Mana _mana;

    void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(_collider.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition),out hit, _maxDistance))
            { 
                _worldPosition = hit.point;
                if (_mana.TryUseMana(_currentZombie.DefaultManaCost)) {

                    Zombie spawnedZombie = Instantiate(_currentZombie.Prefab, _worldPosition, Quaternion.LookRotation(targetAltar.transform.position));
                    spawnedZombie.SetTargetAltarPosition(targetAltar);
                }
                // TODO play sound and animation
            }
        }
    }

    public void SwitchZombie(ZombieSO zombieSO, int lvl) {
        _tempZombie = zombieSO.Prefab;
        _currentZombie = zombieSO;
    }
}
