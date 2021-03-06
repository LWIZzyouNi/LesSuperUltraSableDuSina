﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetButton : MonoBehaviour {
    public bool inAct = false;

    private Outline outlineScript;

    public GameObject ball;

    private Vector3 ballTransformSave;

    private bool doOnce = false;

    public AudioClip pressResetButton;

    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

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
        //transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = true;
        outlineScript = GetComponent<Outline>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MouseClick();
        SavePosition();
	}

    public void ResetTab()
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        transform.parent.gameObject.GetComponent<BallBoard>().ResetPlatform();

        inAct = false;
        //ball.transform.position = ballTransformSave;

        SoundManager.instance.PlaySingle(pressResetButton);
    }

    private void MouseClick()
    {
        if (outlineScript.isOutlined)
        {
            if (buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space))
            {
                ResetTab();
                Debug.Log("Tab is reset");
            }
        }
        /*
        else
        {
            transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = false;
        }
        */
    }

    private void SavePosition()
    {
        if (!doOnce)
        {
            ballTransformSave = ball.transform.position;
            //ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            doOnce = true;
        }
        
    }
}