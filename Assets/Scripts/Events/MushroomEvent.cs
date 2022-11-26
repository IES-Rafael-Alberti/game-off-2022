using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEvent : DefaultEvent
{
    public GameObject canvasEffect;
    public float trippingTime = 3f;

    private SpriteRenderer mushroom;
    private PopUpEnter popUpComponent;
    private bool isTripping;

    private void Start()
    {
        mushroom = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        popUpComponent = GetComponent<PopUpEnter>();
    }
    public override void EventOnStay(PlayerMovement player)
    {
        if (!isTripping) StartCoroutine(Tripping());
    }
    IEnumerator Tripping()
    {
        isTripping = true;
        mushroom.enabled = false;
        popUpComponent.enabled = false;
        popUpComponent.popUp.enabled = false;
        canvasEffect.SetActive(true);
        yield return new WaitForSeconds(trippingTime);
        canvasEffect.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
