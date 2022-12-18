using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private MeshRenderer mesh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mesh.enabled = false;
            particle.Play();
            animator.Play("Ending");
            Invoke("LoadSence", 3);
            Debug.Log("玩家撞到結局");
        }
    }

    private void LoadSence()
    {
        SceneManager.LoadScene(4);
    }
}
