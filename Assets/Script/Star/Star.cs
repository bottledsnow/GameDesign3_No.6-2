using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private enum Color
    {
        �S���P�� = 0,
        ����P�� = 1,
        �Ŧ�P�� = 2,
        ���P�� = 3,
    }

    private Animator animator;
    private GameMannager gameMannager;
    private CloakSystem cloakSystem;
    [SerializeField]
    private CloakSystem.Color thisColor;
    [SerializeField]

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameMannager = GameObject.Find("Mannager").GetComponent<GameMannager>();
        cloakSystem = gameMannager.cloakSystem;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.Play("GetStar");
            Debug.Log("���a�I��P��");

            if(cloakSystem.Space1==false)
            {
                Debug.Log("1���Ŷ����o���P��");
                cloakSystem.Space1Color = thisColor;
                cloakSystem.Space1 = true;
            }else
            if(cloakSystem.Space1Color == thisColor)
            {
                Debug.Log("�ɥR1���Ŷ����P����q");
            }
            else
            if(cloakSystem.Space2==false)
            {
                Debug.Log("2���Ŷ����o���P��");
                cloakSystem.Space2Color = thisColor;
                cloakSystem.Space2 = true;
            }
            else
            if(cloakSystem.Space2Color==thisColor)
            {
                Debug.Log("�ɥR2���Ŷ����P����q");
            }else
            {
                Debug.Log("�P���|��");
            }
        }
    }
}
