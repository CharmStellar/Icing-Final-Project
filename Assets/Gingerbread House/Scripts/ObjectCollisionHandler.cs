using UnityEngine;

public class ObjectCollisionHandler : MonoBehaviour
{
    public string targetTag = "Gingerbread";  // Tag of the object to prevent collision with
    public float minimumDistance = 0.5f;      // Minimum allowed distance to prevent the object from passing through
    public float velocityDamping = 0.5f;      // Factor to reduce the velocity when moving away

    private Rigidbody rb;
    private GameObject targetObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody of the moving object

        // Find the target object by tag
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calculate the distance between the two objects
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);

            // If the distance is less than the minimum allowed distance
            if (distance < minimumDistance)
            {
                // Prevent movement: Option 1 (Stop movement by setting velocity to zero)
                rb.velocity = Vector3.zero;  // This will stop the object from moving further

                // Option 2: Adjust position to maintain the minimum distance
                Vector3 direction = (transform.position - targetObject.transform.position).normalized;
                transform.position = targetObject.transform.position + direction * minimumDistance;  // Position the object at the minimum distance
            }
            else
            {
                // When moving away, apply a damping effect to slow down the object
                if (rb.velocity.magnitude > 0)  // Only modify if there is some velocity
                {
                    rb.velocity = rb.velocity * (1 - velocityDamping * Time.deltaTime);
                }
            }
        }
    }
}
