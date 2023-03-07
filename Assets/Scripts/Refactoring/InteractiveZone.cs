using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractiveZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Texture2D MouseCursor;
    public Texture2D MouseCursorExit;
    public GameObject toolTip;
    public string toolTipText;

    public UnityEvent MouseEnter;
    public UnityEvent MouseExit;
    public UnityEvent MouseClick;

    private GameObject activeTooltip;

    // Start is called before the first frame update
    void Start()
    {
        MouseEnter.AddListener(ShowTooltip);
        MouseExit.AddListener(HideTooltip);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.Auto);
        MouseEnter?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter();
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(MouseCursorExit, Vector2.zero, CursorMode.Auto);
        MouseExit?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit();
    }


    private void OnMouseDown()
    {
        MouseClick?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown();
    }

    public void ShowTooltip()
    {
        // If there is a tooltip, don't instantiate another
        if (activeTooltip == null)
        {
            // Instantiate tooltip
            activeTooltip = Instantiate(toolTip, Vector3.zero, Quaternion.identity);
            // Get textmeshpro component 
            TextMeshProUGUI text = activeTooltip.GetComponentInChildren<TextMeshProUGUI>();
            // If there is an ITextInfo in gameonject, take text from there
            if (gameObject.GetComponent<ITextInfo>() == null) text.text = toolTipText;
            else text.text = gameObject.GetComponent<ITextInfo>().TextInfo();
        }
    }

    public void HideTooltip()
    {
        Destroy(activeTooltip);
    }
}
