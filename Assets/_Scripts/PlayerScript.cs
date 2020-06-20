using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed;
    public float accelSpeed;
    public Camera cam;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit rh;
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rh, 100);
            Vector3 dir = rh.point - gameObject.transform.position;
            rb.AddForce(dir * accelSpeed);
            if(rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.Normalize(rb.velocity) * maxSpeed;
            }
        }
    }
}
