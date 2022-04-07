using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsUtil {
    private static string UnitSequenceKey = "UnitSequence";

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
    private static List<string> GenerateDefaultUnitSequence() {
        List<string> unitSequence = new List<string>();
        unitSequence.Add("Frank");
        unitSequence.Add("Sofi");
        unitSequence.Add("Bob");
        unitSequence.Add("Gary");
        return unitSequence;
    }
}
