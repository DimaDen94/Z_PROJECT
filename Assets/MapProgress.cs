using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProgress : MonoBehaviour
{
    [SerializeField] private List<MapPoint> _points;


    private void Start()
    {
        ProgressStage progress = GetCurrentProgressStage();
        for (int i = 0; i < progress.Points.Count; i++) {
            _points[i].Render(progress.Points[i]);
        }
    }
    private ProgressStage GetCurrentProgressStage()
    {
        return DataService.Progress[0];
    }

}
