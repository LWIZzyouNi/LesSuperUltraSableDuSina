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
    public bool perfectRot01 = true;
    [HideInInspector]
    public bool perfectRot02 = true;
    [HideInInspector]
    public bool perfectRot03 = true;
    [HideInInspector]
    public bool perfectRot04 = true;
    [HideInInspector]
    public bool perfectRot05 = true;

    public AudioClip audioSrc_EnigmaIsComplete;

    public RotateAxis[] m_MyScript;

    public GameManager m_MyGameManager;
    //private CanBeDrag m_DragScript;
    //private Outline m_OutlineScript;

    private bool enigmaIsSolved = false;
    private bool isNumberAdded = false;

    void Start()
    {
        m_MyScript = GetComponentsInChildren<RotateAxis>();

        //m_DragScript = GetComponent<CanBeDrag>();
        //m_OutlineScript = GetComponent<Outline>();
    }
    
    void Update()
    {
        Check_AxisRotation();

        EnigmaIsSolved();
    }

    public void Check_AxisRotation()
    {
        //-270
        if (axis01.transform.rotation.x == -0.7071068f && axis01.transform.rotation.w == -0.7071068f && !enigmaIsSolved)
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

        //-90
        if (axis02.transform.rotation.x == -0.7071068f  && axis02.transform.rotation.w == 0.7071068f && !enigmaIsSolved)
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

        //-180
        if (axis03.transform.rotation.x == -1 && !enigmaIsSolved)
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

        //0
        if (axis04.transform.rotation.x == 0  && axis04.transform.rotation.w == 1  && !enigmaIsSolved)
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

        //-180
        if (axis05.transform.rotation.x == -1 && !enigmaIsSolved)
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
            Debug.Log(enigmaIsSolved);

            if(!isNumberAdded)
            {
                // Une énigme est résolue
                m_MyGameManager.enigmeCompleteNumber++;
                SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
            }
        }

        if (enigmaIsSolved)
        {
            perfectRot01 = false;
            perfectRot02 = false;
            perfectRot03 = false;
            perfectRot04 = false;
            perfectRot05 = false;

            isNumberAdded = true;

            /*
            m_DragScript.Dezoom();
            m_DragScript.isLocked = false;
            m_DragScript.isInteractive = false;
            m_DragScript.canRotate = false;

            m_OutlineScript.GetComponent<Renderer>().material = m_OutlineScript.nonOutlined;
            m_OutlineScript.isOutlined = false;
            */
        }
    }
}


