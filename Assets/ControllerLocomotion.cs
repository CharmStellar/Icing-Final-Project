using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLocomotion : MonoBehaviour
{
    public float locomotionspeed;
    public Vector2 rightAxis2D;

    void Update()
    {
        rightAxis2D = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        rightAxis2D *= locomotionspeed;

        rightAxis2D *= Time.deltaTime;

        transform.position += new Vector3(rightAxis2D.x, 0.0f, rightAxis2D.y);
    }
}
