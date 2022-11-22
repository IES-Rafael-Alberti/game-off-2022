using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TextPopUp : MonoBehaviour
{
    public Font font;
    public Color color = Color.white;
    public int fontSize = 18;
    public string text = "Placeholder";
    public Texture2D background;
    public Rect rect = new Rect(0, 0, 100, 50); //posX , posY, TextWidth, TextHeight
    public Vector3 textOffset = new Vector2(0f, 0f); //TextOffset
    public Vector3 imageOffset = new Vector2(0f, 0f); //ImageOffset

    private GUIStyle textStyle;
    private Vector3 point;

    private void Start()
    {
        textStyle = new GUIStyle();
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.font = font;
        textStyle.fontSize = fontSize;
        textStyle.normal.textColor = color;
    }
    void OnGUI()
    {
        point = Camera.main.WorldToScreenPoint(transform.position + imageOffset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.DrawTexture(rect, background, ScaleMode.StretchToFill);
        point = Camera.main.WorldToScreenPoint(transform.position + textOffset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, text, textStyle);
    }
}
