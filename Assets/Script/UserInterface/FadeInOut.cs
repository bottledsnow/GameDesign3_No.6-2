using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }
    public void FadeIn(float time)
    {
        Invoke("FadeIn", time);
    }
    public void FadeOut()
    {
        animator.Play("FadeOut");
    }
    public void FadeOut(float time)
    {
        Invoke("FadeOut", time);
    }

}
