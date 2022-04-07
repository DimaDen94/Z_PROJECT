using System.Collections.Generic;

public class DataService 
{
    private static int _coinBalance;
    private static List<UserCharacter> _userCharacters;
    private static List<ProgressStage> _progress;

    public static int CoinBalance { get => _coinBalance; set => _coinBalance = value; }
    public static List<UserCharacter> UserCharacters { get => _userCharacters; set => _userCharacters = value; }
    public static List<ProgressStage> Progress { get => _progress; set => _progress = value; }
    public static int LastClickedPoint { get;  set; }

    public static UserCharacter TryToFindZombiInInventoryById(string name)
    {
        foreach (UserCharacter userCharacter in UserCharacters) 
            if (name.Equals(userCharacter.name))
                return userCharacter;
        return null;
        
    }
    public static bool TryToSaveProgress(int stars) {
        if (_progress[0].Points.Count == LastClickedPoint)
        {
            _progress[0].Points[LastClickedPoint - 1].isComplited = true;
            _progress[0].Points[LastClickedPoint - 1].stars = stars;
            ProgressPoint point = new ProgressPoint();
            point.position = LastClickedPoint;
            point.isComplited = false;
            point.stars = 0;
            _progress[0].Points.Add(point);
            return true;
        }
        else if (_progress[0].Points.Count > LastClickedPoint && _progress[0].Points[LastClickedPoint].stars < stars) {
            _progress[0].Points[LastClickedPoint - 1].stars = stars;
            return true;
        }
        return false;
    }
}
