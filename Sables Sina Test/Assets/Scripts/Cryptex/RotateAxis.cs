﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateAxis : MonoBehaviour {

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    private Outline m_MyScript;
    
    public Animator parentAnim;

    public float timerUntilCanClick = 0.5f;
    public bool isInteracting = false;

    // États animation
    private bool state01 = false;
    private bool state02 = false;
    private bool state03 = false;
    private bool state04 = false;
    private bool canPlay = false;
    public bool isRotating = false;
    
    public AudioClip audioSrc_AxisRota;

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
        m_MyScript = GetComponent<Outline>();
        //m_MyScript3 = GetComponentInParent<CanBeDrag>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!isInteracting)
        {
            OnMouseClick();
        }
        
        //print(axis01.transform.eulerAngles.x);

    }

    private void OnMouseClick()
    {
        if (m_MyScript.isOutlined)
        {
            // Lorsque l'objet est lock, donc zoomé, les éléments interactifs sur l'objet sont activables / utilisables lorsqu'on clique droit.
            if (buttonAction.GetState(handType01) ||
                        buttonAction.GetState(handType02) ||
                        Input.GetKeyDown(KeyCode.Space)) 
            {
                canPlay = false;
                isRotating = true;
                SoundManager.instance.RandomizeSFX(audioSrc_AxisRota);
                // Si l'objet tourne, que le premier état de l'animation ne s'est pas joué, et que l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state01 && !canPlay)
                {
                    // Le premier état de l'animation peut se jouer (autrement dit, l'animation du premier état sera considérée comme jouée)..
                    state01 = true;

                    // Reset du quatrième état de l'animation pour effectuer un tour à 360°..
                    if (state01)
                    {
                        state04 = false;
                        parentAnim.SetBool("State04", false);
                    }

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    if (canPlay)
                    {
                        // L'animation, correspondant au premier état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis01");
                        parentAnim.SetBool("State01", true);
                        StartCoroutine(WaitUntilClick());
                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le second état de l'animation ne s'est pas joué, et que l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state02 && !canPlay)
                {
                    // Le second état de l'animation peut se jouer (autrement dit, l'animation du deuxième état sera considérée comme jouée)..
                    state02 = true;

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au second état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis02");
                        parentAnim.SetBool("State02", true);
                        StartCoroutine(WaitUntilClick());
                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le troisième état de l'animation ne s'est pas joué, et que l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state03 && !canPlay)
                {
                    // Le troisième état de l'animation peut se jouer (autrement dit, l'animation du troisième état sera considérée comme jouée)..
                    state03 = true;

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au troisième état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis03");
                        parentAnim.SetBool("State03", true);
                        StartCoroutine(WaitUntilClick());
                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le quatrième état de l'animation ne s'est pas joué, et que l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state04 && !canPlay)
                {
                    // Le quatrième état de l'animation peut se jouer (autrement dit, l'animation du quatrième état sera considérée comme jouée)..
                    state04 = true;

                    // Reset de la boucle pour un tour à 360°..
                    if (state04)
                    {
                        state01 = false;
                        state02 = false;
                        state03 = false;

                        parentAnim.SetBool("State01", false);
                        parentAnim.SetBool("State02", false);
                        parentAnim.SetBool("State03", false);
                    }

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au quatrième état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis04");
                        parentAnim.SetBool("State04", true);
                        parentAnim.SetBool("CanBoucle", true);
                        StartCoroutine(WaitUntilClick());
                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }
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
