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
    private CloakSystem CloakSystem;
    private PlayerState StateSystem;
    private UIMannager UImannager;
    [SerializeField]
    private CloakSystem.Color thisColor;
    [SerializeField]
    private float floatingFroce;
    private void Start()
    {
        animator = GetComponent<Animator>();
        CloakSystem = GameMannager.gameMannager.cloakSystem;
        StateSystem = GameMannager.gameMannager.playerState;
        UImannager = GameMannager.gameMannager.UImannager;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Trigggggggggggggggggggger");
        if (other.gameObject.tag == "Player")
        {
            animator.Play("GetStar");
            Debug.Log("���a�I��P��");

            if (CloakSystem.Space1 == false)
            {
                Debug.Log("1���Ŷ����o���P��");
                CloakSystem.Space1Color = thisColor;
                CloakSystem.Space1 = true;
                StateSystem.DurabilitySystem(1,"Get");
                UImannager.SwitchCloakBarColor();
            }
            else
            if (CloakSystem.Space1Color == thisColor)
            {
                Debug.Log("�ɥR1���Ŷ����P����q");
            }
            else
            if (CloakSystem.Space2 == false) 
            {
                Debug.Log("2���Ŷ����o���P��");
                CloakSystem.Space2Color = thisColor;
                CloakSystem.Space2 = true;
                StateSystem.DurabilitySystem(2,"Get");
                UImannager.SwitchCloakBarColor();
            }
            else
            if(CloakSystem.Space2Color==thisColor)
            {
                Debug.Log("�ɥR2���Ŷ����P����q");
            }else
            {
                Debug.Log("�P���|��");
            }
            
        }else
        {
            
        }
    }
    
    public void DestroyStar()
    {
        Destroy(this.animator.gameObject);
    }
    private void floating()
    {
        //nouse;
        Rigidbody rigid = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, floatingFroce, 0);
        rigid.AddForce(force, ForceMode.Force);
        Debug.Log("Forceeee");
    }
}
