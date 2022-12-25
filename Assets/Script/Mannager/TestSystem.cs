using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Position;
    [SerializeField]
    private GameObject player;
    
    
    private void Update()
    {
        Debug.Log("system..14545");
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            player.transform.position = Position[0].transform.position;
            Debug.Log("system..14545");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            player.transform.position = Position[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            player.transform.position = Position[2].transform.position;
        }
    }
}
