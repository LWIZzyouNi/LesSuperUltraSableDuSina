using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_CheckPos : MonoBehaviour
{
    public bool ballInZone01 = false;
    public bool ballInZone02 = false;
    public bool ballInZone03 = false;
    public bool ballInZone04 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColoredZone01"))
        {
            Debug.Log("Ball is in ColoredZone01");
            ballInZone01 = true;
        }

        else if (other.CompareTag("ColoredZone02"))
        {
            Debug.Log("Ball is in ColoredZone02");
            ballInZone02 = true;
        }

        else if (other.CompareTag("ColoredZone03"))
        {
            Debug.Log("Ball is in ColoredZone03");
            ballInZone03 = true;
        }

        else if (other.CompareTag("ColoredZone04"))
        {
            Debug.Log("Ball is in ColoredZone04");
            ballInZone04 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ColoredZone01"))
        {
            Debug.Log("Ball is out of ColoredZone01");
            ballInZone01 = false;
        }

        else if (other.CompareTag("ColoredZone02"))
        {
            Debug.Log("Ball is out of ColoredZone02");
            ballInZone02 = false;
        }

        else if (other.CompareTag("ColoredZone03"))
        {
            Debug.Log("Ball is out of ColoredZone03");
            ballInZone03 = false;
        }

        else if (other.CompareTag("ColoredZone04"))
        {
            Debug.Log("Ball is out of ColoredZone04");
            ballInZone04 = false;
        }
    }
}
