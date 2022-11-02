using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class PurchaseItem : MonoBehaviour
{
    [SerializeField] private string _inventoryId;
    [SerializeField] private GameObject _activeBtn;
    [SerializeField] private GameObject _deactiveBtn;
    private string productId;
    private void OnEnable()
    {
        CheckAvailability();
    }
    public void CheckAvailability()
    {
        ProductCatalog.LoadDefaultCatalog();
        if (DataService.CheckAvailabilityZombieInInventory(_inventoryId))
        {
            _activeBtn.SetActive(false);
            _deactiveBtn.SetActive(true);
        }
    }
}
