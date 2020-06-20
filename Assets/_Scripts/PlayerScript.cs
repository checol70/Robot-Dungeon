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
    GameObject existingTarget;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //setting up so that if we attack a target it doesn't stop attacking if we move the mouse off.
        if (Input.GetMouseButtonUp(0))
        {
            existingTarget = null;
        }
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

            // we will be comparing tags to decide what we are doing.
            string tag = rh.collider.gameObject.tag;

            if (existingTarget == null)
            {
                switch (tag)
                {
                    //first if it is ground we move towards it.
                    case "Ground":
                        HandleMovement(rh.point);
                        break;
                    // if it is an enemy then we want to either move close enough to attack, or attack it.
                    case "Enemy":
                        HandleEnemyChosen(rh.collider.gameObject);
                        existingTarget = rh.collider.gameObject;
                        break;
                    //if it is loot then we want to either get close enough to pick it up, or pick it up.
                    case "Loot":
                        HandleLoot(rh.collider.gameObject);
                        existingTarget = rh.collider.gameObject;
                        break;
                    default:
                        Debug.Log($"Unhandled tag: {tag} Please change the tag to a different one or add case to handle new tag.");
                        break;
                }
            }
            else
            {
                switch (existingTarget.tag)
                {
                    case "Enemy":
                        HandleEnemyChosen(existingTarget);
                        break;
                    case "Loot":
                        HandleLoot(existingTarget);
                        break;
                    default:
                        Debug.Log("New tag added for existingTarget, Please add case for new tag on existingTarget");
                        break;

                }
            }
        }
    }

    public void HandleLoot(GameObject loot)
    {

    }

    public void HandleEnemyChosen(GameObject target)
    {
        if(Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            Attack(target);
        }
        else
        {
            HandleMovement(target.transform.position);
        }
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
