using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipSystem : MonoBehaviour
{
    [SerializeField]
    private bool Show;
    [SerializeField]
    private GameObject TipUI;
    private Animator animator;
    private bool TriggerEnter;
    private bool TriggerExit;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ToShow()
    {
        if (TriggerEnter == false)
        {
            animator.SetTrigger("Enter");
            //animator.Play("Enter");
            //TipUI.gameObject.SetActive(true);
            TriggerEnter = true;
        }
    }
    public void ToClose()
    {
        if (TriggerExit == false)
        {
            animator.SetTrigger("Exit");
            //animator.Play("Exit");
            //TipUI.gameObject.SetActive(false);
            TriggerExit = true;
        }
    }

}
