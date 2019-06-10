using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotatePlatform : MonoBehaviour {
    
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;
    public GameObject BallBoard;

    private Outline_IntElement m_Outline_IntElem_Script;

    Quaternion startRot;

    public bool canBoucle = false;

    // Use this for initialization
    void Start ()
    {
        BallBoard.GetComponent<BallBoard>().AddInList(this.gameObject);

        m_Outline_IntElem_Script = GetComponent<Outline_IntElement>();
        startRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Outline_IntElem_Script.elementIsOutlined)
        {
            PlatformRotate();
            //Debug.Log(transform.eulerAngles.z);
        }   
    }

    //transform.rotation.z == 0.3420201f && transform.rotation.w == 0.9396927f

    private void PlatformRotate()
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
