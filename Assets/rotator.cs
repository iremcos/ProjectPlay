using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float rotationAngle = 90f; // Angle to rotate each press
    private bool isAligned = false; // Check if aligned with goal
    private Vector3 targetRotation; // Track target rotation

    private void Start()
    {
        // Set the initial target rotation
        targetRotation = transform.eulerAngles;
    }

    private void Update()
    {
        // Check for input and rotate the block
        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate();
        }

        // Smoothly interpolate towards the target rotation
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, Time.deltaTime * 10f);
    }

    private void Rotate()
    {
        if (!isAligned)
        {
            // Increment the target rotation
            targetRotation += Vector3.up * rotationAngle;

            // Clamp rotation to a range (e.g., 0-360) for better control
            targetRotation = new Vector3(
                Mathf.Round(targetRotation.x),
                Mathf.Round(targetRotation.y % 360),
                Mathf.Round(targetRotation.z)
            );

            // Check if the block is correctly aligned with the goal
            CheckAlignment();
        }
    }

    private void CheckAlignment()
    {
        // Assuming the "correct" rotation is Vector3.zero (customize as needed)
        isAligned = Mathf.Approximately(targetRotation.y % 360, 0);
        if (isAligned)
        {
            Debug.Log("Block is aligned!");
        }
    }
}
