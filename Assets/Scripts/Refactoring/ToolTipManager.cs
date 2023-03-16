using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] private float Offsetx = 1.5f;
    [SerializeField] private float Offsety = 1.5f;


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

    void SetMousePosition()
    {
        // TODO: Adjust offset to avoid tooltip under the cursor (aletuno)

        Transform image = gameObject.transform.GetChild(0);
        // Get image size
        RectTransform rt = (RectTransform)image;
        Vector3 mousePosition = Input.mousePosition;
        // Initialize offset vector
        Vector3 offsetVector = new Vector3(Offsetx, Offsety, 0);
        // Negative offset in case tooltip is out of bounds

        if(mousePosition.x + rt.rect.width > Screen.width && mousePosition.y + rt.rect.height > Screen.height)
        {
            offsetVector.y = -(rt.rect.height + Offsety);
            offsetVector.x = -(rt.rect.width + Offsetx);

        }
        else
        {
            if (mousePosition.y + rt.rect.height > Screen.height)
            {
                 offsetVector.y = -(rt.rect.height);
                offsetVector.x = 25;
            }
            if (mousePosition.x + rt.rect.width > Screen.width)
            {
                offsetVector.x = -(rt.rect.width + Offsetx);
            }
        }

        // Applies offset
        image.position = Input.mousePosition + offsetVector;
    }
}
