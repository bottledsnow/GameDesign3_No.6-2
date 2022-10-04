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
    private CloakSystem Mannager;
    [SerializeField]
    private CloakSystem.Color thisColor;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.Play("GetStar");
            Debug.Log("產窱琍方");

            if(Mannager.Space1==false)
            {
                Debug.Log("1腹丁眔琍方");
                Mannager.Space1Color = thisColor;
                Mannager.Space1 = true;
            }else
            if(Mannager.Space1Color == thisColor)
            {
                Debug.Log("干1腹丁琍方秖");
            }
            else
            if(Mannager.Space2==false)
            {
                Debug.Log("2腹丁眔琍方");
                Mannager.Space2Color = thisColor;
                Mannager.Space2 = true;
            }
            else
            if(Mannager.Space2Color==thisColor)
            {
                Debug.Log("干2腹丁琍方秖");
            }else
            {
                Debug.Log("琍方犯");
            }
        }
    }
}
