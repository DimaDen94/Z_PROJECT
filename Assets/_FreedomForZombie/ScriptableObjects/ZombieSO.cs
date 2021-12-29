using UnityEngine;
[CreateAssetMenu(menuName = "Zombies/New Zombie", order = 51)]
public class ZombieSO : ScriptableObject
{
    [SerializeField] private Zombie _prefab;
    [SerializeField] private Sprite _preview;
    [SerializeField] private string _name;
    [SerializeField] private string _descripription;
    [SerializeField] private int _defaultManaCost;
    [SerializeField] private int _defaultManyCost;
    [SerializeField] private int _defaultDamage;
    [SerializeField] private int _defaultHealth;

    public Zombie Prefab => _prefab;
    public Sprite Preview => _preview;
    public string Name => _name;
    public string Descripription => _descripription;
    public int DefaultManaCost => _defaultManaCost; 
    public int DefaultManyCost => _defaultManyCost; 
    public int DefaultDamage => _defaultDamage; 
    public int DefaultHealth => _defaultHealth;

}
