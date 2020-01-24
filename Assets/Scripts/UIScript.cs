using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{

    public GameObject player;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI healthText;

    PlayerStats playerStats;
   
    // Start is called before the first frame update
    void Start()
    {
       playerStats = player.GetComponent<PlayerStats>();
        if(playerStats == null)
        {
            Debug.LogError("Couldn't find playerstats");
        }
    }

    // Update is called once per frame
    void Update()
    {
       attackSpeedText.text =  "Shoot Speed: " + playerStats.shootSpeed;
        healthText.text = "HP: " + playerStats.currentHP + "/" + playerStats.maxHP;
    }
}
