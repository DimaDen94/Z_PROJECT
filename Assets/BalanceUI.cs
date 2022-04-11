using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }
    public void UpdateUI() {
        GetComponent<Text>().text = DataService.CoinBalance.ToString();
    }
}
