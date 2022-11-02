using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerRecoverySpell : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private SpecialPowerSO _power;
    [SerializeField] private Mana _powerManager;

    public UnityEvent<int, int> CountdownChange;


    private int _cooldown;
    private float _countdown;
    private bool _canUse = true;
    private void Start()
    {
        _cooldown = _power.GetCooldownByLvl();
    }

    private void Update()
    {
        if (_canUse)
            return;

        _countdown -= Time.deltaTime;
        CountdownChange.Invoke((int)_countdown, _cooldown);
        if (_countdown <= 0)
        {
            _canUse = true;
            _btn.interactable = true;
        }
    }

    public void UseSpell()
    {
        if (_canUse)
        {
            _canUse = false;
            _countdown = _cooldown;
            _btn.interactable = false;
            _powerManager.RestoreFullPower();
        }
    }
}
