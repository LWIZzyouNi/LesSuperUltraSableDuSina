using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CanBeDrag : MonoBehaviour
{
    // private float dist = 0f;
    // public float distPerfect = 1f;

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;

    public Outline outlineScript;

    public float moveSpeed = 5f;
    private Vector3 goToPos;
    private Vector3 initialPos;

    private bool isZoomed = false;
    private bool isDeZoomed = false;
    private bool isLocked = false;

    public bool canRotate = true;
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
        /*
        Debug.Log("Zoom " + isZoomed);
        Debug.Log("Lock " + isLocked);
        */
        if (isZoomed)
        {
            //dist = Vector3.Distance(goToPos.position, transform.position);
            if(goToPos == transform.position)
            {
                Debug.Log("Je suis à ma position parfaite");
                isLocked = true;
                isZoomed = false;
            }

            Zoom();
        }

        if (isLocked)
        {
            //dist = Vector3.Distance(goToPos.position, transform.position);
            if (canRotate)
            {
                Rotation();
            }
        }

        if(isDeZoomed)
        {
            if (initialPos == transform.position)
            {
                Debug.Log("Je suis à ma position de départ");
                isLocked = false;
                isDeZoomed = false;
            }

            Dezoom();
        }

        /*
        if (dist <= distPerfect)
        {
            isZoomed = false;
        }
        */
    }

    private void Zoom()
    {
        Debug.Log("J'avance!");
        transform.position = Vector3.MoveTowards(transform.position, goToPos, Time.deltaTime * moveSpeed);
    }

    private void Dezoom()
    {
        Debug.Log("Je recule!");
        transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime * moveSpeed);
    }


    private void OnMouseClick()
    {
        if((Input.GetKeyDown(KeyCode.Mouse0)) && outlineScript.isBordered && isLocked == false)
        {
            if (!isZoomed)
            {
                Debug.Log("Click to zoom");
                isZoomed = true;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && isLocked)
        {
            Debug.Log("Click to dezoom");
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