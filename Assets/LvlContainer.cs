using TMPro;
using UnityEngine;

public class LvlContainer : MonoBehaviour
{
    public void UpdateLvlText(int lvl) {
        GetComponentInChildren<TextMeshProUGUI>().text = lvl.ToString();
    }
}
