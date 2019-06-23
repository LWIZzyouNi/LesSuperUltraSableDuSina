using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Goal_Check : MonoBehaviour {

    public GameObject ballBoard;
    public int receptacleNumber = 0;

    private float fadeTime = 0.5f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Board_Ball")
        {
            if (GameManager.s_Singleton.spawnPointSteleBallBoard == receptacleNumber--)
            {
                other.gameObject.SetActive(false);

                ballBoard.GetComponent<BallBoard>().enigmaIsSolved = true;
            }
            else
            {
                GameManager.s_Singleton.error++;
                StartCoroutine(FadeAway());
            }
        }
    }

    IEnumerator FadeAway()
    {
        SteamVR_Fade.Start(Color.black, fadeTime, true);

        Debug.Log(" Fade is starting ");

        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SceneLDClement");
    }

}
