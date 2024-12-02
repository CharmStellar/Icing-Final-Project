using Oculus.Interaction;
using Oculus.Interaction.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzle : MonoBehaviour
{
    public Transform targetPuzzle;

    public bool isSolved;

    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPuzzle.position);
        
        if(distance < 0.0f & !isSolved)
        {
            IEnumerableHashSet<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors) { interactor.Unselect(); }

            transform.SetPositionAndRotation(targetPuzzle.position, targetPuzzle.rotation);

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            boxCollider.enabled = false;

            audioSource.Play();

            isSolved = true;
        }
        
    }
}
