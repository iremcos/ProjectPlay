using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class bell_spot : MonoBehaviour
{
    public Transform snapPoint;
    public float snapRange = 1.0f;
    public string snappingId;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bell") && Vector3.Distance(transform.position, other.transform.position) < snapRange)
        {
           

            Bell bellComponent = other.GetComponent<Bell>();
            if (bellComponent != null && bellComponent.BellId == snappingId)
            {
                bellComponent.isSnapped = true;
                Debug.Log("is snapped");
                other.transform.position = snapPoint.position;
                other.transform.rotation = snapPoint.rotation;
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }
            else 
            {
                
                Debug.Log("wrong");
            }
           

            
        }
    }
}
