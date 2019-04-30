using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LaserCollision : MonoBehaviour {

    public GameObject objetVisee;
    public Interactable interactable;

	// Use this for initialization
	void Start () {
        interactable = objetVisee.GetComponent<Interactable>(); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "InteractableObject")
        {
            interactable.highlightOnHover = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.tag == "InteractableObject")
        {
            interactable.highlightOnHover = false;
        }
    }
}
