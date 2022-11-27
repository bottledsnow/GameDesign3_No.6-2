using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerChild : MonoBehaviour
{
    [SerializeField]
    private UnityEvent addevent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            TriggerEvent();
            this.gameObject.SetActive(false);
        }
    }

    public void TriggerEvent()
    {
        addevent.Invoke();
    }
}
