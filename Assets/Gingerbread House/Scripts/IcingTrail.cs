using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;  // Reference to LineRenderer
    public Transform icingSpawnPoint;  // Tip of the piping bag
    public float icingInterval = 0.1f;  // Interval between each point
    public GameObject icingPrefab;  // Prefab for the icing (tiny capsule or similar)

    private int currentPoint = 0;  // Keeps track of the next point
    private float lastIcingTime;   // Timer to control the interval of icing generation
    private bool isIcingActive = false; // Flag to track icing state

    void Update()
    {
        // Check if the X button is pressed down to start or continue the icing trail
        if (OVRInput.Get(OVRInput.Button.One)) // If X is pressed
        {
            if (!isIcingActive)
            {
                StartIcing();
            }
            ContinueIcing();
        }
        else if (isIcingActive)
        {
            StopIcing();
        }
    }

    void StartIcing()
    {
        // Start icing generation (reset variables)
        isIcingActive = true;
        currentPoint = 0; // Reset the point counter
        lineRenderer.positionCount = 0; // Clear previous points
    }

    void ContinueIcing()
    {
        // Only continue icing if enough time has passed
        if (Time.time - lastIcingTime >= icingInterval)
        {
            // Increase the position count for the trail
            lineRenderer.positionCount = currentPoint + 1;
            lineRenderer.SetPosition(currentPoint, icingSpawnPoint.position); // Add new point at spawn position

            // Instantiate the icing prefab at the spawn position
            Instantiate(icingPrefab, icingSpawnPoint.position, icingSpawnPoint.rotation);

            // Update for the next point
            currentPoint++;
            lastIcingTime = Time.time;
        }
    }

    void StopIcing()
    {
        // Stop icing generation when the X button is released
        isIcingActive = false;
    }
}
