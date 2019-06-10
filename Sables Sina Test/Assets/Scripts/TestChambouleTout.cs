using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChambouleTout : MonoBehaviour {

    public GameObject prefab;

    public Transform initialPos;

    private Vector3 vectorInitialPos = Vector3.zero;
   

    
    // Use this for initialization
    void Start ()
    {
        vectorInitialPos = initialPos.transform.position;
	}

    private void OnTriggerExit(Collider other)
    {
            Instantiate(prefab, vectorInitialPos, Quaternion.identity);
    }
}
