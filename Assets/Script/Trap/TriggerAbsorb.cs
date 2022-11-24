using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAbsorb : MonoBehaviour
{
    [SerializeField]
    private GameObject absorb;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Star")
        {
            Destroy(collision.gameObject);
            absorb.SetActive(false);
            TriggerEvent();
        }
    }

    private void TriggerEvent()
    {
        Debug.Log("Event of need to trigger");
    }
}
