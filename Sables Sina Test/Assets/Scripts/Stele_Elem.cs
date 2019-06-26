using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stele_Elem : MonoBehaviour {

    public GameObject[] element;

    private int randomNumber = 0;
    public int elementalNumber = 0;


    // Use this for initialization
    void Start () {
        getChild();
        ActiveChild();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void getChild()
    {
        element = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            element[i] = transform.GetChild(i).gameObject;
        }
    }

    private void ActiveChild()
    {
        randomNumber = Random.Range(0, element.Length);

        element[randomNumber].SetActive(true);

        if (element[0].activeInHierarchy)
        {
            elementalNumber = 1;
            Debug.Log("elemental 0 is active" + elementalNumber);
            Debug.LogWarning("Axis05 Rot expected is 0");

        }
        else if (element[1].activeInHierarchy)
        {
            elementalNumber = 2;
            Debug.Log("elemental 1 is active" + elementalNumber);
            Debug.LogWarning("Axis05 Rot expected is 90");
        }
        else if (element[2].activeInHierarchy)
        {
            elementalNumber = 3;
            Debug.Log("elemental 2 is active" + elementalNumber);
            Debug.LogWarning("Axis05 Rot expected is 180");
        }
        else if (element[3].activeInHierarchy)
        {
            elementalNumber = 4;
            Debug.Log("elemental 3 is active" + elementalNumber);
            Debug.Log("Axis05 Rot expected is 270");
        }
    }
    /*
    private void ElementalCheck()
    {
        if (element[0].activeInHierarchy)
        {

        }
        else if (element[1].activeInHierarchy)
        {

        }
        else if (element[2].activeInHierarchy)
        {

        }
        else if (element[3].activeInHierarchy)
        {

        }
    }*/
}
