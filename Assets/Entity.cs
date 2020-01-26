using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;
    public string entityName;


    //MIGHT REMOVE LATER
    public float attackSpeed;
    public float range;
    public float bulletForce;

    public void recieveDamage(float damage)
    {
        //Debug.Log("Deal damage");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("Destorying ");
            Destroy(gameObject);
        }
    }
}
