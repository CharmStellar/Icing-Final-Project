using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinControl : MonoBehaviour
{
    private Vector3[] initialPositions;
    private GameObject[] pins;

    private List<GameObject> fallPins;

    // Start is called before the first frame update
    void Start()
    {
        pins = new GameObject[transform.childCount];
        initialPositions = new Vector3[transform.childCount];

        fallPins = new List<GameObject>();

        for(int i = 0; i < transform.childCount; i++)
        {
            pins[i] = transform.GetChild(i).gameObject;
            initialPositions[i] = transform.GetChild(i).position;
        }
    }

    public void AddFallPins(GameObject pin)
    {
        if (!fallPins.Contains(pin))
        {
            fallPins.Add(pin);
        }

    }

    public int GetScore()
    {
        return fallPins.Count;
    }

    public void ResetPinPositions()
    {

        fallPins.Clear();

        for (int i = 0; i < pins.Length; i++)
        {

            pins[i].transform.position = initialPositions[i];
            pins[i].transform.rotation = Quaternion.identity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ResetPinPositions();
        }
    }
}
