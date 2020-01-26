using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    Entity entity;
    // Start is called before the first frame update
    void Start()
    {
        entity = gameObject.GetComponentInParent<Entity>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recieveDamage(float damage)
    {
        //Debug.Log("Deal damage");
        entity.currentHP -= damage;
        if(entity.currentHP <= 0)
        {
            Debug.Log("Destorying ");
            Destroy(gameObject);
        }
    }
}
