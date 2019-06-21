using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Sink_Check : MonoBehaviour {

    public Boxes_Check m_Boxes_Check;

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    private Outline m_Outline_Script;

    public bool ctrlIsInTrigger = false;

    // Use this for initialization
    void Start ()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();

        m_Outline_Script = GetComponent<Outline>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputsCheck();
    }

    private void InputsCheck()
    {
        if ((buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space)) && m_Outline_Script.isOutlined && ctrlIsInTrigger)
        {
            m_Boxes_Check.CheckResult();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            Debug.Log("in Trigger");
            ctrlIsInTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            Debug.Log("out of Trigger");
            ctrlIsInTrigger = false;
        }
    }
}
