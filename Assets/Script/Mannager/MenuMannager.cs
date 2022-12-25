using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMannager : MonoBehaviour
{
    [SerializeField]
    private Animator aniCredit;
    private AnimatorStateInfo CreditInfo;
    [SerializeField]
    private Animator aniSetting;
    private AnimatorStateInfo SettingInfo;
    private bool OpenCredit;
    private bool OpenSetting;

    private void Start()
    {
        Cursor.visible = true;
    }
    private void Update()
    {
        if(aniCredit!=null)
        {
            CreditInfo = aniCredit.GetCurrentAnimatorStateInfo(0);
        }
        if(aniSetting!=null)
        {
            SettingInfo = aniSetting.GetCurrentAnimatorStateInfo(0);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Opening()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        if(OpenCredit)
        {
            Credit("Close");
        }
        if(SettingInfo.normalizedTime >= 1.0f)
        {
            if (OpenSetting)
            {
                aniSetting.Play("CloseSetting");
                OpenSetting = false;
            }
            aniSetting.Play("OpenSetting");
            OpenSetting = true;
        }
    }
    private void Setting(string type)
    {
        if(type=="Open")
        {
            aniSetting.Play("OpenSetting");
            OpenSetting = true;
        }
        if(type=="Close")
        {
            aniSetting.Play("CloseSetting");
            OpenSetting = false;
        }
    }

    public void Credit()
    {
        if(OpenSetting)
        {
            Setting("Close");

        }
        if (CreditInfo.normalizedTime >= 1.0f)
        {
            if (OpenCredit)
            {
                aniCredit.Play("CloseCredit");
                OpenSetting = false;
            }
            aniCredit.Play("OpenCredit");
            OpenCredit = true;
        }
    }
    private void Credit(string type)
    {
        if(type=="Close")
        {
            aniCredit.Play("CloseCredit");
            OpenCredit = false;
        }
        if(type=="Open")
        {
            aniCredit.Play("OpenCredit");
            OpenCredit = true;
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
