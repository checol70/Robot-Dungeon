using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour
{
    GunScript firedFrom;
    float expirationTime;
    protected float cycle;
    protected bool homing;
    protected float speed;

    private void Awake()
    {
        SetParams();
    }

    protected abstract void SetParams();

    public void SetGunScript(GunScript g)
    {
        firedFrom = g;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        if (firedFrom != null)
        {
            firedFrom.InactivateBullet(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
        expirationTime = Time.time + cycle;
    }

    private void Update()
    {
        if (Time.time > expirationTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //do damages.
        gameObject.SetActive(false);
    }
}
