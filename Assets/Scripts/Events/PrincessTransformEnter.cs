using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessTransformEnter : DefaultEvent
{
    public AudioClip bossMusic;
    public AudioSource bgMusic;
    public PrincessBehaviour princess;
    public GameObject gate;

    private GameObject virtualCam;

    public override void EventOnEnter(PlayerMovement player)
    {
        if (!princess.isTransformed) StartCoroutine(TransformPrincess(player));
    }
    IEnumerator TransformPrincess(PlayerMovement player)
    {
        bgMusic.clip = bossMusic;
        bgMusic.Play();
        virtualCam = GameObject.Find("CM vcam1");
        virtualCam.SetActive(false);
        gate.SetActive(true);
        princess.isTransformed = true;
        player.StopInput();
        yield return new WaitForSeconds(princess.itsTransformingTime);
        princess.available = true;
        player.ReceiveInput();
        enabled = false;
    }
}
