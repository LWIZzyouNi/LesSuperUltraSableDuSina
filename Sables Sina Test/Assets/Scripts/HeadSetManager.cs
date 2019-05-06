using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetManager : MonoBehaviour
{

    public Vector3 targetObject;

    public static HeadSetManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 GetTrsDest()
    {
        targetObject = this.transform.position;
        return targetObject;
    }
}