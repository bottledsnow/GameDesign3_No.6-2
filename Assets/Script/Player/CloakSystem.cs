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
    private int SpaceNumber;
    [SerializeField]
    private GameObject[] PlayerChild;


    [Header("1腹 ゆ罯逆")]
    public bool Space1;
    public Color Space1Color;
    [Header("2腹 ゆ罯逆")]
    public bool Space2;
    public Color Space2Color;
    [Header("琍方メ耏")]
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            throwCD = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q帝");
            throwCD += Time.deltaTime;
        }
        else
        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            Debug.Log("Q秨");
            if (throwCD < OnetypeSensitivity) 
            {
                if (SpaceNumber == 0)
                {
                    Debug.Log("ち传1腹ゆ罯逆");
                    SpaceNumber = 1;
                    SwitchColor(1);
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
            if (throwCD > MaxThrowCD)
            {
                Debug.Log("メ耏琍");
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
                //ネΘ聋琍方琵ウ┕玡產確Θフ︹ゆ罯
                Vector3 ShootingPositio0 = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
                GameObject TossedStar = Instantiate(Star[(int)Space1Color], ShootingPositio0, this.transform.rotation);
                Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
                Vector3 Direction = this.transform.forward;
                Vector3 DirectoinUp = this.transform.up;
                StarRigid.velocity = Direction * Speed + DirectoinUp *SpeedUp;
                Debug.Log("產確フ︹ゆ罯");
                Color temporaryColor = Space2Color;
                bool temporarySpace = Space2;
                Space2Color = Color.⊿Τ琍方;
                Space2 = false;
                Space1Color = temporaryColor;
                SwitchColor(1);
                Space1 = temporarySpace;
                
            }
            else
            {
                Debug.Log("瞷逆");
            }
        }
        if (SpaceNumber == 2)
        {
            if (Space2)
            {
                //ネΘ聋琍方琵ウ┕玡產確Θフ︹ゆ罯
                Vector3 ShootingPositio0 = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
                GameObject TossedStar = Instantiate(Star[(int)Space2Color], ShootingPositio0, this.transform.rotation);
                Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
                Vector3 Direction = this.transform.forward;
                Vector3 DirectoinUp = this.transform.up;
                StarRigid.velocity = Direction * Speed + DirectoinUp * SpeedUp;
                Debug.Log("產確フ︹ゆ罯");
                Space2Color = Color.⊿Τ琍方;
                SwitchColor(2);
                Space2 = false;
            }
            else
            {
                Debug.Log("瞷逆");
            }
        }
    }
    private void SwitchColor(int SpaceNumber)
    {
        if (SpaceNumber == 1)
        {
            if (Space1)
            {
                Debug.Log("ち传Θ腹肅︹");

                /*
                PlayerJoints.sharedMaterial = Material[(int)Space1Color].JointsColor;
                PlayerSurface.sharedMaterial = Material[(int)Space1Color].SurfaceColor;
                */

                SwitchParticle((int)Space1Color);
                SwitchLayers((int)Space1Color);
                #region 衡Α
                /*
                switch ((int)(Space1Color))
                {
                    case 0:
                        Debug.Log("ち传Θη︹");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(0);
                        break;
                    case 1:
                        Debug.Log("ち传Θ︹");
                        PlayerJoints.sharedMaterial = Material[1].JointsColor;
                        PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                        SwitchParticle(1);
                        SwitchLayers(1);
                        break;
                    case 2:
                        Debug.Log("ち传Θ屡︹");
                        PlayerJoints.sharedMaterial = Material[2].JointsColor;
                        PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                        SwitchParticle(2);
                        SwitchLayers(2);
                        break;
                    case 3:
                        Debug.Log("ち传Θ厚︹");
                        PlayerJoints.sharedMaterial = Material[3].JointsColor;
                        PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                        SwitchParticle(3);
                        SwitchLayers(3);
                        break;
                    default:
                        Debug.Log("ち传Θη︹");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(4);
                        break;

                }
                */
                #endregion 
            }else
            {
                Debug.Log("ち传Θη︹");

                /*
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                */

                SwitchParticle(0);
                SwitchLayers(0);
            }
        }
        if (SpaceNumber == 2)
        {
            if (Space2)
            {
                Debug.Log("ち传Θ腹肅︹");

                /*
                PlayerJoints.sharedMaterial = Material[(int)Space2Color].JointsColor;
                PlayerSurface.sharedMaterial = Material[(int)Space2Color].SurfaceColor;
                */

                SwitchParticle((int)Space2Color);
                SwitchLayers((int)Space2Color);
                #region 衡Α
                /*
                switch ((int)(Space1Color))
                {
                    case 0:
                        Debug.Log("ち传Θη︹");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(0);
                        break;
                    case 1:
                        Debug.Log("ち传Θ︹");
                        PlayerJoints.sharedMaterial = Material[1].JointsColor;
                        PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                        SwitchParticle(1);
                        SwitchLayers(1);
                        break;
                    case 2:
                        Debug.Log("ち传Θ屡︹");
                        PlayerJoints.sharedMaterial = Material[2].JointsColor;
                        PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                        SwitchParticle(2);
                        SwitchLayers(2);
                        break;
                    case 3:
                        Debug.Log("ち传Θ厚︹");
                        PlayerJoints.sharedMaterial = Material[3].JointsColor;
                        PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                        SwitchParticle(3);
                        SwitchLayers(3);
                        break;
                    default:
                        Debug.Log("ち传Θη︹");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(4);
                        break;

                }
                */
                #endregion 
            }
            else
            {
                Debug.Log("ち传Θη︹");

                /*
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                */

                SwitchParticle(0);
                SwitchLayers(0);
            }
        }
        else if(SpaceNumber > 2) Debug.Log("祘Α岿粇");
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
