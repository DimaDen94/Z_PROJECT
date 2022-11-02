using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpecialPowerUpgradeUI : MonoBehaviour
{
    [SerializeField] private Image _preview;
    [SerializeField] private SpecialPowerSO _specialPowerSO;
    [SerializeField] private GameObject _lvlContainer;
    [SerializeField] private Text _lvlNumber;
    [SerializeField] private Color _disableColor;

    private int _zombieLvl;
    private Button _button;
    public SpecialPowerSO ZombieSO => _specialPowerSO;
    public UnityEvent<SpecialPowerSO> OnChooseZombie;
    private bool _isContainsInInventory = false;
    public bool IsContainsInInventory => _isContainsInInventory;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => {
            OnChooseZombie.Invoke(_specialPowerSO);
            Debug.Log("Click");
        });

    }

    public void Init()
    {
        _preview.sprite = _specialPowerSO.Preview;
        if (DataService.TryToFindItemInInventoryById(_specialPowerSO.Name) != null)
        {
            _isContainsInInventory = true;
            _zombieLvl = DataService.TryToFindItemInInventoryById(_specialPowerSO.Name).lvl;
        }
        if (!_isContainsInInventory)
        {
            _preview.color = _disableColor;
        }
        else if (_lvlContainer != null)
        {
            _preview.color = Color.white;
            _lvlContainer.SetActive(true);
            _lvlNumber.text = _zombieLvl.ToString();
        }
    }
}