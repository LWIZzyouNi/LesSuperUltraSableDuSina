using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    public GameObject moveText;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            moveText.SetActive(false);
        }
    }
}
