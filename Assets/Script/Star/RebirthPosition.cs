using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthPosition : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField]
    private bool OnLive;
    [SerializeField]
    private GameObject WaitProducing;
    [SerializeField]
    private float refreshTime;
    [SerializeField]
    private CloakSystem.Color StarColor;

    [Header("Setting")]
    private float time;
    [SerializeField]
    private GameObject[] Star;
    [SerializeField]
    private GameObject ProducingObject;
    private void Start()
    {
        time = refreshTime; 
    }
    private void Update()
    {
        OnliveChick();
        timer();
    }
    private void produceStar()
    {
        Vector3 thisPosition = this.transform.position;
        Quaternion thisRotation = this.transform.rotation;
        if (OnLive)
        {
            Debug.Log("Now Have Star");
        }
        else
        {
            ProducingObject = Instantiate(WaitProducing, thisPosition, thisRotation);
            Debug.Log("Instantiate");
            OnLive = true;
        }
    }

    private void judgeColor()
    {
        if ((int)StarColor == 0)
        {
            WaitProducing = Star[Random.Range(1, 3)];
        }
        else
        if ((int)StarColor == 1)
        {
            WaitProducing = Star[0];
        }
        else
        if ((int)StarColor == 2) 
        {
            WaitProducing = Star[1];
        }
        else
        if ((int)StarColor == 3)
        {
            WaitProducing = Star[2];
        }
    }

    private void OnliveChick()
    {
        if(ProducingObject==null)
        {
            OnLive = false;
        }
    }

    private void timer()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = refreshTime;
            judgeColor();
            produceStar();
        }
    }
}
