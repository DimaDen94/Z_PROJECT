using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class DeathState : State
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Unit>().Animator;
        if (GetComponent<Altar>() == null)
        {
            Destroy(GetComponent<ZombieStateMachine>());
            Destroy(GetComponent<Unit>());
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
            _animator.SetTrigger("Death");
        }
        StartCoroutine(StartFadeAnimationAndDelate());
    }
    private IEnumerator StartFadeAnimationAndDelate() {
        yield return new WaitForSeconds(2);
        transform.DOMoveY(-2, 2);
        yield return new WaitForSeconds(2);
        if(GetComponent<Altar>() == null)
            Destroy(gameObject);
    }
   
    private void Update()
    {
        //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) { _animator.SetTrigger("Idle");}
    }

}
