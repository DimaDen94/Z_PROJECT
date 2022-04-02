using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDescriptionPanel : MonoBehaviour
{
    [SerializeField] Image _preview;
    [SerializeField] Text _name;
    [SerializeField] Text _description;
    [SerializeField] Text _damage;
    [SerializeField] Text _health;
    [SerializeField] Text _speed;
    public void Init(ZombieSO zombieSO) {

        _preview.sprite = zombieSO.Preview;
        _name.text = zombieSO.Name;
        _description.text = zombieSO.Descripription;
        _damage.text =  zombieSO.DefaultDamage.ToString();
        _health.text = zombieSO.DefaultHealth.ToString();
        _speed.text = zombieSO.DefaultSpeed.ToString();
    }
}
