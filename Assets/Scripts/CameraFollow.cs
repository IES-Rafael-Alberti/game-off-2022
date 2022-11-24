using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private CinemachineVirtualCamera camera;

    public void SearchCamera()
    {
        camera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = transform;
    }

}
