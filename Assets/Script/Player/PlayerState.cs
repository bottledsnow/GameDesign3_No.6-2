using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private Animator animator;
    private CloakSystem cloakSystem;
    private FadeInOut fadeInout;
    private RebirthManager rebirthManager;
    private PlayerMovement_Velocity movement;
    [Header("生命")]
    [SerializeField]
    private float MaxHp;
    [SerializeField]
    public float Hp;
    [SerializeField]
    public float Recover;
    [Header("斗篷 1 號位置")]
    [SerializeField]
    private bool Activity_1;
    [SerializeField]
    private float MaxDurability_1;
    public float Durability_1;
    [SerializeField]
    private float lose_1;
    [Header("斗篷 2 號位置")]
    [SerializeField]
    private bool Activity_2;
    [SerializeField]
    private float MaxDurability_2;
    public float Durability_2;
    [SerializeField]
    private float lose_2;
    [Header("特效")]
    [SerializeField]
    private ParticleSystem hurtParticle;

    private void Awake()
    {
        cloakSystem = GameMannager.gameMannager.cloakSystem;
        animator = GetComponent<Animator>();
        fadeInout = GameMannager.gameMannager.fadeInOut;
        rebirthManager = GameMannager.gameMannager.rebirthManager;
        movement = GameMannager.gameMannager.movement;
    }
    private void Update()
    {
        DurabilitySystem();
        LifeSystem();

        //test
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Hp = 0;
        }
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
                    float temporaryDurability = Durability_2;
                    bool temporaryActivity = Activity_2;
                    Durability_2 = 0;
                    Activity_2 = false;
                    Activity_1 = temporaryActivity;
                    Durability_1 = temporaryDurability;
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
        if (Hp >= MaxHp)
        {
            Hp = MaxHp;
        }else
        if (0<Hp && Hp<MaxHp)
        {
            Hp += Recover * Time.deltaTime;
        }
        else
        if (Hp <= 0)
        {
            animator.Play("Death");
            rebirthManager.ToRebirth();
            Hp = 80;
            loseController();
            Invoke("GetController", 1.5f);
        }
    }

    public void GetHurt(float Damage)
    {
        Hp -= Damage;
        hurtParticle.Play();
    }

    private void loseController()
    {
        movement.enabled = false;
    }
    private void GetController()
    {
        movement.enabled = true;
    }
}
