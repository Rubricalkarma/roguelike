using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;



    PlayerStats playerStats;
    float nextShoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponentInParent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShoot)
        {
            //Debug.Log(Time.time);
            nextShoot = Time.time + (1/playerStats.shootSpeed);
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.range = playerStats.range;
        bs.startPos = firePoint;
        bs.damage = 10f;
        rb.AddForce(firePoint.up * playerStats.bulletForce, ForceMode2D.Impulse);
    }
}
