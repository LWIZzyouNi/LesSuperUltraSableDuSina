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
    [HideInInspector]
    public bool perfectRot01 = false;
    [HideInInspector]
    public bool perfectRot02 = true;
    [HideInInspector]
    public bool perfectRot03 = true;
    [HideInInspector]
    public bool perfectRot04 = true;
    [HideInInspector]
    public bool perfectRot05 = true;

    public AudioSource audioSrc_EnigmaIsComplete;

    public Use_IntElement[] m_MyScript;

    public GameManager m_MyGM;

    public bool enigmaIsSolved = false;

    void Start()
    {
        audioSrc_EnigmaIsComplete = GetComponent<AudioSource>();
        m_MyScript = GetComponentsInChildren<Use_IntElement>();
    }
    
    void Update()
    {
        //Check_AxisRotation();

        if (perfectRot01 && perfectRot02 && perfectRot03 && perfectRot04 && perfectRot05)
        {
            enigmaIsSolved = true;
            Debug.Log(enigmaIsSolved);
            m_MyGM.enigmeCompleteNumber++;
            print("merde");
            perfectRot01 = false;
            perfectRot02 = false;
            perfectRot03 = false;
            perfectRot04 = false;
            perfectRot05 = false;
        }


    }

    public void Check_AxisRotation()
    {
        if (axis01.transform.rotation.w == -1.0)
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

        if (axis02.transform.rotation.w == -1.0)
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

        if (axis03.transform.rotation.w == -1.0)
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

        if (axis04.transform.rotation.w == -1.0)
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

        if (axis05.transform.rotation.w == -1.0)
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

}


