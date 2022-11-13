using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipChild : MonoBehaviour
{
    [SerializeField]
    private TipSystem tipSystem;
    [SerializeField]
    private bool Toshow;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(Toshow)
            {
                tipSystem.ToShow();
            }else
            {
                tipSystem.ToClose();
            }
        }
    }
}
