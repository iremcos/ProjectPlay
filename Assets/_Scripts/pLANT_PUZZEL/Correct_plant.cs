using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct_plant : MonoBehaviour
{
    public GameObject selectedPlantPrefab; // Holds the currently selected plant prefab
    public GameObject selectedSoil;       // Holds the selected soil plot

    public void SelectPlant(GameObject plantPrefab)
    {
        selectedPlantPrefab = plantPrefab;
        Debug.Log($"Selected {plantPrefab.name} as the current plant to use.");
    }

    public void Plant()
    {
        if (selectedSoil != null && selectedPlantPrefab != null)
        {
            // Ensure the prefab spawns upright
            Quaternion correctRotation = Quaternion.Euler(270, 0, 0); // Set the desired rotation (Y-up)
            GameObject plant = Instantiate(selectedPlantPrefab, selectedSoil.transform.position, correctRotation);

            // Store the reference in the soil
            selectedSoil.GetComponent<Ground>().plantedPlant = plant;

            Debug.Log($"{plant.name} planted on {selectedSoil.name}.");
        }
        else
        {
            Debug.LogWarning("No soil or plant selected!");
        }
    }

    public void Water()
    {
        if (selectedSoil != null)
        {
            Ground soil = selectedSoil.GetComponent<Ground>();
            if (soil != null && soil.plantedPlant != null)
            {
                plant plant = soil.plantedPlant.GetComponent<plant>();
                plant.Water();
            }
            else
            {
                Debug.LogWarning("No plant found on the selected soil!");
            }
        }
        else
        {
            Debug.LogWarning("No soil selected to water!");
        }
    }
}
