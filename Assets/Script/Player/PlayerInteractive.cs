using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    //��¦�y�{�A�p�g�����쪫����լd
    //��¦�y�{�AĲ�o������������լd
    private DialogueSystem dialogueSystem;
    [Header("�ƥ�")]
    public int MeetID=0;
    [SerializeField]
    private bool[] Meet; 
    private bool canTalk;
    private bool OnTalk;

    private void Start()
    {
        dialogueSystem = GameMannager.gameMannager.dialogueSystem;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="NPC")
        {
            canTalk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            canTalk = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTalk && OnTalk != true)
        {
            if(!Meet[MeetID])
            {
                dialogueSystem.StartMeet(MeetID);
                Meet[MeetID] = true;
            }
        }
    }
}
