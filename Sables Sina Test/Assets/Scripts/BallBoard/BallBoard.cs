using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBoard : MonoBehaviour
{
    private AudioSource audioSrc_EnigmaIsComplete;
    private CanBeDrag m_DragScript;
    private Outline m_OutlineScript;

    public bool enigmaIsSolved = false;
    private bool doOnce = false;

    // Use this for initialization
    void Start()
    {
        m_DragScript = GetComponent<CanBeDrag>();
        m_OutlineScript = GetComponent<Outline>();
        audioSrc_EnigmaIsComplete = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EnigmaIsSolved();
    }

    private void EnigmaIsSolved()
    {
        if (enigmaIsSolved)
        {
            if (!doOnce)
            {
                GameManager.s_Singleton.enigmeCompleteNumber++;
                audioSrc_EnigmaIsComplete.Play();
                doOnce = true;
            }

            m_DragScript.Dezoom();
            m_DragScript.isLocked = false;
            m_DragScript.isInteractive = false;
            m_DragScript.canRotate = false;

            m_OutlineScript.GetComponent<Renderer>().material = m_OutlineScript.nonOutlined;
            m_OutlineScript.isOutlined = false;
        }
    }

}