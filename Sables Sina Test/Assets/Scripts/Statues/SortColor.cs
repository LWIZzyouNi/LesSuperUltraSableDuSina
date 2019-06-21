using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortColor : MonoBehaviour {

    public GameObject[] objectToColor;

    int randomColor01 = 0;
    int randomColor02 = 0;
    int randomColor03 = 0;

    public Color[] colors = { Color.blue, Color.red, Color.yellow, Color.green };

    [SerializeField]
    public List<Renderer> renderers;

    public bool forbiddenZoneIsBlue = false;
    public bool forbiddenZoneIsGreen = false;
    public bool forbiddenZoneIsRed = false;
    public bool forbiddenZoneIsYellow = false;

    public bool forbiddenZoneIsDownLeft = false;
    public bool forbiddenZoneIsDownRight = false;

    // Use this for initialization
    void Start()
    {
        getChild();
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

    public void FirstColorAttribution()
    {
        randomColor01 = Random.Range(0, colors.Length);

        objectToColor[0].GetComponent<Renderer>().material.color = colors[randomColor01];
    }

    public void CheckColor()
    {

        // Checking first color

        //First Color is Blue

        if (renderers[0].material.color == Color.blue)
        {
            Color[] colorsAfterFirstAttribution = { Color.red, Color.yellow, Color.green };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color

            //Second Color is Red (B, R, ?, ?)

            if (renderers[1].material.color == Color.red)
           {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { Color.yellow, Color.green };

                    randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (B, R, Y, ?)
                if(renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Green (B, R, Y, G)
                    renderers[3].material.color = Color.green;
                }

                //Third Color is Green (B, R, G, ?)
                else if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Yellow (B, R, G, Y)
                    renderers[3].material.color = Color.yellow;
                }
            }

            //Second Color is Yellow (B, Y, ?, ?)

            else if (renderers[1].material.color == Color.yellow)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { Color.green, Color.red };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

               renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (B, Y, G, ?)
                if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Red (B, Y, G, R)
                    renderers[3].material.color = Color.red;
                }

                //Third Color is Red (B, Y, R, ?)
                else if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Green (B, Y, R, G)
                    renderers[3].material.color = Color.green;
                }
            }

            //Second Color is Green (B, G, ?, ?)

            else if (renderers[1].material.color == Color.green)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { Color.red, Color.yellow };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (B, G, R, ?)
                if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Yellow (B, G, R, Y)
                    renderers[3].material.color = Color.yellow;
                }

                //Third Color is Yellow (B, G, Y, ?)
                else if (renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Red (B, G, Y, R)
                    renderers[3].material.color = Color.red;
                }
                
            }

        }

        //First Color is Red

        else if (renderers[0].material.color == Color.red)
        {
            Color[] colorsAfterFirstAttribution = { Color.blue, Color.yellow, Color.green };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];


            // Checking second color
            // Second Color is Blue (R, B, ?, ?)

            if (renderers[1].material.color == Color.blue)
             {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { Color.yellow, Color.green };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (R, B, Y, ?)
                if (renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Green (R, B, Y, G)
                    renderers[3].material.color = Color.green;
                }

                //Third Color is Green (R, B, G, ?)
                else if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Yellow (R, B, G, Y)
                    renderers[3].material.color = Color.yellow;
                }
                
            }

            // Second Color is Yellow (R, Y, ?, ?)

            else if (renderers[1].material.color == Color.yellow)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { Color.green, Color.blue };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (R, Y, G, ?)
                if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Blue (R, Y, G, B)
                    renderers[3].material.color = Color.blue;
                }

                //Third Color is Blue (R, Y, B, ?)
                else if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Green (R, Y, B, G)
                    renderers[3].material.color = Color.green;
                }
                
            }

            // Second Color is Green (R, G, ?, ?)

            else if (renderers[1].material.color == Color.green)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { Color.blue, Color.yellow };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (R, G, B, ?)
                if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Yellow (R, G, B, ?)
                    renderers[3].material.color = Color.yellow;
                }

                //Third Color is Yellow (R, G, Y, ?)
                else if (renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Blue (R, G, Y, B)
                    renderers[3].material.color = Color.blue;
                }
                
            }
        }

        //First Color is Green

        else if (renderers[0].material.color == Color.green)
        {
            Color[] colorsAfterFirstAttribution = { Color.red, Color.blue, Color.yellow };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color
            // Second Color is Red (G, R, ?, ?)

            if (renderers[1].material.color == Color.red)
            {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { Color.blue, Color.yellow };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (G, R, B, ?)
                if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Yellow (G, R, B, Y)
                    renderers[3].material.color = Color.yellow;
                }

                //Third Color is Yellow (G, R, Y, ?)
                else if (renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Blue (G, R, Y, B)
                    renderers[3].material.color = Color.blue;
                }
                
            }

            // Second Color is Blue (G, B, ?, ?)

            else if (renderers[1].material.color == Color.blue)
            {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { Color.yellow, Color.red };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Yellow (G, B, Y, ?)
                if (renderers[2].material.color == Color.yellow)
                {
                    //Fourth Color is Red (G, B, Y, R)
                    renderers[3].material.color = Color.red;
                }

                //Third Color is Red (G, B, R, ?)
                else if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Yellow (G, B, R, Y)
                    renderers[3].material.color = Color.yellow;
                }
                
            }

            // Second Color is Yellow (G, Y, ?, ?)

            else if (renderers[1].material.color == Color.yellow)
            {
                Debug.Log("Second color is yellow");

                Color[] colorsAfterSecondAttribution = { Color.red, Color.blue };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (G, Y, R, ?)
                if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Blue (G, Y, R, B)
                    renderers[3].material.color = Color.blue;
                }
                
                //Third Color is Blue (G, Y, B, ?)
                else if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Red (G, Y, B, R)
                    renderers[3].material.color = Color.red;
                }
            }
        }

        //First Color is Yellow

        else if (renderers[0].material.color == Color.yellow)
        {
            Color[] colorsAfterFirstAttribution = { Color.red, Color.blue, Color.green };

            randomColor02 = Random.Range(0, colorsAfterFirstAttribution.Length);

            renderers[1].material.color = colorsAfterFirstAttribution[randomColor02];

            // Checking second color
            // Second Color is Red (Y, R, ?, ?)

            if (renderers[1].material.color == Color.red)
            {
                Debug.Log("Second color is red");

                Color[] colorsAfterSecondAttribution = { Color.blue, Color.green };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Blue (Y, R, B, ?)
                if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Green (Y, R, B, G)
                    renderers[3].material.color = Color.green;
                }

                //Third Color is Green (Y, R, G, ?)
                else if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Blue (Y, R, G, B)
                    renderers[3].material.color = Color.blue;
                }
                
            }

            // Second Color is Blue (Y, B, ?, ?)

            else if (renderers[1].material.color == Color.blue)
            {
                Debug.Log("Second color is blue");

                Color[] colorsAfterSecondAttribution = { Color.green, Color.red };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Green (Y, B, G, ?)
                if (renderers[2].material.color == Color.green)
                {
                    //Fourth Color is Red (Y, B, G, R)
                    renderers[3].material.color = Color.red;
                }

                //Third Color is Red (Y, B, R, ?)
                else if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Green (Y, B, R, G)
                    renderers[3].material.color = Color.green;
                }
                
            }

            // Second Color is Green (Y, G, ?, ?)

            else if (renderers[1].material.color == Color.green)
            {
                Debug.Log("Second color is green");

                Color[] colorsAfterSecondAttribution = { Color.red, Color.blue };

                randomColor03 = Random.Range(0, colorsAfterSecondAttribution.Length);

                renderers[2].material.color = colorsAfterSecondAttribution[randomColor03];

                //Third Color is Red (Y, G, R, ?)
                if (renderers[2].material.color == Color.red)
                {
                    //Fourth Color is Blue (Y, G, R, B)
                    renderers[3].material.color = Color.blue;
                }

                //Third Color is Blue (Y, G, B, ?)
                else if (renderers[2].material.color == Color.blue)
                {
                    //Fourth Color is Red (Y, G, B, R)
                    renderers[3].material.color = Color.red;
                }
                
            }
        }
    }

    public void SetForbiddenZone()
    {
        if (objectToColor[1].GetComponent<Renderer>().material.color == Color.red)
        {
            forbiddenZoneIsGreen = true;
            Debug.Log("Forbidden color is green");
        }

        else if (objectToColor[1].GetComponent<Renderer>().material.color == Color.green)
        {
            forbiddenZoneIsBlue = true;
            Debug.Log("Forbidden color is blue");
        }

        else if(objectToColor[1].GetComponent<Renderer>().material.color == Color.blue)
        {
            forbiddenZoneIsRed = true;
            Debug.Log("Forbidden color is red");
        }

        else if(objectToColor[1].GetComponent<Renderer>().material.color == Color.yellow)
        {
            forbiddenZoneIsYellow = true;
            Debug.Log("Forbidden color is yellow");
        }
    }

    void LimitationAttribution ()
    {
        if(forbiddenZoneIsGreen)
        {
            if (renderers[2].material.color == Color.red)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == Color.red)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
        else if (forbiddenZoneIsBlue)
        {
            if (renderers[2].material.color == Color.green)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == Color.green)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
        else if (forbiddenZoneIsRed)
        {
            if (renderers[2].material.color == Color.blue)
            {
                forbiddenZoneIsDownLeft = true;
            }
            else if (renderers[3].material.color == Color.blue)
            {
                forbiddenZoneIsDownRight = true;
            }
        }
    }
}