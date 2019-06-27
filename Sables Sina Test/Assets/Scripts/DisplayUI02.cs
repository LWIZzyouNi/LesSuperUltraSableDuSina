using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DisplayUI02 : MonoBehaviour
{

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    public GameObject interactText;
    public bool interactTextIsActive = false;

    // Use this for initialization
    void Start ()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputsCheck();
    }

    private void InputsCheck()
    {
        if ((buttonAction.GetStateDown(handType01) || buttonAction.GetStateDown(handType02) || Input.GetKeyDown(KeyCode.Space)) && interactTextIsActive)
        {
            interactText.SetActive(false);
            interactTextIsActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            interactTextIsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            interactTextIsActive = false;
        }
    }
}
