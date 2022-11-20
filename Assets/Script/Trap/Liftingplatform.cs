using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftingplatform : MonoBehaviour
{
    private Rigidbody rigid;
    private float time;
    
    [Header("Basic")]
    [SerializeField]
    private float Speed;
    private float speed;
    [SerializeField]
    private float movetime;
    [SerializeField]
    private float stoptime;



    private void Awake()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        speed = Speed;
        time = movetime;
    }

    private void Update()
    {
        movePlatform();
        timer();
    }

    private void movePlatform()
    {
        rigid.velocity = new Vector3(0, speed, 0);
    }

    private void timer()
    {
        time -= Time.deltaTime;

        if(time<=0)
        {
            time = movetime;
            speed = -speed;
        }
    }

}
