using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Element : MonoBehaviour {

    private Outline m_MyScript;
    private Interacting m_MyScript2;
    private CanBeDrag m_MyScript3;

    private Animator anim;
    public Animator parentAnim;

    private bool state01 = false;
    private bool state02 = false;
    private bool state03 = false;
    private bool state04 = false;
    private bool canPlay = false;
    private bool isRotating = false;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();

        m_MyScript = GetComponentInParent<Outline>();
        m_MyScript2 = GetComponentInParent<Interacting>();
        m_MyScript3 = GetComponentInParent<CanBeDrag>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        OnMouseClick();
        
    }

    private void OnMouseClick()
    {
        if(m_MyScript.isBordered)
        {
            // Lorsque l'objet est lock, donc zoomé, les éléments interactifs sur l'objet sont activables / utilisables lorsqu'on clique droit.
            if (Input.GetKeyDown(KeyCode.Mouse1) && m_MyScript.isBordered && m_MyScript3.isLocked)
            {
                m_MyScript2.Rotate();

                canPlay = false;
                isRotating = true;

                // Si l'objet tourne, que le premier état de l'animation ne s'est pas joué, l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state01 && !canPlay)
                {
                    // Le premier état de l'animation peut se jouer (autrement dit, l'animation du premier état sera considérée comme jouée)..
                    state01 = true;

                    // Reset du quatrième état de l'animation pour effectuer un tour à 360°..
                    if (state01)
                    {
                        state04 = false;
                        parentAnim.SetBool("State04", false);
                    }

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    if(canPlay)
                    {
                        // L'animation, correspondant au premier état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis01");
                        parentAnim.SetBool("State01", true);

                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le second état de l'animation ne s'est pas joué, l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state02 && !canPlay)
                {
                    // Le second état de l'animation peut se jouer (autrement dit, l'animation du deuxième état sera considérée comme jouée)..
                    state02 = true;

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au second état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis02");
                        parentAnim.SetBool("State02", true);

                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le troisième état de l'animation ne s'est pas joué, l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state03 && !canPlay)
                {
                    // Le troisième état de l'animation peut se jouer (autrement dit, l'animation du troisième état sera considérée comme jouée)..
                    state03 = true;

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au troisième état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis03");
                        parentAnim.SetBool("State03", true);

                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }

                // Si l'objet tourne, que le quatrième état de l'animation ne s'est pas joué, l'animation lui correspondant ne peut pas se jouer..
                if (isRotating && !state04 && !canPlay)
                {
                    // Le quatrième état de l'animation peut se jouer (autrement dit, l'animation du quatrième état sera considérée comme jouée)..
                    state04 = true;

                    // Reset de la boucle pour un tour à 360°..
                    if(state04)
                    {
                        state01 = false;
                        state02 = false;
                        state03 = false;

                        parentAnim.SetBool("State01", false);
                        parentAnim.SetBool("State02", false);
                        parentAnim.SetBool("State03", false);
                    }

                    // L'animation lui correspondant peut se jouer..
                    canPlay = true;

                    // Si l'animation peut se jouer..
                    if (canPlay)
                    {
                        // L'animation, correspondant au quatrième état se joue ("NomDeLanimation")..
                        //parentAnim.Play("RotationAxis04");
                        parentAnim.SetBool("State04", true);
                        parentAnim.SetBool("CanBoucle", true);

                        // L'objet ne tourne plus, il vient de tourner.
                        isRotating = false;
                    }
                }
            }
        }
    }
}
