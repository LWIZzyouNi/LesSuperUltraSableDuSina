using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoor : MonoBehaviour {

    public GameObject[] cylinders;
    public List<Animator> m_Animator;
    public List<Vector3> vectors;

    public GameObject pillar;
    public Animator m_PillarAnimator;

    public AudioClip lockSound;
    public AudioClip locked;

    public float timer = 0f;
    public float maxTimerValue = 5f;
    private float startTimer = 0f;

    private int stateNumber = 0;

    // Use this for initialization
    void Start ()
    {
        getChild();
        pillar = GameObject.FindGameObjectWithTag("Pillar");
        m_PillarAnimator = pillar.GetComponent<Animator>();
        maxTimerValue = GameManager.s_Singleton.timer / 10;

    }
	
	// Update is called once per frame
	void Update ()
    {
        TimerCount();
    }

    private void getChild()
    {
        cylinders = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            cylinders[i] = transform.GetChild(i).gameObject;
            cylinders[i].GetComponent<Animator>();
            m_Animator.Add(cylinders[i].GetComponent<Animator>());
        }

        foreach(GameObject obj in cylinders)
        {
            Vector3 startPos = Vector3.zero;
            startPos = obj.transform.localPosition;
            vectors.Add(obj.transform.localPosition);
        }
    }

    private void TimerCount()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimerValue)
        {
            timer = startTimer;
            Vector3 startPos = Vector3.zero;
            startPos = pillar.transform.localPosition;

            if (stateNumber == 0)
            {
                m_Animator[0].enabled = true;
                m_Animator[0].SetBool("Push01", true);
                m_PillarAnimator.SetBool("Up01", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 1)
            {
                m_Animator[1].enabled = true;
                m_Animator[1].SetBool("Push02", true);
                m_PillarAnimator.SetBool("Up02", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 2)
            {
                m_Animator[2].enabled = true;
                m_Animator[2].SetBool("Push03", true);
                m_PillarAnimator.SetBool("Up03", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 3)
            {
                m_Animator[3].enabled = true;
                m_Animator[3].SetBool("Push04", true);
                m_PillarAnimator.SetBool("Up04", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 4)
            {
                m_Animator[4].enabled = true;
                m_Animator[4].SetBool("Push05", true);
                m_PillarAnimator.SetBool("Up05", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 5)
            {
                m_Animator[5].enabled = true;
                m_Animator[5].SetBool("Push06", true);
                m_PillarAnimator.SetBool("Up06", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 6)
            {
                m_Animator[6].enabled = true;
                m_Animator[6].SetBool("Push07", true);
                m_PillarAnimator.SetBool("Up07", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 7)
            {
                m_Animator[7].enabled = true;
                m_Animator[7].SetBool("Push08", true);
                m_PillarAnimator.SetBool("Up08", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 8)
            {
                m_Animator[8].enabled = true;
                m_Animator[8].SetBool("Push09", true);
                m_PillarAnimator.SetBool("Up09", true);
                SoundManager.instance.RandomizeSFX(lockSound);
                stateNumber++;
            }

            else if (stateNumber == 9)
            {
                m_Animator[9].enabled = true;
                m_Animator[9].SetBool("Push10", true);
                m_PillarAnimator.SetBool("Up10", true);
                SoundManager.instance.PlaySingle(locked);
                stateNumber++;
            }
        }
    }


}
