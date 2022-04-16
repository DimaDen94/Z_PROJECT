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
        Destroy(GetComponent<ZombieStateMachine>());
        Destroy(GetComponent<Unit>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
        _animator.SetTrigger("Death");
        StartCoroutine(StartFadeAnimationAndDelate());
    }
    private IEnumerator StartFadeAnimationAndDelate() {
        yield return new WaitForSeconds(2);
        transform.DOMoveY(-2, 3);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void Update()
    {
        //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) { _animator.SetTrigger("Idle");}
    }

}
