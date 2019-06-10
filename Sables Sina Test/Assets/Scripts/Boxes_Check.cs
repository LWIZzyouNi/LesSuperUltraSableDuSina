using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes_Check : MonoBehaviour {

    public Illuminate[] m_IlluminateScript;
    public GameObject[] boxes;

    public AudioSource audioSrc_EnigmaIsComplete;
    public GameManager m_MyGameManager;
    private CanBeDrag m_DragScript;
    private Outline m_OutlineScript;

    private bool enigmaIsSolved = false;
    private bool isNumberAdded = false;

    public int caseNumber = 0;

    // Use this for initialization
    void Start ()
    {
        m_IlluminateScript = GetComponentsInChildren<Illuminate>();
        m_DragScript = GetComponent<CanBeDrag>();
        m_OutlineScript = GetComponent<Outline>();
        audioSrc_EnigmaIsComplete = GetComponent<AudioSource>();

        getChild();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckBoxes();
        EnigmaIsSolved();
    }

    private void getChild()
    {
        boxes = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            boxes[i] = transform.GetChild(i).gameObject;
        }
    }

    private void CheckBoxes()
    {
        for(int i = 0; i < boxes.Length; i++)
        {
            if (boxes[0].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("Première Case");
            }

            if (boxes[5].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("Deuxième Case");
            }

            if (boxes[10].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("Troisième Case");
            }

            if (boxes[12].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("Quatrième Case");
            }

            if (boxes[7].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("5eme Case");
            }

            if (boxes[3].GetComponent<Illuminate>().isIlluminated)
            {
                Debug.Log("6eme Case");
            }
        }


    }
    
    private void EnigmaIsSolved()
    {
        if (boxes[0].GetComponent<Illuminate>().isIlluminated && boxes[5].GetComponent<Illuminate>().isIlluminated 
                    && boxes[10].GetComponent<Illuminate>().isIlluminated  && boxes[12].GetComponent<Illuminate>().isIlluminated &&
                        boxes[7].GetComponent<Illuminate>().isIlluminated && boxes[3].GetComponent<Illuminate>().isIlluminated &&
                            caseNumber == 6)
        {
            enigmaIsSolved = true;
            Debug.Log(enigmaIsSolved);
            if(!isNumberAdded)
            {
                // Une énigme est résolue
                m_MyGameManager.enigmeCompleteNumber++;
                audioSrc_EnigmaIsComplete.Play();
            }
        }

        if (enigmaIsSolved)
        {
            isNumberAdded = true;
            m_DragScript.Dezoom();
            m_DragScript.isLocked = false;
            m_DragScript.isInteractive = false;
            m_DragScript.canRotate = false;

            m_OutlineScript.GetComponent<Renderer>().material = m_OutlineScript.nonOutlined;
            m_OutlineScript.isOutlined = false;

        }
    }
}
