using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation_Check : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject axis01;
    public GameObject axis02;
    public GameObject axis03;
    public GameObject axis04;
    public GameObject axis05;

    // Vérifie la position parfaite de chaque axe
    public bool perfectRot01 = false;
    public bool perfectRot02 = false;
    public bool perfectRot03 = false;
    public bool perfectRot04 = false;
    public bool perfectRot05 = false;

    public AudioSource audioSrc_EnigmaIsComplete;

    public Use_IntElement[] m_MyScript;

    public GameManager m_MyGM;
    private Outline m_OutlineScript;
    private CanBeDrag m_DragScript;

    public bool enigmaIsSolved = false;

    void Start()
    {
        audioSrc_EnigmaIsComplete = GetComponent<AudioSource>();
        m_MyScript = GetComponentsInChildren<Use_IntElement>();
        m_DragScript = GetComponent<CanBeDrag>();
        m_OutlineScript = GetComponent<Outline>();
    }
    
    void Update()
    {
        Check_AxisRotation();

        EnigmaIsSolved();
    }

    public void Check_AxisRotation()
    {
        if (axis01.transform.rotation.x == 0f && !enigmaIsSolved)
        {
            perfectRot01 = true;
            //Debug.Log(transform.rotation.w);
            print("Perfect Rotation 01");
            print(perfectRot01);
        }

        else
        {
            perfectRot01 = false;
            print(perfectRot01);
        }

        if (axis02.transform.rotation.x == 0f && !enigmaIsSolved)
        {
            perfectRot02 = true;
            Debug.Log(transform.rotation.w);
            print("Perfect Rotation 02");
        }

        else
        {
            perfectRot02 = false;
            print(perfectRot02);
        }

        if (axis03.transform.rotation.x == 0f && !enigmaIsSolved)
        {
            perfectRot03 = true;
            Debug.Log(transform.rotation.w);
            print("Perfect Rotation 03");
        }

        else
        {
            perfectRot03 = false;
            print(perfectRot03);
        }

        if (axis04.transform.rotation.x == 0f && !enigmaIsSolved)
        {
            perfectRot04 = true;
            Debug.Log(transform.rotation.w);
            print("Perfect Rotation 04");
        }

        else
        {
            perfectRot04 = false;
            print(perfectRot04);
        }

        if (axis05.transform.rotation.w == -1.0 && !enigmaIsSolved)
        {
            perfectRot05 = true;
            Debug.Log(transform.rotation.w);
            print("Perfect Rotation 05");
        }

        else
        {
            perfectRot05 = false;
            print(perfectRot05);
        }

        
    }

    private void EnigmaIsSolved()
    {
        if (perfectRot01 && perfectRot02 && perfectRot03 && perfectRot04 && perfectRot05)
        {
            // L'énigme est résolue
            enigmaIsSolved = true;

            // Une énigme a été résolue
            m_MyGM.enigmeCompleteNumber++;

            if (enigmaIsSolved)
            {
                // Reset des bool
                perfectRot01 = false;
                perfectRot02 = false;
                perfectRot03 = false;
                perfectRot04 = false;
                perfectRot05 = false;
            }
        }

        else if (!perfectRot01 && !perfectRot02 && !perfectRot03 && !perfectRot04 && !perfectRot05)
        {
            // Dezoom l'object, il n'est plus interactif et ne peut plus être surligné
            m_DragScript.Dezoom();
            m_DragScript.isInteractive = false;
            m_DragScript.isLocked = false;
            m_OutlineScript.GetComponent<Renderer>().material = m_OutlineScript.nonBordered;
        }
    }

}


