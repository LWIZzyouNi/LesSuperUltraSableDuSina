using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Levier : MonoBehaviour
{
    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    private SteamVR_Behaviour_Pose leftHand;
    private SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    // La vérification du trigger
    public bool ctrlIsInTrigger = false;

    private bool DoOnce = false;
    public float timerUntilCanTrigger = 0.5f;
    private float realTimer = 0f;

    public GameObject RB;
    public GameObject Ball;

    public List<GameObject> spawnPointBall;

    private int state = 0;

    private void Awake()
    {
        GameObject m_LeftHand = GameObject.Find("Controller (left)");
        leftHand = m_LeftHand.GetComponent<SteamVR_Behaviour_Pose>();

        GameObject m_handRight = GameObject.Find("Controller (right)");
        rightHand = m_handRight.GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Use this for initialization
    void Start () {
        realTimer = timerUntilCanTrigger;

        AddInList();
	}
	
	// Update is called once per frame
	void Update () {
        Controller();
        Timer();
        BallPos();
    }

    void Controller()
    {
        if ((buttonAction.GetState(handType01) || buttonAction.GetState(handType02) || Input.GetKeyDown(KeyCode.Space)) && ctrlIsInTrigger)
        {
            if (DoOnce == false)
            {
                DoOnce = true;

                //LE TRUUUUUUUUUUUUUUUUUUUUUUUUUUUUUC
                state++;
                if(state >= spawnPointBall.Count)
                {
                    state = 0;
                }
            }
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

    void Timer ()
    {
        if (DoOnce == true)
        {
            realTimer -= 1 * Time.deltaTime;

            if (realTimer <= 0)
            {
                DoOnce = false;
                realTimer = timerUntilCanTrigger;
            }
        }
    }

    void AddInList ()
    {
        spawnPointBall.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint_BallBoard_Ball"));
    }

    void BallPos ()
    {
        if (RB.GetComponent<ResetButton>().inAct == false)
        {
            Ball.transform.position = spawnPointBall[state].transform.position;
        }
    }
}
