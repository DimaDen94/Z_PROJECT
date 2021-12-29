using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationState : State
{
    private Animator _animator;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }
    private void OnEnable()
    {
        _animator.Play("Celebration");
    }
    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
