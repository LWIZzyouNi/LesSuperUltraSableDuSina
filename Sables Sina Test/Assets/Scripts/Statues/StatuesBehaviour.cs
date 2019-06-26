using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuesBehaviour : MonoBehaviour
{
    private int[] numbers = { 1, 2 };
    public int randomNumber = 0;

    public bool rotIs90 = false;
    public bool rotIs270 = false;

    private void Awake()
    {
        AssignRandomRotation();
        CheckOrientation();
    }

    // Use this for initialization
    void Start()
    {
        //AssignRandomRotation();
        //CheckOrientation();
    }

    private void AssignRandomRotation()
    {
        randomNumber = Random.Range(0, numbers.Length);

        switch (randomNumber)
        {
            case 1:
                gameObject.transform.rotation = Quaternion.Euler(270f, 90f, 0f);
                break;

            default:
                gameObject.transform.rotation = Quaternion.Euler(270f, 270f, 0f);
                break;
        }
    }

    private void CheckOrientation()
    {
        // Valeurs de rotations possibles
        // 0 = .w 1
        // 90 = .y 0.7071068  /  .w 0.7071068 // .x 270 = y. -0.5 w. -0.5
        // 180 = .y 1
        // 270 = .y 0.7071068 / .w -0.7071068 // .x 270 = y. -0.5 w. 0.5

        if (transform.rotation.y == -0.5 && transform.rotation.w == -0.5)
        {
            rotIs90 = true;
        }

        else if (transform.rotation.y == -0.5 && transform.rotation.w == 0.5)
        {
            rotIs270 = true;
        }
    }
}
