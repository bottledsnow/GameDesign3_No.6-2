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
            Debug.Log("���a�I��P��");

            if(Mannager.Space1==false)
            {
                Debug.Log("1���Ŷ����o���P��");
                Mannager.Space1Color = thisColor;
                Mannager.Space1 = true;
            }else
            if(Mannager.Space1Color == thisColor)
            {
                Debug.Log("�ɥR1���Ŷ����P����q");
            }
            else
            if(Mannager.Space2==false)
            {
                Debug.Log("2���Ŷ����o���P��");
                Mannager.Space2Color = thisColor;
                Mannager.Space2 = true;
            }
            else
            if(Mannager.Space2Color==thisColor)
            {
                Debug.Log("�ɥR2���Ŷ����P����q");
            }else
            {
                Debug.Log("�P���|��");
            }
        }
    }
}
