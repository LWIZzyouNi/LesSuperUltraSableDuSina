using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour {
    
    public Material nonOutlined;
    public Material outlined;

    public bool isOutlined = false;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LaserPointer")
        {
            GetComponent<Renderer>().material = outlined;
            isOutlined = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = nonOutlined;
        isOutlined = false;
    }

}
