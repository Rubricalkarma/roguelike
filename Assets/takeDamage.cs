using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    EnemyStats es;
    // Start is called before the first frame update
    void Start()
    {
        es = gameObject.GetComponentInParent<EnemyStats>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recieveDamage(float damage)
    {
        //Debug.Log("Deal damage");
        es.currentHP -= damage;
        if(es.currentHP <= 0)
        {
            Debug.Log("Destorying ");
            Destroy(gameObject);
        }
    }
}
