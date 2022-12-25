using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    public int Position;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private FadeInOut FadeInOut;
    [Header("Setting")]
    [SerializeField]
    private GameObject RebirthPosition;
    [SerializeField]
    private float KeepBlackTime;
    [Header("Manager")]
    [SerializeField]
    private bool Manager;
    [SerializeField]
    private GameObject[] AllRebirthPosition;
    public void ToRebirth()
    {
        Debug.Log("Rebirth");
        
        FadeInOut.FadeIn();
        FadeInOut.FadeOut(KeepBlackTime+1);
        if(Manager)
        {
            Invoke("allRebirth", 1);
        }else
        {
            Invoke("Rebirth", 1);
        }
    }

    private void Rebirth()
    {
        Player.transform.position = RebirthPosition.transform.position;
    }
    public void allRebirth()
    {
        Player.transform.position = AllRebirthPosition[Position-1].transform.position;
    }

}
