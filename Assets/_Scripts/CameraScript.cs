using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.gameObject.GetComponent<PlayerScript>().cam = gameObject.GetComponent<Camera>();
    }

}
