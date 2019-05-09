using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Element : MonoBehaviour {

    public CanBeDrag m_MyScript;
    public Interacting m_MyScript2;

    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        OnMouseClick();
    }

    private void OnMouseClick()
    {
        if(m_MyScript.isLocked)
        {
            // Lorsque l'objet est lock, donc zoomé, les éléments interactifs sur l'objet sont activables / utilisables lorsqu'on clique droit.
            if (Input.GetKeyDown(KeyCode.Mouse1) && m_MyScript.isLocked)
            {
                // Joue("nomDeLanimation")
                anim.Play("NewAnim");
                m_MyScript2.Rotate();
            }
        }
    }
}
