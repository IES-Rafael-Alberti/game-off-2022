using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Image shadow;

    public Texture2D MouseCursor;
    public Texture2D MouseCursorExit;
    public bool highlight;

    public UnityEvent MouseEnter;
    public UnityEvent MouseExit;
    public UnityEvent MouseClick;

    // Start is called before the first frame update
    void Start()
    {
        shadow = GetComponent<Image>();        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.Auto);
        if (highlight)
        {
            Color tempColor = shadow.color;
            tempColor.a = 0.2f;
            shadow.color = tempColor;
        }
        MouseEnter?.Invoke();

    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(MouseCursorExit, Vector2.zero, CursorMode.Auto);
        if (highlight)
        {
            Color tempColor = shadow.color;
            tempColor.a = 0f;
            shadow.color = tempColor;
        }
        MouseExit?.Invoke();
    }

    private void OnMouseDown()
    {
        MouseClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown();
    }
}
