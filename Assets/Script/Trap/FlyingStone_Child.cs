using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingStone_Child : MonoBehaviour
{
    [SerializeField]
    private FlyingStone flyingStone;
    [Header("基本資料")]
    [SerializeField]
    private int PositionID;
    [SerializeField]
    private float stayTime;
    [SerializeField]
    private float maxStayTime;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FlyingStone" && flyingStone.targetNumber == PositionID) 
        {
            stayTime += Time.deltaTime;
            if(stayTime>maxStayTime)
            {
                flyingStone.PositionMoveTo(PositionID + 1);
                stayTime = 0;
            }
        }
    }
}
