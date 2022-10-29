using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private enum Color
    {
        ⊿Τ琍方 = 0,
        ︹琍方 = 1,
        屡︹琍方 = 2,
        厚︹琍方 = 3,
    }

    private Animator animator;
    [SerializeField]
    private CloakSystem CloakSystem;
    [SerializeField]
    private PlayerState StateSystem;
    [SerializeField]
    private CloakSystem.Color thisColor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CloakSystem = GameMannager.gameMannager.cloakSystem;
        StateSystem = GameMannager.gameMannager.playerState;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.Play("GetStar");
            Debug.Log("產窱琍方");

            if (CloakSystem.Space1 == false)
            {
                Debug.Log("1腹丁眔琍方");
                CloakSystem.Space1Color = thisColor;
                CloakSystem.Space1 = true;
                StateSystem.DurabilitySystem(1,"Get");
            }
            else
            if (CloakSystem.Space1Color == thisColor)
            {
                Debug.Log("干1腹丁琍方秖");
            }
            else
            if (CloakSystem.Space2 == false) 
            {
                Debug.Log("2腹丁眔琍方");
                CloakSystem.Space2Color = thisColor;
                CloakSystem.Space2 = true;
                StateSystem.DurabilitySystem(2,"Get");
            }
            else
            if(CloakSystem.Space2Color==thisColor)
            {
                Debug.Log("干2腹丁琍方秖");
            }else
            {
                Debug.Log("琍方犯");
            }
        }
    }
}
