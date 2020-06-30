using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovementScript
{
    public static Vector3 GetInputDir(float x, float z)
    {
        Vector3 dir = new Vector3(x, 0, z);


        //for some reason Unity's normalized don't total 1 all the time. since we are multiplying this we want the total to equal 1.

        if (Mathf.Abs(dir.x) + Mathf.Abs(dir.z) > 1)
        {
            float divider = Mathf.Abs(dir.x) + Mathf.Abs(dir.z);

            float finalX = dir.x / divider;

            float finalZ = dir.z / divider;

            dir = new Vector3(finalX, 0, finalZ);
        }

        return dir;
    }
    
}
