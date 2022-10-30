using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ä²µo");
        if (other.gameObject.tag == "Star")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Ä²µo2");
            animator.Play("Brewing");
        }
    }
}
