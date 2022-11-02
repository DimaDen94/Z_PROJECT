using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllvlCompleteHandler : MonoBehaviour
{
    public UnityEvent AllvlComplete;
    private void Start()
    {
        if (PlayerPrefsUtil.GetUserProgress()[0].Points.Count == 21)
            AllvlComplete?.Invoke();
    }
}
