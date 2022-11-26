using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum wordType
{
    Tip,
    Mine,
}
public class TipSystem : MonoBehaviour
{
    private Animator animator;
    private bool Show;
    
    [Header("Basic")]
    [SerializeField]
    private TMP_Text Text;
    [Header("Setting")]
    [SerializeField]
    private float waitTime;
    [Header("Event")]
    [TextArea(3,10)]
    [SerializeField]
    private string[] Tips;
    [TextArea(3,10)]
    [SerializeField]
    private string[] Mines;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ToShow(wordType Type, int ID)
    {
        switch(Type)
        {
            case wordType.Tip:
                Text.text = Tips[ID];
                break;
            case wordType.Mine:
                Text.text = Mines[ID];
                break;
        }
        if(Show)
        {
            animator.Play("Exit");
            Show = false;
            CancelInvoke();
        }
        animator.SetTrigger("Enter");
        Invoke("ToClose", waitTime);
        Show = true;
    }
    public void ToClose()
    {
        animator.SetTrigger("Exit");
        Show = false;
    }
}
