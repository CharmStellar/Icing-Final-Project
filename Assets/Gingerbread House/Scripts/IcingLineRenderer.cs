using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Material IcingMaterial; // Optional, for custom material
    public float icingThickness = 0.1f;
    

    private bool isDrawing = false;
    private List<Vector3> ropePoints = new List<Vector3>();

    void Start()
    {
        

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Configure LineRenderer
        lineRenderer.material = IcingMaterial;
        lineRenderer.startWidth = icingThickness;
        lineRenderer.endWidth = icingThickness;
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)&& (isDrawing == false))
        {
            StartDrawing();
        }

        if (isDrawing)
        {
            UpdateRope();
        }

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            StopDrawing();
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        ropePoints.Clear(); // Clear any existing points
        AddPoint(transform.position);
    }

    void UpdateRope()
    {
        if (isDrawing)
        {
            Vector3 currentPosition = transform.position;

            // Add a new point if the object has moved significantly
            if (ropePoints.Count == 0 || Vector3.Distance(ropePoints[ropePoints.Count - 1], currentPosition) > 0.01f)
            {
                AddPoint(currentPosition);
                Debug.Log($"Position Count: {lineRenderer.positionCount}");
            }
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
    }

    void AddPoint(Vector3 point)
    {
        ropePoints.Add(point);
        lineRenderer.positionCount = ropePoints.Count;
        lineRenderer.SetPositions(ropePoints.ToArray());
    }
}
