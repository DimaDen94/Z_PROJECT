using System;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;

public class DataService 
{
    private static int _coinBalance;
    private static List<InventoryItem> _inventoryItems;
    private static List<ProgressStage> _progress;

    public static int CoinBalance { get => _coinBalance; set => _coinBalance = value; }
    public static List<InventoryItem> InventoryItems { get => _inventoryItems; set => _inventoryItems = value; }
    public static List<ProgressStage> Progress { get => _progress; set => _progress = value; }
    public static int LastClickedPoint { get;  set; }
    //public static List<CatalogItem> Catalog { get; set; }

    public static InventoryItem TryToFindItemInInventoryById(string characterId)
    {
        foreach (InventoryItem item in InventoryItems) 
            if (characterId.Equals(item.name))
                return item;
        return null;
        
    }

    public static int GetUnitLvlById(string name)
    {
        return TryToFindItemInInventoryById(name).lvl;
    }

    public static bool TryToSaveProgress(int stars) {
        if (_progress[0].Points.Count == LastClickedPoint)
        {
            _progress[0].Points[LastClickedPoint - 1].isComplited = true;
            _progress[0].Points[LastClickedPoint - 1].stars = stars;
            ProgressPoint point = new ProgressPoint();
            point.position = LastClickedPoint;
            point.isComplited = false;
            point.stars = 0;
            _progress[0].Points.Add(point);
            return true;
        }
        else if (_progress[0].Points.Count > LastClickedPoint && _progress[0].Points[LastClickedPoint - 1].stars < stars) {
            _progress[0].Points[LastClickedPoint - 1].stars = stars;
            //Debug.Log("new stars - " + stars + "old stars - " + _progress[0].Points[LastClickedPoint - 1].stars);
            return true;
        }
        return false;
    }
    public static int GetBonusCoinsByCurrentStars(int stars) {
        if (_progress[0].Points.Count == LastClickedPoint)
            return stars * 15 * LastClickedPoint;
        else
            return (stars - _progress[0].Points[LastClickedPoint - 1].stars) * 15 * LastClickedPoint;
    }

    /*public static int GetPriceForCharacterById(string name)
    {
       return ((int)TryToFindZombiInCatalogById(name).VirtualCurrencyPrices["CO"]);
    }
    public static CatalogItem TryToFindZombiInCatalogById(string characterId)
    {
        Debug.Log("TryToFindZombiInCatalogById - " + characterId);
        foreach (CatalogItem catalogItem in Catalog)
        {
            Debug.Log("catalogItemId - " + catalogItem.ItemId);
            if (characterId.Equals(catalogItem.ItemId))
            {
                return catalogItem;
            }
        }
        return null;

    }*/
    public static bool CheckAvailabilityZombieInInventory(string name)
    {
        foreach (InventoryItem userCharacter in InventoryItems) 
            if (userCharacter.name.Equals(name))
                return true;
        return false;
    }

    public static void IncrementCharacterById(string name)
    {
        if (TryToFindItemInInventoryById(name) == null)
        {
            _inventoryItems.Add(new InventoryItem(name, 1));
        }
        else {
            TryToFindItemInInventoryById(name).lvl++;
        }
    }

    internal static void SubtractCoinBalance(int amount)
    {
        _coinBalance -= amount;
    }
}
