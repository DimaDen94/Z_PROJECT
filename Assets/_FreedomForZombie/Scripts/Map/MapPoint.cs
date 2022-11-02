using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _pointNumber;
    [SerializeField] private TextMeshPro _pointNumberText;
    [SerializeField] private StarContainer _starsContainer;
    [SerializeField] private SpriteRenderer _pointImage;
    [SerializeField] private Sprite _activeSparite;
    public UnityAction ChoosePoint;
    private bool isActive = false;
    private void Start()
    {
        _pointNumberText.text = _pointNumber.ToString();
    }

    public void Render(ProgressPoint progressPoint)
    {
        SetActivePoint();
        _starsContainer.RenderStar(progressPoint.stars);
    }
    private void SetActivePoint() {
        isActive = true;
        _pointImage.sprite = _activeSparite;
    }
    private void OnMouseUpAsButton()
    {
        

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!MapService.MapIsActive)
            return;
        if (isActive)
        {
            ChoosePoint?.Invoke();
            DataService.LastClickedPoint = _pointNumber;
            SceneManager.LoadScene(Scenes.MainGameScene.ToString());
        }
    }
}
