using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    private GameObject InterObj;
    //基礎流程，雷射→打到物件→調查
    //基礎流程，觸發→偵測物件→調查
    private bool InteractiveTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KeyItem")
        {
            Debug.Log("觸發調查");
            InteractiveTrigger = true;
            InterObj = other.gameObject;
        }
    }

    private void Update()
    {
        Interactive();
    }

    private void Interactive()
    {
        //調查物件
        if(InteractiveTrigger)
        {

        }
    }

}
