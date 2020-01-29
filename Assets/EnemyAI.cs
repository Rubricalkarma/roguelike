using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform firePointPivot;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;

    public Entity target;

    // Start is called before the first frame update

    Rigidbody2D rb;

    void Start()
    {
        StartCoroutine(shootBegin());
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 lookDir = (Vector2)target.transform.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePointPivot.rotation = Quaternion.Euler(0f, 0f, angle);
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
        rb.AddForce(firePoint.up * bs.sourceEntity.bulletForce, ForceMode2D.Impulse);
    }

    public IEnumerator shootBegin()
    {
        while (true)
        {
            Debug.Log("Coroutine");
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }
}
