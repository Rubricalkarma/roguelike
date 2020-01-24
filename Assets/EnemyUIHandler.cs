using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIHandler : MonoBehaviour
{

    public Text hp;
    public GameObject enemy;
    public Camera cam;

    EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = enemy.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HELLO"+stats.hp;
        hp.transform.position = cam.WorldToScreenPoint(enemy.transform.position);
    }
}
