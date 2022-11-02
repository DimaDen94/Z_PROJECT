using UnityEngine;
using UnityEngine.UI;

public class CoinsHandller : MonoBehaviour
{
    [SerializeField] private Text _earnedCoinsView;
    private int _earnedCoins = 0;

    public int EarnedCoins => _earnedCoins;

    public void IncreaseCoins(Enemy enemy) {
        _earnedCoins += enemy.DeathCost;
        _earnedCoinsView.text = _earnedCoins.ToString();
    }
}
