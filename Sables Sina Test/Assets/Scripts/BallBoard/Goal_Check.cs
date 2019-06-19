using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Check : MonoBehaviour {

    public GameObject ballBoard;
    public int receptacleNumber = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Board_Ball" && (GameManager.s_Singleton.spawnPointSteleBallBoard == (receptacleNumber--)))
        {
            other.gameObject.SetActive(false);

            ballBoard.GetComponent<BallBoard>().enigmaIsSolved = true;
        }
    }

}
