using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityUI : MonoBehaviour
{
    public Text hpText;
    public GameObject entity;
    public GameObject healthBar;

    Entity stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = entity.GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "" + stats.currentHP;
        healthBar.transform.localScale = new Vector3(stats.currentHP / stats.maxHP, 1, 1);
    }
}
