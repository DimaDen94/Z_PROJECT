using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEjector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.localEulerAngles.Equals(Vector3.zero))
        {
            transform.localEulerAngles = Vector3.zero;
        }
        if (!transform.localPosition.Equals(Vector3.zero))
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
