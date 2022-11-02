using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTutorialStarter : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialDialog;
    void Start()
    {
        if (!PlayerPrefsUtil.IsGameTutorialComplete()) {
            _tutorialDialog.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
}
