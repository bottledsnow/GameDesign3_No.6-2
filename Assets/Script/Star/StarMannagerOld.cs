using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMannagerOld : MonoBehaviour
{
    [SerializeField]
    private GameObject Star;
    public int starInPosition=1;
    public GameObject[] Positions;

    private void Start()
    {
        Star.transform.position = Positions[starInPosition - 1].transform.position;
    }
    public void PlayerGetStar()
    {
        Star.transform.position = Positions[starInPosition].transform.position;
    }
}
