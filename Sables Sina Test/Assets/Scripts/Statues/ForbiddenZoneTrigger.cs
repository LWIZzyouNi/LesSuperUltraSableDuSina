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

            // ForbiddenZoneIsGreen

            if ((m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsBlue || m_SortColor.forbiddenZoneIsRed) && gameObject.name == ("ColoredZone01"))
            {
                Debug.Log("Ball is in ColoredZone01");

                if (m_SortColor.renderers[0].material.color == m_SortColor.color02 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[0].material.color == m_SortColor.color04 && m_SortColor.forbiddenZoneIsBlue && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[0].material.color == m_SortColor.color01 && m_SortColor.forbiddenZoneIsRed && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            else if ((m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsBlue || m_SortColor.forbiddenZoneIsRed) && gameObject.name == ("ColoredZone03"))
            {
                Debug.Log("Ball is in ColoredZone03");

                if (m_SortColor.renderers[2].material.color == m_SortColor.color02 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[2].material.color == m_SortColor.color04 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[2].material.color == m_SortColor.color01 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            else if ((m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsBlue || m_SortColor.forbiddenZoneIsRed) && gameObject.name == ("ColoredZone04"))
            {
                Debug.Log("Ball is in ColoredZone04");

                if (m_SortColor.renderers[3].material.color == m_SortColor.color02 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[3].material.color == m_SortColor.color04 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }

                else if (m_SortColor.renderers[3].material.color == m_SortColor.color01 && m_Activation.ballBoardGameAsStarted)
                {
                    Debug.Log("You lose !");
                    StartCoroutine(FadeAway());
                }
            }

            // ForbiddenZoneIsYellow

            else if (gameObject.name == ("ColoredZone02"))
            {
                Debug.Log("Ball is in ColoredZone02");

                if (m_SortColor.forbiddenZoneIsYellow)
                {
                    if (m_SortColor.renderers[1].material.color == m_SortColor.color03 && m_Activation.ballBoardGameAsStarted)
                    {
                        Debug.Log("You lose !");
                        StartCoroutine(FadeAway());
                    }
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
