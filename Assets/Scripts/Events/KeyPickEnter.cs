using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickEnter : MonoBehaviour
{

    public GameObject DoorToOpen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            DoorToOpen.GetComponent<ChangeScene>().canEnter = true;
            gameObject.SetActive(false);

                }
    }
}
