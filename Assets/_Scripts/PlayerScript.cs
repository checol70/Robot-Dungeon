using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed;
    public float accelSpeed;
    public Camera cam;
    public int averageDamage;
    public float range;
    public Transform torsoRotation;
    List<GunScript> guns;
    public static GameObject player;
    List<GameObject> inventory;
    List<GameObject> weaponSlots;


    public void AddGun(GunScript gun)
    {
        if(guns == null)
        {
            guns = new List<GunScript>();
        }
        guns.Add(gun);
    }

    public void RemoveGun(GunScript gun)
    {
        guns.Remove(gun);
    }

    void Shoot()
    {
        foreach(GunScript g in guns)
        {
            g.Fire();
        }
    }

    private void Awake()
    {
        if(player == null)
        {
            player = gameObject;
        }
        if(gameObject!= player)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    

    private void Update()
    {
        //Handle torso rotation
        RaycastHit rh;
        Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out rh, 100);
        HandleRotation(rh.point);
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3.Normalize(dir);

        if(Mathf.Abs(dir.x) + Mathf.Abs(dir.z) > 1)
        {
            dir.x = dir.x / 2;
            dir.z = dir.z / 2;
            
            if(Mathf.Abs(dir.x) > Mathf.Abs(dir.z))
            {
                if(dir.x > 0)
                {
                    dir.x = 1 - Mathf.Abs(dir.z);
                }
                else
                {
                    dir.x = -1 + Mathf.Abs(dir.z);
                }
            }
            else
            {
                if (dir.z > 0)
                {
                    dir.z = 1 - Mathf.Abs(dir.x);
                }
                else
                {
                    dir.z = -1 + Mathf.Abs(dir.x);
                }
            }
        }

        Vector3 acceleration = dir * accelSpeed * Time.fixedDeltaTime;

        rb.AddForce(acceleration, ForceMode.VelocityChange);
    }

    public void HandleLoot(GameObject loot)
    {
        //Gotta get that sweet swag
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
        rb.AddForce(Vector3.Normalize(dir) * accelSpeed, ForceMode.VelocityChange);

        //if we exceed the max speed then this will limit us to maxSpeed.
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.Normalize(rb.velocity) * maxSpeed;
        }
    }


    //This is to handle the rotation of the torso
    public void HandleRotation(Vector3 point)
    {
        point.y = torsoRotation.position.y;
        torsoRotation.LookAt(point);

    }

}
