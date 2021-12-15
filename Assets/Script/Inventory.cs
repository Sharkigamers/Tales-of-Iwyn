using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public static Inventory instance;

    public GameObject FireSpell;
    public GameObject WaterSpell;
    public GameObject HealSpell;
    
    //TODO SPACE AND STACK
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }

    #endregion
    
    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);

        if (item.ItemName == "Crystal Shard")
        {
            FireSpell.SetActive(false);
        } else if (item.ItemName == "Crystal Shard Water")
        {
            WaterSpell.SetActive(false);
        } else if (item.ItemName == "Crystal Shard Nature") {
            HealSpell.SetActive(false);
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
    public void Remove(Item item)
    {
        items.Remove(item);
        
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
