using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler,IPointerClickHandler
{
    [SerializeField] private Transform _dragContainer;
    [SerializeField] private Transform _parant;
    [SerializeField] private ZombieUpgradeUI _zombieUpgradeUI;
    [SerializeField] private UISoundManager _soundManager;
   

    private Vector3 _startPosition;
    private RectTransform _transform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    public static ZombieSO _currentZombie;
    void Start()
    {
        _startPosition = transform.localPosition;
        _transform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_zombieUpgradeUI.IsContainsInInventory)
        {
            _soundManager.PlaySound(SoundType.StartDragItem);
            _canvasGroup.blocksRaycasts = false;
            _transform.parent = _dragContainer;
            _currentZombie = _zombieUpgradeUI.ZombieSO;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_zombieUpgradeUI.IsContainsInInventory)
            _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_zombieUpgradeUI.IsContainsInInventory)
        {
            _soundManager.PlaySound(SoundType.EndDragItem);
            _canvasGroup.blocksRaycasts = true;
            _transform.parent = _parant;
            _transform.localPosition = _startPosition;
            _currentZombie = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _soundManager.PlaySound(SoundType.SelectItem);
        GetComponentInParent<Button>().onClick.Invoke();
    }
}
