using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabManager
{
    private const string CURRENCY_CODE = "CO";
    private const string CatalogKey = "Units";
    private const string CharactersKey = "Characters";
    private const string ProgressKey = "Progress";

    public static void Login(Action<LoginResult> OnLoginSuccess)
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
    public static void AddVirtualCurrency(int amount, Action<ModifyUserVirtualCurrencyResult> success) {
        var request = new AddUserVirtualCurrencyRequest()
        {
           Amount = amount,
           VirtualCurrency = CURRENCY_CODE
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, success, OnPlayfabError);

    }

    public static void GetUserData(Action<List<UserCharacter>, List<ProgressStage>> userData)
    {
        var request = new GetUserDataRequest()
        { Keys = new List<string>() { CharactersKey, ProgressKey } };

        PlayFabClientAPI.GetUserData(request,
            result =>
            {
                if (result.Data == null || !result.Data.ContainsKey(ProgressKey) || !result.Data.ContainsKey(CharactersKey))
                {
                    Debug.Log("No Characters");
                    SaveUserStartParams(InitDefaultCharacters(), InitDefaultProgress(), userData);
                }
                else
                {
                    string CharactersValue = result.Data[CharactersKey].Value;
                    string ProgressValue = result.Data[ProgressKey].Value;
                    userData.Invoke(JsonUtil.DeserializeObject<List<UserCharacter>>(CharactersValue), JsonUtil.DeserializeObject<List<ProgressStage>>(ProgressValue));
                }
            }, OnPlayfabError);
    }

    public static void TryToBuyCharacter(string characterId, int amount, Action success, Action error)
    {
        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "AddCharacter",
            FunctionParameter = new
            {
                characterId = characterId,
                amount = amount
            },
            GeneratePlayStreamEvent = true
        };
        PlayFabClientAPI.ExecuteCloudScript(request, result =>
        {
            Debug.Log(result.ToJson().ToString());

            List<UserCharacter> characters = JsonUtil.DeserializeObject<List<UserCharacter>>(result.FunctionResult.ToString());
            DataService.UserCharacters = characters;
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
    }

    public static void TryToUpgradeCharacter(UserCharacter userCharacter,int amount, Action success, Action error)
    {
        IncrementCharacterLvl (userCharacter.name, amount, list => { success.Invoke(); }, error);
    }
    private static void IncrementCharacterLvl(string characterId,int amount, Action<List<UserCharacter>> success, Action error)
    {
        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "IncrementCharacterLvl",
            FunctionParameter = new
            {
                characterId = characterId,
                amount = amount
            },
            GeneratePlayStreamEvent = true
        };
        PlayFabClientAPI.ExecuteCloudScript(request, result =>
        {
            Debug.Log(result.ToJson().ToString());

            List<UserCharacter> characters = JsonUtil.DeserializeObject<List<UserCharacter>>(result.FunctionResult.ToString());
            //DataService.IncrementCharacterById(_zombieSO.Name);
            DataService.UserCharacters = characters;
            DataService.SubtractCoinBalance(amount);
            if (characters != null)
                success.Invoke(characters);
            else
                error.Invoke();
        }, fabError =>
        {
            Debug.LogError(fabError.ErrorMessage);
            error.Invoke();
        });

    }
    private static void SaveUserStartParams(List<UserCharacter> characters, List<ProgressStage> progressStages, Action<List<UserCharacter>, List<ProgressStage>> userChatacters)
    {
        string charactersJson = JsonUtil.SerializeObject(characters);
        string progressJson = JsonUtil.SerializeObject(progressStages);
        Dictionary<string, string> defData = new Dictionary<string, string>();
        defData.Add(CharactersKey, charactersJson);
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
    private static List<UserCharacter> InitDefaultCharacters()
    {
        List<UserCharacter> characters = new List<UserCharacter>();
        characters.Add(new UserCharacter("Frank", 1));
        characters.Add(new UserCharacter("Sofi", 1));
        characters.Add(new UserCharacter("Bob", 1));
        characters.Add(new UserCharacter("Gary", 1));
        return characters;
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
}
