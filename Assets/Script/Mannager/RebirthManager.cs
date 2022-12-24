using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private FadeInOut FadeInOut;
    [Header("Setting")]
    [SerializeField]
    private GameObject RebirthPosition;
    [SerializeField]
    private float KeepBlackTime;
    protected void ToRebirth()
    {
        Debug.Log("Rebirth");
        Invoke("Rebirth",1);
        FadeInOut.FadeIn();
        FadeInOut.FadeOut(KeepBlackTime+1);
    }

    private void Rebirth()
    {
        Player.transform.position = RebirthPosition.transform.position;
    }
}
