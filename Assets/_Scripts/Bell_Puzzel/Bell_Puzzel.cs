using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell_Puzzel : MonoBehaviour
{
    public List<Transform> correctOrder;
    public List<GameObject> bells;

    public void CheckOrder()
    {
        for (int i = 0; i < correctOrder.Count; i++)
        {
            if (!bells[i].GetComponent<Bell>().isSnapped || bells[i].transform.position != correctOrder[i].position)
            {
                Debug.Log("Bells are not in the correct order!");
                return;
            }
        }

        Debug.Log("Bells are in the correct order!");
        
    }
}
