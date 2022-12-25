using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMannager : MonoBehaviour
{
    private CloakSystem cloakSystem;
    private PlayerState playerState;
    [Header("Hp")]
    [SerializeField]
    private GameObject HpBar;
    [SerializeField]
    private Vector3 HpScale;
    [SerializeField]
    [Range(0,3.75f)]
    private float ShowHp;
    [Header("Cloak")]
    [SerializeField]
    private Slider Cloak1;
    [SerializeField]
    private Image Cloak1BarImage;
    [SerializeField]
    private Slider cloak2;
    [SerializeField]
    private Image Cloak2BarImage;
    [SerializeField]
    private Color[] BarColor;
    [SerializeField]
    private GameObject[] Space1Icon;
    [SerializeField]
    private GameObject[] Space2Icon;

    private void Start()
    {
        playerState = GameMannager.gameMannager.playerState;
        cloakSystem = GameMannager.gameMannager.cloakSystem;
    }
    private void Update()
    {
        ShowCloakSystem();
        ShowSystem();
        HpConvert();
    }
    private void ShowCloakSystem()
    {
        Cloak1.value = playerState.Durability_1 * 0.01f;
        cloak2.value = playerState.Durability_2 * 0.01f;
    }
    private void ShowSystem()
    {
        Vector3 temporaryHpScale = HpScale;
        HpScale = new Vector3(ShowHp, temporaryHpScale.y, temporaryHpScale.z);

        if (ShowHp > 3.75f) ShowHp = 3.75f;
        else
        if (ShowHp < 3.75f && ShowHp > 0)
        {
            HpBar.transform.localScale = HpScale;
        }
        else
        if (ShowHp < 0.00f)
        {
            HpScale = new Vector3(4, 0.4f, 1);
        }

    }
    private void HpConvert()
    {
        ShowHp = playerState.Hp * 0.0375f;
    }
    public void SwitchCloakBarColor()
    {
        Cloak1BarImage.color = BarColor[(int)cloakSystem.Space1Color];
        Cloak2BarImage.color = BarColor[(int)cloakSystem.Space2Color];

        for(int i=0;i<4;i++)
        {
            Space1Icon[i].SetActive(false);
            Space2Icon[i].SetActive(false);
        }
        Space1Icon[(int)cloakSystem.Space1Color].SetActive(true);
        Space2Icon[(int)cloakSystem.Space2Color].SetActive(true);
    }


}
