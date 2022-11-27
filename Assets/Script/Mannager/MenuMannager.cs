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
        Debug.Log("�}�ҳ]�w���");
    }

    public void Credit()
    {
        Debug.Log("�}�һs�@�H��");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
