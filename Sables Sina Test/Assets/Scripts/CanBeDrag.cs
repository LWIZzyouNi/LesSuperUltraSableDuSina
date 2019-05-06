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
    private bool isLocked = false;


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

        Debug.Log("Zoom " + isZoomed);
        Debug.Log("Lock " + isLocked);

        if (isZoomed)
        {
            //dist = Vector3.Distance(goToPos.position, transform.position);
            if(goToPos == transform.position)
            {
                Debug.Log("Je suis à ma position parfaite");
                isLocked = true;
            }

            Zoom();
        }

        if (isLocked)
        {
            //dist = Vector3.Distance(goToPos.position, transform.position);
            if (initialPos == transform.position)
            {
                Debug.Log("Je suis à ma position de départ");
                isLocked = false;
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
        transform.position = Vector3.MoveTowards(transform.position, goToPos, Time.deltaTime * moveSpeed);
    }

    private void Dezoom()
    {
        transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime * moveSpeed);
    }


    private void OnMouseClick()
    {
        if((Input.GetKeyDown(KeyCode.Mouse0)) && outlineScript.isBordered)
        {
            if (!isZoomed)
            {
                Debug.Log("Click to zoom");
                isZoomed = true;
            }

            if ((Input.GetKeyDown(KeyCode.Mouse0)) && isLocked)
            {
                Debug.Log("Click to dezoom");
                isZoomed = false;
            }
        }

    }
}