using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : Zombie
{
   public int GetStars()
    {
        if (_maxHealth == _health)
            return 3;
        else if (_maxHealth / 2 < _health)
            return 2;
        else
            return 1;

    }
}
