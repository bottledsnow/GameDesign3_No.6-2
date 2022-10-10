using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorMaterial
{
    public string ColorName;
    public Material JointsColor;
    public Material SurfaceColor;
}
[System.Serializable]
public class PlayerParticle
{
    public string ParticleName;
    public ParticleSystem particleSystem;
}

public class CloakSystem : MonoBehaviour
{
    public enum Color
    {
        沒有星源=0,
        紅色星源=1,
        藍色星源=2,
        綠色星源=3,
    }
    [Header("斗篷運行")]
    private int SpaceNumber;

    [Header("1號 斗篷欄位")]
    public bool Space1;
    public Color Space1Color;
    [Header("2號 斗篷欄位")]
    public bool Space2;
    public Color Space2Color;
    [Header("星源丟擲")]
    [SerializeField]
    private GameObject[] Star;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float SpeedUp;
    [SerializeField]
    private float MaxThrowCD;
    [SerializeField]
    private float OnetypeSensitivity;
    private float throwCD;

    [Header("皮膚顏色")]
    [SerializeField]
    private Renderer PlayerJoints;
    [SerializeField]
    private Renderer PlayerSurface;
    [SerializeField]
    private ColorMaterial[] Material;
    [Header("特效")]
    [SerializeField]
    private PlayerParticle[] Particle;

    private void Update()
    {
        UIupdate();
        SwitchSystem();
    }

    private void SwitchSystem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            throwCD = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q按著");
            throwCD += Time.deltaTime;
        }
        else
        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            Debug.Log("Q放開");
            if (throwCD < OnetypeSensitivity) 
            {
                if (SpaceNumber == 0)
                {
                    Debug.Log("切換為1號斗篷欄位");
                    SpaceNumber = 1;
                    SwitchColor(1);
                }
                else
                if (SpaceNumber == 1) 
                {
                    Debug.Log("切換為2號斗篷欄位");
                    SpaceNumber = 2;
                    SwitchColor(2);
                }
                else
                if (SpaceNumber == 2)
                {
                    Debug.Log("切換為1號斗篷欄位");
                    SpaceNumber = 1;
                    SwitchColor(1);
                }
                else
                {
                    Debug.Log("程式出錯");
                }
            }
            if (throwCD > MaxThrowCD)
            {
                Debug.Log("丟擲星原");
                if(SpaceNumber==1)
                {
                    ThorwStar(1);
                }
                else
                if(SpaceNumber==2)
                {
                    ThorwStar(2);
                }
            }
        }
    }
    private void ThorwStar(int SpaceNumber)
    {
        if (SpaceNumber == 1) 
        {
            if(Space1)
            {
                //生成一顆星源，讓它往前飛出去，玩家恢復成白色斗篷。
                Vector3 ShootingPositio0 = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
                GameObject TossedStar = Instantiate(Star[(int)Space1Color], ShootingPositio0, this.transform.rotation);
                Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
                Vector3 Direction = this.transform.forward;
                Vector3 DirectoinUp = this.transform.up;
                StarRigid.velocity = Direction * Speed + DirectoinUp *SpeedUp;
                Debug.Log("玩家恢復為白色斗篷");
                Space1Color = Color.沒有星源;
                SwitchColor(1);
                Space1 = false;
            }
            else
            {
                Debug.Log("現在的欄位為空");
            }
        }
        if (SpaceNumber == 2)
        {
            if (Space2)
            {
               
            }else
            {
                Debug.Log("現在的欄位為空");
            }
        }
    }
    private void SwitchColor(int SpaceNumber)
    {
        if (SpaceNumber == 1)
        {
            if (Space1)
            {
                if ((int)Space1Color == 0)
                {
                    Debug.Log("切換成灰色");
                    PlayerJoints.sharedMaterial = Material[0].JointsColor;
                    PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                    SwitchParticle(0);
                }else
                if ((int)Space1Color == 1)
                {
                    Debug.Log("切換成紅色");
                    PlayerJoints.sharedMaterial = Material[1].JointsColor;
                    PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                    SwitchParticle(1);
                }
                else
                if ((int)Space1Color == 2)
                {
                    Debug.Log("切換成藍色");
                    PlayerJoints.sharedMaterial = Material[2].JointsColor;
                    PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                    SwitchParticle(2);
                }
                else
                if ((int)Space1Color == 3)
                {
                    Debug.Log("切換成綠色");
                    PlayerJoints.sharedMaterial = Material[3].JointsColor;
                    PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                    SwitchParticle(3);
                }
            } else
            {
                Debug.Log("切換成灰色");
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                SwitchParticle(0);
            }
        }
        if (SpaceNumber == 2)
        {
            if (Space2)
            {
                if ((int)Space2Color == 0)
                {
                    Debug.Log("切換成灰色");
                    PlayerJoints.sharedMaterial = Material[0].JointsColor;
                    PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                    SwitchParticle(0);
                }
                else
                if ((int)Space2Color == 1)
                {
                    Debug.Log("切換成紅色");
                    PlayerJoints.sharedMaterial = Material[1].JointsColor;
                    PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                    SwitchParticle(1);
                }
                else
                if ((int)Space2Color == 2)
                {
                    Debug.Log("切換成藍色");
                    PlayerJoints.sharedMaterial = Material[2].JointsColor;
                    PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                    SwitchParticle(2);
                }
                else
                if ((int)Space2Color == 3)
                {
                    Debug.Log("切換成綠色");
                    PlayerJoints.sharedMaterial = Material[3].JointsColor;
                    PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                    SwitchParticle(3);
                }
            }else
            {
                Debug.Log("切換成灰色");
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                SwitchParticle(0);
            }
        }
        else if(SpaceNumber > 2) Debug.Log("程式錯誤");
    }
    private void SwitchParticle(int index)
    {
        if (index == 0)
        {
            Particle[0].particleSystem.gameObject.SetActive(true);
            Particle[1].particleSystem.gameObject.SetActive(false);
            Particle[2].particleSystem.gameObject.SetActive(false);
            Particle[3].particleSystem.gameObject.SetActive(false);
        }
        if (index == 1)
        {
            Particle[0].particleSystem.gameObject.SetActive(false);
            Particle[1].particleSystem.gameObject.SetActive(true);
            Particle[2].particleSystem.gameObject.SetActive(false);
            Particle[3].particleSystem.gameObject.SetActive(false);
        }
        if (index == 2)
        {
            Particle[0].particleSystem.gameObject.SetActive(false);
            Particle[1].particleSystem.gameObject.SetActive(false);
            Particle[2].particleSystem.gameObject.SetActive(true);
            Particle[3].particleSystem.gameObject.SetActive(false);
        }
        if (index == 3)
        {
            Particle[0].particleSystem.gameObject.SetActive(false);
            Particle[1].particleSystem.gameObject.SetActive(false);
            Particle[2].particleSystem.gameObject.SetActive(false);
            Particle[3].particleSystem.gameObject.SetActive(true);
        }
    }
    private void UIupdate()
    {
        if (Space1 == true)
        {

        }
        if (Space2 == true)
        {

        }
    }
}
