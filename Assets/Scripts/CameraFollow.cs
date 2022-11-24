using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private CinemachineVirtualCamera virtualCam;

    public void SearchCamera()
    {
        virtualCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        virtualCam.Follow = transform;
    }

}
