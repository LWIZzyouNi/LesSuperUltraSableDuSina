using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuesManager : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject[] prefabs;
    public GameObject[] prefabsInstantiated;

    public List<StatuesBehaviour> m_StatuesBehaviour = new List<StatuesBehaviour>();

    public Transform spawnPointsPos01;
    public Transform spawnPointsPos02;

    // CheckStatuesValue results
    [HideInInspector] public bool statue01IsHigher = false;
    [HideInInspector] public bool statue01IsLower = false;

    public bool statuesAreEquals = false;
    public bool statuesAreLittleOnes = false;
    public bool statuesAreMediumOnes = false;

    //statue01 90 / 270
    public bool statue01IsNinety = false;
    public bool statue01IsTwoHundredSeventy = false;

    //rstatue02 90 / 270
    public bool statue02IsNinety = false;
    public bool statue02IsTwoHundredSeventy = false;
    private int[] numbers = { 1, 2, 3, 4, 5, 6 };
    private int randomNumber = 0;

    private float offSet25 = 0.25f;

    // Use this for initialization
    void Start ()
    {
        getChild();
        SpawnObjectRandomly();
        CheckStatuesScale();
        SetObjectif();
    }

    public void getChild()
    {
        spawnPoints = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SpawnObjectRandomly()
    {
        randomNumber = Random.Range(0, numbers.Length);

        spawnPointsPos01 = spawnPoints[0].GetComponent<Transform>();
        spawnPointsPos02 = spawnPoints[1].GetComponent<Transform>();
        
        switch (randomNumber)
        {
            case 1:
                Instantiate(prefabs[0], spawnPointsPos01.position, spawnPointsPos01.rotation);
                Instantiate(prefabs[1], spawnPointsPos02.position, spawnPointsPos02.rotation);
                break;

            case 2:
                Instantiate(prefabs[0], spawnPointsPos01.position, spawnPointsPos01.rotation);
                Instantiate(prefabs[0], spawnPointsPos02.position, spawnPointsPos02.rotation);
                break;

            case 3:
                Instantiate(prefabs[1], spawnPointsPos01.position, spawnPointsPos01.rotation);
                Instantiate(prefabs[0], spawnPointsPos02.position, spawnPointsPos02.rotation);
                break;
                
            default:
                Instantiate(prefabs[1], spawnPointsPos01.position, spawnPointsPos01.rotation);
                Instantiate(prefabs[1], spawnPointsPos02.position, spawnPointsPos02.rotation);
                break;
        }
    }
    
    public void CheckStatuesScale()
    {

        prefabsInstantiated = GameObject.FindGameObjectsWithTag("Statue");

        m_StatuesBehaviour.Add(prefabsInstantiated[0].GetComponent<StatuesBehaviour>());
        m_StatuesBehaviour.Add(prefabsInstantiated[1].GetComponent<StatuesBehaviour>());

        if (prefabsInstantiated[0].transform.localScale.y > prefabsInstantiated[1].transform.localScale.y)
        {
            Debug.LogWarning(" First statue is higher than the second ");
            statue01IsHigher = true;

        }

        else if (prefabsInstantiated[0].transform.localScale.y < prefabsInstantiated[1].transform.localScale.y)
        {
            Debug.LogWarning(" First statue is lower than the second ");
            statue01IsLower = true;
        }

        else
        {
            Debug.LogWarning(" First statue has the same height than second statue ");
            statuesAreEquals = true;
        }
    }

    public void SetObjectif()
    {
        // Plus grande
        if (statue01IsHigher)
        {
            Debug.Log("Statue 01 is Higher !");

            // A/C
            if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : première case de la première ligne, dernière case de la dernière colonne, première case de la première ligne, deuxième case de la deuxième ligne, deuxième case de la première colonne, quatrième case de la troisième colonne (7, 12, 3, 6, 2, 8)");
                statue01IsNinety = true;
                statue02IsNinety = true;
            }

            // A/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : troisième case de la deuxième colonne, deuxième case de la deuxième ligne, troisième case de la troisième colonne, troisième case de la première ligne, première case de la quatrième colonne (5, 4, 9, 11, 15)");
                statue01IsNinety = true;
                statue02IsTwoHundredSeventy = true;
            }

            // B/C
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : première case de la quatrième colonne, quatrième case de la quatrième ligne, troisième case de la première colonne, première case de la deuxième ligne, quatrième case de la deuxième colonne (15, 12, 1, 2, 4)");
                statue01IsTwoHundredSeventy = true;
                statue02IsNinety = true;
            }

            // B/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : quatrième case de la deuxième colonne, quatrième case de la première ligne, deuxième case de la troisième colonne, deuxième case de la deuxième ligne, première case de la deuxième colonne (4, 15, 10, 6, 7)");
                statue01IsTwoHundredSeventy = true;
                statue02IsTwoHundredSeventy = true;
            }
        }

        // Plus petite
        if (statue01IsLower)
        {
            Debug.Log("Statue 01 is Lower !");

            // A/C
            if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : deuxième case de la troisième ligne, deuxième case de la deuxième colonne, troisième case de la première ligne, troisième case de la quatrième colonne, quatrième case de la deuxième ligne (5, 6, 11, 13, 14)");
                statue01IsNinety = true;
                statue02IsNinety = true;
            }

            // A/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : deuxième case de la quatrième colonne, troisième case de la première ligne, deuxième case de la troisième colonne, troisième case de la troisième ligne, deuxième case de la deuxième colonne, deuxième case de la troisième ligne (14, 11, 10, 9, 6, 5)");
                statue01IsNinety = true;
                statue02IsTwoHundredSeventy = true;
            }

            // B/C
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : première case de la première colonne, quatrième case de la deuxième ligne, deuxième case de la troisième colonne, deuxième case de la deuxième ligne, deuxième case de la première colonne (3, 14, 10, 6, 2)");
                statue01IsTwoHundredSeventy = true;
                statue02IsNinety = true;
            }

            // B/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : quatrième case de la deuxième colonne, quatrième case de la quatrième ligne, quatrième case de la troisième colonne, deuxième case de la troisième ligne, troisième case de la première colonne (4, 12, 8, 5, 1)");
                statue01IsTwoHundredSeventy = true;
                statue02IsTwoHundredSeventy = true;
            }
        }
        
        // Egalité
        if (statuesAreEquals)
        {
            Debug.Log("Statues are equals!");

            // A/C
            if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : troisième case de la première colonne, première case de la deuxième ligne, troisième case de la deuxième colonne, deuxième case de la deuxième ligne, deuxième case de la troisième colonne, troisième case de la première ligne (1, 2, 5,  6, 10, 11)");
                statue01IsNinety = true;
                statue02IsNinety = true;
            }

            // A/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs90 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : première case de la première ligne, quatrième case de la deuxième colonne, troisième case de la quatrième ligne, première case de la deuxième colonne, quatrième case de la troisième ligne, deuxième case de la quatrième colonne (3, 4, 8, 7, 13, 14)");
                statue01IsNinety = true;
                statue02IsTwoHundredSeventy = true;
            }

            // B/C
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs90)
            {
                Debug.Log("Illuminer les cases suivantes : troisième case de la quatrième colonne, quatrième case de la deuxième ligne, première case de la troisième colonne, première case de la troisième ligne, première case de la première colonne, quatrième case de la deuxième colonne (13, 14, 11, 1, 3, 4)");
                statue01IsTwoHundredSeventy = true;
                statue02IsNinety = true;
            }

            // B/D
            else if (prefabsInstantiated[0].GetComponent<StatuesBehaviour>().rotIs270 && prefabsInstantiated[1].GetComponent<StatuesBehaviour>().rotIs270)
            {
                Debug.Log("Illuminer les cases suivantes : quatrième case de la première ligne, troisième case de la première colonne, troisième case de la quatrième ligne, troisième case de la deuxième colonne, deuxième case de la première ligne, quatrième case de la deuxième colonne (15, 1, 8, 5, 7, 4");
                statue01IsTwoHundredSeventy = true;
                statue02IsTwoHundredSeventy = true;
            }
        }
    }
}
