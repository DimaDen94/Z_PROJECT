using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsUtil {
    private static string UnitSequenceKey = "UnitSequence";
    private static string GameTutorial = "GameTutorial";
    private static string CurrencyBalance = "CurrencyBalance";
    private static string Inventory = "Inventory";
    private static string Progress = "Progress";

    public static void SaveUnitSequence(List<string> unitSequence)
    {
        PlayerPrefs.SetString(UnitSequenceKey, JsonUtil.SerializeObject(unitSequence));
        PlayerPrefs.Save();
    }

    public static List<string> GetUnitSequence()
    {
        string data = PlayerPrefs.GetString(UnitSequenceKey);
        if (string.IsNullOrEmpty(data))
            return GenerateDefaultUnitSequence();
        else
            return JsonUtil.DeserializeObject<List<string>>(data);
    }

    public static void GameTutorialComplete()
    {
        PlayerPrefs.SetString(GameTutorial, "true");
        PlayerPrefs.Save();
    }

    public static bool IsGameTutorialComplete()
    {
        return PlayerPrefs.GetString(GameTutorial,"false").Equals("true");
    }

    public static void AddVirtualCurrency(int value)
    {
        PlayerPrefs.SetInt(CurrencyBalance, PlayerPrefs.GetInt(CurrencyBalance, 0) + value);
        PlayerPrefs.Save();
        DataService.CoinBalance = GetCurrencyBalance();
    }

    public static int GetCurrencyBalance()
    {
        return PlayerPrefs.GetInt(CurrencyBalance, 0);
    }

    public static List<InventoryItem> GetUserInventory() {
        return JsonUtil.DeserializeObject<List<InventoryItem>>(PlayerPrefs.GetString(Inventory, JsonUtil.SerializeObject(InitDefaultInventory())));
    }

    public static void SaveUserInventory(List<InventoryItem> items)
    {
        PlayerPrefs.SetString(Inventory, JsonUtil.SerializeObject(items));
        DataService.InventoryItems = items;
    }

    public static List<ProgressStage> GetUserProgress()
    {
        Debug.Log(PlayerPrefs.GetString(Progress, JsonUtil.SerializeObject(InitDefaultProgress())));
        return JsonUtil.DeserializeObject<List<ProgressStage>>(PlayerPrefs.GetString(Progress, JsonUtil.SerializeObject(InitDefaultProgress())));
    }

    public static void SaveUserProgress(List<ProgressStage> progress)
    {
        PlayerPrefs.SetString(Progress, JsonUtil.SerializeObject(progress));
        
    }

    public static void AddItem(string id, int amount)
    {
        AddVirtualCurrency(-amount);
        List<InventoryItem> inventory = GetUserInventory();
        inventory.Add(new InventoryItem(id, 1));
        SaveUserInventory(inventory);
    }

    public static void UpgradeItem(InventoryItem item, int amount)
    {
        AddVirtualCurrency(-amount);
        List<InventoryItem> inventory = GetUserInventory();
        foreach (InventoryItem inventoryItem in inventory) {
            if (inventoryItem.name == item.name) {
                inventoryItem.lvl += 1;
                break;
            }
        }
        SaveUserInventory(inventory);
    }

    private static List<InventoryItem> InitDefaultInventory()
    {
        List<InventoryItem> inventory = new List<InventoryItem>();
        inventory.Add(new InventoryItem("Frank", 1));
        inventory.Add(new InventoryItem("Sofi", 1));
        inventory.Add(new InventoryItem("Bob", 1));
        inventory.Add(new InventoryItem("Gary", 1));
        inventory.Add(new InventoryItem("Altar", 1));
        inventory.Add(new InventoryItem("Power Recovery", 1));
        inventory.Add(new InventoryItem("Explosion", 1));
        return inventory;
    }

    private static List<string> GenerateDefaultUnitSequence()
    {
        List<string> unitSequence = new List<string>();
        unitSequence.Add("Frank");
        unitSequence.Add("Sofi");
        unitSequence.Add("Bob");
        unitSequence.Add("Gary");
        return unitSequence;
    }

    private static List<ProgressStage> InitDefaultProgress()
    {
        List<ProgressStage> stages = new List<ProgressStage>();
        ProgressStage progress = new ProgressStage();
        List<ProgressPoint> points = new List<ProgressPoint>();
        ProgressPoint point = new ProgressPoint();
        point.stars = 0;
        point.position = 0;
        point.isComplited = false;
        points.Add(point);
        progress.Points = points;
        progress.position = 0;
        stages.Add(progress);
        return stages;
    }
}
