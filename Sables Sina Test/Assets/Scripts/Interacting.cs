using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Interacting : MonoBehaviour
{
    private Animator anim;

    [HideInInspector]

    public Hand m_ActiveHand = null;

    void Start()
    {
        anim = GetComponent<Animator>();

        Debug.Log(transform.rotation.x);
    }
    
    void Update()
    {

    }

    public void Rotate()
    {
        float rotateValue = 90f;

        transform.rotation *= Quaternion.AngleAxis(rotateValue, Vector3.left);
        //transform.Rotate(Vector3.right, rotateValue);
        Debug.Log("Rotation");
        Debug.Log(transform.rotation.x);
    }
    
}


