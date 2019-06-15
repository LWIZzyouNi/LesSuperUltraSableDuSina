using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBoard : MonoBehaviour
{
    public AudioClip audioSrc_EnigmaIsComplete;
    //private CanBeDrag m_DragScript;
   // private Outline m_OutlineScript;

    public List<Quaternion> originalTransformPlatform;
    public List<GameObject> originalGameobjectPlatform;

    public bool enigmaIsSolved = false;
    private bool doOnce = false;

    // Use this for initialization
    void Start()
    {
        //m_DragScript = GetComponent<CanBeDrag>();
        //m_OutlineScript = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        EnigmaIsSolved();
    }

    private void EnigmaIsSolved()
    {
        if (enigmaIsSolved)
        {
            if (!doOnce)
            {
                GameManager.s_Singleton.enigmeCompleteNumber++;
                SoundManager.instance.PlaySingle(audioSrc_EnigmaIsComplete);
                doOnce = true;
            }

            /*
            m_DragScript.Dezoom();
            m_DragScript.isLocked = false;
            m_DragScript.isInteractive = false;
            m_DragScript.canRotate = false;

            m_OutlineScript.GetComponent<Renderer>().material = m_OutlineScript.nonOutlined;
            m_OutlineScript.isOutlined = false;
            */
        }
    }

    public void AddInList(GameObject actualGameObject)
    {
        originalGameobjectPlatform.Add(actualGameObject);
        originalTransformPlatform.Add(actualGameObject.transform.rotation);
    }

    public void ResetPlatform()
    {
        Debug.Log("Oui");

        for (int i = 0; i < originalGameobjectPlatform.Count; i++)
        {
            Debug.Log(i);
            Debug.Log("le premier: " + originalGameobjectPlatform[i].transform.rotation);
            Debug.Log("le deuxieme: " + originalTransformPlatform[i]);
            originalGameobjectPlatform[i].transform.rotation = originalTransformPlatform[i];
            Debug.Log("le nouveau premier: " + originalGameobjectPlatform[i].transform.rotation);
        }
    }
}