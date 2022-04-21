using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverToCurrentPoint : MonoBehaviour
{
    [SerializeField] private MapProgress _mapProgress;
    [SerializeField] private ScrollMapContainer _scrollMapContainer;

    public void SetCurrentPosition()
    {
        int currentPointId = DataService.Progress[0].Points.Count - 1;
        float xPosition = _mapProgress.Points[currentPointId].transform.position.x;
        if (xPosition > 0)
            _scrollMapContainer.Move(-xPosition);

    }
}
