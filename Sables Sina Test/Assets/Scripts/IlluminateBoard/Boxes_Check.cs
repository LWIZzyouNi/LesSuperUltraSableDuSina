using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Boxes_Check : MonoBehaviour {
    
    public GameObject[] boxes;

    public List<Illuminate> m_Illuminate;
    public StatuesManager m_StatuesManager;
    
    public AudioClip audioSrc_EnigmaIsComplete;
    public GameManager m_MyGameManager;

    private float fadeTime = 0.5f;

    private bool enigmaIsSolved = false;
    private bool isNumberAdded = false;

    // Use this for initialization
    void Start ()
    {
        getChild();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void getChild()
    {
        boxes = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            boxes[i] = transform.GetChild(i).gameObject;
            boxes[i].GetComponent<Illuminate>();
            m_Illuminate.Add(boxes[i].GetComponent<Illuminate>());
        }
    }

    public void CheckResult()
    {
        //1
        if (m_StatuesManager.statue01IsHigher)
        {
            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsNinety)
            {
                Debug.Log("Higher. " + " 90 / 90 ");

                if (m_Illuminate[7].isIlluminated && m_Illuminate[12].isIlluminated && m_Illuminate[3].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[2].isIlluminated && m_Illuminate[8].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Higher. " + " 90 / 270 ");

                if (m_Illuminate[5].isIlluminated && m_Illuminate[4].isIlluminated && m_Illuminate[9].isIlluminated && m_Illuminate[11].isIlluminated && m_Illuminate[15].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsNinety)
            {
                Debug.Log("Higher. " + " 270 / 90 ");

                if (m_Illuminate[15].isIlluminated && m_Illuminate[12].isIlluminated && m_Illuminate[1].isIlluminated && m_Illuminate[2].isIlluminated && m_Illuminate[4].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Higher. " + " 270 / 270 ");

                if (m_Illuminate[4].isIlluminated && m_Illuminate[15].isIlluminated && m_Illuminate[10].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[7].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }
        }

        //2
        if (m_StatuesManager.statue01IsLower)
        {
            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsNinety)
            {
                Debug.Log("Lower. " + " 90 / 90 ");

                if (m_Illuminate[5].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[11].isIlluminated && m_Illuminate[13].isIlluminated && m_Illuminate[14].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Lower. " + " 90 / 270 ");

                if (m_Illuminate[14].isIlluminated && m_Illuminate[11].isIlluminated && m_Illuminate[10].isIlluminated && m_Illuminate[9].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[5].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsNinety)
            {
                Debug.Log("Lower. " + " 270 / 90 ");

                if (m_Illuminate[3].isIlluminated && m_Illuminate[14].isIlluminated && m_Illuminate[10].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[2].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Lower. " + " 270 / 270 ");

                if (m_Illuminate[4].isIlluminated && m_Illuminate[12].isIlluminated && m_Illuminate[8].isIlluminated && m_Illuminate[5].isIlluminated && m_Illuminate[1].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }
        }

        //3
        if (m_StatuesManager.statuesAreEquals)
        {
            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsNinety)
            {
                Debug.Log("Equals. " + " 90 / 90 ");

                if (m_Illuminate[1].isIlluminated && m_Illuminate[2].isIlluminated && m_Illuminate[5].isIlluminated && m_Illuminate[6].isIlluminated && m_Illuminate[10].isIlluminated && m_Illuminate[11].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsNinety && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Equals. " + " 90 / 270 ");

                if (m_Illuminate[3].isIlluminated && m_Illuminate[4].isIlluminated && m_Illuminate[8].isIlluminated && m_Illuminate[7].isIlluminated && m_Illuminate[13].isIlluminated && m_Illuminate[14].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsNinety)
            {

                Debug.Log("Equals. " + " 270 / 90 ");

                if (m_Illuminate[4].isIlluminated && m_Illuminate[13].isIlluminated && m_Illuminate[14].isIlluminated && m_Illuminate[11].isIlluminated && m_Illuminate[1].isIlluminated && m_Illuminate[3].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
                    StartCoroutine(FadeAway());
                }
            }

            if (m_StatuesManager.statue01IsTwoHundredSeventy && m_StatuesManager.statue02IsTwoHundredSeventy)
            {
                Debug.Log("Equals. " + " 270 / 270 ");

                if (m_Illuminate[15].isIlluminated && m_Illuminate[1].isIlluminated && m_Illuminate[8].isIlluminated && m_Illuminate[5].isIlluminated && m_Illuminate[7].isIlluminated && m_Illuminate[4].isIlluminated)
                {
                    Debug.Log("You win !");

                    enigmaIsSolved = true;
                    Debug.Log(enigmaIsSolved);
                    if (!isNumberAdded)
                    {
                        // Une énigme est résolue
                        m_MyGameManager.enigmeCompleteNumber++;
                        SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                    }

                    if (enigmaIsSolved)
                    {
                        isNumberAdded = true;
                    }
                }

                else
                {
                    Debug.Log("You loose, this is not the correct answer !");

                    // Rappel des fonctions, remise à zéro et nouveau pattern en cas d'échec du joueur
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
