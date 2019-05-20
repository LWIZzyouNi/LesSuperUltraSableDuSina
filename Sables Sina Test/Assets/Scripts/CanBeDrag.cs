using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CanBeDrag : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;

    public Outline outlineScript;

    public float moveSpeed = 5f;
    private Vector3 goToPos;
    private Vector3 initialPos;

    public bool isZoomed = false;
    public bool isDeZoomed = false;
    public bool isLocked = false;
    public bool isInteractive = true;

    public bool canRotate = false;
    public int rotationSpeed = 1;

    // Use this for initialization
    void Start()
    {

        goToPos = HeadSetManager.s_Singleton.GetTrsDest();

        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // VR Inputs

        /* if (m_GrabAction.GetStateDown(m_Pose.inputSource))
         {
             if (isLocked == false)
             {
                 isLocked = true;
                 isZoomed = true;
             }
         }
         */

        // Mouse (+Keyboard) Inputs

        OnMouseClick();
       
        if (isZoomed)
        {
            if(goToPos == transform.position)
            {
                //Debug.Log("Je suis à ma position parfaite");
                isLocked = true;
                isZoomed = false;
                if(gameObject.tag == "Rotating")
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

        if(isDeZoomed)
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
        //Debug.Log("Je recule!");
        transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime * moveSpeed);
    }


    private void OnMouseClick()
    {
        if((Input.GetKeyDown(KeyCode.Mouse0)) && outlineScript.isOutlined && !isLocked && isInteractive)
        {
            if (!isZoomed)
            {
                //Debug.Log("Click to zoom");
                isZoomed = true;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && isLocked)
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