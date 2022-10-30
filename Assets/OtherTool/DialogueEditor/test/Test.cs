using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Test : MonoBehaviour
{
    public NPCConversation npc;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(npc);
    }
}
