using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazorScript : ProjectileScript
{
    protected override void SetParams()
    {
        cycle = 5;
        homing = false;
        speed = 50;
    }
}
