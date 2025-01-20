using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public GameObject popupPrefab;

    private GameObject popupInstance;
    private bool isPlayerNearby = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            if (inventory != null)
            {
                inventory.AddItem(item);
                Destroy(popupInstance);
                Destroy(gameObject);
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (popupPrefab != null)
            {
                popupInstance = Instantiate(popupPrefab, transform.position + Vector3.up, Quaternion.identity);
                popupInstance.GetComponentInChildren<Text>().text = "Press E to Pick Up";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; 

            if (popupInstance != null)
            {
                Destroy(popupInstance);
            }
        }
    }

    void PickUp()
    {




        Destroy(gameObject);

        Debug.Log($"Picked up {item.name}");
    }
}
