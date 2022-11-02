using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlayMarket : MonoBehaviour
{
    public void OpenMarket() {
        //Application.OpenURL("market://details?id=" + Application.productName);
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.life_is_game.zombie");
    }
}
