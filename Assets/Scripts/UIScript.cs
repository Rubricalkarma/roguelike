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

    Entity e;
   
    // Start is called before the first frame update
    void Start()
    {
       e = player.GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
       attackSpeedText.text =  "Shoot Speed: " + e.attackSpeed;
        healthText.text = "HP: " + e.currentHP + "/" + e.maxHP;
    }
}
