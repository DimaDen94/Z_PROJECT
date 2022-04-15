using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDeactivator : MonoBehaviour
{
    private void OnEnable()
    {
        MapService.MapIsActive = false;
    }
    private void OnDisable()
    {
        MapService.MapIsActive = true;

    }
}
