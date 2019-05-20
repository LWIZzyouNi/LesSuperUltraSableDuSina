using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illuminate : MonoBehaviour {

    private Outline_IntElement m_Outline_IntElem_Script;
    private CanBeDrag m_DragScript;

    public Material notIlluminated;
    public Material illuminated;

    public bool isIlluminated = false;

    // Use this for initialization
    void Start ()
    {
        m_Outline_IntElem_Script = GetComponent<Outline_IntElement>();
        m_DragScript = GetComponentInParent<CanBeDrag>();

    }

    // Update is called once per frame
    void Update ()
    {
        //IlluminateBox();

    }
    /*
    private void IlluminateBox()
    {
            

            else if (m_Outline_IntElem_Script.elementIsOutlined && isIlluminated)
            {
                
            }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LaserPointer" && !isIlluminated && m_DragScript.isLocked)
        {
            GetComponent<Renderer>().material = illuminated;
            isIlluminated = true;
            Debug.Log(isIlluminated);
        }

        else if (other.gameObject.tag == "LaserPointer" && isIlluminated && m_DragScript.isLocked)
        {
            GetComponent<Renderer>().material = notIlluminated;
            isIlluminated = false;
            Debug.Log(isIlluminated);
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LaserPointer" && !isIlluminated && m_DragScript.isLocked)
        {
            GetComponent<Renderer>().material = notIlluminated;
            isIlluminated = false;
            Debug.Log(isIlluminated);
        }
    }
    */
}
