using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    private GameObject InterObj;
    //��¦�y�{�A�p�g�����쪫����լd
    //��¦�y�{�AĲ�o������������լd
    private bool InteractiveTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KeyItem")
        {
            Debug.Log("Ĳ�o�լd");
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
        //�լd����
        if(InteractiveTrigger)
        {

        }
    }

}
