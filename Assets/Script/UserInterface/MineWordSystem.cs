using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class MineSentence
{
    public string Summary;
    public int ID;
    [TextArea(3, 10)]
    public string sentence;
}
public class MineWordSystem : MonoBehaviour
{
    [Header("Mine System Basic Setting")]
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    private Animator animator;
    private bool start;
    private float timer;
    [SerializeField]
    private MineSentence[] Sentence;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(start)
        {
            timerSystem();
            animator.SetFloat("TinnkingTime", timer);
        }
    }

    public void StartSentence(int ID)
    {
        textMeshPro.text = Sentence[ID].sentence;
        start = true;
        animator.SetTrigger("Thinking");
       
    }

    private void timerSystem()
    {
        timer -= Time.deltaTime;
        
        if(timer<0)
        {
            start = false;
            timer = 0;
            Debug.Log("Time over");
        }
    }
    public void SetTimer(float Time)
    {
        timer = Time;
    }
}
