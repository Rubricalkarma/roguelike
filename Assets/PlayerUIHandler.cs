using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    public Text hp;
    public GameObject player;
    public Camera cam;

    PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //hp.text = "HELLO" + stats.health;
        //hp.transform.position = cam.WorldToScreenPoint(player.transform.position);
    }
}
