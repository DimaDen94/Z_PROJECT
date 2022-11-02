using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    [SerializeField] private Image _front;

    public void SetFrontBlock(int current, int max ) {
        float fullness = (float)current / max;
        _front.fillAmount = fullness;
     }
}
