using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enigmeNumber = 0;
    public int enigmeCompleteNumber = 0;

    [SerializeField]
    private AxisRotation_Check m_MyScript;

    public static GameManager s_Singleton;

    public GameObject[] loupiotes;

    private void Awake()
    {
        if(s_Singleton != null)
        {
            Destroy(gameObject);
        }

        else
        {
            s_Singleton = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        enigmeNumber = loupiotes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Validation();
        /*
        if(m_MyScript.enigmaIsSolved)
        {
            enigmeCompleteNumber = 1;
        }
        */
    }

    void Validation()
    {
        for (int i = 0; i < enigmeCompleteNumber; i++)
        {
            loupiotes[i].GetComponent<Display_EnigmaIsSolved>().activated = true;
        }
    }
}