using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private void OnEnable()
    {
        _animator = GetComponent<Unit>().Animator;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator.SetTrigger("Walk");
    }
    private void Update()
    {
        if (Target == null)
            Target = GetComponent<StateMachine>().TargetEnemy;
        if (Target == null) {
            GetComponent<StateMachine>().ResetTarget();
            Target = GetComponent<StateMachine>().TargetEnemy;
        }

        if (Target != null)
        {
            _navMeshAgent.SetDestination(Target.gameObject.transform.position);
//            Debug.Log(Target.gameObject.transform.position);
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                _animator.SetTrigger("Walk");
            }

            Debug.DrawLine(transform.position, Target.transform.position, Color.red);


            //FaceTarget(Target.transform.position, Time.deltaTime * 10);

        }


    }
    private void FaceTarget(Vector3 destination, float speed)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
    [System.Obsolete]
    private void OnDisable()
    {
    }


}
