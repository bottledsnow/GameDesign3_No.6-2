using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ĳ�o");
        if (other.gameObject.tag == "Star")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Ĳ�o2");
            animator.Play("Brewing");
        }
    }
}
