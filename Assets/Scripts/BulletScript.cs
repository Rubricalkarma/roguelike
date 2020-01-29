using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletScript : MonoBehaviour
{

    public float range;
    public Transform startPos;
    public float damage;
    public GameObject textPrefab;
    public Entity sourceEntity;

    /*
 void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.GetComponent<Entity>().entityName.CompareTo(sourceEntity.entityName) != 0)
        {
            //if (collision.gameObject.tag.CompareTo("Enemy") == 0)
            //{
                Debug.Log("Hit Enemy");
                // Debug.Log(collision.gameObject.GetComponent<EnemyStats>().currentHP);
                collision.gameObject.GetComponent<Entity>().recieveDamage(damage);

                GameObject text = Instantiate(textPrefab, transform.position, Quaternion.identity);
                text.GetComponent<FloatingTextScript>().setText("" + damage);

           // }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Poggers hit self");
        }  
        
    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.tag.CompareTo(sourceEntity.gameObject.tag) == 0)
        {
            //Debug.Log("Hit friendly");
        }
        else if (!GameObject.ReferenceEquals(collision.gameObject, sourceEntity.gameObject))
        {

            if (collision.gameObject.GetComponent<Entity>() != null)
            {
                Debug.Log("Hit Enemy");
                collision.gameObject.GetComponent<Entity>().recieveDamage(damage);
                GameObject text = Instantiate(textPrefab, transform.position, Quaternion.identity);
                text.GetComponent<FloatingTextScript>().setText("" + damage);
            }
        
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (startPos == null)
        {
            Destroy(gameObject);
        }
        else
        {
            if (Vector2.Distance(startPos.position, transform.position) > range)
            {
                //Debug.Log("Destoryed from distance");
                Destroy(gameObject);
            }
        }
    }
}
