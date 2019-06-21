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

    public AudioClip rotatingPlateformSound;

    private Outline m_Outline_Script;

    Quaternion startRot;

    public bool isInteracting = false;
    public bool canBoucle = false;
    
    public float timerUntilCanClick = 0.5f;

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
        InputsCheck();
    }

    //transform.rotation.z == 0.3420201f && transform.rotation.w == 0.9396927f

    void InputsCheck()
    {
        if ((buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space)) && !isInteracting && m_Outline_Script.isOutlined)
        {
            PlateformRotate();
            StartCoroutine(WaitUntilClick());
            SoundManager.instance.RandomizeSFX(rotatingPlateformSound);
        }
    }

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

    IEnumerator WaitUntilClick()
    {
        isInteracting = true;

        yield return new WaitForSeconds(timerUntilCanClick);

        isInteracting = false;
    }
}
