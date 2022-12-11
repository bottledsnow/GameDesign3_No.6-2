using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipChild : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField]
    private TipSystem tipSystem;
    [SerializeField]
    private bool haveSameObject;
    [SerializeField]
    private GameObject[] SameObjects;
    [Header("Setting")]
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private bool TriggerYet;
    [SerializeField]
    private wordType wordType;
    public int TriiggerID;
    [Header("Level Tip")]
    [SerializeField]
    private bool useLevelSystem;
    [SerializeField]
    private int MaxLevel;
    [SerializeField]
    private TipChild[] otherTips;
    [Header("SetExit")]
    [SerializeField]
    private bool SetExit;
    [SerializeField]
    private GameObject Tips1;
    [SerializeField]
    private GameObject Tips2;
    [Header("serial")]
    [SerializeField]
    private GameObject NextObject;

    private void OnTriggerEnter(Collider other)
    {
        if(!TriggerYet)
        {
            if(NextObject!=null)
            {
                NextObject.SetActive(true);
            }
            if (other.gameObject.tag == "Player")
            {
                if(waitTime!=0)
                {
                    tipSystem.waitTime = waitTime;
                }
                tipSystem.ToShow(wordType, TriiggerID);
                TriggerYet = true;
                Debug.Log("Trigeer");
                if(haveSameObject)
                {
                    for(int i=0;i<SameObjects.Length;i++)
                    {
                        SameObjects[i].SetActive(false);
                    }
                }
                if(useLevelSystem && MaxLevel>0)
                {
                    for(int i=0;i<otherTips.Length;i++)
                    {
                        otherTips[i].TriiggerID++;
                        MaxLevel--;
                        otherTips[i].MaxLevel--;
                    }
                }
                if(SetExit)
                {
                    Tips1.SetActive(true);
                    Tips2.SetActive(true);
                }
            }
        }
    }
}
