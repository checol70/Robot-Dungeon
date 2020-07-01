using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletExample;
    public float reloadTime;
    float nextFireTime;
    List<GameObject> bullets = new List<GameObject>();

    public void InactivateBullet(GameObject bullet)
    {
        bullets.Add(bullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.root.gameObject.GetComponent<PlayerScript>().AddGun(this);
    }

    private void OnDestroy()
    {
        transform.root.gameObject.GetComponent<PlayerScript>().RemoveGun(this);
    }

    public void Fire()
    {
        if (Time.time >= nextFireTime)
        {
            Bullet();
            nextFireTime = Time.time + reloadTime;
        }
    }

    void Bullet()
    {
        GameObject bullet;
        if(bullets.Count > 0)
        {
            bullet = bullets[0];
            bullets.Remove(bullet);
        }
        else
        {
            GameObject b = Instantiate(bulletExample, spawnPoint.position, spawnPoint.rotation);
            b.GetComponent<ProjectileScript>().SetGunScript(this);
            bullet = b;
        }
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = spawnPoint.rotation;
        bullet.SetActive(true);

    }
}
