﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    private Outline outlineScript;

    public GameObject ball;

    private Vector3 ballTransformSave;

    private bool doOnce = false;

    public AudioSource audioSRC;

    // Use this for initialization
    void Start () {
        //transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = true;
        outlineScript = GetComponent<Outline>();
	}
	
	// Update is called once per frame
	void Update () {
        MouseClick();
        SavePosition();
	}

    public void ResetTab()
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        ball.transform.position = ballTransformSave;

        audioSRC.Play();
    }

    private void MouseClick()
    {
        if (outlineScript.isOutlined && transform.parent.gameObject.GetComponent<CanBeDrag>().isLocked == true && transform.parent.gameObject.GetComponent<CanBeDrag>().isInteractive == true)
        {
            transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = true;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ResetTab();
            }
        }
        else
        {
            transform.parent.gameObject.GetComponent<CanBeDrag>().onResetButton = false;
        }
    }

    private void SavePosition()
    {
        if (transform.parent.gameObject.GetComponent<CanBeDrag>().isLocked == true && transform.parent.gameObject.GetComponent<CanBeDrag>().isDeZoomed == false)
        {
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (!doOnce)
            {
                ballTransformSave = ball.transform.position;
                ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                doOnce = true;
            }
        }
    }
}