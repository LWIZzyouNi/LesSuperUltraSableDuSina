using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stele_Elem : MonoBehaviour {

    public GameObject[] element;

    private int randomNumber = 0;
    public int elementalNumber = 0;
        
    public bool hasBeenChecked = false;

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
        hasBeenChecked = true;

        randomNumber = Random.Range(0, element.Length);

        element[randomNumber].SetActive(true);

        if (element[0].activeInHierarchy)
        {
            elementalNumber = 1;
            Debug.Log("elemental 0 is active" + elementalNumber);
        }
        else if (element[1].activeInHierarchy)
        {
            elementalNumber = 2;
            Debug.Log("elemental 1 is active" + elementalNumber);
        }
        else if (element[2].activeInHierarchy)
        {
            elementalNumber = 3;
            Debug.Log("elemental 2 is active" + elementalNumber);
        }
        else if (element[3].activeInHierarchy)
        {
            elementalNumber = 4;
            Debug.Log("elemental 3 is active" + elementalNumber);
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
