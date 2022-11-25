using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxComponent : MonoBehaviour
{
    public GameObject cameraToFollow;
    public float paralaxRatio = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.transform.position.x * paralaxRatio,transform.position.y,transform.position.z);
    }
}
