using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Uh oh more than one inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public int space = 8;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Inventory Full!");
            return false;
        }
        items.Add(item);
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
