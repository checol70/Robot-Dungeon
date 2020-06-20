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
        // first getting if the left mouse button is down.
        if (Input.GetMouseButton(0))
        {
            RaycastHit rh;
            
            //then converting the mouses position to a ray to get the point that the ray hits.
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rh, 100);
            
            //changing the point to a variable we can change.
            Vector3 point = rh.point;
            
            //preventing flying.
            point.y = gameObject.transform.position.y;

            //getting the difference between where we are and where the point that was hit was.
            Vector3 dir = rh.point - gameObject.transform.position;
            
            //Adding the force (normalize converts the vector3 to have a total of 1(i.e. 100, 0 , 100 becomes .5,0,.5)
            rb.AddForce(Vector3.Normalize(dir) * accelSpeed);
            if(rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.Normalize(rb.velocity) * maxSpeed;
            }
        }
    }
}
