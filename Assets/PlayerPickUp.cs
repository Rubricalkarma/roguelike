using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponentInParent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.tag.CompareTo("Coin") == 0)
        {
            Debug.Log("Touch Coin");
            playerStats.shootSpeed *= 2;
            Destroy(collision.gameObject);
        }
    }
}
