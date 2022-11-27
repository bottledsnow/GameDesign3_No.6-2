using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMannager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        Debug.Log("開啟設定選單");
    }

    public void Credit()
    {
        Debug.Log("開啟製作人員");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
