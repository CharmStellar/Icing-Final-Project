using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;

    private void Update()
    {
        material.color = fcp.color; 
    }
   
}
