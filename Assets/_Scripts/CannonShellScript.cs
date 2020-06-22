using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShellScript : ProjectileScript
{
    protected override void SetParams()
    {
        cycle = 10;
        homing = false;
        speed = 10;
    }
}
