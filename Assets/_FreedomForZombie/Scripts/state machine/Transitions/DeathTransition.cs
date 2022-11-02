using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTransition : Transition
{
    // Start is called before the first frame update
    public void OnUnitDied() {
        NeedTransit = true;
    }
}
