using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField]
    private float padding = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetMousePosition();
    }

    // Update is called once per frame
    void Update()
    {
        SetMousePosition(); 
    }

    void SetMousePosition() {
        Transform image = gameObject.transform.GetChild(0);
        RectTransform rt = (RectTransform)image;
        Vector3 mp = Input.mousePosition;
        Vector3 dp = new Vector3(padding, padding, 0);
        if (mp.x + rt.rect.width > Screen.width) dp.x = -(rt.rect.width + padding);
        if (mp.y + rt.rect.height > Screen.height) dp.y = -(rt.rect.height + padding);
        image.position = Input.mousePosition + dp;
    }
}
