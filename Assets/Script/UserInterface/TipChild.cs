using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipChild : MonoBehaviour
{
    [SerializeField]
    public AnimatorControllerParameter Controller;
    [SerializeField]
    private TipSystem tipSystem;
    [SerializeField]
    private wordType wordType;
    [SerializeField]
    private int TriiggerID;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            tipSystem.ToShow(wordType, TriiggerID);
            Debug.Log("Trigeer");
        }
    }
}
