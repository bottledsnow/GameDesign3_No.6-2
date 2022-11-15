using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueSystem : MonoBehaviour
{
    public bool Ontalk;
    [SerializeField]
    private NPCConversation Meet1;
    public void StartMeet1()
    {
        ConversationManager.Instance.StartConversation(Meet1);
    }
}
