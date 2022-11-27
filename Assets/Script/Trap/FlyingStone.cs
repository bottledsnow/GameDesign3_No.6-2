using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingStone : MonoBehaviour
{
    private Rigidbody stoneRigid;
    [Header("兩點移動座標")]
    private GameObject Target;
    public int targetNumber;
    [SerializeField]
    private GameObject[] position;
    [Header("基本參數")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool Trigger;
    private void Start()
    {
        Target = position[targetNumber];
        stoneRigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(Trigger)
        {
            Vector3 StartPosition = this.transform.position;
            Vector3 Direction = Target.transform.position - StartPosition;
            stoneRigid.velocity = Direction * speed;
        }
    }

    public void PositionMoveTo(int PositionID)
    {
        targetNumber = PositionID;

        if(position[targetNumber]!=null)
        {
            Target = position[targetNumber];
        }
        else
        {
            Target = position[0];
            targetNumber = 0;
        }
    }

    public void StartMove()
    {
        Trigger = true;
    }
    public void StopMove()
    {
        Trigger = false;
    }
}
