using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToSpawnPoint : MonoBehaviour {

    private GameObject[] listSpawnPoint;
    private int numberOfSpawnPoint = 0;

	// Use this for initialization
	void Start () {
        if (gameObject.tag == "BallBoard")
        {
            int tmps_alea = 0;

            listSpawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint_TabBall");

            foreach (GameObject SpawnPoint_TabBall in listSpawnPoint)
            {
                numberOfSpawnPoint++;
            }

            tmps_alea = Random.Range(0, numberOfSpawnPoint);
            transform.position = listSpawnPoint[tmps_alea].transform.position;
        }
        else if(gameObject.tag == "IlluminatedBoard")
        {
            int tmps_alea = 0;

            listSpawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint_TabLight");

            foreach (GameObject SpawnPoint_TabLight in listSpawnPoint)
            {
                numberOfSpawnPoint++;
            }

            tmps_alea = Random.Range(0, numberOfSpawnPoint);
            transform.position = listSpawnPoint[tmps_alea].transform.position;
        }
        else if (gameObject.tag == "Cryptex")
        {
            int tmps_alea = 0;

            listSpawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint_Cryptex");

            foreach (GameObject SpawnPoint_Cryptex in listSpawnPoint)
            {
                numberOfSpawnPoint++;
            }

            tmps_alea = Random.Range(0, numberOfSpawnPoint);
            transform.position = listSpawnPoint[tmps_alea].transform.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
