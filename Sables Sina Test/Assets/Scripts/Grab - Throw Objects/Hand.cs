using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour {

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interacting m_CurrentInterectable = null;
    public List<Interacting> m_ContactInterectables = new List<Interacting>();

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }


	private void Update ()
    {
		//Down
        if(m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " Trigger Down");
            Pickup();
        }

        //Up
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + " Trigger Up");
            Drop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInterectables.Add(other.gameObject.GetComponent<Interacting>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInterectables.Remove(other.gameObject.GetComponent<Interacting>());
    }

    public void Pickup()
    {
        // Get nearest 
        m_CurrentInterectable = GetNearestInterectable();

        // Null Check
        if (!m_CurrentInterectable)
            return;

        // Already held, check
        if (m_CurrentInterectable.m_ActiveHand)
            m_CurrentInterectable.m_ActiveHand.Drop();

        // Position
        m_CurrentInterectable.transform.position = transform.position;

        // Attach
        Rigidbody targetBody = m_CurrentInterectable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        // Set active hand
        m_CurrentInterectable.m_ActiveHand = this;
    }

    public void Drop()
    {
        // Null check
        if (!m_CurrentInterectable)
            return;

        // Apply velocity
        Rigidbody targetBody = m_CurrentInterectable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();

        // Detach
        m_Joint.connectedBody = null;

        // Clear
        m_CurrentInterectable.m_ActiveHand = null;
        m_CurrentInterectable = null;
    }

    private Interacting GetNearestInterectable()
    {
        Interacting nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(Interacting interectable in m_ContactInterectables)
        {
            distance = (interectable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interectable;
            }
        }

        return nearest;
    }
}
