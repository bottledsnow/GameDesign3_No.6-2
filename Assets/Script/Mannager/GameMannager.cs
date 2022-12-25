using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour
{
    public static GameMannager gameMannager;
    private void Awake()
    {
        gameMannager = GetComponent<GameMannager>();
        eventMannager = GetComponent<EventMannager>();
    }

    public EventMannager eventMannager;
    public CloakSystem cloakSystem;
    public PlayerState playerState;
    public UIMannager UImannager;
    public DialogueSystem dialogueSystem;
    public FadeInOut fadeInOut;
    public RebirthManager rebirthManager;
    public PlayerMovement_Velocity movement;
    
}
