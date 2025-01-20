using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float rotationAngle = 90f; // Angle to rotate each press
    public float alignmentAngle = 0f; // The angle for alignment, customizable in the editor
    public Material alignedMaterial; // Optional: Material to show when aligned
    private Material originalMaterial; // Store the original material
    private bool isAligned = false; // Check if aligned with the goal
    private Vector3 targetRotation; // Track target rotation

    private void Start()
    {
        // Set the initial target rotation and store the original material
        targetRotation = transform.eulerAngles;
        if (GetComponent<Renderer>())
        {
            originalMaterial = GetComponent<Renderer>().material;
        }
    }

    private void Update()
    {
        // Rotate the block when 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate();
        }

        // Reset alignment when 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAlignment();
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

            // Clamp rotation to a range (0-360) for better control
            targetRotation = new Vector3(
                Mathf.Round(targetRotation.x),
                Mathf.Repeat(targetRotation.y, 360), // Ensure y is in the range [0, 360)
                Mathf.Round(targetRotation.z)
            );

            // Check if the block is correctly aligned
            CheckAlignment();
        }
    }

    private void CheckAlignment()
    {
        // Check if the current Y rotation matches the specified alignment angle
        isAligned = Mathf.Approximately(targetRotation.y, alignmentAngle);
        if (isAligned)
        {
            Debug.Log($"Block is aligned at {alignmentAngle} degrees!");

            // Update material to indicate alignment
            if (alignedMaterial && GetComponent<Renderer>())
            {
                GetComponent<Renderer>().material = alignedMaterial;
            }
        }
    }

    private void ResetAlignment()
    {
        // Allow further rotations by resetting the alignment state
        isAligned = false;
        Debug.Log("Alignment reset.");

        // Reset the material to the original
        if (originalMaterial && GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}