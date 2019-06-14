using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour {
    
    public Material nonOutlined;
    public Material outlined;

    public bool isOutlined = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item is outlined");

        if (other.gameObject.CompareTag("Controller"))
        {
            GetComponent<Renderer>().material = outlined;
            isOutlined = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Item is outlined");

        if (other.gameObject.CompareTag("Controller"))
        {
            GetComponent<Renderer>().material = nonOutlined;
            isOutlined = false;
        }
    }
}
