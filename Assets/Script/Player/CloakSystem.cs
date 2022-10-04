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
    [Header("1腹 ゆ罯逆")]
    public bool Space1;
    public Color Space1Color;
    [Header("2腹 ゆ罯逆")]
    public bool Space2;
    public Color Space2Color;

    [Header("ブ涧肅︹")]
    [SerializeField]
    private Renderer PlayerJoints;
    [SerializeField]
    private Renderer PlayerSurface;
    [SerializeField]
    private ColorMaterial[] Material;
    [Header("疭")]
    [SerializeField]
    private PlayerParticle[] Particle;

    private void Update()
    {
        UIupdate();
        SwitchSystem();
    }

    private void SwitchSystem()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (SpaceNumber == 0)
            {
                Debug.Log("ち传1腹ゆ罯逆");
                SpaceNumber = 1;
                SwitchColor(1);
            }else
            if (SpaceNumber==1)
            {
                Debug.Log("ち传2腹ゆ罯逆");
                SpaceNumber = 2;
                SwitchColor(2);
            }
            else
            if(SpaceNumber==2)
            {
                Debug.Log("ち传1腹ゆ罯逆");
                SpaceNumber = 1;
                SwitchColor(1);
            }else
            {
                Debug.Log("祘Α岿");
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
                    Debug.Log("ち传Θη︹");
                    PlayerJoints.sharedMaterial = Material[0].JointsColor;
                    PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                    SwitchParticle(0);
                }else
                if ((int)Space1Color == 1)
                {
                    Debug.Log("ち传Θ︹");
                    PlayerJoints.sharedMaterial = Material[1].JointsColor;
                    PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                    SwitchParticle(1);
                }
                else
                if ((int)Space1Color == 2)
                {
                    Debug.Log("ち传Θ屡︹");
                    PlayerJoints.sharedMaterial = Material[2].JointsColor;
                    PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                    SwitchParticle(2);
                }
                else
                if ((int)Space1Color == 3)
                {
                    Debug.Log("ち传Θ厚︹");
                    PlayerJoints.sharedMaterial = Material[3].JointsColor;
                    PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                    SwitchParticle(3);
                }
            } else
            {
                Debug.Log("ち传Θη︹");
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
                    Debug.Log("ち传Θη︹");
                    PlayerJoints.sharedMaterial = Material[0].JointsColor;
                    PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                    SwitchParticle(0);
                }
                else
                if ((int)Space2Color == 1)
                {
                    Debug.Log("ち传Θ︹");
                    PlayerJoints.sharedMaterial = Material[1].JointsColor;
                    PlayerSurface.sharedMaterial = Material[1].SurfaceColor;
                    SwitchParticle(1);
                }
                else
                if ((int)Space2Color == 2)
                {
                    Debug.Log("ち传Θ屡︹");
                    PlayerJoints.sharedMaterial = Material[2].JointsColor;
                    PlayerSurface.sharedMaterial = Material[2].SurfaceColor;
                    SwitchParticle(2);
                }
                else
                if ((int)Space2Color == 3)
                {
                    Debug.Log("ち传Θ厚︹");
                    PlayerJoints.sharedMaterial = Material[3].JointsColor;
                    PlayerSurface.sharedMaterial = Material[3].SurfaceColor;
                    SwitchParticle(3);
                }
            }else
            {
                Debug.Log("ち传Θη︹");
                PlayerJoints.sharedMaterial = Material[0].JointsColor;
                PlayerSurface.sharedMaterial = Material[0].SurfaceColor;
                SwitchParticle(0);
            }
        }
        else Debug.Log("祘Α岿粇");
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
