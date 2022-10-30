using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private PlayerState playerState;
    [Header("基本資料")]
    [SerializeField]
    private float damage;
    [SerializeField]
    private float interval;
    private float damageInterval;
    private bool canHurt;

    private void Start()
    {
        playerState = GameMannager.gameMannager.playerState;
    }
    private void Update()
    {
        damageSystem();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player" && canHurt)
        {
            hurt();
        }
    }
    private void damageSystem()
    {
        if(canHurt==false)
        {
            interval += Time.deltaTime;

            if (interval > damageInterval)
            {
                interval = 0;
                canHurt = true;
            }
        }
    }
    private void hurt()
    {
        playerState.GetHurt(damage);
        canHurt = false;
    }
}
