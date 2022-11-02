using UnityEngine;

public class SpecialContainer : MonoBehaviour
{
    [SerializeField] ZombieUpgradeUI _altar;
    [SerializeField] SpecialPowerUpgradeUI _time;
    [SerializeField] SpecialPowerUpgradeUI _bomb;
    private void Start()
    {
        UpdateUI();
    }
    public void UpdateUI() {
        _altar.Init();
        _time.Init();
        _bomb.Init();
    }
}
