using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextsceneiftouch : MonoBehaviour
{
	[SerializeField]
	private Animator animator;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Yuna v0.2")
		{
			animator.Play("BlackShady");
		}
	}

	public void LoadSence()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
