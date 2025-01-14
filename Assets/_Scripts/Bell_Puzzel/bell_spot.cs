using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bell_spot : MonoBehaviour
{
    public Transform snapPosition; 
    public float snapRange = 1.0f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bell"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < snapRange)
            {
                other.transform.position = snapPosition.position; 
                other.GetComponent<Bell>().isSnapped = true; 
            }
        }
    }
}
