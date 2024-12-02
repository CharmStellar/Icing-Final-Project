using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class snaptoplacewithsound : MonoBehaviour
{
    public Transform targetSnapPoint;  // The target position to snap to
    public float snapDistance = 0.5f;  // Distance within which the object should snap
    public AudioSource snapSound;      // Optional: Sound to play on snap

    private bool isSnapped = false;    // To track if the object has already snapped

    // Oculus Interaction: Called when the object is released
    public void OnSelectExited()
    {
        // Check the distance between the object and the target snap point
        float distance = Vector3.Distance(transform.position, targetSnapPoint.position);

        // If the object is within snapping distance
        if (distance <= snapDistance && !isSnapped)
        {
            SnapObject();  // Snap the object into place
        }
    }

    private void SnapObject()
    {
        // Snap to the target position and rotation
        transform.position = targetSnapPoint.position;
        transform.rotation = targetSnapPoint.rotation;

        // Play snap sound if available
        if (snapSound != null)
        {
            snapSound.Play();
        }

        // Mark the object as snapped
        isSnapped = true;
    }

    // Optional: Reset snap state to allow re-snapping
    public void ResetSnapState()
    {
        isSnapped = false;
    }

  
}
