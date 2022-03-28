using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseDialogButton : MonoBehaviour
{
    [SerializeField] private GameObject _dialog;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseDialog);
    }
    private void CloseDialog()
    {
        _dialog.SetActive(false);

    }
}
