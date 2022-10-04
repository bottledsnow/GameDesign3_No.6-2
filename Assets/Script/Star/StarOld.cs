using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOld : MonoBehaviour
{
    [SerializeField]
    private StarMannagerOld mannager;
    [SerializeField]
    private GameObject fireworks;
    private ParticleSystem firework1;
    private ParticleSystem firework2;

    private void Start()
    {
        firework1 = fireworks.transform.GetChild(0).GetComponent<ParticleSystem>();
        firework2 = fireworks.transform.GetChild(1).GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            fireWork();
            mannager.PlayerGetStar();
            mannager.starInPosition++;
        }
    }

    private void fireWork()
    {
        fireworks.transform.position = mannager.Positions[mannager.starInPosition-1].transform.position;
        firework1.Play();
        firework2.Play();
        Debug.Log("Trigger");
    }
}
