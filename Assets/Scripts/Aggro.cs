using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{
    public GameObject e;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag.CompareTo("Player") == 0)
        {
            Debug.Log("Player entered aggro");
            e.GetComponent<EnemyAI>().target = other.GetComponent<Entity>();
        }
    }
}
