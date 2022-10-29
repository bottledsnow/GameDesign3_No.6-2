using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private CloakSystem cloakSystem;
    [Header("生命")]
    public float MaxHp;
    public float Hp;
    public float Recover;
    [Header("斗篷 1 號位置")]
    [SerializeField]
    private bool Activity_1;
    [SerializeField]
    private float MaxDurability_1;
    [SerializeField]
    private float Durability_1;
    [SerializeField]
    private float lose_1;
    [Header("斗篷 2 號位置")]
    [SerializeField]
    private bool Activity_2;
    [SerializeField]
    private float MaxDurability_2;
    [SerializeField]
    private float Durability_2;
    [SerializeField]
    private float lose_2;

    private void Start()
    {
        cloakSystem = GameMannager.gameMannager.cloakSystem;
    }
    private void Update()
    {
        DurabilitySystem();
    }
    private void DurabilitySystem()
    {
        //Put in Update
        if(Activity_1 && cloakSystem.SpaceNumber==1)
        {
            Durability_1 -= Time.deltaTime * lose_1;
            Debug.Log("失去中");

            if (Durability_1 > MaxDurability_1)
            {
                Durability_1 = MaxDurability_1;
            }
            if (Durability_1 < 0)
            {
                DurabilitySystem(1, "Lose");
                cloakSystem.SwitchColor(0);
                cloakSystem.SpaceNumber = 0;
                cloakSystem.Space1 = false;
                cloakSystem.Space1Color = 0;
            }
        }

        if(Activity_2 && cloakSystem.SpaceNumber == 2)
        {
            Durability_2 -= Time.deltaTime * lose_2;

            if (Durability_2 > MaxDurability_2)
            {
                Durability_2 = MaxDurability_2;
            }
            if (Durability_1 < 0)
            {
                DurabilitySystem(1, "Lose");
                cloakSystem.SwitchColor(0);
                cloakSystem.SpaceNumber = 0;
                cloakSystem.Space2 = false;
                cloakSystem.Space2Color = 0;
            }
        }
    }
    public void DurabilitySystem(int SpaceNumber,string GetLose)
    {
        if(GetLose=="Get")
        {
            switch (SpaceNumber)
            {
                case 1:
                    Durability_1 = MaxDurability_1;
                    Activity_1 = true;
                    break;
                case 2:
                    Durability_2 = MaxDurability_2;
                    Activity_2 = true;
                    break;
                default:
                    Debug.Log("系統出錯");
                    break;
            }
        }
        if(GetLose=="Lose")
        {
            switch (SpaceNumber)
            {
                case 1:
                    Durability_1 = 0;
                    Activity_1 = false;
                    break;
                case 2:
                    Durability_2 = 0;
                    Activity_2 = false;
                    break;
                default:
                    Debug.Log("系統出錯");
                    break;
            }
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
