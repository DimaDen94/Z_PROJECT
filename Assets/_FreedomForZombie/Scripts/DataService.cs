using System;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;

public class DataService 
{
    private static int _coinBalance;
    private static List<UserCharacter> _userCharacters;
    private static List<ProgressStage> _progress;

    public static int CoinBalance { get => _coinBalance; set => _coinBalance = value; }
    public static List<UserCharacter> UserCharacters { get => _userCharacters; set => _userCharacters = value; }
    public static List<ProgressStage> Progress { get => _progress; set => _progress = value; }
    public static int LastClickedPoint { get;  set; }
    public static List<CatalogItem> Catalog { get; set; }

    public static UserCharacter TryToFindZombiInInventoryById(string characterId)
    {
        foreach (UserCharacter userCharacter in UserCharacters) 
            if (characterId.Equals(userCharacter.name))
                return userCharacter;
        return UserCharacters[0];
        
    }

    public static int GetUnitLvlById(string name)
    {
        return TryToFindZombiInInventoryById(name).lvl;
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
        else if (_progress[0].Points.Count > LastClickedPoint && _progress[0].Points[LastClickedPoint].stars < stars) {
            _progress[0].Points[LastClickedPoint - 1].stars = stars;
            return true;
        }
        return false;
    }

    public static int GetPriceForCharacterById(string name)
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

    }
    public static bool CheckAvailabilityZombieInInventory(string name)
    {
        foreach (UserCharacter userCharacter in UserCharacters) 
            if (userCharacter.name.Equals(name))
                return true;
        return false;
    }

    public static void IncrementCharacterById(string name)
    {
        if (TryToFindZombiInInventoryById(name) == null)
        {
            _userCharacters.Add(new UserCharacter(name, 1));
        }
        else {
            TryToFindZombiInInventoryById(name).lvl++;
        }
    }

    internal static void SubtractCoinBalance(int amount)
    {
        _coinBalance -= amount;
    }
}
