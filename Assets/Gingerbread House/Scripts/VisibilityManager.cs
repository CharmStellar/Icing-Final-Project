using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    private GameObject currentlyVisibleObject = null;  // Tracks the currently visible GameObject

    // This function will be called by each button when pressed
    public void ShowObject(GameObject targetObject)
    {
        // If there is already a visible object, hide it
        if (currentlyVisibleObject != null && currentlyVisibleObject != targetObject)
        {
            currentlyVisibleObject.SetActive(false);
        }

        // Toggle the visibility of the target object
        bool isTargetActive = targetObject.activeSelf;
        if (!isTargetActive)
        {
            targetObject.SetActive(true);
        }

        // Set the currently visible object to the new one
        currentlyVisibleObject = targetObject;
    }
}
