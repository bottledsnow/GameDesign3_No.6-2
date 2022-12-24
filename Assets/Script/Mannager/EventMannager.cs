using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMannager : MonoBehaviour
{
    private PlayerInteractive playerInteractive;
    [Header("ALL")]
    [SerializeField]
    private bool[] EventTrigger;
    [Header("Event0")]
    [SerializeField]
    private GameObject Mine1;
    [SerializeField]
    private GameObject Mine2;
    [Header("Event1")]
    [SerializeField]
    private GameObject Star1;
    [SerializeField]
    private GameObject Mine;
    [Header("Event2")]
    public bool[] Telepor;
    [Header("Event3")]
    [SerializeField]
    private GameObject StarRoad;
    [SerializeField]
    private GameObject realObservatory;
    [SerializeField]
    private GameObject NormalObject;
    [Header("Event4")]
    [SerializeField]
    private Animator KanaAnimator;

    private void Start()
    {
        playerInteractive = GameMannager.gameMannager.cloakSystem.gameObject.GetComponent<PlayerInteractive>();
    }
    public void Event0()
    {
        Mine1.SetActive(false);
        Mine2.SetActive(false);
        EventTrigger[0] = true;
        Debug.Log("Event0 Trigger");
        //跟卡娜對話
    }
    public void Event1()
    {
        Star1.SetActive(true);
        EventTrigger[1] =true;
        Mine.SetActive(true);
        Debug.Log("Event1 Trigger");
        //對話完
    }

    public void Event2()
    {
        if(Telepor[0])
        {
            Debug.Log("回去找 NPC 吧！");
            EventTrigger[2] = true;
            playerInteractive.MeetID = 1;
            Debug.Log("Event2 Trigger");
        }
    }

    public void Event3()
    {
        StarRoad.SetActive(true);
        realObservatory.SetActive(true);
        NormalObject.SetActive(false);
        EventTrigger[3] = true;
        Debug.Log("Event3 Trigger");
    }
    public void Event4()
    {
        KanaAnimator.Play("Stand");
    }
}
