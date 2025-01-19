using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public GameObject[] growthStages; // Assign child objects for each stage in the Inspector
    private int currentStage = 0;

    public void Water()
    {
        if (currentStage < growthStages.Length - 1)
        {
            // Advance to the next growth stage
            growthStages[currentStage].SetActive(false);
            currentStage++;
            growthStages[currentStage].SetActive(true);
            Debug.Log($"{gameObject.name} grew to stage {currentStage + 1}.");
        }
        else
        {
            Debug.Log($"{gameObject.name} is fully grown!");
        }
    }
}


