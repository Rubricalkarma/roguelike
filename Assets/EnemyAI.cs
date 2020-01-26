using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootBegin());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Shoot()
    {
        //Debug.Log("Shooting");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.range = 10;
        bs.startPos = firePoint;
        bs.damage = 10f;
        bs.sourceEntity = gameObject.GetComponentInParent<Entity>();
        rb.AddForce(firePoint.up * 20, ForceMode2D.Impulse);
    }

    public IEnumerator shootBegin()
    {
        while (true)
        {
            //Debug.Log("Coroutine");
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }
}
