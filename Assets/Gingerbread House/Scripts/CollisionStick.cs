using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStick : MonoBehaviour
{

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Gingerbread"))
        {
            Debug.Log("Icing collided with Gingerbread.");

            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;  // Disable physics calculations
                rb.useGravity = false;  // Disable gravity
                rb.velocity = Vector3.zero;  // Stop any movement from physics forces
                rb.angularVelocity = Vector3.zero;  // Stop any rotation
                Debug.Log("Icing Rigidbody set to kinematic and gravity disabled.");
            }

            transform.SetParent(collision.transform);
            transform.position = collision.contacts[0].point;
        }
    }
}
