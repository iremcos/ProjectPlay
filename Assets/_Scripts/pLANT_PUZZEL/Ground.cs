using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject plantedPlant; // Tracks the plant on this soil plot

    private void OnMouseDown()
    {
        // Assign this soil to the Garden Manager when clicked
        Correct_plant manager = FindObjectOfType<Correct_plant>();
        manager.selectedSoil = gameObject;
        Debug.Log($"{gameObject.name} selected as the current soil.");
    }
}