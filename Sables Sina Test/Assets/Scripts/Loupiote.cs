using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loupiote : MonoBehaviour {

    public bool activated = false;

    public Material[] material;
    Renderer rend;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
        Activated();
	}

    void Activated()
    {
        if (activated == true)
        {
            rend.sharedMaterial = material[1];
        }
    }
}
