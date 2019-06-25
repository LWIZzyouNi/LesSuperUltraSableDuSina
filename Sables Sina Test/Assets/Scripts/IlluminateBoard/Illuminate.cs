using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Illuminate : MonoBehaviour {

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    //private Outline_IntElement m_Outline_IntElem_Script;
    //private CanBeDrag m_DragScript;
    public Boxes_Check m_Boxes_Check_Script;

    public Material notIlluminated;
    public Material illuminated;

    public bool isIlluminated = false;
    public bool isInteracting = false;
    public bool ctrlIsInTrigger = false;

    [HideInInspector]
    public float timerUntilCanClick = 0.5f;

    private void Awake()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Use this for initialization
    void Start ()
    {
        //m_Outline_IntElem_Script = GetComponent<Outline_IntElement>();
        //m_DragScript = GetComponentInParent<CanBeDrag>();
    }

    // Update is called once per frame
    void Update ()
    {
        InputsCheck();
    }

    private void InputsCheck()
    {
        if ((buttonAction.GetStateDown(handType01) || buttonAction.GetStateDown(handType02) || Input.GetKeyDown(KeyCode.Space)) && ctrlIsInTrigger && !isIlluminated && !isInteracting)
        {
            Debug.Log("Button Press");
            GetComponent<Renderer>().material = illuminated;
            isIlluminated = true;
            Debug.Log(isIlluminated);
            StartCoroutine(WaitUntilClick());
        }

        else if ((buttonAction.GetStateDown(handType01) || buttonAction.GetStateDown(handType02) || Input.GetKeyDown(KeyCode.Space)) && ctrlIsInTrigger && isIlluminated && !isInteracting)
        {
            Debug.Log("Button Press Back");
            GetComponent<Renderer>().material = notIlluminated;
            isIlluminated = false;
            Debug.Log(isIlluminated);
            StartCoroutine(WaitUntilClick());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Controller"))
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

    IEnumerator WaitUntilClick()
    {
        isInteracting = true;

        yield return new WaitForSeconds(timerUntilCanClick);

        isInteracting = false;
    }
}