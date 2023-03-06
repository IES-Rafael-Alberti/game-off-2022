using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractiveZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Image shadow;

    public Texture2D MouseCursor;
    public Texture2D MouseCursorExit;
    public GameObject toolTip;
    public string toolTipText;
    public bool highlight;

    public UnityEvent MouseEnter;
    public UnityEvent MouseExit;
    public UnityEvent MouseClick;

    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        shadow = GetComponent<Image>();
        MouseEnter.AddListener(ShowTooltip);
        MouseExit.AddListener(HideTooltip);
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


    public void ShowTooltip()
    {
        if (temp == null)
        {
            temp = Instantiate(toolTip, Vector3.zero, Quaternion.identity);
            TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
            if (gameObject.GetComponent<ITextInfo>() == null) text.text = toolTipText;
            else text.text = gameObject.GetComponent<ITextInfo>().Show();
        }
    }

    public void HideTooltip()
    {
        Destroy(temp);
    }
}
