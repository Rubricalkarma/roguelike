using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform firePointPivot;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Entity target;

    // Start is called before the first frame update

    Rigidbody2D rb;

    void Start()
    {
        //StartCoroutine(shootBegin());
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 lookDir = (Vector2)target.transform.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            firePointPivot.rotation = Quaternion.Euler(0f, 0f, angle);

            //rb.MovePosition(transform.position + target.transform.position * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.position, target.transform.position) > 1)
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, gameObject.GetComponentInParent<Entity>().moveSpeed * Time.deltaTime);
            //Vector2 dir = target.transform.position.normalized;
            //rb.velocity = dir * 5;
        }

    }

    void Shoot()
    {
        gameObject.GetComponentInParent<Entity>().Shoot();
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
