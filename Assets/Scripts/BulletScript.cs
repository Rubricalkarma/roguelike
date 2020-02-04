using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletScript : MonoBehaviour
{

    public float range;
    public Transform startPos;
    public float damage;
    public string damageType;
    public GameObject textPrefab;
    public Entity sourceEntity;
    public bool registered = false;

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
        //CHECKS IF HITTING FRIENDLY
        if (collision.gameObject.tag.CompareTo(sourceEntity.gameObject.tag) == 0)
        {

        }
        //CHECKS IF HITTING ANYTHING BUT SELF
        else if (!GameObject.ReferenceEquals(collision.gameObject, sourceEntity.gameObject))
        {
            //CHECKS IF HIT WAS AN ENTITY
            if (collision.gameObject.GetComponent<Entity>() != null)
            {
                //CHECKS IF BULLET HASN'T COLLIDED WITH ANYTHING
                if (!registered)
                {
                    registered = true;
                    // Debug.Log("Hit Enemy");
                    Entity entityScript = collision.gameObject.GetComponent<Entity>();
                    float calculatedDamage = entityScript.CalculateDamage(damage, damageType);

                    if (entityScript.WillKill(calculatedDamage))
                    {
                        Debug.Log("Gain Exp");
                        entityScript.Die();
                        sourceEntity.GainExperience(200f);
                    }
                    else
                    {
                        entityScript.TakeDamage(calculatedDamage);
                    }



                    GameObject text = Instantiate(textPrefab, transform.position, Quaternion.identity);
                    FloatingTextScript textScript = text.GetComponent<FloatingTextScript>();
                    textScript.SetText("" + calculatedDamage);
                    textScript.SetColor(GetColor(damageType));
                    textScript.StartFloatText();
                }

                Destroy(gameObject);
            }
        }
    }

    Color GetColor(string damageType)
    {
        switch (damageType)
        {
            case "Physical": return Color.red;

            case "Fire": return new Color(1f, .4f, 0, 1f);

            default: Debug.LogError("Unknown damageType:" + damageType); return Color.white;
               
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
                Destroy(gameObject);
            }
        }
    }
}
