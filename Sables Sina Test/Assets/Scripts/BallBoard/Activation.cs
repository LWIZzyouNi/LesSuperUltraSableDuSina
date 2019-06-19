using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Activation : MonoBehaviour {

    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    // La vérification du trigger
    public bool ctrlIsInTrigger = false;

    public GameObject ball;
    public GameObject resetButton;

    private void Awake()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Controller();
	}

    void Controller()
    {
        if ((buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space)) && ctrlIsInTrigger)
        {
            Act();
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

    void Act ()
    {
        resetButton.GetComponent<ResetButton>().inAct = true;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
