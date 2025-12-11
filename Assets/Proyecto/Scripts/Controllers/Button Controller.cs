using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum CursorType { Normal, Linked }

    public CursorType cursorType = CursorType.Normal;

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
    }
}
