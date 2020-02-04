using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;
    public string entityName = "Unkown";

    public float moveSpeed = 5;

    public float experience = 0;
    public float experienceToNextLevel = 300;
    public int level = 1;

    public float armor = 5;
    public float fireResist = 5;

    public float attackDamage = 10;


    //MIGHT REMOVE LATER
    public float attackSpeed;
    public float range;
    public float bulletForce;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.range = range;
        bs.startPos = firePoint;
        bs.damage = attackDamage;
        bs.sourceEntity = gameObject.GetComponentInParent<Entity>();
        rb.AddForce(firePoint.up * bs.sourceEntity.bulletForce, ForceMode2D.Impulse);
    }


    public bool WillKill(float damage)
    {
        if(currentHP - damage <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
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

    public void GainExperience(float exp)
    {
        experience += exp;
        if(experience >= experienceToNextLevel)
        {
            experience = experience - experienceToNextLevel;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        experienceToNextLevel *= 2;
    }
}
