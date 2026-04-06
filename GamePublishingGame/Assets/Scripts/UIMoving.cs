using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIMoving : MonoBehaviour, IPointerClickHandler
{
    Vector2 mousePosition;
    RectTransform rectTransform;
    Canvas canvas;
    bool isDragging;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        isDragging = false;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = !isDragging;
        }
    }
    

    void Update()
    {
        if (isDragging)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), mousePosition, canvas.worldCamera, out pos);
            rectTransform.localPosition = pos;
        }
        
    }
}
