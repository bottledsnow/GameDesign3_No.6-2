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
        �S���P��=0,
        ����P��=1,
        �Ŧ�P��=2,
        ���P��=3,
    }
    [Header("���O�B��")]
    private int SpaceNumber;
    [SerializeField]
    private GameObject[] PlayerChild;


    [Header("1�� ���O���")]
    public bool Space1;
    public Color Space1Color;
    [Header("2�� ���O���")]
    public bool Space2;
    public Color Space2Color;
    [Header("�P�����Y")]
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
    [Header("�ֽ��C��")]
    [SerializeField]
    private Renderer PlayerJoints;
    [SerializeField]
    private Renderer PlayerSurface;
    [SerializeField]
    private ColorMaterial[] Material;
    */
    [Header("�S��")]
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
            Debug.Log("Q����");
            throwCD += Time.deltaTime;
        }
        else
        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            Debug.Log("Q��}");
            if (throwCD < OnetypeSensitivity) 
            {
                if (SpaceNumber == 0)
                {
                    Debug.Log("������1�����O���");
                    SpaceNumber = 1;
                    SwitchColor(1);
                }
                else
                if (SpaceNumber == 1) 
                {
                    Debug.Log("������2�����O���");
                    SpaceNumber = 2;
                    SwitchColor(2);
                }
                else
                if (SpaceNumber == 2)
                {
                    Debug.Log("������1�����O���");
                    SpaceNumber = 1;
                    SwitchColor(1);
                }
                else
                {
                    Debug.Log("�{���X��");
                }
            }
            if (throwCD > MaxThrowCD)
            {
                Debug.Log("���Y�P��");
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
                //�ͦ��@���P���A�������e���X�h�A���a��_���զ���O�C
                Vector3 ShootingPositio0 = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
                GameObject TossedStar = Instantiate(Star[(int)Space1Color], ShootingPositio0, this.transform.rotation);
                Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
                Vector3 Direction = this.transform.forward;
                Vector3 DirectoinUp = this.transform.up;
                StarRigid.velocity = Direction * Speed + DirectoinUp *SpeedUp;
                Debug.Log("���a��_���զ���O");
                Color temporaryColor = Space2Color;
                bool temporarySpace = Space2;
                Space2Color = Color.�S���P��;
                Space2 = false;
                Space1Color = temporaryColor;
                SwitchColor(1);
                Space1 = temporarySpace;
                
            }
            else
            {
                Debug.Log("�{�b����쬰��");
            }
        }
        if (SpaceNumber == 2)
        {
            if (Space2)
            {
                //�ͦ��@���P���A�������e���X�h�A���a��_���զ���O�C
                Vector3 ShootingPositio0 = this.transform.position + this.transform.forward * 2 + this.transform.up * 2;
                GameObject TossedStar = Instantiate(Star[(int)Space2Color], ShootingPositio0, this.transform.rotation);
                Rigidbody StarRigid = TossedStar.GetComponent<Rigidbody>();
                Vector3 Direction = this.transform.forward;
                Vector3 DirectoinUp = this.transform.up;
                StarRigid.velocity = Direction * Speed + DirectoinUp * SpeedUp;
                Debug.Log("���a��_���զ���O");
                Space2Color = Color.�S���P��;
                SwitchColor(2);
                Space2 = false;
            }
            else
            {
                Debug.Log("�{�b����쬰��");
            }
        }
    }
    private void SwitchColor(int SpaceNumber)
    {
        if (SpaceNumber == 1)
        {
            if (Space1)
            {
                Debug.Log("�������@�����C��");

                /*
                PlayerJoints.sharedMaterial = Material[(int)Space1Color].JointsColor;
                PlayerSurface.sharedMaterial = Material[(int)Space1Color].SurfaceColor;
                */

                SwitchParticle((int)Space1Color);
                SwitchLayers((int)Space1Color);
                #region ��⦡
                /*
                switch ((int)(Space1Color))
                {
                    case 0:
                        Debug.Log("�������Ǧ�");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(0);
                        break;
                    case 1:
                        Debug.Log("����������");
                        PlayerJoints.sharedMaterial = Material[1].JointsColor;
                        PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                        SwitchParticle(1);
                        SwitchLayers(1);
                        break;
                    case 2:
                        Debug.Log("�������Ŧ�");
                        PlayerJoints.sharedMaterial = Material[2].JointsColor;
                        PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                        SwitchParticle(2);
                        SwitchLayers(2);
                        break;
                    case 3:
                        Debug.Log("���������");
                        PlayerJoints.sharedMaterial = Material[3].JointsColor;
                        PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                        SwitchParticle(3);
                        SwitchLayers(3);
                        break;
                    default:
                        Debug.Log("�������Ǧ�");
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
                Debug.Log("�������Ǧ�");

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
                Debug.Log("�������@�����C��");

                /*
                PlayerJoints.sharedMaterial = Material[(int)Space2Color].JointsColor;
                PlayerSurface.sharedMaterial = Material[(int)Space2Color].SurfaceColor;
                */

                SwitchParticle((int)Space2Color);
                SwitchLayers((int)Space2Color);
                #region ��⦡
                /*
                switch ((int)(Space1Color))
                {
                    case 0:
                        Debug.Log("�������Ǧ�");
                        PlayerJoints.sharedMaterial = Material[0].JointsColor;
                        PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                        SwitchParticle(0);
                        SwitchLayers(0);
                        break;
                    case 1:
                        Debug.Log("����������");
                        PlayerJoints.sharedMaterial = Material[1].JointsColor;
                        PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                        SwitchParticle(1);
                        SwitchLayers(1);
                        break;
                    case 2:
                        Debug.Log("�������Ŧ�");
                        PlayerJoints.sharedMaterial = Material[2].JointsColor;
                        PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                        SwitchParticle(2);
                        SwitchLayers(2);
                        break;
                    case 3:
                        Debug.Log("���������");
                        PlayerJoints.sharedMaterial = Material[3].JointsColor;
                        PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                        SwitchParticle(3);
                        SwitchLayers(3);
                        break;
                    default:
                        Debug.Log("�������Ǧ�");
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
                Debug.Log("�������Ǧ�");

                /*
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                */

                SwitchParticle(0);
                SwitchLayers(0);
            }
        }
        else if(SpaceNumber > 2) Debug.Log("�{�����~");
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
                Debug.Log("�������զ� Layers");
                this.gameObject.layer = 7;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 7;     
                }
                break;
            case 1:
                Debug.Log("���������� Layers");
                this.gameObject.layer = 8;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 8;
                }
                break;
            case 2:
                Debug.Log("�������Ŧ� Layers");
                this.gameObject.layer = 9;
                for (int i = 0; i < childNumber; i++)
                {
                    PlayerChild[i].gameObject.layer = 9;
                }
                break;
            case 3:
                Debug.Log("��������� Layers");
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
