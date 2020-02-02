using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;



    Entity thisEntity;
    float nextShoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Physics.IgnoreLayerCollision(8, 8);
       // Physics2D.IgnoreLayerCollision();
       thisEntity = gameObject.GetComponentInParent<Entity>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShoot)
        {
            //Debug.Log(Time.time);
            nextShoot = Time.time + (1/thisEntity.attackSpeed);
            Shoot();
        } 
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.range = thisEntity.range;
        bs.startPos = firePoint;
        bs.damage = 10f;
        bs.damageType = "Fire";
        bs.sourceEntity = gameObject.GetComponentInParent<Entity>();
        rb.AddForce(firePoint.up * thisEntity.bulletForce, ForceMode2D.Impulse);
    }
}
