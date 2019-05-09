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
    }
    
    void Update()
    {

    }

    public void Rotate()
    {
        float rotateValue = 90f;

        transform.Rotate(Vector3.right, rotateValue);

        anim.Play("Rotation01");
    }
    
}


