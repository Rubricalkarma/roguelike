using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public float value = 0;
    public string rarity = "Common";
    public string itemName = "New Item";
    public Sprite icon = null;


}
