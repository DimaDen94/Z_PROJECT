using UnityEngine;
[CreateAssetMenu(menuName = "Wave/LvlWaves", order = 51)]
public class LvlWaves : ScriptableObject
{
    [SerializeField] private EnemyAltarModelSO _altarModel;
    [SerializeField] private Wave[] _wawes;

    public Wave[] Wawes => _wawes;

    public EnemyAltarModelSO AltarModel => _altarModel;
}
