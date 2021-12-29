using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAltarDieTransition : Transition
{
    private void Update()
    {
        if (TargetAltar == null)
        {
            NeedTransit = true;
        }
    }
}
