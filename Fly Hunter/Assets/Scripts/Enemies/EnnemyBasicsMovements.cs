using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBasicsMovements : MonoBehaviour
{
    public Collider tapette;
    public Rigidbody fly;
    public bool active;

    public float speed;
    private float step;
    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        


    }
    /*
    void OnCollisionEnter(Collision col)
    {
        active = false;

        if (col.gameObject.name == "haut")
        {
            Destroy(col.gameObject);
        }
    }
    */
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("sa marche");

        if (collision.gameObject.CompareTag("weapon"))
        {
            active = false;

            Debug.Log("sa marche");

            fly.useGravity = true;
            fly.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == tapette)
        {
            active = false;

            Debug.Log("sa marche");

            fly.useGravity = true;
            fly.isKinematic = false;

            GetComponent<Collider>().isTrigger = false;
        }
        

    }



}
