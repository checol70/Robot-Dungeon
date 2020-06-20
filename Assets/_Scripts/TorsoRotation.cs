using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoRotation: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.root.gameObject.GetComponent<PlayerScript>().torsoRotation=transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
