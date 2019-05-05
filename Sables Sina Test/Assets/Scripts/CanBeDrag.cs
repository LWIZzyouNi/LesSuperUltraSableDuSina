using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CanBeDrag : MonoBehaviour
{
    private float Dist = 0f;
    public float DistPerfect = 1f;

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;

    public Outline outlineScript;

    public float moveSpeed = 5f;
    private Transform goToPos;
    private bool isZoomed = false;

    private bool isLocked = false;


    // Use this for initialization
    void Start()
    {
        goToPos = HeadSetManager.s_Singleton.GetTrsDest();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (m_GrabAction.GetStateDown(m_Pose.inputSource))
         {
             if (isLocked == false)
             {
                 isLocked = true;
                 isZoomed = true;
             }
         }
         */

        if (isZoomed)
        {
            Dist = Vector3.Distance(goToPos.position, transform.position);
            Debug.Log("Je suis à ma position parfaite");

            Zoom();
        }

        if (Dist <= DistPerfect)
        {
            isZoomed = false;
        }
    }

    private void Zoom()
    {
        transform.position = Vector3.MoveTowards(transform.position, goToPos.position, Time.deltaTime * moveSpeed);
    }

   
    private void OnMouseDown()
    {
        if(outlineScript.isBordered)
        {
            if (!isLocked)
            {
                isLocked = true;
                isZoomed = true;
            }
        }
      
    }

}