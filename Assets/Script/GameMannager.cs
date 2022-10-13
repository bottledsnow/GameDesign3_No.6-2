using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager : MonoBehaviour
{
    public static GameMannager gameMannager;

    private void Start()
    {
        gameMannager = GetComponent<GameMannager>();
    }

    public CloakSystem cloakSystem;
}
