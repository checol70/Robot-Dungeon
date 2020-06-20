using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed;
    public float accelSpeed;
    public Camera cam;
    public int averageDamage;
    public float range;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3.Normalize(dir);

        Debug.Log(dir);
        Debug.Log(dir.normalized);
        Vector3 acceleration = dir * accelSpeed * Time.fixedDeltaTime;

        rb.AddForce(acceleration, ForceMode.VelocityChange);
    }

    public void HandleLoot(GameObject loot)
    {

    }

    void Attack(GameObject target)
    {
        target.GetComponent<HealthScript>().Damaged(averageDamage);
    }

    public void HandleMovement(Vector3 point)
    {
        //preventing flying.
        point.y = gameObject.transform.position.y;

        //getting the difference between where we are and where the point that was hit was.
        Vector3 dir = point - gameObject.transform.position;


        //Adding the force, Normalize makes the magnitude equal to one, and multiplied by the change in time over a physics frame.
        rb.AddForce(Vector3.Normalize(dir) * accelSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //if we exceed the max speed then this will limit us to maxSpeed.
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.Normalize(rb.velocity) * maxSpeed;
        }
    }
}
