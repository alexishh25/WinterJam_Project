using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum CursorType { Normal, Linked, Grab, GrabHover }
    public CursorType cursorType = CursorType.Normal;

    [Header("Eventos de Unity")]
    public UnityEvent ClickEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (cursorType)
        {
            case CursorType.Normal:
                AudioManager.Instance.ReproducirHover();
                CursorManager.Instance.SetLinkedCursor();
                break;
            case CursorType.Grab:
                // Suponiendo que tienes este método en tu CursorManager
                CursorManager.Instance.SetGrabCursor();
                break;
            case CursorType.GrabHover:
                CursorManager.Instance.SetGrabHoverCursor();
                break;
            default:
                CursorManager.Instance.SetNormalCursor();
                break;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.SetNormalCursor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (cursorType)
        {
            case CursorType.Normal:
                AudioManager.Instance.ReproducirClick();
                ClickEvent?.Invoke();
                break;
            case CursorType.Grab:
                AudioManager.Instance.ReproducirNext();
                ClickEvent?.Invoke();
                break;
            default:
                
                ClickEvent?.Invoke();
                break;

        }
    }
}
