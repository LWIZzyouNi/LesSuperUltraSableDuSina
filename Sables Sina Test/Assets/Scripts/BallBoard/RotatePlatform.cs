using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotatePlatform : MonoBehaviour {
    
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;
    public GameObject BallBoard;

    private Outline m_Outline_Script;

    Quaternion startRot;

    public bool canBoucle = false;

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
        BallBoard.GetComponent<BallBoard>().AddInList(this.gameObject);

        m_Outline_Script = GetComponent<Outline>();
        startRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (buttonAction.GetState(handType01) && m_Outline_Script.isOutlined || buttonAction.GetState(handType02) && m_Outline_Script.isOutlined)
        {
            PlateformRotate();
            //Debug.Log(transform.eulerAngles.z);
        }   
    }

    //transform.rotation.z == 0.3420201f && transform.rotation.w == 0.9396927f

    private void PlateformRotate()
    {
        //0

        if (transform.rotation.z == 0)
        {
            if (canBoucle)
            {
                transform.Rotate(new Vector3(0, 0, -40f));
                canBoucle = false;

                return;
            }

            if (!canBoucle)
            {
                transform.Rotate(new Vector3(0, 0, 40f));
                canBoucle = true;

                return;
            }
        }
        else
        {
            print("Active method");
            // 40
            if (canBoucle)
            {
                //canBoucle = true;
                transform.Rotate(new Vector3(0, 0, -40f));
                startRot.Set(0, 0, 0, 0);
                transform.rotation = startRot;
                return;
            }

            // -40
            if (!canBoucle)
            {
                //canBoucle = false;
                transform.Rotate(new Vector3(0, 0, 40f));
                startRot.Set(0, 0, 0, 0);
                transform.rotation = startRot;
                return;
            }
        }
    }
}
