using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.player.GetComponent<PlayerScript>().cam = gameObject.GetComponent<Camera>();
        offset = transform.position - PlayerScript.player.transform.position;
    }
    private void Update()
    {
        gameObject.transform.position = PlayerScript.player.transform.position + offset;
    }
}
