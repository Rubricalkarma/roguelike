using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float range;
    public Transform startPos;
    public float damage;

 void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            Debug.Log("Hit Enemy");
            // Debug.Log(collision.gameObject.GetComponent<EnemyStats>().currentHP);
            collision.gameObject.GetComponent<Entity>().recieveDamage(damage);
        }
        Destroy(gameObject);
        
    }

    void Update()
    {
        if(Vector2.Distance(startPos.position,transform.position) > range)
        {
            //Debug.Log("Destoryed from distance");
            Destroy(gameObject);
        }
    }
}
