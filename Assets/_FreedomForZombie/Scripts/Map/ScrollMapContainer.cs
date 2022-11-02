using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrollMapContainer : MonoBehaviour
{
 
    [SerializeField] private List<MovingMap> _movingMaps = new List<MovingMap>();

    private float? _lastXMousePos;
    private float _inerction = 0;
    private Vector2 _currentMousePos;
    private bool _isMove = false;

    private int _maxDistance = 1000;
    private Camera _mainCamera;
    public UnityEvent StartPositionSet;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        SetupStartPosition();
        StartPositionSet?.Invoke();

    }
    private void SetupStartPosition()
    {
        for (var i = 0; i < _movingMaps.Count; i++)
        {
            _movingMaps[i].MoveToStartPosition();
        }
    }

    private void Update()
    {
        if (!MapService.MapIsActive) {
            _lastXMousePos = null;
            return;
        }
        if (Input.GetMouseButton(0))
        {
            _currentMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (!_isMove)
            {
                RaycastHit2D hit = Physics2D.Raycast(_currentMousePos, transform.TransformDirection(Vector3.forward), _maxDistance);
                if (hit.transform == null || hit.transform.gameObject.GetComponent<MovingMap>() == null) return;
                _isMove = true;
                _lastXMousePos = _currentMousePos.x;
                return;
            }

            if (_lastXMousePos == null)
            {
                _lastXMousePos = _currentMousePos.x;
            }
            else
            {
                float delta = (float)(_currentMousePos.x - _lastXMousePos);
                _inerction = delta / (Time.deltaTime * 2f);
                Move(delta);
                _lastXMousePos = _currentMousePos.x;
            }
        }


        if (Input.GetMouseButtonUp(0) && !Input.GetMouseButtonDown(1))
        {
            _lastXMousePos = null;
            _isMove = false;
        }

        if (!Input.GetMouseButton(0))
        {
            
            if (Math.Abs(_inerction) > 0.1)
            {
                Move(_inerction * Time.deltaTime);
                _inerction -= _inerction * Time.deltaTime * 2;
            }
        }
    }
    
    public void Move(float delta)
    {
        
        for (var i = 0; i < _movingMaps.Count; i++)
        {
            delta = _movingMaps[i].GetMaxDelta(delta, _movingMaps.Count - 1);
            Debug.Log("delta - " + delta);

        }
        for (var i = 0; i < _movingMaps.Count; i++)
        {
            _movingMaps[i].Move(delta);
        }

    }
}