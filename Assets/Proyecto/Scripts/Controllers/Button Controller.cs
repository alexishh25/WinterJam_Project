using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum CursorType { Normal, Linked }
    public CursorType cursorType = CursorType.Normal;

    [Header("Eventos de Unity")]
    public UnityEvent ClickEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirHover();
        CursorManager.Instance.SetLinkedCursor();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.SetNormalCursor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.ReproducirClick();
        ClickEvent?.Invoke();
    }
}
