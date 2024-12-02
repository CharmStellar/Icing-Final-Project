using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglevisibility : MonoBehaviour
{
    public GameObject targetObject;  // The GameObject to show/hide

    // This function will be called when the button is clicked
    public void ToggleVisibility()
    {
        if (targetObject != null)
        {
            // Toggle the active state of the target GameObject
            bool isActive = targetObject.activeSelf;
            targetObject.SetActive(!isActive);
        }
    }

}
