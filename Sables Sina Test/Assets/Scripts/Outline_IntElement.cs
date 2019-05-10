using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_IntElement : MonoBehaviour {

    public Material elementBordered;
    public Material elementNonBordered;

    public bool elementisBordered = false;

    private CanBeDrag m_MyScript;

    // Use this for initialization
    void Start ()
    {
        m_MyScript = GetComponentInParent<CanBeDrag>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!m_MyScript.isLocked && elementisBordered)
        {
            GetComponent<Renderer>().material = elementNonBordered;
            elementisBordered = false;
            Debug.Log("Can't Outline");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LaserPointer" && m_MyScript.isLocked)
        {
            GetComponent<Renderer>().material = elementBordered;
            elementisBordered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        elementisBordered = false;
        GetComponent<Renderer>().material = elementNonBordered;
    }
}
