using UnityEngine;
using UnityEngine.Events;

public class ExitChecker : MonoBehaviour
{
    public UnityAction<Zombie> CollisionExit;
    private void OnTriggerExit(Collider other)
    {
        Zombie target;
        other.gameObject.TryGetComponent<Zombie>(out target);
        if (target != null)
        {
            CollisionExit?.Invoke(target);
            Debug.Log(target.gameObject.name);
        }
    }

}