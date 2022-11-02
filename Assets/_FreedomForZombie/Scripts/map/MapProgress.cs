using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapProgress : MonoBehaviour
{
    [SerializeField] private List<MapPoint> _points;
    [SerializeField] private UISoundManager _soundManager;
    public List<MapPoint> Points => _points;
    public UnityEvent LvlClick;
    private void OnEnable()
    {
        ProgressStage progress = GetCurrentProgressStage();
        for (int i = 0; i < progress.Points.Count; i++)
        {
            if (i < _points.Count)
            {
                _points[i].Render(progress.Points[i]);
                _points[i].ChoosePoint += PlaySound;
                _points[i].ChoosePoint += ClickLvl;
            }
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _points[i].ChoosePoint -= PlaySound;
            _points[i].ChoosePoint -= ClickLvl;
        }
    }

    private void PlaySound() {
        _soundManager.PlaySound(SoundType.ClickPoint);
    }
    private void ClickLvl() {
        LvlClick?.Invoke();
    }
  
    private ProgressStage GetCurrentProgressStage()
    {
        return DataService.Progress[0];
    }

}
