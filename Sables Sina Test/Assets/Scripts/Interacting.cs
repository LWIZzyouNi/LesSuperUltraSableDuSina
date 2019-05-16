using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Interacting : MonoBehaviour
{
    private Animator anim;
    public int XAxis = 0;
    public int rotationSpeed;

    public Use_IntElement m_MyScript;

    private int incrTurn = 1;
    public float angle = 0;

    public Quaternion baseRotate;

    [HideInInspector]

    public Hand m_ActiveHand = null;

    void Start()
    {
        baseRotate = transform.rotation;
        anim = GetComponent<Animator>();

    }
    
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        //float rotateValue = 90f;
        
        if(m_MyScript.isRotating)
        {
            float angle = 90f;

            //XAxis = rotationSpeed;
            //transform.Rotate(XAxis, 0f, 0f);
            print("Rotation XAxis");
            
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.left);

            Debug.Log(angle);

            if (angle == 90 * incrTurn)
            {
                m_MyScript.isRotating = false;
                transform.eulerAngles = new Vector3(90f, 0f, 0f);
                switch (incrTurn)
                {
                    case 1:

                        incrTurn = 2;
                        break;
                    case 2:
                        incrTurn = 3;
                        break;
                    case 3:
                        incrTurn = 4;
                        break;
                    case 4:
                        incrTurn = 1;
                        break;
                }
            }
        }

        

        //transform.eulerAngles = new Vector3(90f, 0f, 0f);
        //transform.Rotate(-90f, 0f, 0f);
        //transform.rotation *= Quaternion.AngleAxis(rotateValue, Vector3.left);
        //transform.Rotate(Vector3.right, rotateValue);
        /*
        Debug.Log("Rotation");
        Debug.Log(transform.eulerAngles.x);
        */
    }
    
}


