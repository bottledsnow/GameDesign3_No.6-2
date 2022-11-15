using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMannager : MonoBehaviour
{
    [Header("Event1")]
    [SerializeField]
    private bool Event1Trigger;
    [SerializeField]
    private GameObject Star1;
    [SerializeField]
    private GameObject Star2;
    public void Event1()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
    }
}
