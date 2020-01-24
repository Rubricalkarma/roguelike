using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIHandler : MonoBehaviour
{

    public Text hp;
    public GameObject enemy;
    public GameObject hpBar;

    EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = enemy.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = ""+stats.currentHP;
        hpBar.transform.localScale = new Vector3(stats.currentHP / stats.maxHP,1,1);
    }
}
