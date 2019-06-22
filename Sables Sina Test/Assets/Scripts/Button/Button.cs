using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Button : MonoBehaviour {

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    private bool DoOnce = false;

    private Outline m_Outline_Script;
    private Animator m_Animator;

    public Vector3 startPos = Vector3.zero;

    // La vérification du trigger
    public bool ctrlIsInTrigger = false;

    private void Awake()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Use this for initialization
    void Start ()
    {
        m_Outline_Script = GetComponent<Outline>();
        m_Animator = GetComponent<Animator>();

        startPos = gameObject.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Controller ();
    }

    void Controller ()
    {
        if ((buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space)) && m_Outline_Script.isOutlined && ctrlIsInTrigger)  
        {
            if (DoOnce == false)
            {
                DoOnce = true;
                GameManager.s_Singleton.ActivateButton();
                m_Animator.SetBool("Push", true);
            }
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
