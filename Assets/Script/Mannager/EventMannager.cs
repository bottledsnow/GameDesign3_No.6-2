using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMannager : MonoBehaviour
{
    private PlayerInteractive playerInteractive;
    [Header("Event1")]
    [SerializeField]
    private bool[] EventTrigger;
    [SerializeField]
    private GameObject Star1;
    [SerializeField]
    private GameObject Star2;
    [Header("Event2")]
    public bool[] Telepor;
    [Header("Event3")]
    [SerializeField]
    private GameObject StarRoad;
    [SerializeField]
    private GameObject realObservatory;

    private void Start()
    {
        playerInteractive = GameMannager.gameMannager.cloakSystem.gameObject.GetComponent<PlayerInteractive>();
    }
    public void Event1()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        EventTrigger[0] =true;
    }

    public void Event2()
    {
        if(Telepor[0]&& Telepor[1]&&Telepor[2])
        {
            Debug.Log("¦^¥h§ä NPC §a¡I");
            EventTrigger[1] = true;
            playerInteractive.MeetID = 1;
        }
    }

    public void Event3()
    {
        StarRoad.SetActive(true);
        realObservatory.SetActive(true);
    }
}
