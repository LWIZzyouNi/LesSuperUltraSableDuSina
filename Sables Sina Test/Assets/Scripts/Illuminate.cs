﻿using System.Collections;
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
    public bool isInteracting = false;

    // Use this for initialization
    void Start ()
    {
        m_Outline_IntElem_Script = GetComponent<Outline_IntElement>();
        m_DragScript = GetComponentInParent<CanBeDrag>();

    }

    // Update is called once per frame
    void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("in Trigger");
     if (other.gameObject.CompareTag("LaserPointer") && buttonAction.GetState(handType01) && !isIlluminated && m_DragScript.isLocked || other.gameObject.CompareTag("LaserPointer") && buttonAction.GetState(handType02) && !isIlluminated && m_DragScript.isLocked)
            {
                Debug.Log("Press Button");
                GetComponent<Renderer>().material = illuminated;
                isIlluminated = true;
                m_Boxes_Check_Script.caseNumber++;
                Debug.Log(isIlluminated);
            }

            else if (other.gameObject.CompareTag("LaserPointer") && buttonAction.GetState(handType01) && isIlluminated && m_DragScript.isLocked || other.gameObject.CompareTag("LaserPointer") && buttonAction.GetState(handType02) && isIlluminated && m_DragScript.isLocked)
            {
                GetComponent<Renderer>().material = notIlluminated;
                isIlluminated = false;
                m_Boxes_Check_Script.caseNumber--;
                Debug.Log(isIlluminated);
            }       
    }

    IEnumerator WaitUntilClick()
    {
        isInteracting = true;

        yield return new WaitForSeconds(.5f);

        isInteracting = false;
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
