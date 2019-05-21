using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour {
    
    public Material nonOutlined;
    public Material outlined;

    public bool isOutlined = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("LaserPointer"))
        {
            GetComponent<Renderer>().material = outlined;
            isOutlined = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
            GetComponent<Renderer>().material = nonOutlined;
            isOutlined = false;
    }
}
