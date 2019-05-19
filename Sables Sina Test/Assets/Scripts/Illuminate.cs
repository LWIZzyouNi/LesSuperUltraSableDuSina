using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illuminate : MonoBehaviour {

    private Outline_IntElement m_Outline_IntElem_Script;
    private CanBeDrag m_DragScript;

    public Material nonIlluminated;
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
        IlluminateBox();

    }

    private void IlluminateBox()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_Outline_IntElem_Script.elementIsOutlined && m_DragScript.isLocked)
        {
            GetComponent<Renderer>().material = illuminated;
            m_Outline_IntElem_Script.GetComponent<Renderer>().material = m_Outline_IntElem_Script.elementOutlined;
            m_Outline_IntElem_Script.elementIsOutlined = false;
            isIlluminated = true;
            Debug.Log(isIlluminated);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !m_Outline_IntElem_Script.elementIsOutlined && m_DragScript.isLocked && isIlluminated)
        {
            GetComponent<Renderer>().material = nonIlluminated;
            isIlluminated = false;
            m_Outline_IntElem_Script.elementIsOutlined = true;
            Debug.Log(isIlluminated);
        }
    }
}
