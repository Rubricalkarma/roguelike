using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;
    public float range = 5f;
    public float shootSpeed = .1f;

    float nextShoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShoot)
        {
            Debug.Log(Time.time);
            nextShoot = Time.time + shootSpeed;
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.range = range;
        bs.startPos = firePoint;
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
