using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CanBeDrag : MonoBehaviour
{
    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    public Outline outlineScript;

    public float moveSpeed = 5f;
    private Vector3 goToPos;
    private Vector3 initialPos;

    public bool isZoomed = false;
    public bool isDeZoomed = false;
    public bool isLocked = false;
    public bool isInteractive = true;

    private bool resetTab = false;
    //private bool afterReset = false;

    public bool canRotate = false;
    public int rotationSpeed = 1;

    public bool onResetButton = false;

    // Use this for initialization
    void Start()
    {

        goToPos = HeadSetManager.s_Singleton.GetTrsDest();

        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs

        OnButtonClick();
       
        if (isZoomed)
        {
            if(goToPos == transform.position)
            {
                //Debug.Log("Je suis à ma position parfaite");
                isLocked = true;
                isZoomed = false;
                resetTab = false;
                //afterReset = true;

                if (gameObject.tag == "Rotating")
                {
                    canRotate = true;
                }
            }

            Zoom();
        }

        if (isLocked)
        {
            if (canRotate)
            {
                Rotation();
            }
        }

        //if(isDeZoomed && afterReset)
        if (isDeZoomed)
        {
            canRotate = false;

            if (initialPos == transform.position)
            {
                //Debug.Log("Je suis à ma position de départ");
                isLocked = false;
                isDeZoomed = false;

            }

            Dezoom();
        }
    }

    private void Zoom()
    {
        //Debug.Log("J'avance!");
        transform.position = Vector3.MoveTowards(transform.position, goToPos, Time.deltaTime * moveSpeed);
    }

    public void Dezoom()
    {
        if (gameObject.name == "- BallBoard -" && resetTab == false)
        {
            resetTab = true;

            GetComponentInChildren<ResetButton>().ResetTab();
        }
        //Debug.Log("Je recule!");
        transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime * moveSpeed);
    }


    private void OnButtonClick()
    {
        if (/*buttonAction.GetState(handType01) && outlineScript.isOutlined && !isLocked && isInteractive ||
                    buttonAction.GetState(handType02) && outlineScript.isOutlined && !isLocked && isInteractive ||*/
                    Input.GetKeyDown(KeyCode.Mouse0) && outlineScript.isOutlined && !isLocked && isInteractive)
        {
            if (!isZoomed)
            {
                //Debug.Log("Click to zoom");
                isZoomed = true;
            }
        }

        if (/*buttonAction.GetState(handType01) && isLocked && !onResetButton || buttonAction.GetState(handType02) && isLocked && !onResetButton ||*/
                    Input.GetKeyDown(KeyCode.Mouse0) && isLocked && !onResetButton)
        {
            //Debug.Log("Click to dezoom");
            isDeZoomed = true;
        }
    }

    private void Rotation()
    {
        int tempHorizontalAxis = 0;
        int tempVerticalAxis = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            tempVerticalAxis--;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tempVerticalAxis++;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            tempHorizontalAxis++;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempHorizontalAxis--;
        }

        tempHorizontalAxis *= rotationSpeed;
        tempVerticalAxis *= rotationSpeed;

        transform.Rotate(tempHorizontalAxis, tempVerticalAxis, 0);
    }
}