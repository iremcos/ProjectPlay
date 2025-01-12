using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> inventory = new List<Item>();
    public int maxSlots = 5;

    public void AddItem(Item item)
    {
        if (inventory.Count >= maxSlots)
        {
            Debug.Log("inventory full!");
            return;
        }

        inventory.Add(item);
        Debug.Log($"{item.itemName} added to inventory");
    }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
