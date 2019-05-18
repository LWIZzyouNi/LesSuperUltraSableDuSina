using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enigmeNumber = 0;
    public int enigmeCompleteNumber = 0;

    public GameObject[] loupiotes;
    
    // Use this for initialization
    void Start()
    {
        enigmeNumber = loupiotes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Validation();
    }

    void Validation()
    {
        for (int i = 0; i < enigmeCompleteNumber; i++)
        {
            loupiotes[i].GetComponent<Loupiote>().activated = true;
        }
    }
}