using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManagerChild : RebirthManager
{
    [Header("Setting")]
    [SerializeField]
    private bool Check;
    [SerializeField]
    private RebirthManager rebirth;
    [SerializeField]
    private int PositionID;
    private void OnTriggerEnter(Collider other)
    {
        if(Check)
        {
            rebirth.Position = PositionID;
        }else
        {
            if (other.tag == "Player")
            {
                ToRebirth();
            }
        }
    }
}
