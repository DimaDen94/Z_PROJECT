using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAltarDieTransition : Transition
{
    public void StartCelebration() {
        NeedTransit = true;
    }
    private void Update()
    {
        if (TargetAltar == null)
        {
            NeedTransit = true;
        }
    }
}
