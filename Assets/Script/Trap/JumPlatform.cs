using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumPlatform : MonoBehaviour
{
    [SerializeField]
    private float Force;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 UpForce = new Vector3(rigid.velocity.x, Force, rigid.velocity.z);
            rigid.AddForce(UpForce, ForceMode.Impulse);
            animator.Play("JumpPlatform");
    }
}
