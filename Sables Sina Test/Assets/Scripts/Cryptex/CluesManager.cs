using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour {

    // Every possible Spawns for sprites
    private GameObject[] cluesSpawnPoints;

    //Square spawns
    private Transform spawnPointsPos01;
    private Transform spawnPointsPos02;

    // Sphere spawns
    private Transform spawnPointsPos03;
    private Transform spawnPointsPos04;

    // Première case carée
    public GameObject[] m_SquareSpriteRenderer01;
    // Deuxième case carée
    public GameObject[] m_SquareSpriteRenderer02;

    // Première case sphérique
    public GameObject[] m_SphereSpriteRenderer01;
    // Deuxième case sphérique
    public GameObject[] m_SphereSpriteRenderer02;

    // Référence booléan check du sprite pour chaque case
    [HideInInspector] public bool isSpriteRenderer01Image01 = false;
    [HideInInspector] public bool isSpriteRenderer01Image02 = false;
    //
    [HideInInspector] public bool isSpriteRenderer02Image01 = false;
    [HideInInspector] public bool isSpriteRenderer02Image02 = false;
    //
    [HideInInspector] public bool isSpriteRenderer03Image01 = false;
    [HideInInspector] public bool isSpriteRenderer03Image02 = false;
    //
    [HideInInspector] public bool isSpriteRenderer04Image01 = false;
    [HideInInspector] public bool isSpriteRenderer04Image02 = false;

    // SetObjectif référence booléan 
    // For the two square sprites :
    // AA
    public bool axis01RotaExpectedIs0 = false;
    // AB
    public bool axis01RotaExpectedIs90 = false;
    // BA
    public bool axis01RotaExpectedIs180 = false;
    // BB
    public bool axis01RotaExpectedIs270 = false;

    // For the two sphere sprites :
    // AA
    public bool axis02RotaExpectedIs0 = false;
    // AB
    public bool axis02RotaExpectedIs90 = false;
    // BA
    public bool axis02RotaExpectedIs180 = false;
    // BB
    public bool axis02RotaExpectedIs270 = false;

    // Just random index to draw a sprite at start
    private int randomSprite01 = 0;
    private int randomSprite02 = 0;
    private int randomSprite03 = 0;
    private int randomSprite04 = 0;

    // Use this for initialization
    void Start ()
    {
        getChild();
        AssignRandomSprite();
        CheckSprites();
        SetObjectif();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void getChild()
    {
        cluesSpawnPoints = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            cluesSpawnPoints[i] = transform.GetChild(i).gameObject;
        }
    }

    private void AssignRandomSprite()
    {
        randomSprite01 = Random.Range(0, m_SquareSpriteRenderer01.Length);
        randomSprite02 = Random.Range(0, m_SquareSpriteRenderer02.Length);
        //
        randomSprite03 = Random.Range(0, m_SphereSpriteRenderer01.Length);
        randomSprite04 = Random.Range(0, m_SphereSpriteRenderer02.Length);


        spawnPointsPos01 = cluesSpawnPoints[0].GetComponent<Transform>();
        spawnPointsPos02 = cluesSpawnPoints[1].GetComponent<Transform>();
        spawnPointsPos03 = cluesSpawnPoints[2].GetComponent<Transform>();
        spawnPointsPos04 = cluesSpawnPoints[3].GetComponent<Transform>();

        m_SquareSpriteRenderer01[randomSprite01].SetActive(true);
        m_SquareSpriteRenderer02[randomSprite02].SetActive(true);
        m_SphereSpriteRenderer01[randomSprite03].SetActive(true);
        m_SphereSpriteRenderer02[randomSprite04].SetActive(true);
    }

    private void CheckSprites()
    {
        // 1

        if(m_SquareSpriteRenderer01[0].activeInHierarchy)
        {
            //Debug.LogWarning("Premier sprite de la première case carée");
            isSpriteRenderer01Image01 = true;
        }

        else
        {
            //Debug.LogWarning("Deuxième sprite de la première case carée");
            isSpriteRenderer01Image02 = true;
        }

        // 2

        if (m_SquareSpriteRenderer02[0].activeInHierarchy)
        {
            //Debug.LogWarning("Premier sprite de la deuxième case carée");
            isSpriteRenderer02Image01 = true;
        }

        else
        {
            //Debug.LogWarning("Deuxième sprite de la deuxième case carée");
            isSpriteRenderer02Image02 = true;
        }

        // 1

        if (m_SphereSpriteRenderer01[0].activeInHierarchy)
        {
            //Debug.LogWarning("Premier sprite de la première case sphérique");
            isSpriteRenderer03Image01 = true;
        }

        else
        {
            //Debug.LogWarning("Deuxième sprite de la première case sphérique");
            isSpriteRenderer03Image02 = true;
        }

        // 2

        if (m_SphereSpriteRenderer02[0].activeInHierarchy)
        {
            //Debug.LogWarning("Premier sprite de la deuxième case sphérique");
            isSpriteRenderer04Image01 = true;
        }

        else
        {
            //Debug.LogWarning("Deuxième sprite de la deuxième case sphérique");
            isSpriteRenderer04Image02 = true;
        }
    }

    private void SetObjectif()
    {
        // For the two square sprites

        // AA
        if(isSpriteRenderer01Image01 && isSpriteRenderer02Image01)
        {
            axis01RotaExpectedIs0 = true;
            Debug.LogWarning(" Axis01 is Rota 0 ");
        }
        // AB
        if (isSpriteRenderer01Image01 && isSpriteRenderer02Image02)
        {
            axis01RotaExpectedIs90 = true;
            Debug.LogWarning(" Axis01 is Rota 90 ");
        }

        // BA
        if (isSpriteRenderer01Image02 && isSpriteRenderer02Image01)
        {
            axis01RotaExpectedIs180 = true;
            Debug.LogWarning(" Axis01 is Rota 180 ");
        }

        // BB
        if (isSpriteRenderer01Image02 && isSpriteRenderer02Image02)
        {
            axis01RotaExpectedIs270 = true;
            Debug.LogWarning(" Axis01 is Rota 270 ");
        }


        // For the two sphere sprites

        // AA
        if (isSpriteRenderer03Image01 && isSpriteRenderer04Image01)
        {
            axis02RotaExpectedIs0 = true;
            Debug.LogWarning(" Axis02 is Rota 0 ");
        }
        // AB
        if (isSpriteRenderer03Image01 && isSpriteRenderer04Image02)
        {
            axis02RotaExpectedIs90 = true;
            Debug.LogWarning(" Axis02 is Rota 90 ");
        }

        // BA
        if (isSpriteRenderer03Image02 && isSpriteRenderer04Image01)
        {
            axis02RotaExpectedIs180 = true;
            Debug.LogWarning(" Axis02 is Rota 180 ");
        }

        // BB
        if (isSpriteRenderer03Image02 && isSpriteRenderer04Image02)
        {
            axis02RotaExpectedIs270 = true;
            Debug.LogWarning(" Axis02 is Rota 270 ");
        }



    }
}
