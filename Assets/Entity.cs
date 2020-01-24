using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;

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
