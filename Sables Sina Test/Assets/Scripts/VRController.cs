﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour {

    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig = null;
    private Transform m_Head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start ()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleHead();
        CalculateMovement();
        HandleHeight();

    }

    private void HandleHead()
    {
        // Store current position
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        // Rotation
        transform.eulerAngles = new Vector3 
    }

    private void CalculateMovement()
    {

    }

    private void HandleHeight()
    {

    }
}
