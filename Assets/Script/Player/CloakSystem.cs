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
        ⊿Τ琍方=0,
        ︹琍方=1,
        屡︹琍方=2,
        厚︹琍方=3,
    }
    [Header("ゆ罯笲︽")]
    public int SpaceNumber;
    [SerializeField]
    private GameObject[] PlayerChild;
    private PlayerState playerState;


    [Header("1腹 ゆ罯逆")]
    public bool Space1;
    public Color Space1Color;
    [Header("2腹 ゆ罯逆")]
    public bool Space2;
    public Color Space2Color;
    [Header("琍方ち传")]
    [SerializeField]
    private float MaxQCD;
    private float QCD;
    [Header("琍方メ耏")]
    [SerializeField]
    private GameObject[] Star;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float SpeedUp;
    
    [SerializeField]
    private float OnetypeSensitivity;
    

    /*
    [Header("ブ涧肅︹")]
    [SerializeField]
    private Renderer PlayerJoints;
    [SerializeField]
    private Renderer PlayerSurface;
    [SerializeField]
    private ColorMaterial[] Material;
    */
    [Header("疭")]
    [SerializeField]
    private PlayerParticle[] Particle;

    private void Start()
    {
        playerState = GameMannager.gameMannager.playerState;
        int childNumber = transform.childCount;
        PlayerChild = new GameObject[childNumber];
        for (int i = 0; i < childNumber;i++)
        {
            PlayerChild[i] = this.transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        UIupdate();
        SwitchSystem();
    }

    private void SwitchSystem()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThorwStar();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QCD = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q帝");
            QCD += Time.deltaTime;
        }
        else
        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            Debug.Log("Q秨");
            if (QCD < OnetypeSensitivity) 
            {
                if (SpaceNumber == 0)
                {
                    if(Space1Color == Color.⊿Τ琍方)
                    {
                        Debug.Log("Noting can switch");
                    }else
                    {
                        Debug.Log("ち传1腹ゆ罯逆");
                        SpaceNumber = 1;
                        SwitchColor(1);
                    }
                }
                else
                if (SpaceNumber == 1) 
                {
                    Debug.Log("ち传2腹ゆ罯逆");
                    SpaceNumber = 2;
                    SwitchColor(2);
                }
                else
                if (SpaceNumber == 2)
                {
                    Debug.Log("ち传1腹ゆ罯逆");
                    SpaceNumber = 1;
                    SwitchColor(1);
                }
                else
                {
                    Debug.Log("祘Α岿");
                }
            }
            if (QCD > MaxQCD)
            {
                Debug.Log("確︹ゆ罯");
                SpaceNumber = 0;
                SwitchColor(0);
            }
        }
    }
    private void ThorwStar()
    {
        if (SpaceNumber == 0)
        {
            Debug.Log("Noting Can Thorw");
        } else
        {
            //ネΘ聋琍方琵ウ┕玡產確Θフ︹ゆ罯
            Vector3 ShootingPosition = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
            GameObject TossedStar = null;

            if (SpaceNumber == 1)
            {
                if (Space1Color != Color.⊿Τ琍方)
                {
                    GameObject tossedStar = Instantiate(Star[(int)Space1Color], ShootingPosition, this.transform.rotation);
                    TossedStar = tossedStar;
                    playerState.DurabilitySystem(1, "Lose");

                    Color temporaryColor = Space2Color;
                    bool temporarySpace = Space2;
                    Space2Color = Color.⊿Τ琍方;
                    Space2 = false;
                    Space1Color = temporaryColor;
                    SwitchColor(1);
                    Space1 = temporarySpace;

                    /*
                    bool tempoaryActivity = playerState.Activity_2;
                    float temporaryDurability = playerState.Durability_2;
                    playerState.DurabilitySystem(2, "Lose");
                    playerState.Activity_1 = tempoaryActivity;
                    playerState.Durability_1 = temporaryDurability;
                    */
                }
                else Debug.Log("Noting can throw");
            }
            else
            if (SpaceNumber == 2)
            {
                if (Space2Color != Color.⊿Τ琍方)
                {
                    GameObject tossedStar = Instantiate(Star[(int)Space2Color], ShootingPosition, this.transform.rotation);
                    TossedStar = tossedStar;
                    playerState.DurabilitySystem(2, "Lose");

                    Space2Color = Color.⊿Τ琍方;
                    SwitchColor(2);
                    Space2 = false;
                }
                else Debug.Log("Noting can thorw");
            }
            Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
            Vector3 Direction = this.transform.forward;
            Vector3 DirectoinUp = this.transform.up;
            StarRigid.velocity = Direction * Speed + DirectoinUp * SpeedUp;
            Debug.Log("產確フ︹ゆ罯");
            SpaceNumber = 0;
        }
    }
    public void SwitchColor(int SpaceNumber)
    {
        switch(SpaceNumber)
        {
            case 0:
                Debug.Log("ち传Θη︹");
                SwitchParticle(0);
                SwitchLayers(0);
                break;
            case 1:
                if (Space1)
                {
                    Debug.Log("ち传Θ腹肅︹");

                    /*
                    PlayerJoints.sharedMaterial = Material[(int)Space1Color].JointsColor;
                    PlayerSurface.sharedMaterial = Material[(int)Space1Color].SurfaceColor;
                    */

                    SwitchParticle((int)Space1Color);
                    SwitchLayers((int)Space1Color);
                }else SwitchColor(0);
                break;
            case 2:
                if (SpaceNumber == 2)
                {
                    if (Space2)
                    {
                        Debug.Log("ち传Θ腹肅︹");
                        SwitchParticle((int)Space2Color);
                        SwitchLayers((int)Space2Color);
                    }else SwitchColor(0);
                }
                break;
            default:
                if (SpaceNumber > 2) Debug.Log("祘Α岿粇");
                break;
        }
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
    private void SwitchLayers(int Color)
    {
        int childNumber = transform.childCount;
        switch (Color)
        {
            case 0:
                Debug.Log("ち传フ︹ Layers");
                this.gameObject.layer = 7;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 7;     
                }
                break;
            case 1:
                Debug.Log("ち传︹ Layers");
                this.gameObject.layer = 8;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 8;
                }
                break;
            case 2:
                Debug.Log("ち传屡︹ Layers");
                this.gameObject.layer = 9;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 9;
                }
                break;
            case 3:
                Debug.Log("ち传厚︹ Layers");
                this.gameObject.layer = 10;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 10;
                }
                break;
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
