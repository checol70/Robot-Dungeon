using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    protected int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<HealthScript>().SetMaxHealth(maxHealth);
        gameObject.tag = "Enemy";
        foreach(Transform t in transform)
        {
            t.gameObject.tag = "Enemy";
        }
    }
}
