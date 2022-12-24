using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManagerChild : RebirthManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            ToRebirth();
        }
    }
}
