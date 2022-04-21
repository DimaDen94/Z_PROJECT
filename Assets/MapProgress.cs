using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProgress : MonoBehaviour
{
    [SerializeField] private List<MapPoint> _points;
    [SerializeField] private UISoundManager _soundManager;
    public List<MapPoint> Points => _points;

    private void OnEnable()
    {
        ProgressStage progress = GetCurrentProgressStage();
        for (int i = 0; i < progress.Points.Count; i++)
        {
            _points[i].Render(progress.Points[i]);
            _points[i].ChoosePoint += PlaySound;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _points[i].ChoosePoint -= PlaySound;
        }
    }

    private void PlaySound() {
        _soundManager.PlaySound(SoundType.ClickPoint);
    }
    private void Start()
    {
       
    }
    private ProgressStage GetCurrentProgressStage()
    {
        return DataService.Progress[0];
    }

}
