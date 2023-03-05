using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D MouseCursor;
    void Start()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.Auto);
    }

}
