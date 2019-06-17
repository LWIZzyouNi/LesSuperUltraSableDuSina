using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // La valeur de référence pour toute la game!
    public int gameValue = 0;

    public float timer = 0;
    private bool timerDoOnce = false;

    private int enigmeNumber = 0;
    public int enigmeCompleteNumber = 0;

    public static GameManager s_Singleton;

    public GameObject button;
    public List<GameObject> spawnPointButton;
    private int numberOfButton = 0;

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
        gameValue = Random.Range(2,6);

        ButtonGestion();

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

    void ButtonGestion ()
    {
        int tmpsSpawnPointChoosed;

        spawnPointButton.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint_Button"));
        foreach (GameObject SpawnPoint_Button in spawnPointButton)
        {
            numberOfButton++;
        }

        for (int i = 0; i < gameValue; i++)
        {
            tmpsSpawnPointChoosed = Random.Range(0, numberOfButton);
            GameObject tmpsButton;

            Vector3 tmpsVector = spawnPointButton[tmpsSpawnPointChoosed].transform.position;

            tmpsButton = Instantiate(button);
            tmpsButton.transform.position = tmpsVector;
            
            spawnPointButton.Remove(spawnPointButton[tmpsSpawnPointChoosed]);
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