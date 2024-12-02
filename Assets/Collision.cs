using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Only move the piping bag if it's not colliding with gingerbread
        if (!isCollidingWithGingerbread)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveX, 0, moveY);
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
        }
    }

    private bool isCollidingWithGingerbread = false;

    // Detect collision with gingerbread
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Gingerbread"))
        {
            isCollidingWithGingerbread = true;
        }
    }

    // If the piping bag is no longer colliding, allow movement again
    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Gingerbread"))
        {
            isCollidingWithGingerbread = false;
        }
    }
}
