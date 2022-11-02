using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseDialogButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseDialog);
    }
    private void CloseDialog()
    {
        Time.timeScale = 1;
        _animator.Play("MoveToTop");

    }
}
