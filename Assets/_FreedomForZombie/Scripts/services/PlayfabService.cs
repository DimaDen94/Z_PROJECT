using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabService
{
    private const string CURRENCY_CODE = "CO";
    private const string CatalogKey = "Units";
    private const string InventoryKey = "Inventory";
    private const string ProgressKey = "Progress";
    private const string PowersKey = "Powers";

    /*public static void Login(Action<LoginResult> OnLoginSuccess)
    {
        var request = new LoginWithCustomIDRequest { CustomId = PlayFabSettings.DeviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnPlayfabError);
    }

   public static void GetCurrencyBalance(Action<int> balance)
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), resultCallback =>
        {
            balance.Invoke(resultCallback.VirtualCurrency[CURRENCY_CODE]);
        }, OnPlayfabError);
    }

    public static void LoadInventory(Action<GetUserInventoryResult> success)
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), success, OnPlayfabError);
    }
    public static void LoadUnitsCatalog(Action<GetCatalogItemsResult> success)
    {
        var request = new GetCatalogItemsRequest()
        {
            CatalogVersion = CatalogKey
        };
        PlayFabClientAPI.GetCatalogItems(request, success, OnPlayfabError);
    }
    /*public static void AddVirtualCurrency(int amount, Action<ModifyUserVirtualCurrencyResult> success)
    {
        var request = new AddUserVirtualCurrencyRequest()
        {
            Amount = amount,
            VirtualCurrency = CURRENCY_CODE
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, success, OnPlayfabError);

    }*/

    /*public static void GetUserData(Action<List<InventoryItem>, List<ProgressStage>> userData)
    {
        var request = new GetUserDataRequest()
        { Keys = new List<string>() { InventoryKey, ProgressKey } };

        PlayFabClientAPI.GetUserData(request,
            result =>
            {
                if (result.Data == null || !result.Data.ContainsKey(ProgressKey) || !result.Data.ContainsKey(InventoryKey))
                {
                    Debug.Log("No Inventory");
                    SaveUserStartParams(InitDefaultInventory(), InitDefaultProgress(), userData);
                }
                else
                {
                    string CharactersValue = result.Data[InventoryKey].Value;
                    string ProgressValue = result.Data[ProgressKey].Value;
                    userData.Invoke(JsonUtil.DeserializeObject<List<InventoryItem>>(CharactersValue), JsonUtil.DeserializeObject<List<ProgressStage>>(ProgressValue));
                }
            }, OnPlayfabError);
    }*/

    /*public static void TryToBuyCharacter(string itemId, int amount, Action success, Action error)
    {
        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "AddItem",
            FunctionParameter = new
            {
                itemId = itemId,
                amount = amount
            },
            GeneratePlayStreamEvent = true
        };
        if (DataService.CoinBalance >= amount)
            PlayFabClientAPI.ExecuteCloudScript(request, result =>
            {
                Debug.Log(result.ToJson().ToString());

                List<InventoryItem> characters = JsonUtil.DeserializeObject<List<InventoryItem>>(result.FunctionResult.ToString());
                DataService.InventoryItems = characters;
                DataService.SubtractCoinBalance(amount);

                if (characters != null)
                    success.Invoke();
                else
                    error.Invoke();
            }, fabError =>
            {
                Debug.LogError(fabError.ErrorMessage);
                error.Invoke();
            });
        else
            error.Invoke();
    }*/
    /*
    public static void TryToInventory(InventoryItem inventoryItem, int amount, Action success, Action error)
    {
        if(amount > 0)
            IncrementInventoryItemLvl(inventoryItem.name, amount, list => { success.Invoke(); }, error);
    }
    private static void IncrementInventoryItemLvl(string itemId, int amount, Action<List<InventoryItem>> success, Action error)
    {
        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "IncrementItemLvl",
            FunctionParameter = new
            {
                itemId = itemId,
                amount = amount
            },
            GeneratePlayStreamEvent = true
        };
        if (DataService.CoinBalance >= amount)
            PlayFabClientAPI.ExecuteCloudScript(request, result =>
            {
                Debug.Log(result.ToJson().ToString());

                List<InventoryItem> inventory = JsonUtil.DeserializeObject<List<InventoryItem>>(result.FunctionResult.ToString());
                    //DataService.IncrementCharacterById(_zombieSO.Name);
                    DataService.InventoryItems = inventory;
                DataService.SubtractCoinBalance(amount);
                if (inventory != null)
                    success.Invoke(inventory);
                else
                    error.Invoke();
            }, fabError =>
        {
            Debug.LogError(fabError.ErrorMessage);
            error.Invoke();
        });
        else
            error.Invoke();

    }
    
    private static void SaveUserStartParams(List<InventoryItem> characters, List<ProgressStage> progressStages, Action<List<InventoryItem>, List<ProgressStage>> userChatacters)
    {
        string inventoryJson = JsonUtil.SerializeObject(characters);
        string progressJson = JsonUtil.SerializeObject(progressStages);
        Dictionary<string, string> defData = new Dictionary<string, string>();
        defData.Add(InventoryKey, inventoryJson);
        defData.Add(ProgressKey, progressJson);

        var request = new UpdateUserDataRequest() { Permission = UserDataPermission.Private, Data = defData };

        PlayFabClientAPI.UpdateUserData(request,
            result =>
            {
                userChatacters.Invoke(characters, progressStages);
            }, OnPlayfabError);
    }
    public static void SaveUserProgress(List<ProgressStage> progressStages, Action success, Action error)
    {
        string progressJson = JsonUtil.SerializeObject(progressStages);
        Dictionary<string, string> newData = new Dictionary<string, string>();
        newData.Add(ProgressKey, progressJson);

        var request = new UpdateUserDataRequest() { Permission = UserDataPermission.Private, Data = newData };

        PlayFabClientAPI.UpdateUserData(request,
            result =>
            {
                success.Invoke();
            }, errorData =>
            {
                OnPlayfabError(errorData);
                error.Invoke();
            });
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
    private static void OnPlayfabError(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    */
}
