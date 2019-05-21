using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Illuminate : MonoBehaviour {

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    private Outline_IntElement m_Outline_IntElem_Script;
    private CanBeDrag m_DragScript;
    public Boxes_Check m_Boxes_Check_Script;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LaserPointer"))
        {
            Debug.Log("in Trigger");
            if (buttonAction.GetState(handType01) && !isIlluminated && m_DragScript.isLocked ||
                    buttonAction.GetState(handType02) && !isIlluminated && m_DragScript.isLocked)
            {
                Debug.Log("Press Button");
                GetComponent<Renderer>().material = illuminated;
                isIlluminated = true;
                m_Boxes_Check_Script.caseNumber++;
                Debug.Log(isIlluminated);
            }

            else if (buttonAction.GetState(handType01) && isIlluminated && m_DragScript.isLocked ||
                    buttonAction.GetState(handType02) && isIlluminated && m_DragScript.isLocked)
            {
                GetComponent<Renderer>().material = notIlluminated;
                isIlluminated = false;
                m_Boxes_Check_Script.caseNumber--;
                Debug.Log(isIlluminated);

            }
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
