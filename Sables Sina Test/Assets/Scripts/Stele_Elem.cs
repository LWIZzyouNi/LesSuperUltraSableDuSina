using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stele_Elem : MonoBehaviour {

    public GameObject[] element;

    private int randomNumber = 0;

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
    }
}
