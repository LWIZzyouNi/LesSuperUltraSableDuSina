using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetButton : MonoBehaviour {

    private Outline outlineScript;

    public GameObject ball;

    private Vector3 ballTransformSave;

    private bool doOnce = false;

    public AudioSource audioSRC;

    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    // Use this for initialization
    void Start () {
        //transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = true;
        outlineScript = GetComponent<Outline>();
	}
	
	// Update is called once per frame
	void Update () {
        MouseClick();
        SavePosition();
	}

    public void ResetTab()
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        transform.parent.gameObject.GetComponent<BallBoard>().ResetPlatform();

        ball.transform.position = ballTransformSave;

        audioSRC.Play();
    }

    private void MouseClick()
    {
        if (outlineScript.isOutlined && transform.parent.gameObject.GetComponent<CanBeDrag>().isLocked == true && transform.parent.gameObject.GetComponent<CanBeDrag>().isInteractive == true)
        {
            transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = true;

            if (buttonAction.GetState(handType01) || buttonAction.GetState(handType02))
            {
                ResetTab();
            }
        }
        else
        {
            transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = false;
        }
    }

    private void SavePosition()
    {
        if (transform.parent.gameObject.GetComponent<CanBeDrag>().isLocked == true && transform.parent.gameObject.GetComponent<CanBeDrag>().isDeZoomed == false)
        {
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

            if (!doOnce)
            {
                ballTransformSave = ball.transform.position;
                //ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                doOnce = true;
            }
        }
    }
}