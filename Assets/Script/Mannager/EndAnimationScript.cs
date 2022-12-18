using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadSence", 7);
    }

    private void LoadSence()
    {
        SceneManager.LoadScene(2);
    }
}
