using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotTemplate;
    public Transform slotContainer;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventoryManager.inventory)
        {
            GameObject slot = Instantiate(slotTemplate, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
        }
    }
}
