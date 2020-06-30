using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHookScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.player.GetComponent<PlayerScript>().AddWeaponHook(transform);
    }

}
