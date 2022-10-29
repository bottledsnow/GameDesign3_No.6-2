using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("生命")]
    public float MaxHp;
    public float Hp;
    public float Recover;
    [Header("斗篷 1 號位置")]
    public bool Activity_1;
    public float MaxDurability_1;
    public float Durability_1;
    [Header("斗篷 2 號位置")]
    public bool Activity_2;
    public float MaxDurability_2;
    public float Durability_2;

    private void Update()
    {
        DurabilitySystem();
    }
    private void DurabilitySystem()
    {
        //Put in Update
        if(Activity_1)
        {

        }
        if(Activity_2)
        {

        }
    }
    private void LifeSystem()
    {
        if (Hp > MaxHp)
        {
            Hp = MaxHp;
        }
        else
        if (Hp <= 0)
        {
            Debug.Log("玩家死亡");
        }
    }
}
