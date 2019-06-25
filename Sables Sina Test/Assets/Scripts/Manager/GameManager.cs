using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    ///// TOUT CE QUI CONCERNE LE JEU EN LUI MEME /////
    // La valeur de référence pour toute la game!
    public int gameValue = 0;
    public int error = 0;
    public int numberMaxError = 1;
    public float fadeTime = 0.5f;
    // Les Timer
    public float timer = 0;

    // Les "Do Once"
    private bool timerDoOnce = false;

    // Le compte des énigmes
    private int enigmeNumber = 0;
    public int enigmeCompleteNumber = 0;
    public GameObject[] loupiotes;
    public GameObject[] door;
    public int roomNumber = 1;
    public bool canPassRoom = true;

    // L'énigme des bouttons
    public GameObject button;
    public List<GameObject> spawnPointButton;
    public int numberOfButtonOn = 0;
    private  GameObject tmpsButton;

    // Les variables pour la stèle du BallBoard
    public GameObject steleBallBoard;
    public List<GameObject> spawnSteleBallBoard;
    public int spawnPointSteleBallBoard = 0;

    // Le singleton
    public static GameManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
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
        ButtonGestion();
        SpawnStele();

        enigmeNumber = loupiotes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
        CheckError();
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
        int tmpsRandom = Random.Range(0, 4);
        //Debug.Log("tmpsRandom " + tmpsRandom);

        switch (tmpsRandom)
        {
            case 0:
                gameValue = 2;
                break;

            case 1:
                gameValue = 3;
                break;

            case 2:
                gameValue = 4;
                break;

            case 3:
                gameValue = 5;
                break;
        }

        int tmpsSpawnPointChoosed;

        spawnPointButton.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint_Button"));

        for (int i = 0; i < gameValue; i++)
        {
            tmpsSpawnPointChoosed = Random.Range(0, spawnPointButton.Count);

            Vector3 tmpsVector = spawnPointButton[tmpsSpawnPointChoosed].transform.position;

            tmpsButton = Instantiate(button, spawnPointButton[tmpsSpawnPointChoosed].transform.position, spawnPointButton[tmpsSpawnPointChoosed].transform.rotation);
            tmpsButton.transform.eulerAngles += new Vector3(0f, 0f, 90f);
            //tmpsButton.transform.position = tmpsVector;
            spawnPointButton.Remove(spawnPointButton[tmpsSpawnPointChoosed]);
        }
    }

    void SpawnStele()
    {
        spawnSteleBallBoard.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint_Stele"));

        spawnPointSteleBallBoard = Random.Range(0, spawnSteleBallBoard.Count);
        GameObject tmpsButton;

        Vector3 tmpsVector = spawnSteleBallBoard[spawnPointSteleBallBoard].transform.position;

        tmpsButton = Instantiate(steleBallBoard);
        tmpsButton.transform.position = tmpsVector;

        spawnSteleBallBoard.Remove(spawnSteleBallBoard[spawnPointSteleBallBoard]);

    }

    void TimerCount ()
    {
        timer -= 1 * Time.deltaTime;

        if(timer <= 0 && timerDoOnce == false)
        {
            timer = 0;
            timerDoOnce = true;
            EndGame();
        }
    }

    public void ActivateButton ()
    {
        numberOfButtonOn++;
        Debug.Log("++");
        Debug.Log("SPBC " + gameValue);

        if(numberOfButtonOn == gameValue)
        {
            Debug.Log("enigme ++");
            enigmeCompleteNumber++;
        }
    }

    void CheckError ()
    {
        if(error == numberMaxError)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("SceneTestTom");
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        SteamVR_Fade.Start(Color.black, fadeTime, true);

        Debug.Log(" Fade is starting ");

        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SceneLDClement");
    }
}