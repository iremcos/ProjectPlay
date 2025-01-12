using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell_Puzzel : MonoBehaviour
{
    public GameObject[] bellSlots; 
    private List<GameObject> placedBells = new List<GameObject>();

    public void CheckOrder()
    {
        for (int i = 0; i < bellSlots.Length; i++)
        {
            if (bellSlots[i].transform.childCount > 0)
            {
                var bell = bellSlots[i].transform.GetChild(0).gameObject;
                if (bell != placedBells[i])
                {
                    Debug.Log("Incorrect Order");
                    return;
                }
            }
        }
        Debug.Log("Correct Order! Puzzle Solved!");
        
    }
}
