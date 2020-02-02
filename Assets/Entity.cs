using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;
    public string entityName;

    public float armor = 5;
    public float fireResist = 5;


    //MIGHT REMOVE LATER
    public float attackSpeed;
    public float range;
    public float bulletForce;

    public void RecieveDamage(float damage)
    {

        //Debug.Log("Deal damage");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("Destorying ");
            Destroy(gameObject);
        }
    }

    public float CalculateDamage(float baseDamage, string damageType)
    {
        float totalDamage = baseDamage;

        switch (damageType)
        {
            case "Physical": totalDamage -= armor;
                break;
            case "Fire": totalDamage -= fireResist;
                break;
            default: Debug.LogError("Unknown Damage Type:" + damageType);
                break;
        }
        
        if(totalDamage <= 0)
        {
            totalDamage = 1;
        }

        return totalDamage;
    }
}
