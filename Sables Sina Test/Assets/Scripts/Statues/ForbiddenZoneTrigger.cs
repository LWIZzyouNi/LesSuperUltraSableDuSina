using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ForbiddenZoneTrigger : MonoBehaviour {
    
    public SortColor m_SortColor;
    public Activation m_Activation;
    public Ball_CheckPos m_Ball_CheckPos;

    public float fadeTime = 0.5f;

    private void Awake()
    {
        m_SortColor = gameObject.GetComponentInParent<SortColor>();
    }

    private void Update()
    {
        CheckBallPos();
    }

    private void CheckBallPos()
    {
        if(m_Ball_CheckPos.ballInZone01)
        {
            if(m_SortColor.forbiddenZoneIsGreen)
            {
                Debug.Log(" forbiddenZoneIsGreen ");

                if (m_SortColor.renderers[0].material.color == m_SortColor.color04)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsBlue)
            {
                Debug.Log(" forbiddenZoneIsBlue ");

                if(m_SortColor.renderers[0].material.color == m_SortColor.color01)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsRed)
            {
                Debug.Log(" forbiddenZoneIsRed ");

                if (m_SortColor.renderers[0].material.color == m_SortColor.color02)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }
        }

        else if (m_Ball_CheckPos.ballInZone02)
        {
            if (m_SortColor.forbiddenZoneIsYellow)
            {
                Debug.Log(" forbiddenZoneIsYellow ");

                if (m_SortColor.renderers[1].material.color == m_SortColor.color03)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }
        }

        else if (m_Ball_CheckPos.ballInZone03)
        {
            if (m_SortColor.forbiddenZoneIsGreen)
            {
                Debug.Log(" forbiddenZoneIsGreen ");

                if (m_SortColor.renderers[2].material.color == m_SortColor.color04)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsBlue)
            {
                Debug.Log(" forbiddenZoneIsBlue ");

                if (m_SortColor.renderers[2].material.color == m_SortColor.color01)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsRed)
            {
                Debug.Log(" forbiddenZoneIsRed ");

                if (m_SortColor.renderers[2].material.color == m_SortColor.color02)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }
        }

        else if (m_Ball_CheckPos.ballInZone04)
        {
            if (m_SortColor.forbiddenZoneIsGreen)
            {
                Debug.Log(" forbiddenZoneIsGreen ");

                if (m_SortColor.renderers[3].material.color == m_SortColor.color04)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsBlue)
            {
                Debug.Log(" forbiddenZoneIsBlue ");

                if (m_SortColor.renderers[3].material.color == m_SortColor.color01)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
                    StartCoroutine(FadeAway());
                }
            }

            else if (m_SortColor.forbiddenZoneIsRed)
            {
                Debug.Log(" forbiddenZoneIsRed ");

                if (m_SortColor.renderers[3].material.color == m_SortColor.color02)
                {
                    Debug.Log(" You lose ! Sorry not sorry");
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
