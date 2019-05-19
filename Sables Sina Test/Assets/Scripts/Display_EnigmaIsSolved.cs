using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_EnigmaIsSolved : MonoBehaviour {

    public bool activated = false;

    public Material enigmaNotComplete;
    public Material enigmaComplete;

    //Renderer rend;

    // Use this for initialization
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;

        GetComponent<Renderer>().material = enigmaNotComplete;

        //rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Activated();
	}

    void Activated()
    {
        if (activated == true)
        {
            GetComponent<Renderer>().material = enigmaComplete;
            //rend.sharedMaterial = material[1];
        }
    }
}
