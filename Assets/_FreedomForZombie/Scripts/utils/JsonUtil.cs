using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class JsonUtil : MonoBehaviour
{
    // Start is called before the first frame update
    public static Model DeserializeObject<Model>(string jsonArray)
    {
        Model list = JsonConvert.DeserializeObject<Model>(jsonArray);

        return list;
    }

    public static string SerializeObject(object objec)
    {
        string unParse = JsonConvert.SerializeObject(objec);
        Debug.Log("" + unParse);
        return unParse;
    }
}
