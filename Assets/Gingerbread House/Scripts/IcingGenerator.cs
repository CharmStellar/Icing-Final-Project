using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingGenerator : MonoBehaviour
{
    public GameObject icingPrefab;  // Reference to the icing prefab
    public Transform icingSpawnPoint;  // Tip of the piping bag
    public float icingInterval = 0.001f;  // Interval between each new icing segment (in seconds)
   

    private bool isIcing = false;  // Flag to check if icing is being generated
    private float lastIcingTime;  // Timer to control the interval of icing generation

    void Update()
    {
        // Start generating icing when X button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            StartIcing();
        }

        // Continue icing generation while holding X button
        if (isIcing)
        {
            GenerateIcing();
        }

        // Stop icing when X button is released
        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            StopIcing();
        }
    }

    void StartIcing()
    {
        // Start icing generation (reset timer)
        isIcing = true;
        lastIcingTime = Time.time;
    }

    void GenerateIcing()
    {
        // Check if enough time has passed to instantiate another icing segment
        if (Time.time - lastIcingTime >= icingInterval)
        {
            // Instantiate a new icing segment at the spawn point in world space
            Vector3 spawnPosition = icingSpawnPoint.position;
            Quaternion spawnRotation = icingSpawnPoint.rotation;
            GameObject newIcing = Instantiate(icingPrefab, spawnPosition, spawnRotation);
          

            // Update the timer
            lastIcingTime = Time.time;
        }
    }

    void StopIcing()
    {
        // Stop icing generation
        isIcing = false;
    }
}
