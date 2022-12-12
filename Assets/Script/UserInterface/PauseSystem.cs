using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    private bool Open;
    private Image image;
    [Header("basic")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject PauseGameObject;
    private void Start()
    {
        image = animator.GetComponent<Image>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Open)
                 ToPause();
            else ClosePause();
        }
    }

    private void ToPause()
    {
        animator.Play("Open");
        PauseGameObject.SetActive(true);
        Time.timeScale = 0;
        Open = true;
        image.raycastTarget = true;
    }

    public void ClosePause()
    {
        animator.Play("Close");
        PauseGameObject.SetActive(false);
        Time.timeScale = 1;
        Open = false;
        image.raycastTarget = false;
    }
}
