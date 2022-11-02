using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class CloseTutorial : MonoBehaviour
{
    private Button _btn;
    [SerializeField] private GameObject _dialog;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(ComplateTutorial);
    }

    private void ComplateTutorial()
    {
        PlayerPrefsUtil.GameTutorialComplete();
        _dialog.SetActive(false);
        Time.timeScale = 1;
    }
}
