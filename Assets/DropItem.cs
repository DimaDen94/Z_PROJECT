using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] private int _position;
    private PlayerUnitsContainer _playerUnitsContainer;
    public UnityEvent<ZombieSO, int> OnDropItem;
    private void Start()
    {
        _playerUnitsContainer = GetComponentInParent<PlayerUnitsContainer>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropItem.Invoke(DragItem._currentZombie, _position);
    }
  
}
