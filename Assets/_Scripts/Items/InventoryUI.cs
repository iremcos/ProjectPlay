using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotTemplate;  // Prefab of the slot template
    public Transform slotContainer; // Parent for inventory slots

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Clear existing slots
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        // Add new slots for each inventory item
        foreach (Item item in inventoryManager.inventory)
        {
            GameObject slot = Instantiate(slotTemplate, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
        }
    }
}
