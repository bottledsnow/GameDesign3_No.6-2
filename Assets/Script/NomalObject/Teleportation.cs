using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int teleportationID;
    [SerializeField]
    private EventMannager eventMannager;
    [SerializeField]
    private GameObject Mine_Triggerfalse1;
    [SerializeField]
    private GameObject Mine_Triggerfalse2;
    [SerializeField]
    private GameObject Mine_Triggertrue;
    private bool ready;

    private void Start()
    {
        eventMannager = GameMannager.gameMannager.eventMannager;
        animator.Play("absorb");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("觸發");
        if (other.gameObject.tag == "Star")
        {
            other.gameObject.SetActive(false);
            Teleport(0);
        }
        if (other.gameObject.tag == "Player" && ready)
        {
            Debug.Log("Player Trigger Teleport");
            Teleport(1);
            eventMannager.Event2();
            Mine_Triggerfalse1.SetActive(false);
            Mine_Triggerfalse2.SetActive(false);
            Mine_Triggertrue.SetActive(true);
        }
    }

    private void Teleport(int State)
    {
        switch(State)
        {
            case 0:
                ready = true;
                animator.Play("diverge");
                break;
            case 1:
                Debug.Log("觸發2");
                animator.Play("Brewing");
                eventMannager.Telepor[teleportationID] = true;
                //觸發前往下一個的特效
                break;
            case 2:
                break;
        }
           
    }
}
