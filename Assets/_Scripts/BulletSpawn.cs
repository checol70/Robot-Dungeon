using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.gameObject.GetComponent<GunScript>().spawnPoint = transform;
    }

}
