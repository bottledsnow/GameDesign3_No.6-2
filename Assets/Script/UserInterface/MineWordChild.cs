using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWordChild : MonoBehaviour
{
    [SerializeField]
    private MineWordSystem mineWordSystem;
    [SerializeField]
    private int WordID;
    [SerializeField]
    private float thinkingTime;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mineWordSystem.StartSentence(WordID);
            mineWordSystem.SetTimer(thinkingTime);
        }
    }
}
