using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingParticleController : MonoBehaviour
{
    public ParticleSystem icingParticleSystem;  // Reference to the Particle System
    public Transform icingSpawnPoint;  // Tip of the piping bag

    void Update()
    {
        // Check if X button is pressed
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            StartIcing();
        }

        // Stop icing when X button is released
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            StopIcing();
        }
    }

    void StartIcing()
    {
        // Move the particle system to the spawn point and enable it
        icingParticleSystem.transform.position = icingSpawnPoint.position;
        icingParticleSystem.transform.rotation = icingSpawnPoint.rotation;
        icingParticleSystem.Play();  // Start the particle system
    }

    void StopIcing()
    {
        // Stop the particle system
        icingParticleSystem.Stop();
    }
}
