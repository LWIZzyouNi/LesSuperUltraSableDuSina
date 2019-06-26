/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Goal_Check : MonoBehaviour {
    
    private GameObject ballBoard;
    private GameObject Stele;

    public int receptacleNumber = 0;

    private float fadeTime = 0.5f;

    // Use this for initialization
    void Start () {
        Stele = GameObject.FindGameObjectWithTag("Stele");
    }
	
	// Update is called once per frame
	void Update () {
        Indexing();
    }

    private void Indexing()
    {
        if (Stele.GetComponent<Stele_Elem>().hasBeenChecked)
        {
            Debug.Log("ALORS MON CHèRE AMI LA RéPONSE EST: " + Stele.GetComponent<Stele_Elem>().elementalNumber);
            Stele.GetComponent<Stele_Elem>().hasBeenChecked = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Board_Ball")
        {
            if (receptacleNumber == Stele.GetComponent<Stele_Elem>().elementalNumber  GameManager.s_Singleton.spawnPointSteleBallBoard == receptacleNumber-- )
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
*/