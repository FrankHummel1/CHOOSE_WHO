using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D customCursor;
    [SerializeField] private CursorMode cursorModeSerialized;

    private void Start() => Cursor.SetCursor(customCursor, Vector2.zero, cursorModeSerialized);
}