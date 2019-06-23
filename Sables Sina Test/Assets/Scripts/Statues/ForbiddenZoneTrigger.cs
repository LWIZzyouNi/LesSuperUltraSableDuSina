using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ForbiddenZoneTrigger : MonoBehaviour {
    
    public SortColor m_SortColor;
    public Activation m_Activation;

    public float fadeTime = 0.5f;

    private void Awake()
    {
        m_SortColor = gameObject.GetComponentInParent<SortColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Board_Ball"))
        {
            Debug.Log("Ball is in Trigger");

            if(gameObject.name == ("ColoredZone01"))
            {
                Debug.Log("Ball is in ColoredZone01");

                if ((m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue) && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            else if (gameObject.name == ("ColoredZone02"))
            {
                Debug.Log("Ball is in ColoredZone02");

                if ((m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue) && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            else  if(gameObject.name == ("ColoredZone03"))
            {
                Debug.Log("Ball is in ColoredZone03");

                if ((m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue) && m_Activation.ballBoardGameAsStarted)
                { 
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            else if(gameObject.name == ("ColoredZone04"))
            {
                Debug.Log("Ball is in ColoredZone04");

                if ((m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue) && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
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
