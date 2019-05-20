using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_IntElement : MonoBehaviour {
    
    public Material elementNonOutlined;
    public Material elementOutlined;

    public bool elementIsOutlined = false;

    private CanBeDrag m_DragScript;
    private Illuminate m_IlluminateScript;

    // Use this for initialization
    void Start ()
    {
        m_DragScript = GetComponentInParent<CanBeDrag>();
        m_IlluminateScript = GetComponentInParent<Illuminate>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!m_DragScript.isLocked && elementIsOutlined)
        {
            GetComponent<Renderer>().material = elementNonOutlined;
            elementIsOutlined = false;
            Debug.Log("Can't Outline");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LaserPointer" && m_DragScript.isLocked)
        {
            GetComponent<Renderer>().material = elementOutlined;
            elementIsOutlined = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Board_Box")
        {
            elementIsOutlined = false;
            GetComponent<Renderer>().material = elementNonOutlined;
        }

        else
        {
            elementIsOutlined = false;
            GetComponent<Renderer>().material = elementNonOutlined;
        }
    }
}
