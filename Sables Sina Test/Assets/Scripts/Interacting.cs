using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Interacting : MonoBehaviour
{

    [HideInInspector]

    public Hand m_ActiveHand = null;
}


