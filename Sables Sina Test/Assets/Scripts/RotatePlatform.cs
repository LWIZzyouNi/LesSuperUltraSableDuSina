using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {

    private Outline_IntElement m_Outline_IntElem_Script;

    Quaternion startRot;

    public bool canBoucle = false;

    // Use this for initialization
    void Start ()
    {
        m_Outline_IntElem_Script = GetComponent<Outline_IntElement>();
        startRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (/*m_Outline_IntElem_Script.elementIsOutlined&& */ Input.GetKeyDown(KeyCode.Mouse1))
        {
            PlatformRotate();
            //Debug.Log(transform.eulerAngles.z);
            print(transform.rotation.z);
        }   
    }

    //transform.rotation.z == 0.3420201f && transform.rotation.w == 0.9396927f

    private void PlatformRotate()
    {
        //0

        if (transform.rotation.z == 0)
        {
            print("rentre dans le else if 0");
            if (canBoucle)
            {
                transform.Rotate(new Vector3(0, 0, -40f));
                canBoucle = false;
                print("To -40");
                return;
            }

            if (!canBoucle)
            {
                transform.Rotate(new Vector3(0, 0, 40f));
                canBoucle = true;
                print("To 40");
                return;
            }
        }
        else
        {
            print("Active method");
            // 40
            if (canBoucle)
            {
                print("From 40 To 0");
                //canBoucle = true;
                transform.Rotate(new Vector3(0, 0, -40f));
                startRot.Set(0, 0, 0, 0);
                transform.rotation = startRot;
                return;
            }

            // -40
            if (!canBoucle)
            {
                print("From -40 To 0");
                //canBoucle = false;
                transform.Rotate(new Vector3(0, 0, 40f));
                startRot.Set(0, 0, 0, 0);
                transform.rotation = startRot;
                return;
            }
        }
    }
}
