using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAbsorb : MonoBehaviour
{
    public UnityEvent addEvent;
    [SerializeField]
    private GameObject absorb;
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            absorb.SetActive(false);
            TriggerEvent();
        }
    }


    private void TriggerEvent()
    {
        Debug.Log("Event of need to trigger");
        addEvent.Invoke();
    }
}
