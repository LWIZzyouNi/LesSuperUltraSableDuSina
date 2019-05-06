using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_CanBeUse : MonoBehaviour {

    public CanBeDrag m_MyScript;

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        OnClickMouse();

    }

    private void OnClickMouse()
    {
        if(m_MyScript.isLocked)
        {
            // Lorsque l'objet est lock, donc zoomé, les éléments interactifs sur l'objet sont activables / utilisables lorsqu'on clique droit.
            if (Input.GetKeyDown(KeyCode.Mouse1) && m_MyScript.isLocked)
            {
                // Joue("nomDeLanimation")
                anim.Play("NewAnim");
            }
        }
    }
}
