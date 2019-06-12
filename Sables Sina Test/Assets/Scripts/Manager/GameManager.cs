using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 0;
    private bool timerDoOnce = false;

    private int enigmeNumber = 0;
    public int enigmeCompleteNumber = 0;

    public static GameManager s_Singleton;

    public GameObject[] loupiotes;
    public GameObject[] door;

    public int roomNumber = 1;
    public bool canPassRoom = true;

    private void Awake()
    {
        if(s_Singleton != null)
        {
            Destroy(gameObject);
        }

        else
        {
            s_Singleton = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        enigmeNumber = loupiotes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();

        Validation();
    }

    void Validation()
    {
        Debug.Log("Valide le passage");
        for (int i = 0; i < enigmeCompleteNumber; i++)
        {
            loupiotes[i].GetComponent<Display_EnigmaIsSolved>().activated = true;

            if(enigmeCompleteNumber == enigmeNumber && canPassRoom == true)
            {
                int tmpDoorDetector = roomNumber - 1;
                bool doorOpen = door[tmpDoorDetector].GetComponent<OpenDoor>().activated = true;
                roomNumber++;
                canPassRoom = false;
            }
        }
    }

    void TimerCount ()
    {
        timer -= 1 * Time.deltaTime;

        if(timer <= 0 && timerDoOnce == false)
        {
            timerDoOnce = true;
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("SceneTestTom");
    }
}