using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class matching_colors : MonoBehaviour
{
    public string matchingColor; 

    private void OnTriggerEnter(Collider other)
    {
            var item = other.GetComponent<color_identefier>();
            if (item != null && item.colorid == matchingColor)
            {
                Debug.Log("Correct!");
                
            }
            else
            {
                Debug.Log("Wrong!");
            }
    }
}
