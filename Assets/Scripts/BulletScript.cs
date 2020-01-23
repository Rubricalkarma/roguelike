using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float range;
    public Transform startPos;

 void OnCollisionEnter2D(Collision2D collision)
    {
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
