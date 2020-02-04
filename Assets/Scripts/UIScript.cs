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
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI levelText;
    public Image healthBar;
    public Image expBar;

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
        healthText.text = e.currentHP + "/" + e.maxHP;
        experienceText.text = "Exp: " + e.experience + "/" + e.experienceToNextLevel;
        healthBar.fillAmount = e.currentHP / e.maxHP;
        expBar.fillAmount = e.experience / e.experienceToNextLevel;
        levelText.text = e.level+"";
    }
}
