using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.Play("broken");
    }
}
