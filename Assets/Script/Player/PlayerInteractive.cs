using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    //基礎流程，雷射→打到物件→調查
    //基礎流程，觸發→偵測物件→調查
    private DialogueSystem dialogueSystem;
    [Header("事件")]
    [SerializeField]
    private bool Meet1; 
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
            if(!Meet1)
            {
                dialogueSystem.StartMeet1();
                Meet1 = true;
            }
        }
    }
}
