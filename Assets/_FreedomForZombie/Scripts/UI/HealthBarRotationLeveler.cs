using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotationLeveler : MonoBehaviour
{
    [SerializeField] private GameObject _root; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_root.transform.rotation.Equals(Vector3.zero)) {
            transform.rotation = Quaternion.Euler(30, 90, 0);
        }
    }
}
