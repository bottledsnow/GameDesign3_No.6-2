using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("�ͩR")]
    public float MaxHp;
    public float Hp;
    public float Recover;
    [Header("���O 1 ����m")]
    public bool Activity_1;
    public float MaxDurability_1;
    public float Durability_1;
    [Header("���O 2 ����m")]
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
            Debug.Log("���a���`");
        }
    }
}
