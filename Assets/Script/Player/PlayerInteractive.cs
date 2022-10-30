using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    //基礎流程，雷射→打到物件→調查
    //基礎流程，觸發→偵測物件→調查
    private DialogueSystem dialogueSystem;
    private bool canTalk;

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
        if(Input.GetKeyDown(KeyCode.E) && canTalk)
        {
            dialogueSystem.StartMeet1();
        }
    }

}
