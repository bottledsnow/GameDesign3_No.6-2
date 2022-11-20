using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueSystem : MonoBehaviour
{
    public bool Ontalk;
    [SerializeField]
    private NPCConversation[] Meet;
    public void StartMeet(int ID)
    {
        ConversationManager.Instance.StartConversation(Meet[ID]);
    }
}
