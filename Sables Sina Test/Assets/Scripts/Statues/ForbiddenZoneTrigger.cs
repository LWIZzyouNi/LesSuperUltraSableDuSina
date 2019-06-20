using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenZoneTrigger : MonoBehaviour {
    
    public SortColor m_SortColor;

    private void Awake()
    {
        m_SortColor = gameObject.GetComponentInParent<SortColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Board_Ball"))
        {
            Debug.Log("Ball is in Trigger");

            if(gameObject.name == ("ColoredZone01"))
            {
                Debug.Log("Ball is in ColoredZone01");

                if (m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue)
                {
                    Debug.Log("You lose !");
                }
            }

            if (gameObject.name == ("ColoredZone02"))
            {
                Debug.Log("Ball is in ColoredZone02");

                if (m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue)
                {
                    Debug.Log("You lose !");
                }
            }

            if (gameObject.name == ("ColoredZone03"))
            {
                Debug.Log("Ball is in ColoredZone03");

                if(m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue)
                { 
                    Debug.Log("You lose !");
                }
            }

            if (gameObject.name == ("ColoredZone04"))
            {
                Debug.Log("Ball is in ColoredZone04");

                if (m_SortColor.forbiddenZoneIsRed || m_SortColor.forbiddenZoneIsGreen || m_SortColor.forbiddenZoneIsYellow || m_SortColor.forbiddenZoneIsBlue)
                {
                    Debug.Log("You lose !");
                }
            }
        }
    }
}
