using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIManager : MonoBehaviour {

    [Header("Controller Components")]
    public SteamVR_Input_Sources handType01;
    public SteamVR_Input_Sources handType02;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public SteamVR_Action_Boolean buttonAction;

    public GameObject UI_Manager;


    public void ToStartGame()
    {
            UI_Manager.SetActive(!UI_Manager.gameObject.activeSelf);
            Debug.Log("Click");
    }

    public void ToQuitGame()
    {
        if(buttonAction.GetState(handType01) || buttonAction.GetState(handType02))
        {
            Application.Quit();
        }
    }
}
