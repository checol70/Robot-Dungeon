using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReCenterScript
{
    public static void Center(Transform[] transforms)
    {
        foreach(Transform t in transforms)
        {
            t.localPosition = Vector3.zero;
        }
    }
}
