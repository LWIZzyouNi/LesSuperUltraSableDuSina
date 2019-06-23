using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class AxisRotation_Check : MonoBehaviour
{
    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;
    public bool ctrlIsInTrigger = false;

    public GameObject[] buttonsInGame;
    public int numberOfButton = 0;

    [Header("Cryptex Axis")]
    public GameObject axis01;
    public GameObject axis02;
    public GameObject axis03;
    public GameObject axis04;
    public GameObject axis05;

    // Vérifie la position parfaite de chaque axe
    public bool perfectRot01 = false;
    public bool perfectRot02 = false;
    public bool perfectRot03 = false;
    public bool perfectRot04 = false;
    public bool perfectRot05 = false;

    public AudioClip audioSrc_EnigmaIsComplete;
    private Outline m_Outline;

    public GameManager m_MyGameManager;
    private bool enigmaIsSolved = false;
    private bool isNumberAdded = false;

    public CluesManager m_CluesManager;

    private float fadeTime = 0.5f;

    private void Awake()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        m_Outline = GetComponent<Outline>();
    }
    
    void Update()
    {
        CheckFirstAndSecondAxis();
        CheckThirdAxis();
        CheckFourthAxis();
        InputsCheck();
    }

    private void InputsCheck()
    {
        Debug.Log("Checking Cryptex results");
        if ((buttonAction.GetStateDown(handType01) || buttonAction.GetStateDown(handType02) || Input.GetKeyDown(KeyCode.Space)) && m_Outline.isOutlined && ctrlIsInTrigger)
        {
            CheckResults();
        }
    }

    public void CheckFirstAndSecondAxis()
    {
        // PREMIER AXE DU CRYPTEX

        Debug.Log("Checking rotations !");
        // booléan 01 de CluesManager + position de l'axe 01
        // 0
        if ((axis01.transform.rotation.w == 1 || axis01.transform.rotation.w == -1) && m_CluesManager.axis01RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot01 = true;
        }

        else if ((axis01.transform.rotation.w != 1 || axis01.transform.rotation.w != -1) && m_CluesManager.axis01RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot01 = false;
        }

        // booléan 02 de CluesManager + position de l'axe 01
        // 90
        if (axis01.transform.rotation.x == -0.7071068f && axis01.transform.rotation.w == 0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot01 = true;
        }

        else if (axis01.transform.rotation.x != -0.7071068f && axis01.transform.rotation.w != 0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot01 = false;
        }

        // booléan 03 de CluesManager + position de l'axe 01
        // 180
        if (axis01.transform.rotation.x == -1 && m_CluesManager.axis01RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot01 = true;
        }

        else if(axis01.transform.rotation.x != -1 && m_CluesManager.axis01RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot01 = false;
        }
        
        // booléan 04 de CluesManager + position de l'axe 01
        // 270
        if (axis01.transform.rotation.x == -0.7071068f && axis01.transform.rotation.w == -0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot01 = true;
        }

        else if ( axis01.transform.rotation.x != -0.7071068f && axis01.transform.rotation.w != -0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot01 = false;
        }

        // DEUXIEME AXE DU CRYPTEX

        // booléan 01 de CluesManager + position de l'axe 02
        // 0
        if ((axis02.transform.rotation.w == 1 || axis02.transform.rotation.w == -1) && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot02 = true;
        }

        else if ((axis02.transform.rotation.w != 1 || axis02.transform.rotation.w != -1) && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot02 = false;
        }

        // booléan 02 de CluesManager + position de l'axe 02
        // 90
        if (axis02.transform.rotation.x == -0.7071068f && axis02.transform.rotation.w == 0.7071068f && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot02 = true;
        }

        else if (axis02.transform.rotation.x != -0.7071068f && axis02.transform.rotation.w != 0.7071068f && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot02 = false;
        }

        // booléan 03 de CluesManager + position de l'axe 02
        // 180
        if (axis02.transform.rotation.x == -1 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot02 = true;
        }

        else if (axis02.transform.rotation.x != -1 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot02 = false;
        }
        
        // booléan 04 de CluesManager + position de l'axe 02
        // 270
        if (axis02.transform.rotation.x == -0.7071068f && axis02.transform.rotation.w == -0.7071068f && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot02 = true;
        }

        else if (axis02.transform.rotation.x != -0.7071068f && axis02.transform.rotation.w != -0.7071068f && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot02 = false;
        } 
    }

    private void CheckThirdAxis()
    {
        // TROISIEME AXE DU CRYPTEX

        ///// PREMIER CAS \\\\\

        // AA 0 / 0 = 270
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == -0.7071068f && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != -0.7071068f && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }
        
        // AB 0 / 90 = 0
        if ((axis03.transform.rotation.w == 1 || axis03.transform.rotation.w == -1) && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if ((axis03.transform.rotation.w != 1 || axis03.transform.rotation.w != -1) && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }
        
        // AC 0 / 180 = 90
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == 0.7071068f && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03= true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != 0.7071068f && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }
        
        // AD 0 / 270 = 180
        if (axis03.transform.rotation.x == -1 && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -1 && m_CluesManager.axis01RotaExpectedIs0 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        ///// DEUXIEME CAS \\\\\

        // BA 90 / 0 = 180
        if (axis03.transform.rotation.x == -1 && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -1 && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BB 90 / 90 = 270
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == -0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != -0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BC 90 / 180 = 0
        if ((axis03.transform.rotation.w == 1 || axis03.transform.rotation.w == -1) && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if ((axis03.transform.rotation.w != 1 || axis03.transform.rotation.w != -1) && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BD 90 / 270 = 90
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == 0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != 0.7071068f && m_CluesManager.axis01RotaExpectedIs90 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        ///// TROISIEME CAS \\\\\

        // BA 180 / 0 = 90
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == 0.7071068f && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != 0.7071068f && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BB 180 / 90 = 180
        if (axis03.transform.rotation.x == -1 && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -1 && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BC 180 / 180 = 270
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == -0.7071068f && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != -0.7071068f && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BD 180 / 270 = 0
        if ((axis03.transform.rotation.w == 1 || axis03.transform.rotation.w == -1) && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if ((axis03.transform.rotation.w != 1 || axis03.transform.rotation.w != -1) && m_CluesManager.axis01RotaExpectedIs180 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }


        ///// QUATRIEME CAS \\\\\

        // BA 270 / 0 = 0
        if ((axis03.transform.rotation.w == 1 || axis03.transform.rotation.w == -1) && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if ((axis03.transform.rotation.w != 1 || axis03.transform.rotation.w != -1) && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs0 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BB 270 / 90 = 90
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == 0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != 0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs90 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BC 270 / 180 = 180
        if (axis03.transform.rotation.x == -1 && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -1 && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs180 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

        // BD 270 / 270 = 270
        if (axis03.transform.rotation.x == -0.7071068f && axis03.transform.rotation.w == -0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = true;
        }

        else if (axis03.transform.rotation.x != -0.7071068f && axis03.transform.rotation.w != -0.7071068f && m_CluesManager.axis01RotaExpectedIs270 && m_CluesManager.axis02RotaExpectedIs270 && !enigmaIsSolved)
        {
            perfectRot03 = false;
        }

    }

    private void CheckFourthAxis()
    {
        buttonsInGame = GameObject.FindGameObjectsWithTag("Button");
        numberOfButton = buttonsInGame.Length;

        if(numberOfButton == 2)
        {
            Debug.Log("Two buttons here");
            Debug.LogWarning("Axis 04 Rot is 0");

            if ((axis04.transform.rotation.w == 1 || axis04.transform.rotation.w == -1) && !enigmaIsSolved)
            {
                perfectRot04 = true;
            }

            else if ((axis04.transform.rotation.w != 1 || axis04.transform.rotation.w != -1) && !enigmaIsSolved)
            {
                perfectRot04 = false;
            }
        }

        else if (numberOfButton == 3)
        {
            Debug.Log("Three buttons here");
            Debug.LogWarning("Axis 04 Rot is 90");

            if (axis04.transform.rotation.x == -0.7071068f && axis04.transform.rotation.w == 0.7071068f && !enigmaIsSolved)
            {
                perfectRot04 = true;
            }

            else if (axis04.transform.rotation.x != -0.7071068f && axis04.transform.rotation.w != 0.7071068f && !enigmaIsSolved)
            {
                perfectRot04 = false;
            }
        }

        else if (numberOfButton == 4)
        {
            Debug.Log("Four buttons here");
            Debug.LogWarning("Axis 04 Rot is 270");

            if (axis04.transform.rotation.x == -0.7071068f && axis04.transform.rotation.w == -0.7071068f && !enigmaIsSolved)
            {
                perfectRot04 = true;
            }

            else if (axis04.transform.rotation.x != -0.7071068f && axis04.transform.rotation.w != -0.7071068f && !enigmaIsSolved)
            {
                perfectRot04 = false;
            }
        }

        else if (numberOfButton == 5)
        {
            Debug.Log("Five buttons here");
            Debug.LogWarning("Axis 04 Rot is 180");

            if (axis04.transform.rotation.x == -1 && !enigmaIsSolved)
            {
                perfectRot04 = true;
            }

            else if (axis04.transform.rotation.x != -1 && !enigmaIsSolved)
            {
                perfectRot04 = false;
            }
        }
    }

    private void CheckResults()
    {
        if (perfectRot01 && perfectRot02 && perfectRot03 && perfectRot04 && perfectRot05)
        {
            // L'énigme est résolue
            enigmaIsSolved = true;
            Debug.Log(enigmaIsSolved);

            if(!isNumberAdded)
            {
                // Une énigme est résolue
                m_MyGameManager.enigmeCompleteNumber++;
                SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
            }
        }

        else if (!perfectRot01 || !perfectRot02 || !perfectRot03 || !perfectRot04 || !perfectRot05)
        {
            StartCoroutine(FadeAway());
        }

        if (enigmaIsSolved)
        {
            perfectRot01 = false;
            perfectRot02 = false;
            perfectRot03 = false;
            perfectRot04 = false;
            perfectRot05 = false;

            isNumberAdded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            Debug.Log("in Trigger");
            ctrlIsInTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            Debug.Log("out of Trigger");
            ctrlIsInTrigger = false;
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


