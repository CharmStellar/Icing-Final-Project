using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArea : MonoBehaviour
{
    public pinControl pinControl;
    public TMPro.TextMeshProUGUI score;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pin"))
        {
            pinControl.AddFallPins(other.gameObject);
            score.text = "SCORE: " + pinControl.GetScore();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
