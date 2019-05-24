using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public int doorNumber = 0;

    public bool activated = false;

    public Animator animDoor;

    public AudioSource audioSRC;

    private bool doOnce = false;

	// Use this for initialization
	void Start ()
    {
        animDoor = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(activated && doOnce == false)
        {
            doOnce = true;
            Activated();
        }
	}

    void Activated()
    {
        animDoor.SetBool("Open", true);
        audioSRC.Play();
    }
}
