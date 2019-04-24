using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTapette : MonoBehaviour {

    public Collider tapette;
    public Rigidbody fly;
    //EnnemyBasicsMovements myScript;


	// Use this for initialization
	void Start () {
        //fly = GetComponent<Rigidbody>();
        //myScript = GetComponent<EnnemyBasicsMovements>();

	}
	
	// Update is called once per frame
	void Update () {
		

	}


    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("sa marche");

        if (collision.gameObject.CompareTag("weapon"))
        {
            Debug.Log("sa marche");

            fly.useGravity = true;
            fly.isKinematic = false;

            GetComponent<EnnemyBasicsMovements>().enabled = false;
        }



    }
}
