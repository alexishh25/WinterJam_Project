using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: si quieres que persista entre escenas
            Debug.Log("Se fue al carajo todo");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Se quiso duplicar el CursorManager");
        }
    }

    [SerializeField] private Texture2D normal;

    [SerializeField] private Texture2D linked;

    [SerializeField] private Texture2D grab;
    [SerializeField] private Texture2D grab_hover;

    private Vector2 Coord_Cursor;
    private void Start()
    {
        SetNormalCursor();
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Coord_Cursor, CursorMode.Auto);
    }

    // Métodos públicos que llaman al Manager
    public void SetNormalCursor()
    {
        Coord_Cursor = new Vector2(0, 0);
        SetCursor(normal);
    }
    public void SetLinkedCursor() 
    {
        Coord_Cursor = new Vector2(10, 0);
        SetCursor(linked); 
    }
    public void SetGrabCursor() => SetCursor(grab);
    public void SetGrabHoverCursor() => SetCursor(grab_hover);
}
