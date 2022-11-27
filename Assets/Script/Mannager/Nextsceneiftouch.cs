using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextsceneiftouch : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.name =="Yuna v0.2")
	{
	  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	  }
 }
}
