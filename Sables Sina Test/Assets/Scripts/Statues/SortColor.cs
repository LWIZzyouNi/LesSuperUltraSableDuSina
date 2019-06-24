using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class SortColor : MonoBehaviour {

    public GameObject[] objectToColor;

    int randomColor01 = 0;
    int randomColor02 = 0;
    int randomColor03 = 0;

    public Color color01 = Color.green;
    public Color color02;
    public Color color03;
    public Color color04;

    public Color[] colors = new Color[4];

    [SerializeField]
    public List<Renderer> renderers;

    public bool forbiddenZoneIsBlue = false;
    public bool forbiddenZoneIsGreen = false;
    public bool forbiddenZoneIsRed = false;
    public bool forbiddenZoneIsYellow = false;

    public bool forbiddenZoneIsDownLeft = false;
    public bool forbiddenZoneIsDownRight = false;

    private float fadeTime = 0.5f;

    // Use this for initialization
    void Start()
    {
        getChild();
        InitializeListOfColor();
        FirstColorAttribution();
        CheckColor();
        SetForbiddenZone();
        LimitationAttribution();
    }

    private void getChild()
    {
        objectToColor = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objectToColor[i] = transform.GetChild(i).gameObject;
            objectToColor[i].GetComponent<Renderer>();
            renderers.Add(objectToColor[i].GetComponent<Renderer>());
        }
    }

    private void InitializeListOfColor()
    {
        colors[0] = color01;
        colors[1] = color02;
        colors[2] = color03;
        colors[3] = color04;
    }

    public void FirstColorAttribution()
    {
        randomColor01 = Random.Range(0, colors.Length);

        objectToColor[0].GetComponent<Renderer>().material.color = colors[randomColor01];
    }

    public void CheckColor()
    {

        // Checking first color

        //First Color is Blue

        if (renderers[0].material.color == color01)
        {
            Color[] colorsAfterFirstAttribution = { color02, color03, color04 };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color

            //Second Color is Red (B, R, ?, ?)

            if (renderers[1].material.color == color02)
           {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { color03, color04 };

                    randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (B, R, Y, ?)
                if(renderers[2].material.color == color03)
                {
                    //Fourth Color is Green (B, R, Y, G)
                    renderers[3].material.color = color04;
                }

                //Third Color is Green (B, R, G, ?)
                else if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Yellow (B, R, G, Y)
                    renderers[3].material.color = color03;
                }
            }

            //Second Color is Yellow (B, Y, ?, ?)

            else if (renderers[1].material.color == color03)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { color04, color02 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

               renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (B, Y, G, ?)
                if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Red (B, Y, G, R)
                    renderers[3].material.color = color02;
                }

                //Third Color is Red (B, Y, R, ?)
                else if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Green (B, Y, R, G)
                    renderers[3].material.color = color04;
                }
            }

            //Second Color is Green (B, G, ?, ?)

            else if (renderers[1].material.color == color04)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { color02, color03 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (B, G, R, ?)
                if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Yellow (B, G, R, Y)
                    renderers[3].material.color = color03;
                }

                //Third Color is Yellow (B, G, Y, ?)
                else if (renderers[2].material.color == color03)
                {
                    //Fourth Color is Red (B, G, Y, R)
                    renderers[3].material.color = color02;
                }
                
            }

        }

        //First Color is Red

        else if (renderers[0].material.color == color02)
        {
            Color[] colorsAfterFirstAttribution = { color01, color03, color04 };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];


            // Checking second color
            // Second Color is Blue (R, B, ?, ?)

            if (renderers[1].material.color == color01)
             {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { color03, color04 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (R, B, Y, ?)
                if (renderers[2].material.color == color03)
                {
                    //Fourth Color is Green (R, B, Y, G)
                    renderers[3].material.color = color04;
                }

                //Third Color is Green (R, B, G, ?)
                else if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Yellow (R, B, G, Y)
                    renderers[3].material.color = color03;
                }
                
            }

            // Second Color is Yellow (R, Y, ?, ?)

            else if (renderers[1].material.color == color03)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { color04, color01 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (R, Y, G, ?)
                if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Blue (R, Y, G, B)
                    renderers[3].material.color = color01;
                }

                //Third Color is Blue (R, Y, B, ?)
                else if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Green (R, Y, B, G)
                    renderers[3].material.color = color04;
                }
                
            }

            // Second Color is Green (R, G, ?, ?)

            else if (renderers[1].material.color == color04)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { color01, color03 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (R, G, B, ?)
                if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Yellow (R, G, B, ?)
                    renderers[3].material.color = color03;
                }

                //Third Color is Yellow (R, G, Y, ?)
                else if (renderers[2].material.color == color03)
                {
                    //Fourth Color is Blue (R, G, Y, B)
                    renderers[3].material.color = color01;
                }
                
            }
        }

        //First Color is Green

        else if (renderers[0].material.color == color04)
        {
            Color[] colorsAfterFirstAttribution = { color02, color01, color03 };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color
            // Second Color is Red (G, R, ?, ?)

            if (renderers[1].material.color == color02)
            {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { color01, color03 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (G, R, B, ?)
                if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Yellow (G, R, B, Y)
                    renderers[3].material.color = color03;
                }

                //Third Color is Yellow (G, R, Y, ?)
                else if (renderers[2].material.color == color03)
                {
                    //Fourth Color is Blue (G, R, Y, B)
                    renderers[3].material.color = color01;
                }
                
            }

            // Second Color is Blue (G, B, ?, ?)

            else if (renderers[1].material.color == color01)
            {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { color03, color02 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (G, B, Y, ?)
                if (renderers[2].material.color == color03)
                {
                    //Fourth Color is Red (G, B, Y, R)
                    renderers[3].material.color = color02;
                }

                //Third Color is Red (G, B, R, ?)
                else if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Yellow (G, B, R, Y)
                    renderers[3].material.color = color03;
                }
                
            }

            // Second Color is Yellow (G, Y, ?, ?)

            else if (renderers[1].material.color == color03)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { color02, color01 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (G, Y, R, ?)
                if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Blue (G, Y, R, B)
                    renderers[3].material.color = color01;
                }
                
                //Third Color is Blue (G, Y, B, ?)
                else if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Red (G, Y, B, R)
                    renderers[3].material.color = color02;
                }
            }
        }

        //First Color is Yellow

        else if (renderers[0].material.color == color03)
        {
            Color[] colorsAfterFirstAttribution = { color02, color01, color04 };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color
            // Second Color is Red (Y, R, ?, ?)

            if (renderers[1].material.color == color02)
            {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { color01, color04 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (Y, R, B, ?)
                if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Green (Y, R, B, G)
                    renderers[3].material.color = color04;
                }

                //Third Color is Green (Y, R, G, ?)
                else if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Blue (Y, R, G, B)
                    renderers[3].material.color = color01;
                }
                
            }

            // Second Color is Blue (Y, B, ?, ?)

            else if (renderers[1].material.color == color01)
            {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { color04, color02 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (Y, B, G, ?)
                if (renderers[2].material.color == color04)
                {
                    //Fourth Color is Red (Y, B, G, R)
                    renderers[3].material.color = color02;
                }

                //Third Color is Red (Y, B, R, ?)
                else if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Green (Y, B, R, G)
                    renderers[3].material.color = color04;
                }
                
            }

            // Second Color is Green (Y, G, ?, ?)

            else if (renderers[1].material.color == color04)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { color02, color01 };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (Y, G, R, ?)
                if (renderers[2].material.color == color02)
                {
                    //Fourth Color is Blue (Y, G, R, B)
                    renderers[3].material.color = color01;
                }

                //Third Color is Blue (Y, G, B, ?)
                else if (renderers[2].material.color == color01)
                {
                    //Fourth Color is Red (Y, G, B, R)
                    renderers[3].material.color = color02;
                }
                
            }
        }
    }

    public void SetForbiddenZone()
    {
        if (objectToColor[1].GetComponent<Renderer>().material.color == color02 /* red */)
        {
            forbiddenZoneIsGreen = true;
            Debug.Log("Forbidden color is green");
        }

        else if (objectToColor[1].GetComponent<Renderer>().material.color == color04 /* green */)
        {
            forbiddenZoneIsBlue = true;
            Debug.Log("Forbidden color is blue");
        }
         
        else if(objectToColor[1].GetComponent<Renderer>().material.color == color01 /* blue */)
        {
            forbiddenZoneIsRed = true;
            Debug.Log("Forbidden color is red");
        }

        else if(objectToColor[1].GetComponent<Renderer>().material.color == color03 /*yellow */)
        {
            forbiddenZoneIsYellow = true;
            Debug.Log("Forbidden color is yellow");
        }
    }

    void LimitationAttribution ()
    {
        if(forbiddenZoneIsGreen)
        {
            if (renderers[2].material.color == color02)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == color02)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
        else if (forbiddenZoneIsBlue)
        {
            if (renderers[2].material.color == color04)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == color04)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
        else if (forbiddenZoneIsRed)
        {
            if (renderers[2].material.color == color01)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == color01)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
    }

    ///// Pour lutiliser l'énumérator, ajoute : StartCoroutine(FadeAway()); aux endroits où le joueur perd \\\\\

    IEnumerator FadeAway()
    {
        SteamVR_Fade.Start(Color.black, fadeTime, true);

        Debug.Log(" Fade is starting ");

        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SceneLDClement");
    }
}